using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace Laba6_OOP
{
    public class CTriangle : Shape
    {
        int length;
        int minLength;
        PointF[] vertex;

        public CTriangle(int x, int y)
        {
            this.x = x;
            this.y = y;
            minLength = 5;
            length = 40;
            vertex = new PointF[3];
            calc();
            path = new GraphicsPath();
            lastCommand = "Constructor";
        }

        //равносторонний треугольник
        private void calc()
        {
            vertex[0] = new PointF(x - (length / 2), y + (float)((1.73 / 6) * length));
            vertex[1] = new PointF(x, y - (float)((1.73 / 3) * length));
            vertex[2] = new PointF(x + (length / 2), y + (float)((1.73 / 6) * length));
        }

        public override void scale(int delta)
        {
            length += delta;
            if (length < minLength)
            {
                length = minLength;
            }
            lastCommand = "scale";
        }

        protected override void makePath()
        {
            calc();
            path.Reset();
            path.AddPolygon(vertex);
            boundsRec = path.GetBounds();
        }

    }
}
