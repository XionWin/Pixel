using SemanticExtension;
using System.Drawing;

namespace Pixel.Graphics;

public abstract class PixelGraphic
{
    //private static PixelGraphic? _Instance;
    //public static PixelGraphic Create<T>(Size size) where T: PixelGraphic =>
    //    _Instance is PixelGraphic isntance ?
    //        isntance.IsSizeChanged(size) ?
    //            isntance.With(x => x.Resize(size)) :
    //            isntance :
    //        new T(size).With(x => _Instance = x);

    public Size Size { get; private set; }

    public bool IsDirty { get; private set; } = true;

    private PixelGraphic(Size size)
    {
        this.Size = size;
    }

    protected virtual void Resize(Size size)
    {
        this.Size = size;
        this.IsDirty = true;
        Render();
    }

    protected virtual void Render()
    {
        if (IsDirty is false)
            return;
    }
}

public static class PixelGraphicExtensions
{
    public static bool IsSizeChanged(this PixelGraphic pixelGraphic, Size newSize) =>
        (pixelGraphic.Size.Width == newSize.Width && pixelGraphic.Size.Height == newSize.Height) is false;
}
