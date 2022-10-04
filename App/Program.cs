using OpenTK.Graphics.ES30;
using OpenTK.Windowing.Common;
using SemanticExtension;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Pixel Started");


new Window.PixelWindow("Pixel", 1920, 1280)
.With(x => x.VSync = VSyncMode.On)
.With(x => x.RenderFrame += args =>
{
    GL.ClearColor(1, 1, 1, 1);
    GL.Clear(ClearBufferMask.ColorBufferBit);
})
.Run();
