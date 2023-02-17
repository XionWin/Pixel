namespace Pixel.Core.Sub.Domain.Color;
public struct RGBA
{
    public RGBA(byte r, byte g, byte b, byte a = 255)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = a;
    }

    private byte r;
    private byte g;
    private byte b;
    private byte a;
    public byte R { get => r; set => r = value; }
    public byte G { get => g; set => g = value; }
    public byte B { get => b; set => b = value; }
    public byte A { get => a; set => a = value; }
}
