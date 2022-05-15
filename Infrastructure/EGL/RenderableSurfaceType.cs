using EGL.Definitions;

namespace EGL
{
    public enum RenderableSurfaceType: uint
    {
        OpenGL = Definition.OPENGL_BIT,
        // OpenGLES = Definition.OPENGL_ES_BIT,
        // OpenOpenGLES = Definition.OPENGL_ES2_BIT,
        // OpenGLESV3 = Definition.OPENGL_ES3_BIT,

        OpenGLES = Definition.OPENGL_ES2_BIT,
        Window = Definition.WINDOW_BIT,
    }
}
