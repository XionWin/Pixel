namespace Pixel.Core.Sub.Domain.Color;
public struct RGB
{
    public RGB(byte r, byte g, byte b)
    {
        this.r = r;
        this.g = g;
        this.b = b;
    }

    private byte r;
    private byte g;
    private byte b;
    public byte R { get => r; set => r = value; }
    public byte G { get => g; set => g = value; }
    public byte B { get => b; set => b = value; }
}
