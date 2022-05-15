namespace Graphic.Drawing.Color
{
    public struct RGBA
    {
        public RGBA(float r, float g, float b, float a = 1f): this()
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }
        
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }
    }
}