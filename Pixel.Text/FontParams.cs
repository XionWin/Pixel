namespace Pixel.Text;
public delegate bool RenderCreateHandler<T>(T context, int width, int height); 
public delegate bool RenderResizeHandler<T>(T context, int width, int height);
public delegate void RenderUpdateHandler<T>(T context, ref int[] rect, byte[] data);
public delegate void RenderDrawHandler<T>(T context, float[] verts, float[] tcoords, uint[] colors, int nverts);
public delegate void RenderDeleteHandler<T>(T context);

public class FontParams<T>
{
    public int Width { get; set; }
    public int Height { get; set; }
    public FontFlags FontFlags { get; set; }
    public T? Context { get; set; }
    public RenderCreateHandler<T>? RenderCreate { get; set; }
    public RenderResizeHandler<T>? RenderResize { get; set; }
    public RenderUpdateHandler<T>? RenderUpdate { get; set; }
    public RenderDrawHandler<T>? RenderDraw { get; set; }
    public RenderDeleteHandler<T>? RenderDelete { get; set; }
}
