using System.Linq;

namespace Graphic.Drawing;
public class Circle : Shape
{
    private static int MIN_SEGMENT_COUNT = 16;
    private static int MAX_SEGMENT_COUNT = 360;
    private int segmentCount = MIN_SEGMENT_COUNT;
    public Circle(System.Drawing.Point center, int radius): base()
    {
        this.center = center;
        this.radius = radius;
        this.vertexs = GenerateVertexs();
    }
    public Circle(int x, int y, int radius): this(new System.Drawing.Point(x, y), radius) {}

    private System.Drawing.Point center = new System.Drawing.Point();
    public System.Drawing.Point Center
    {
        get => this.center;
        set 
        {
            this.center = value;
            this.vertexs = GenerateVertexs();
        }
    }

    private int radius = 0;
    public int Radius
    {
        get => this.radius;
        set 
        {
            this.radius = value;
            this.vertexs = GenerateVertexs();
        }
    }

    private Vertex[] GenerateVertexs()
    {
        var segmentCount = CalculateSegmentCount(this.radius);
        return Enumerable.Range(0, segmentCount).Select(x => new Vertex(){x = (float)Math.Cos(Math.PI * 2 * x / segmentCount) * this.radius + this.Center.X, y = (float)Math.Sin(Math.PI * 2 * x / segmentCount) * this.radius + this.Center.Y}).ToArray();

    }
    
    private static int CalculateSegmentCount(int radius) =>
    (int)(Math.Min(Math.Max(radius - 16, 0), 160) / (160f - 16f) * (MAX_SEGMENT_COUNT - MIN_SEGMENT_COUNT)) + MIN_SEGMENT_COUNT;
    
    private Vertex[] vertexs = new Vertex[0];
    public override Vertex[] Vertexs  => this.vertexs;

}
