namespace Pixel.FontStash;
public class FontState
{
	public int Font { get; set; }
	public FontAlign Align { get; set; }
	public float Size { get; set; }
	public uint Color { get; set; }
	public float Blur { get; set; }
	public float Spacing { get; set; }
}

	public enum FontAlign
	{
		// Horizontal align

		// Default
		LEFT = 1 << 0,
		CENTER = 1 << 1,
		RIGHT = 1 << 2,
		// Vertical align
		TOP = 1 << 3,
		MIDDLE	= 1 << 4,
		BOTTOM	= 1 << 5,
		// Default
		BASELINE	= 1 << 6,
	}
