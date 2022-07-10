using System.Runtime.InteropServices;

namespace FontStash;
public class TrueType
{
    private const uint FIX_SHIFT = 10;
	private const uint FIX = 1 << (int)FIX_SHIFT;
    private const uint FIX_MASK = FIX - 1;

    public unsafe static T Get<T>(byte[] data, uint offset)
        where T: struct
    {
        var len = Marshal.SizeOf<T>();
        return default;
    }

}