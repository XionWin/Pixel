using System.Runtime.InteropServices;

namespace Graphic.Drawing;
[StructLayout(LayoutKind.Sequential)]
public struct Vertex
{
    public float x { get; set; }
    public float y { get; set; }
}
