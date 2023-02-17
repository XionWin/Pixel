namespace Pixel.Core.Sub.Domain.Color;
public class HSL
{
    public HSL(float h, float s, float l = .5f)
    {
        this.h = h;
        this.s = s;
        this.l = l;
    }

    private float h;
    private float s;
    private float l;
    public float H { get => h; set => h = value; }
    public float S { get => s; set => s = value; }
    public float L { get => l; set => l = value; }
}
