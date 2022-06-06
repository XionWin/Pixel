using System.Linq;
using System.Runtime.InteropServices;

namespace Graphic.Drawing;
public abstract class Shape
{
    public Shape()
    {
        this.Vbo = OpenGL.ES.GenBuffers(1).First();
    }
    
    public uint Vbo { get; }

    public abstract Vertex[] Vertexs { get; }

    private short[] indices = new short[0];

    private short[] Indices {
        get
        {
            if(this.Vertexs.Length != indices.Length)
            {
                this.indices = Enumerable.Range(0, this.Vertexs.Length).Select(x => (short)x).ToArray();
            }
            return this.indices;
        }
    }

    public void Render(Action vertexParsingFunc)
    {
        unsafe
        {
            fixed (Vertex* ptrVertex = this.Vertexs)
            fixed (short* ptrIndices = this.Indices)
            {
                OpenGL.ES.glBindBuffer(OpenGL.Def.BufferTarget.ArrayBuffer, this.Vbo);
                OpenGL.ES.glBufferData(OpenGL.Def.BufferTarget.ArrayBuffer, (int)(Marshal.SizeOf(typeof(Vertex)) * this.Vertexs.Length), (nint)ptrVertex, OpenGL.Def.BufferUsageHint.DynamicDraw);

                vertexParsingFunc();

                OpenGL.ES.glDrawElements(OpenGL.Def.BeginMode.TriangleFan, (uint)this.Vertexs.Length, OpenGL.Def.DrawElementsType.UnsignedShort, (nint)ptrIndices);
            }
        }
    }
}
