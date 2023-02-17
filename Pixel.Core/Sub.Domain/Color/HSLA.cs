namespace Pixel.Core.Sub.Domain.Color;
public class HSLA
{
    public HSLA(float h, float s, float l = .5f, float a = 1f)
    {
        this.h = h;
        this.s = s;
        this.l = l;
        this.a = a;
    }

    private float h;
    private float s;
    private float l;
    private float a;
    public float H { get => h; set => h = value; }
    public float S { get => s; set => s = value; }
    public float L { get => l; set => l = value; }
    public float A { get => a; set => a = value; }
}
