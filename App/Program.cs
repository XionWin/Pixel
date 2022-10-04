using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using SemanticExtension;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


IEnumerable<int> values = new [] {1, 2, 3 ,4 ,5};
values.GetEnumerator().With(x => x.MoveNext()).Loop(x => x <= 3, x => Console.WriteLine(x));

var wnd = new Window.PixelWindow(1920, 1280);
wnd.VSync = VSyncMode.On;

wnd.RenderFrame += args => {
    GL.ClearColor(1, 1, 1, 1);
    GL.Clear(ClearBufferMask.ColorBufferBit);
};

wnd.Run();
