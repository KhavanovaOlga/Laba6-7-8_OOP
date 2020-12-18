using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace Laba6_OOP
{
    class CCircle : Shape
    {
        public int radius;
        public int minRadius;


        public CCircle(int x, int y)
        {
            minRadius = 1;
            radius = 20;
            this.x = x;
            this.y = y;
            path = new GraphicsPath();
            lastCommand = "Constructor";
        }

        public override void scale(int delta)
        {
            radius += delta;
            if (radius < minRadius)
            {
                radius = minRadius;
            }

            lastCommand = "scale";
        }

        protected override void makePath()
        {
            path.Reset();
            path.AddEllipse(x - radius, y - radius, radius * 2, radius * 2);
            boundsRec = path.GetBounds();
        }
    }
}
