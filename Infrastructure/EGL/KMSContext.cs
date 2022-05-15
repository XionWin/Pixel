using Extension;

namespace EGL
{
    using EGLConfig = IntPtr;
    using EGLContext = IntPtr;
    using EGLDisplay = IntPtr;
    using EGLSurface = IntPtr;

    public delegate void PageFilpHandler(int fd, uint frame, uint sec, uint usec, ref int data);
    unsafe public class KMSContext : IDisposable
    {
        public DRM.Drm Drm { get; private set; }
        public GBM.Gbm Gbm { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public EGLDisplay EglDisplay { get; private set; }
        public EGLContext EglContext { get; private set; }
        public EGLSurface EglSurface { get; private set; }
        public EGLConfig EGLConfig { get; private set; }
        public int Major { get; private set; }
        public int Minor { get; private set; }

        public bool VerticalSynchronization { get; set; }
        
        public RenderableSurfaceType RenderableSurfaceType { get; init; }

        #region ctor
        public KMSContext(DRM.Drm drm, RenderableSurfaceType surfaceType)
        {
            this.Drm = drm;
            this.Gbm = GBM.Extension.GetGbm(this.Drm, () => EGL.Egl.eglSwapBuffers(this.EglDisplay, this.EglSurface));
            var (display, context, surface, config, major, minor) = Extension.CrateKMSContext(this.Gbm, surfaceType);
            this.EglDisplay = display;
            this.EglContext = context;
            this.EglSurface = surface;
            this.EGLConfig = config;
            this.Major = major;
            this.Minor = minor;
        }
        #endregion

        public KMSContext Initialize(Action<EGL.KMSContext> initFunc)
        {
            this.Gbm.Surface
            .Initialize((bo, fb) =>
            {
                if (DRM.Native.SetCrtc(this.Drm.Fd, this.Drm.Crtc.Id, (uint)fb, 0, 0, new[] { this.Drm.Connector.Id }, this.Drm.Mode) is var setCrtcResult)
                    Console.WriteLine($"set crtc: {setCrtcResult}");
                this.Width = (int)bo.Width;
                this.Height = (int)bo.Height;
                initFunc?.Invoke(this);
            });
            return this;
        }
        nint page_flip_handler = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(new PageFilpHandler(
            (int fd, uint frame, uint sec, uint usec, ref int data) =>
            {
                data = 0;
            }
        ));


        const int DRM_CONTEXT_VERSION = 2;
        public void Render(Action renderFunc)
        {
            var eventCtx = new DRM.EventContext() { version = DRM_CONTEXT_VERSION, page_flip_handler = page_flip_handler };

            this.Gbm.Surface.SwapBuffers(
                renderFunc,
                (bo, fb) =>
                {
                    if(this.VerticalSynchronization)
                    {
                        var syncFlag = 1;
                        if (DRM.Native.PageFlip(this.Drm.Fd, this.Drm.Crtc.Id, (uint)fb, DRM.PageFlipFlags.FlipEvent, ref syncFlag) is int pageFlipResult &&
                        pageFlipResult != 0)
                        {
                            throw new Exception("Context PageFlip error");
                        }
                        while(syncFlag != 0)
                        {
                            if (DRM.Native.HandleEvent(this.Drm.Fd, ref eventCtx) is int handleEventResult &&
                            handleEventResult != 0)
                            {
                                throw new Exception("Context HandleEvent error");
                            }
                        }
                    }
                }
            );
        }

        #region IDisposable implementation
        ~KMSContext()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (this.EglContext != IntPtr.Zero)
                    Egl.eglDestroyContext(this.EglDisplay, this.EglContext);
                if (this.EglDisplay != IntPtr.Zero)
                    Egl.eglTerminate(this.EglDisplay);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error disposing egl context: {0}", ex.ToString());
            }
            finally
            {
                this.EglContext = IntPtr.Zero;
                this.EglDisplay = IntPtr.Zero;
            }
        }
        #endregion
    }
}

