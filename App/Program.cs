using OpenTK.Windowing.Common;
using Pixel.Text;
using GLFontStash = Pixel.OpenGL.Text.GLFontStash;
using Pixel.Window;
using SemanticExtension;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Pixel");

new PixelWindow("Pixel", 720, 720, "Resources/Icon.png")
    .With(x => x.VSync = VSyncMode.Adaptive)
    .With(x => x.Load += () => {
        GL.ClearColor(System.Drawing.Color.MidnightBlue);
        GLFontStash.Create(720, 720, FontFlags.TOPLEFT);
    })
    .With(x => x.RenderFrame += OnRenderFrame)
    .Run();


static void OnRenderFrame(FrameEventArgs args)
{
    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
    GL.DrawArrays(PrimitiveType.Lines, 0, 2);
    
}