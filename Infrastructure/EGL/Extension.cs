using System.Runtime.InteropServices;
using EGL.Definitions;

namespace EGL
{
    using EGLConfig = IntPtr;
    using EGLContext = IntPtr;
    using EGLDisplay = IntPtr;
    using EGLSurface = IntPtr;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate nint GetPlatformDisplayEXTHandler(uint platform, nint native_display, uint[]? attrib_list);
    unsafe public static class Extension
    {
        public static string? GetVersion(EGLDisplay display) => Egl.QueryString(display, Definition.VERSION);
        public static string? GetVendor(EGLDisplay display) => Egl.QueryString(display, Definition.VENDOR);
        public static string? GetExtensions(EGLDisplay display) => Egl.QueryString(display, Definition.EXTENSIONS);
        public static string? OffScreenExtensions => Egl.QueryString(IntPtr.Zero, Definition.EXTENSIONS);

        public static (EGLDisplay display, EGLContext context, EGLSurface surface, EGLConfig config, int major, int minor) CrateKMSContext(GBM.Gbm gbm, RenderableSurfaceType surfaceType)
        {
            const uint EGL_PLATFORM_GBM_KHR = 0x31D7;
            Func<EGLDisplay> getDisplayFunc = () => 
                Extension.OffScreenExtensions?.Contains("EGL_EXT_platform_base") is true &&
                    Marshal.GetDelegateForFunctionPointer(Egl.eglGetProcAddress("eglGetPlatformDisplayEXT"), typeof(GetPlatformDisplayEXTHandler)) is GetPlatformDisplayEXTHandler handler ?
                    handler(EGL_PLATFORM_GBM_KHR, (nint)gbm.Device.Handle, null) :
                    Egl.eglGetDisplay((nint)gbm.Device.Handle);

            Func<EGLDisplay, EGLConfig, EGLSurface> getSurfaceFunc = (display, config) =>
                Egl.eglCreateWindowSurface(display, config, gbm.Surface.Handle, null);
            
            return CrateContext(getDisplayFunc, getSurfaceFunc, surfaceType);
        }

        public static (EGLDisplay display, EGLContext context, EGLSurface surface, EGLConfig config, int major, int minor) CrateWindowContext(nint handle, RenderableSurfaceType surfaceType)
        {
            Func<EGLDisplay> getDisplayFunc = () => Egl.eglGetDisplay(IntPtr.Zero);

            Func<EGLDisplay, EGLConfig, EGLSurface> getSurfaceFunc = (display, config) =>
                Egl.eglCreateWindowSurface(display, config, handle, null);
            
            return CrateContext(getDisplayFunc, getSurfaceFunc, surfaceType);
        }

        public static (EGLDisplay display, EGLContext context, EGLSurface surface, EGLConfig config, int major, int minor) CrateContext(
            Func<EGLDisplay> getDisplayFunc,
            Func<EGLDisplay, EGLConfig, EGLSurface> getSurfaceFunc,
            RenderableSurfaceType surfaceType)
        {
            (EGLDisplay display, EGLContext context, EGLSurface surface, EGLConfig config, int major, int minor) result;
            
            result.display = getDisplayFunc();
            if (result.display == IntPtr.Zero)
                throw new NotSupportedException("[EGL] GetDisplay failed.: " + Egl.eglGetError());

            if (Egl.eglInitialize(result.display, out result.major, out result.minor) is false)
                throw new NotSupportedException("[EGL] Failed to initialize EGL display. Error code: " + Egl.eglGetError());

            var isModifiersSupported = GetExtensions(result.display)?.Contains("EGL_EXT_image_dma_buf_import_modifiers") is true;

            if (Egl.eglBindAPI(RenderApi.GLES) is false)
                throw new NotSupportedException("[EGL] Failed to bind EGL Api: " + Egl.eglGetError());

            var desiredConfig = new[] {
                Definition.SURFACE_TYPE, (int)surfaceType,
                Definition.RENDERABLE_TYPE, Definition.OPENGL_ES3_BIT,
                Definition.RED_SIZE, 8,
                Definition.GREEN_SIZE, 8,
                Definition.BLUE_SIZE, 8,
                Definition.ALPHA_SIZE, 8,
                Definition.STENCIL_SIZE, 8,
                Definition.SAMPLE_BUFFERS, 1,
                Definition.SAMPLES, 4,
                Definition.NONE
            };

            result.config = Extension.GetConfig(result.display, desiredConfig);

            var contextAttrib = new[] {
                Definition.CONTEXT_CLIENT_VERSION, 3,
                Definition.NONE
            };
            result.context = Egl.CreateContext(result.display, result.config, IntPtr.Zero, contextAttrib);
            if (result.context == IntPtr.Zero)
                throw new NotSupportedException(String.Format("[EGL] Failed to create egl context, error {0}.", Egl.eglGetError()));

            result.surface = getSurfaceFunc(result.display, result.config);

            if (result.surface == IntPtr.Zero)
                throw new NotSupportedException(String.Format("[EGL] Failed to create egl surface, error {0}.", Egl.eglGetError()));

            if (Egl.eglMakeCurrent(result.display, result.surface, result.surface, result.context) is false)
            {
                throw new NotSupportedException(String.Format("[EGL] Failed to make current, error {0}.", Egl.eglGetError()));
            }
            return result;
        }
        
