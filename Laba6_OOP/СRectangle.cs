using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace Laba6_OOP
{
    public class СRectangle: Shape
    {
        protected int height;

        public СRectangle(int x, int y)
        {
            height = 40;
            this.x = x;
            this.y = y;
            path = new GraphicsPath();
            lastCommand = "Constructor";
        }

        public override void scale(int delta)
        {
            height += delta;
            lastCommand = "scale";
        }

        protected override void makePath()
        {
            path.Reset();
            path.AddRectangle(new RectangleF((x - ((height * 2) / 2)), (y - (height / 2)), height * 2, height));
            boundsRec = path.GetBounds();
        }

    }
}
