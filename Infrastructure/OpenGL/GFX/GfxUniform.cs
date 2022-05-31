namespace OpenGL.GFX;
public abstract class GfxUniform: GfxObject
{
    public string Name { get; init; }

    public GfxUniform(uint id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}

static class GfxUniformExtension {
    
}
