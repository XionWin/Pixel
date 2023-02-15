using OpenTK.Graphics.ES30;
using OpenTK.Windowing.Common;
using Pixel.FontStash;
using FontStash = Pixel.FontStash.FontStash;
using Pixel.Window;
using SemanticExtension;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Pixel Debug Started");


new PixelWindow("Pixel", 720, 720, "Resources/Terraria.png")
    .With(x => x.VSync = VSyncMode.Adaptive)
    .With(x => x.Load += OnLoad)
    .With(x => x.RenderFrame += OnRenderFrame)
    .Run();


static void OnLoad()
{
    GL.ClearColor(System.Drawing.Color.MidnightBlue);
    FontStash.Create(720, 720, FontFlags.TOPLEFT);
}

static void OnRenderFrame(FrameEventArgs args)
{
    // GL.ClearColor(0, 0, 0, 1);
    GL.Clear(ClearBufferMask.ColorBufferBit);
}