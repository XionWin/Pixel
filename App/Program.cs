using Graphic.Drawing;
using Graphic.Drawing.Color;
using OpenGL.GFX;

internal class Program
{
    private static void Main(string[] args)
    {
        var files = Directory.GetFiles("/dev/dri");
        var cards = files.Where(x => System.Text.RegularExpressions.Regex.IsMatch(x, @"/dev/dri/card\d+"));

        var fds = cards.Select(x => LIBC.Context.open(x, LIBC.OpenFlags.ReadWrite));
        var drm = DRM.Extension.GetDrm(fds);

        float angle = 0f;
        using (var ctx = new EGL.KMSContext(drm, EGL.RenderableSurfaceType.OpenGLES) { VerticalSynchronization = true })
        {
            using (var program = new OpenGL.GFX.GfxProgram(@"shader/simple.vert", @"shader/simple.frag"))
            {
                OpenGL.ES.glUseProgram(program);
                OpenGL.ES.glBindVertexArray(0);

                var shapes = new[] {
                    new Circle(1080/2, 1920/2, 320),
                };
                
                ctx.Initialize(() => ContextInit(ctx, program)).Render(() => ContextRender(program, shapes));
            }
        }

        void ContextInit(EGL.KMSContext ctx, GfxProgram program)
        {
            Console.WriteLine($"GL Extensions: {OpenGL.ES.GetString(OpenGL.Def.StringName.Extensions)}");
            Console.WriteLine($"GL Version: {OpenGL.ES.GetString(OpenGL.Def.StringName.Version)}");
            Console.WriteLine($"GL Sharding Language Version: {OpenGL.ES.GetString(OpenGL.Def.StringName.ShadingLanguageVersion)}");
            Console.WriteLine($"GL Vendor: {OpenGL.ES.GetString(OpenGL.Def.StringName.Vendor)}");
            Console.WriteLine($"GL Renderer: {OpenGL.ES.GetString(OpenGL.Def.StringName.Renderer)}");

            OpenGL.ES.glClearColor(0f, 0f, 0f, 1f);
            OpenGL.ES.glViewport(0, 0, ctx.Width, ctx.Height);

            var view_port_id = program.GetUniformIndex("view_port");
            OpenGL.ES.glUniform2f(view_port_id, ctx.Width, ctx.Height);

        }

        void ContextRender(OpenGL.GFX.GfxProgram program,
                           IEnumerable<Shape> shapes)
        {
            if (shapes is not null)
            {
                var color = new HSLA(angle = angle >= 360 ? 0 : ++angle, 1f, 0.3f, 1f);
                var rgb = color.ToRGB();

                OpenGL.ES.glClearColor(rgb.R, rgb.G, rgb.B, rgb.A);
                OpenGL.ES.glClear(OpenGL.Def.ClearBufferMask.ColorBufferBit);

                shapes.ToList().ForEach(x => x.Render(() => program.VertexParsing()));
            }
            else
            {
                throw new ArgumentNullException(nameof(shapes));
            }

            // foreach (var shape in shapes)
            // {
            //     shape.Render(() => VertexParsing(program));
            // }

            // System.Threading.Thread.Sleep(100);

        }
    }
}

static class ProgramExtention
{
    public static void VertexParsing(this GfxProgram program)
    {
        // uint posAttrib = OpenGL.ES.glGetAttribLocation(program, "position");
        // OpenGL.ES.glEnableVertexAttribArray(posAttrib);
        // OpenGL.ES.glVertexAttribPointerN(posAttrib, 2, false, (uint)Marshal.SizeOf(typeof(Vertex)), 0);
        
        program.SetAttribute("position", typeof(Vertex), 2);
    }
    
}


