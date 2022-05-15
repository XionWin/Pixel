namespace EGL.Definitions
{
    [Flags]
    public enum RenderableType
    {
        DontCare = -1,
        None = 0x3038,

        OpenGLES = 0x0001,
        Openvg = 0x0002,
        OpenGLES2 = 0x0004,
        Opengl = 0x0008,
        OpenGLES3 = 0x00000040,
    }
}