﻿using System.Runtime.InteropServices;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Common.Input;
using OpenTK.Windowing.Desktop;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

using ImageSharp = SixLabors.ImageSharp;

namespace Window;
public class PixelWindow: GameWindow
{
    private readonly static byte[] ICON_DATA = new byte[]
    {
        255, 51, 51, 255,
    };

    public PixelWindow(int width, int height):
        base(
            new ()
            {
                RenderFrequency = 60,
                UpdateFrequency = 30,
            },
            new NativeWindowSettings()
            {
                Title = "Pixel Renderer",
                Size = new OpenTK.Mathematics.Vector2i(width, height),
                API = ContextAPI.OpenGL,
                APIVersion = new Version(3, 2),
                Icon = PixelWindowExtension.CreateWindowIcon(),
            }
        )
    {}

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        this.SwapBuffers();
    }
}

public static class PixelWindowExtension
{
    public static WindowIcon CreateWindowIcon()
    {
        using var image = (Image<Rgba32>)ImageSharp.Image.Load(Configuration.Default, "terraria.png");
            return image.DangerousTryGetSinglePixelMemory(out var memory) &&
            MemoryMarshal.AsBytes(memory.Span).ToArray() is byte[] imageBytes ?
            new WindowIcon(new OpenTK.Windowing.Common.Input.Image(image.Width, image.Height, imageBytes)) :
            throw new Exception();
    }
}