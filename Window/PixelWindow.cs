using System.Runtime.InteropServices;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Common.Input;
using OpenTK.Windowing.Desktop;
using SemanticExtension;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

using ImageSharp = SixLabors.ImageSharp;

namespace Window;
public class PixelWindow : GameWindow
{
    public PixelWindow(string title, int width, int height, string? iconPath = null) :
        base(
            new()
            {
                RenderFrequency = 60,
                UpdateFrequency = 30,
            },
            new NativeWindowSettings()
            {
                Title = title,
                Size = new OpenTK.Mathematics.Vector2i(width, height),
                API = ContextAPI.OpenGLES,
                APIVersion = new Version(3, 2),
                Icon = iconPath?.Then(x => PixelWindowExtension.CreateWindowIcon(x)),
            }
        )
    {
        this.Title = title;
    }

    public new string Title
    {
        get;
        set;
    } = string.Empty;

    private System.Diagnostics.Stopwatch fpsWatch = new System.Diagnostics.Stopwatch().With(x => x.Start());
    protected override void OnRenderFrame(FrameEventArgs args)
    {
        if(fpsWatch.ElapsedMilliseconds > 1000)
        {
            base.Title = $"{this.Title} 🚀 fps: {(uint)(1.0/ args.Time)}";
            fpsWatch.Restart();
        }
        base.OnRenderFrame(args);
        this.SwapBuffers();
    }
}

public static class PixelWindowExtension
{
    public static WindowIcon CreateWindowIcon(string iconPath)
    {
        using var image = (Image<Rgba32>)ImageSharp.Image.Load(Configuration.Default, iconPath);
        return image.GetPixelData() is var pixelSpan &&
        MemoryMarshal.AsBytes(pixelSpan).ToArray() is byte[] imageBytes ?
        new WindowIcon(new OpenTK.Windowing.Common.Input.Image(image.Width, image.Height, imageBytes)) :
        throw new Exception("CreateWindowIcon error");
    }

    public static Span<TPixel> GetPixelData<TPixel>(this Image<TPixel> image)
    where TPixel : unmanaged, IPixel<TPixel> =>
    image.Frames.RootFrame.Size() is var size &&
        new TPixel[size.Width * size.Height] is var pixelSpan ?
        pixelSpan.With(x => image.CopyPixelDataTo(x)) :
        throw new Exception("CreateWindowIcon error");
}
