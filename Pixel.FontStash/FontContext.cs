namespace Pixel.FontStash;

public delegate void HandleErrorHandler(object uptr, FontSerrorCode error, int val);

public class FontContext<T>
{
    public FontParams<T> FontParams { get; set; }
    public float itWidth { get; set; }
    public float itHeight { get; set; }
    public byte[]? TexData { get; set; }
    public int[]? DirtyRect { get; set; }
    public Font[]? Fonts { get; set; }
    public int nFonts { get; set; }
    public uint cFonts { get; set; }
    public FontAtlas Atlas { get; set; }
    public float[]? Verts { get; set; }
    public int nVerts { get; set; }
    public float[]? tCoords { get; set; }
    public uint[]? Colors { get; set; }
    public byte[]? Scratch { get; set; }
    public int nScratch { get; set; }
    public FontState[]? States { get; set; }
    public int nStates { get; set; }
    public HandleErrorHandler? HandelError { get; set; }
    public object? ErrorUserPtr { get; set; }


}

public class Font
{

}
