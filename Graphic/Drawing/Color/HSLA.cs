namespace Graphic.Drawing.Color;
public struct HSLA
{
    public HSLA(float h, float s, float l, float a = 1f): this()
    {
        this.H = h;
        this.S = s;
        this.L = l;
        this.A = a;
    }
    
    public float H { get; set; }
    public float S { get; set; }
    public float L { get; set; }
    public float A { get; set; }
}
