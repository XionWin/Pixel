using OpenTK.Graphics.ES30;
using OpenTK.Windowing.Common;
using Pixel.FontStash;
using FontStash = Pixel.GLES.FontStash.FontStash;
using Pixel.Window;
using SemanticExtension;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Pixel");


new PixelWindow("Pixel", 720, 720, "Resources/Icon.png")
    .With(x => x.VSync = VSyncMode.Adaptive)
    .With(x => x.Load += () => {
        GL.ClearColor(System.Drawing.Color.MidnightBlue);
        FontStash.Create(720, 720, FontFlags.TOPLEFT);
    })
    .With(x => x.RenderFrame += args => GL.Clear(ClearBufferMask.ColorBufferBit))
    .Run();