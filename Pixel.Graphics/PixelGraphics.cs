using SemanticExtension;
using System.Drawing;

namespace Pixel.Graphics;

public abstract class PixelGraphics
{
    public Size Size { get; private set; }

    public bool IsDirty { get; private set; } = true;

    protected PixelGraphics(Size size)
    {
        this.Size = size;
    }

    protected virtual void Resize(Size size)
    {
        this.Size = size;
        this.IsDirty = true;
        Draw();
    }

    protected virtual void Draw()
    {
        if (IsDirty is false)
            return;
    }
}

public static class PixelGraphicExtensions
{
    public static bool IsSizeChanged(this PixelGraphics pixelGraphic, Size newSize) =>
        (pixelGraphic.Size.Width == newSize.Width && pixelGraphic.Size.Height == newSize.Height) is false;
}
