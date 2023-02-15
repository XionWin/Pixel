using SemanticExtension;

namespace Pixel.FontStash;
public static class FontStash
{
    public static void Create(int width, int height, FontFlags fontFlags)
    {
        
    }

    public static bool AddFont<T>(T context, string name, string path)
    {
        if (File.Exists(path) is false)
            throw new Exception("Font file not found");
        byte[] data = File.ReadAllBytes(path);
        var len = (uint)data.Length;
        return AddFontToMemory(context, name, data, len, true);
    }

    private static bool AddFontToMemory<T>(T context, string name, byte[] data, uint dataLen, bool isFreeData)
    {
        throw new NotImplementedException();
    }

}
