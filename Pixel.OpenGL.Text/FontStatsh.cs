using Pixel.Text;
using SemanticExtension;

namespace Pixel.OpenGL.Text;
public static class GLFontStash
{
    public static FontContext<GLFontContext> Create(int width, int height, FontFlags fontFlags)
    {
        var fontParams = new FontParams<GLFontContext>()
            .With(x => x.Width = width)
            .With(x => x.Height = height)
            .With(x => x.FontFlags = fontFlags)
            .With(x => x.RenderCreate = RenderCreate)
            .With(x => x.RenderResize = RenderResize)
            .With(x => x.RenderUpdate = RenderUpdate)
            .With(x => x.RenderDraw = RenderDraw)
            .With(x => x.RenderDelete = RenderDelete)
            .With(x => x.Context = new GLFontContext());

            return Pixel.Text.FontStash.Create(ref fontParams);
    }
    
    private static bool RenderCreate(GLFontContext context, int width, int height)
    {
        if (context.Textures is not null)
        {
            GL.DeleteTextures(1, context.Textures);
            context.Textures = null;
        }
        context.Textures = new uint[1];
        GL.GenTextures(1, context.Textures);
        if (context.Textures is null) return false;

        context.Width = width;
        context.Height = height;
        foreach (var texture in context.Textures)
        {
            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.TexImage2D(TextureTarget2d.Texture2D, 0, TextureComponentCount.Alpha,
            context.Width, context.Height, 0, PixelFormat.Alpha, PixelType.UnsignedByte, IntPtr.Zero);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
            (int)TextureMinFilter.Linear);
        }
        return true;
    }

    private static bool RenderResize(GLFontContext context, int width, int height)
    {
        throw new NotImplementedException();
    }
    private static void RenderUpdate(GLFontContext context, ref int[] rect, byte[] data)
    {
        throw new NotImplementedException();
    }
    private static void RenderDraw(GLFontContext context, float[] verts, float[] tcoords, uint[] colors, int nverts)
    {
        throw new NotImplementedException();
    }
    private static void RenderDelete(GLFontContext context)
    {
        throw new NotImplementedException();
    }
}
