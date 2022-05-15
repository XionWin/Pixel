using System.Runtime.InteropServices;
using Graphic.Drawing;
using Graphic.Drawing.Color;

var files = System.IO.Directory.GetFiles("/dev/dri");
var cards = files.Where(x => System.Text.RegularExpressions.Regex.IsMatch(x, @"/dev/dri/card\d+"));

var fds = cards.Select(x => LIBC.Context.open(x, LIBC.OpenFlags.ReadWrite));
var drm = DRM.Extension.GetDrm(fds);

// float angle = 0f;
// var direction = true;
// unsafe
// {
//     var glesWindow = SDL2.SDL.SDL_CreateWindow("OpenGL ES 3.0", 0, 0, 1920, 1080, SDL2.SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL);
//     SDL2.SDL.SDL_SysWMinfo sysInfo = new SDL2.SDL.SDL_SysWMinfo();
//     SDL2.SDL.SDL_VERSION(out sysInfo.version); // Set SDL version
//     SDL2.SDL.SDL_GetWindowWMInfo(glesWindow, ref sysInfo);

//     using (var ctx = new EGL.WindowContext(sysInfo.info.x11.window, EGL.RenderableSurfaceType.OpenGLES) { VerticalSynchronization = true })
//     {
//         using (var program = new OpenGL.GFX.GfxProgram(@"shader/simplevertshader_v3.glsl", @"shader/simplefragshader_v3.glsl"))
//         {
//             OpenGL.ES.glUseProgram(program);
//             OpenGL.ES.glBindVertexArray(0);

//             var shapes = new [] {
//                 new Circle(1080/2, 1920/2, 1),
//             };
//             ctx.Render(() => ContextRender(program, shapes));
//         }
//     }
// }
  
float angle = 0f;
var direction = true;
using (var ctx = new EGL.KMSContext(drm, EGL.RenderableSurfaceType.OpenGLES) { VerticalSynchronization = true })
{
    using (var program = new OpenGL.GFX.GfxProgram(@"shader/simplevertshader_v3.glsl", @"shader/simplefragshader_v3.glsl"))
    {
        OpenGL.ES.glUseProgram(program);
        OpenGL.ES.glBindVertexArray(0);

        var shapes = new [] {
            new Circle(1080/2, 1920/2, 1),
        };
        ctx.Initialize(ContextInit).Render(() => ContextRender(program, shapes));
    }
}


void ContextInit(EGL.KMSContext ctx)
{
    Console.WriteLine($"GL Extensions: {OpenGL.ES.GetString(OpenGL.Def.StringName.Extensions)}");
    Console.WriteLine($"GL Version: {OpenGL.ES.GetString(OpenGL.Def.StringName.Version)}");
    Console.WriteLine($"GL Sharding Language Version: {OpenGL.ES.GetString(OpenGL.Def.StringName.ShadingLanguageVersion)}");
    Console.WriteLine($"GL Vendor: {OpenGL.ES.GetString(OpenGL.Def.StringName.Vendor)}");
    Console.WriteLine($"GL Renderer: {OpenGL.ES.GetString(OpenGL.Def.StringName.Renderer)}");

    OpenGL.ES.glClearColor(0f, 0f, 0f, 1f);
    OpenGL.ES.glViewport(0, 0, ctx.Width, ctx.Height);
}




void ContextRender(OpenGL.GFX.GfxProgram program, IEnumerable<Shape> shapes)
{

    

    var color = new Graphic.Drawing.Color.HSLA(angle = angle >= 360 ? 0 : ++angle, 1f, 0.2f, 1f);
    var rgb = color.ToRGB();

    OpenGL.ES.glClearColor(rgb.R, rgb.G, rgb.B, rgb.A);
    OpenGL.ES.glClear(OpenGL.Def.ClearBufferMask.ColorBufferBit);
    
    shapes.AsParallel().ForAll(x => {
        if(x is Circle circle)
        {
            circle.Radius += direction ? 3 : -3;
            if (circle.Radius < 0)
            {
                direction = true;
            }
            else if(circle.Radius > 500)
            {
                direction = false;
            }
        }
    });

    shapes.ToList().ForEach(x => x.Render(() => VertexParsing(program)));

    // foreach (var shape in shapes)
    // {
    //     shape.Render(() => VertexParsing(program));
    // }

    // System.Threading.Thread.Sleep(100);

}

void VertexParsing(OpenGL.GFX.GfxProgram program)
{
    uint posAttrib = OpenGL.ES.glGetAttribLocation(program, "position");
    OpenGL.ES.glEnableVertexAttribArray(posAttrib);
    OpenGL.ES.glVertexAttribPointerN(posAttrib, 2, false, (uint)Marshal.SizeOf(typeof(Vertex)), 0);
}
