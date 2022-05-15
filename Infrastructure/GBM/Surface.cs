using System.Runtime.InteropServices;

namespace GBM
{
    public struct gbm_surface
    {

    }
    unsafe public class Surface : IDisposable
    {
        #region pinvoke
        [DllImport(Lib.Name, CallingConvention = CallingConvention.Cdecl)]
        static extern gbm_surface *gbm_surface_create(gbm_device *deviceHandle, uint width, uint height, SurfaceFormat format, SurfaceFlags flags);

        [DllImport(Lib.Name, EntryPoint = "gbm_surface_create_with_modifiers", CallingConvention = CallingConvention.Cdecl)]
        static extern gbm_surface *gbm_surface_create_with_modifiers(gbm_device *deviceHandle, uint width, uint height, SurfaceFormat format, ulong* modifiers, uint count);
        [DllImport(Lib.Name, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void gbm_surface_destroy(gbm_surface *surface);
        [DllImport(Lib.Name, CallingConvention = CallingConvention.Cdecl)]
        static extern gbm_bo *gbm_surface_lock_front_buffer(gbm_surface *surface);
        [DllImport(Lib.Name, CallingConvention = CallingConvention.Cdecl)]
        static extern void gbm_surface_release_buffer(gbm_surface *surface, gbm_bo *bo);
        [DllImport(Lib.Name, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool gbm_surface_has_free_buffers(gbm_surface *surface);
        #endregion

        private gbm_surface *surfaceHandle;

        public nint Handle => (nint)this.surfaceHandle;


        public Device Device { get; private set; }

        #region ctor
        public Surface(Device gbmDev, Action eglSwap)
        {
            this.Device = gbmDev;
            this.eglSwap = eglSwap;
        }
        public Surface(Device gbmDev, uint width, uint height, SurfaceFormat format, SurfaceFlags flags, Action eglSwap): this(gbmDev, eglSwap)
        {
            this.surfaceHandle = gbm_surface_create(gbmDev.Handle, width, height, format, flags);

            if (this.surfaceHandle == null)
                throw new NotSupportedException("[GBM] Failed to create GBM surface");
        }
        public Surface(Device gbmDev, uint width, uint height, SurfaceFormat format, ulong modifier, Action eglSwap): this(gbmDev, eglSwap)
        {
            this.surfaceHandle = gbm_surface_create_with_modifiers(gbmDev.Handle, width, height, format, &modifier, 1);

            if (this.surfaceHandle == null)
                throw new NotSupportedException("[GBM] Failed to create GBM surface");
        }

        #endregion

        public bool HasFreeBuffers => gbm_surface_has_free_buffers(surfaceHandle);
        private gbm_bo *boHandle;

        private Action eglSwap;

        public Surface Initialize(Action<BufferObject, uint> action)
        {
            this.eglSwap.Invoke();
            this.Lock(action);
            return this;
        }

        public void SwapBuffers(Action renderAction, Action<BufferObject, uint> action)
        {
            while (true)
            {
                renderAction();
                this.eglSwap?.Invoke();
                this.Lock(action);
            }
        }

        private void Lock(Action<BufferObject, uint> action)
        {
            unsafe
            {
                var lastBo = this.boHandle;
                this.boHandle = gbm_surface_lock_front_buffer(this.surfaceHandle);

                if (this.boHandle == null)
                    throw new Exception("[GBM]: Failed to lock front buffer.");
                
                var bo = new BufferObject(this.boHandle);
                action?.Invoke(bo, bo.GetFb(this.Device));
                if (lastBo is not null)
                {
                    this.Release(lastBo);
                }
            }
        }


        private void Release(gbm_bo *bo)
        {
            gbm_surface_release_buffer(surfaceHandle, bo);
        }

        #region IDisposable implementation
        ~Surface()
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
            if (surfaceHandle != null)
                gbm_surface_destroy(surfaceHandle);
            surfaceHandle = null;
        }
        #endregion
    }
}

