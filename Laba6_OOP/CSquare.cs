using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace Laba6_OOP
{
    public class CSquare : СRectangle
    {
        public CSquare(int x, int y) : base(x, y)
        {

        }

        protected override void makePath()
        {
            path.Reset();
            path.AddRectangle(new RectangleF((x - ((height * 2) / 2)), (y - (height / 2)), height, height));
            boundsRec = path.GetBounds();
        }
    }
}
