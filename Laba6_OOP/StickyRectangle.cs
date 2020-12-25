using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.IO;

namespace Laba6_OOP
{

    public class StickyRectangle : CRectangle
    {
        public int deltaX = 0, deltaY = 0;
        protected bool stickyFlag = false;

        public StickyRectangle() : base()
        {
            code = 'L';
            path = new GraphicsPath();
        }

        public StickyRectangle(int x, int y, RectangleF boarders) : base(x, y, boarders)
        {
            code = 'L';
        }

        public override void onSubjectChanged(ISubject subject)
        {
            if (subject is Container)
            {
                Container shapes = (subject as Container);
                for (ContainerIterator it = shapes.Begin(); it != shapes.End(); ++it)
                {
                    if (it.getNode().key.intersectWith(path) && !observers.Contains(it.getNode().key) && it.getNode().key != this)
                    {
                        addObserver(it.getNode().key);
                    }
                    else
                    {
                        if (!it.getNode().key.intersectWith(path) && observers.Contains(it.getNode().key))
                        {
                            observers.Remove(it.getNode().key);
                        }
                    }
                }
                return;
            }

            if (subject is StickyRectangle)
            {
                stickyFlag = true;
                offset((subject as StickyRectangle).deltaX, (subject as StickyRectangle).deltaY);
                stickyFlag = false;
            }
        }

        public override void offset(int deltaX, int deltaY)
        {
            int _x = x;
            int _y = y;
            x += deltaX;
            y += deltaY;
            lastCommand = "offset";
            relocate();
            this.deltaX = x - _x;
            this.deltaY = y - _y;
            if (!groupFlag && !stickyFlag)
            {
                notifyEveryone();
            }
            this.deltaX = this.deltaY = 0;
        }


        public override void fillPath()
        {
            path.Reset();
            path.AddRectangle(new RectangleF((x - ((genLength * 2) / 2)), (y - (genLength / 2)), genLength * 2, genLength));
        }

        ~StickyRectangle()
        {

        }
    }
}
