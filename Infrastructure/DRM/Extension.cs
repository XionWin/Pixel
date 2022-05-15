using Extension;

namespace DRM
{
    public static class Extension
    {
        public static DRM.Drm GetDrm(int fd)
        {
            using (var resources = new DRM.Resources(fd))
            {
                /* find a connected connector: */
                var connector = resources.Connectors.First(_ => _.State == DRM.ConnectionStatus.Connected);
                /* find preferred mode: */
                var mode = connector.Modes.First(_ => _.type.BitwiseContains(DRM.DrmModeType.Preferred));
                /* find encoder: */
                var encoder = resources.Encoders.FirstOrDefault(_ => _.Id == connector.EncodeId);
                /* find crtc: */
                var crtc = encoder?.CurrentCrtc ?? resources.Crtcs.First(_ => _.ModeIsValid);

                var drm = new DRM.Drm(fd, mode, crtc, connector);
                Console.WriteLine(drm.ToString());
                return drm;
            }
        }

        
        public static DRM.Drm GetDrm(IEnumerable<int> fds) =>
            fds
            .Select(x => { try{ return DRM.Extension.GetDrm(x); } catch { return null; } })
            .First(x => x is DRM.Drm)!;
    }
}

