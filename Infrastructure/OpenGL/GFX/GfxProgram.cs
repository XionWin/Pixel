using System.Runtime.InteropServices;

namespace OpenGL.GFX;

public class GfxProgram: GfxObject
{
    public GfxProgram(string vertexShaderPath, string fragmentShaderPath): base()
    {
        this.Id = ES.glCreateProgram();

        using(var vertexShader = new GfxShader(Def.ShaderType.VertexShader, vertexShaderPath).Load().Check())
        using(var fragmentShader = new GfxShader(Def.ShaderType.FragmentShader, fragmentShaderPath).Load().Check())
        {
            this.AttachShader(vertexShader)
            .AttachShader(fragmentShader)
            .Link()
            .Check();
        }
    }

    protected override void Release() => ES.glDeleteProgram(this.Id);
}

public static class GfxProgramExtension {
    public static GfxProgram AttachShader(this GfxProgram program, GfxShader shader) {
        ES.glAttachShader(program.Id, shader.Id);
        return program;
    }
    public static GfxProgram Link(this GfxProgram program) {
        ES.glLinkProgram(program.Id);
        program.CheckLink();
        return program;
    }

    public static GfxProgram CheckLink(this GfxProgram program) {
        if(!ES.glGetProgramLinkedStatus(program))
        {
            throw new OpenGLESException(ES.glGetProgramLinkedInformation(program));
        }
        return program;
    }

    public static void SetAttribute(this GfxProgram program, string name, Type type, uint size, uint offset = 0, bool isNormalized = false)
    {
        if(OpenGL.ES.glGetAttribLocation(program, name) is uint id)
        {
            var attribute = new GfxAttribute(id, name, type, size, offset, isNormalized);
            OpenGL.ES.glEnableVertexAttribArray(attribute.Id);
            OpenGL.ES.glVertexAttribPointerF(attribute.Id, attribute.Size, attribute.IsNormalized, (uint)Marshal.SizeOf(attribute.Type), attribute.Offet);
            program.Check();
        }
    }

    public static uint GetUniformIndex(this GfxProgram program, string name) =>
        OpenGL.ES.glGetUniformLocation(program, name);
}
