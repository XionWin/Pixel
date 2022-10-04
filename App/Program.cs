using OpenTK.Graphics.ES30;
using OpenTK.Windowing.Common;
using SemanticExtension;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var wnd = new Window.PixelWindow(1920, 1280);
wnd.VSync = VSyncMode.On;

wnd.RenderFrame += args => {
    GL.ClearColor(1, 1, 1, 1);
    GL.Clear(ClearBufferMask.ColorBufferBit);
};

wnd.Run();
