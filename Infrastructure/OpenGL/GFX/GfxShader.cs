namespace OpenGL.GFX;
public class GfxShader: GfxObject
{
    public string Source { get; init; }
    public Def.ShaderType ShaderType { get; init; }

    internal GfxShader(Def.ShaderType shaderType, string path): base()
    {
        this.Id = ES.glCreateShader(this.ShaderType = shaderType);
        using (var sr = new System.IO.StreamReader(path))
        {
            this.Source = sr.ReadToEnd();
        }
    }

    protected override void Release()
    {
        ES.glDeleteShader(this.Id);
    }
}

static class GfxShaderExtension {
    public static GfxShader Load(this GfxShader shader) {
        ES.glShaderSource(shader.Id, 1, new []{shader.Source}, 0);
        ES.glCompileShader(shader.Id);
        shader.CheckCompile();
        return shader;
    }

    public static GfxShader CheckCompile(this GfxShader shader) {
        if(!ES.glGetShaderCompiledStatus(shader))
        {
            throw new OpenGLESException(ES.glGetShaderCompiledInformation(shader));
        }
        return shader;
    }
}
