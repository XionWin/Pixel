using SemanticExtension;

namespace Pixel.FontStash;
public static class FontStash
{

		public const uint SCRATCH_BUF_SIZE = 16000;
		public const uint HASH_LUT_SIZE = 256;
		public const uint INIT_FONTS = 4;
		public const uint INIT_GLYPHS = 256;
		public const uint INIT_ATLAS_NODES = 256;
		public const uint VERTEX_COUNT = 1024;
		public const uint MAX_STATES = 20;
		public const int INVALID = -1;
		public const int MAX_FALLBACKS = 20;

    public static FontContext<T> Create<T>(ref FontParams<T> fontParams)
    {
        var context = new FontContext<T>();
        context.FontParams = fontParams;
        context.Scratch = new byte[SCRATCH_BUF_SIZE];

        if (context.FontParams.RenderCreate is not null)
        {
            if(context.FontParams.RenderCreate(context.FontParams.Context!, context.FontParams.Width, context.FontParams.Height) is false)
                throw new Exception("Error init renderCreate");

            context.Atlas = AllocAtlas(context.FontParams.Width, context.FontParams.Height, INIT_ATLAS_NODES);

            //Allocate sapce for fonts.
            context.Fonts = new Font[INIT_FONTS];
            for (int i = 0; i < INIT_FONTS; i++)
                context.Fonts[i] = new Font();

            context.cFonts = INIT_FONTS;
            context.nFonts = 0;

            //Create texture for the cache.
            context.itWidth = 1f / context.FontParams.Width;
            context.itHeight = 1f / context.FontParams.Height;
            context.TexData = new byte[context.FontParams.Width * context.FontParams.Height];

            context.DirtyRect![0] = context.FontParams.Width;
            context.DirtyRect![1] = context.FontParams.Height;
            context.DirtyRect![2] = 0;
            context.DirtyRect![3] = 0;

            // Add white rect at 0,0 for debug drawing.

        }
        return context;
    }

    private static void AddWhiteRect<T>(FontContext<T> context, int width, int height)
    {
        int x, y, gx = 0, gy = 0;
        byte[] dst;
        
    }

    private static FontAtlas AllocAtlas(int width, int height, uint nodeLen)
    {
        var fontAtlas = new FontAtlas();
        fontAtlas.Width = width;
        fontAtlas.Height = height;

        fontAtlas.Nodes = new FontStlasNode[nodeLen];
        for (int i = 0; i < nodeLen; i++)
            fontAtlas.Nodes[i] = new FontStlasNode();

        fontAtlas.nNodes = 0;
        fontAtlas.cNodes = nodeLen;

        //Init root node.
        fontAtlas.Nodes[0].x = 0;
        fontAtlas.Nodes[0].y = 0;
        fontAtlas.Nodes[0].width = (short)width;
        fontAtlas.nNodes++;

        return fontAtlas;
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
