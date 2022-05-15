using System.Linq;

namespace Graphic.Drawing
{
    public class Rectangle : Shape
    {
        public Rectangle(float x, float y, float w, float h): base()
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.vertexs = GenerateVertexs();
        }

        private float x = 0;
        public float X
        {
            get => this.x;
            set 
            {
                this.x = value;
                this.vertexs = GenerateVertexs();
            }
        }

        private float y = 0;
        public float Y
        {
            get => this.y;
            set 
            {
                this.y = value;
                this.vertexs = GenerateVertexs();
            }
        }

        private float w = 0;
        public float W
        {
            get => this.w;
            set 
            {
                this.w = value;
                this.vertexs = GenerateVertexs();
            }
        }

        
        private float h = 0;
        public float H
        {
            get => this.h;
            set 
            {
                this.h = value;
                this.vertexs = GenerateVertexs();
            }
        }

        private Vertex[] GenerateVertexs()
        {
            return new [] {
                new Vertex() { x = X, y = Y},
                new Vertex() { x = X, y = Y + H},
                new Vertex() { x = X + W, y = Y + H},
                new Vertex() { x = X + W, y = Y},
            };
        }

        
        private Vertex[] vertexs = new Vertex[0];
        public override Vertex[] Vertexs  => this.vertexs;

    }
}