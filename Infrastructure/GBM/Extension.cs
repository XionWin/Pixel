using Extension;

namespace GBM
{
    public static class Extension
    {
        public static GBM.Gbm GetGbm(DRM.Drm drm, Action eglSwapBuffersFunc)
        {
            var dev = new GBM.Device(drm.Fd);
            foreach (GBM.SurfaceFormat format in Enum.GetValues(typeof(GBM.SurfaceFormat)))
            {
                if (dev.IsSupportedFormat(format, GBM.SurfaceFlags.Linear))
                {
                    Console.WriteLine(Enum.GetName(typeof(GBM.SurfaceFormat), format));
                }
            }

            var gbm = new GBM.Gbm(dev, drm.Crtc.Width, drm.Crtc.Height, GBM.SurfaceFormat.ARGB8888, GBM.FormatMod.DRM_FORMAT_MOD_LINEAR, eglSwapBuffersFunc);
            Console.WriteLine(gbm.ToString());
            return gbm;
        }
    }
}

