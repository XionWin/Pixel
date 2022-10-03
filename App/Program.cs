using System.Diagnostics;
using OpenTK.Graphics.ES30;
using OpenTK.Windowing.Common;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var wnd = new Window.PixelWindow(1920, 1280);
wnd.VSync = VSyncMode.Off;
wnd.RenderFrequency = 1;

var watch = new Stopwatch();
watch.Start();
wnd.RenderFrame += args => {
    GL.ClearColor(1, 1, 1, 1);
    GL.Clear(ClearBufferMask.ColorBufferBit);
    watch.Stop();
    wnd.Title = (1000.0 / watch.ElapsedMilliseconds).ToString("0.000");
    watch.Restart();
};
wnd.Run();
