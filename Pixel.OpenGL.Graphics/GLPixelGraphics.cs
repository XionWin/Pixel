using Pixel.Graphics;
using SemanticExtension;
using System.Drawing;

namespace Pixel.OpenGL.Graphics;

public class GLPixelGraphics : PixelGraphics
{
    private static GLPixelGraphics? _Instance;
    public static GLPixelGraphics Create(Size size) =>
        _Instance is GLPixelGraphics isntance ?
            isntance.IsSizeChanged(size) ?
                isntance.With(x => x.Resize(size)) :
                isntance :
            new GLPixelGraphics(size).With(x => _Instance = x);

    private GLPixelGraphics(Size size) : base(size)
    {
    }

    protected override void Resize(Size size)
    {
        base.Resize(size);
    }

    protected override void Draw()
    {
        base.Draw();
    }
}