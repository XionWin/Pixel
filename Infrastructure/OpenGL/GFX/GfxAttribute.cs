
namespace OpenGL.GFX;
public class GfxAttribute: GfxObject
{
    public string Name { get; init; }
    public Type Type { get; init; }
    public uint Size { get; init; }
    public uint Offet { get; init; }
    public bool IsNormalized { get; init; }

    public GfxAttribute(uint id, string name, Type type, uint size, uint offset = 0, bool isNormalized = false)
    {
        this.Id = id;
        this.Name = name;
        this.Type = type;
        this.Size = size;
        this.Offet = offset;
        this.IsNormalized = isNormalized;
    }

    protected override void Release()
    {
        
    }
}

static class GfxAttributeExtension {
}