        private static nint GetConfig(EGLDisplay display, int[] desiredConfig)
        {
            int num_configs;
            var configs = new nint[1];
            if (!Egl.eglChooseConfig(display, desiredConfig, configs, 1, out num_configs) || num_configs < 1)
                throw new NotSupportedException(String.Format("[EGL] Failed to retrieve GraphicsMode, error {0}", Egl.eglGetError()));
            return configs[0];
        }
        private static nint[] GetAllConfigs(EGLDisplay display, int[] desiredConfig)
        {
            int num_configs;
            if (!Egl.eglChooseConfig(display, desiredConfig, null, 0, out num_configs) || num_configs == 0)
                throw new NotSupportedException(String.Format("[EGL] Failed to retrieve GraphicsMode, error {0}", Egl.eglGetError()));

            var configs = new nint[num_configs];
            if (!Egl.eglChooseConfig(display, null, configs, num_configs, out num_configs))
                throw new NotSupportedException(String.Format("[EGL] Failed to retrieve GraphicsMode, error {0}", Egl.eglGetError()));
            return configs;
        }
        private static void DumpAllConf(EGLDisplay display, int[] desiredConfig)
        {
            Console.Write("EGL Configs");
            nint[] configs = Extension.GetAllConfigs(display, desiredConfig);
            int[] attribs = new int[] {
                (int)Definitions.Attribute.BufferSize,
                Definition.RED_SIZE,
                Definition.GREEN_SIZE,
                Definition.BLUE_SIZE,
                Definition.ALPHA_SIZE,
                (int)Definitions.Attribute.DepthSize,
                Definition.WIDTH,
                Definition.HEIGHT,
                (int)Definitions.Attribute.Samples,
                (int)Definitions.Attribute.SampleBuffers,
                (int)Definitions.Attribute.RenderableType,
                (int)Definitions.Attribute.SurfaceType,
                (int)Definitions.Attribute.Level,
                (int)Definitions.Attribute.ConfigCaveat,
            };

            for (int i = 0; i < configs.Length; i++)
            {
                nint conf = configs[i];
                Console.Write("{0,-3}:", i);
                for (int j = 0; j < attribs.Length; j++)
                {
                    int value;
                    Egl.eglGetConfigAttrib(display, conf, attribs[j], out value);
                    Console.Write((j == 0 ? string.Empty : ", ") + "{0} = {1}", Egl.EglConstToString((int)attribs[j]), value);
                }
                Console.Write("\n");
            }
        }

        public static void ResetMakeCurrent(EGLDisplay display)
        {
            if (!Egl.eglMakeCurrent(display, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero))
                Console.WriteLine("egl clear current ctx failed");
        }
    }
}

