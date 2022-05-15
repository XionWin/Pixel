using Extension;

namespace EGL
{
    using EGLConfig = IntPtr;
    using EGLContext = IntPtr;
    using EGLDisplay = IntPtr;
    using EGLSurface = IntPtr;

    unsafe public class WindowContext : IDisposable
    {
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
        public WindowContext(nint windowHandle, RenderableSurfaceType surfaceType)
        {
            var (display, context, surface, config, major, minor) = Extension.CrateWindowContext(windowHandle, surfaceType);
            this.EglDisplay = display;
            this.EglContext = context;
            this.EglSurface = surface;
            this.EGLConfig = config;
            this.Major = major;
            this.Minor = minor;
        }
        #endregion

        nint page_flip_handler = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(new PageFilpHandler(
            (int fd, uint frame, uint sec, uint usec, ref int data) =>
            {
                data = 0;
            }
        ));

        public void Render(Action renderFunc)
        {
            while (true) {
                // renderFunc();
                System.Threading.Thread.Sleep(10);
            }
        }

        #region IDisposable implementation
        ~WindowContext()
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

