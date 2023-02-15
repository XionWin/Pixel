namespace Pixel.FontStash;
public struct FontAtlas
{
	public int Width { get; set; }
	public int Height { get; set; }
	public FontStlasNode Nodes { get; set; }
	public int nNodes { get; set; }
	public uint cNodes { get; set; }
}
public class FontStlasNode
{
	public short x, y, width;
}
