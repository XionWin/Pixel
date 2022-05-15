using Extension;

namespace DRM
{
    public class Drm
    {
        public Drm(int fd, ModeInfo mode, Crtc crtc, Connector connector)
        {
            this.Fd = fd;
            this.Mode = mode;
            this.Crtc = crtc;
            this.Connector = connector;
        }

        public int Fd { get; set; }

        public ModeInfo Mode { get; set; }

        // public Plane Plane { get; set; }

        public Crtc Crtc { get; set; }

        public Connector Connector { get; set; }

        public override string ToString()
        {
            return string.Format("[Drm: Crtc={0}\n Connector={1}]", Crtc, Connector);
        }
    }
}

