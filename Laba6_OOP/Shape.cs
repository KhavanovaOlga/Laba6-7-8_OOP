using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6_OOP
{
    public abstract class Shape
    {
        public bool marked = true;
        protected string lastCommand;
        protected RectangleF boundsRec;
        protected RectangleF boarders;
        protected GraphicsPath path;
        protected int x;
        protected int y;

        protected SolidBrush brush;

        //Проверка на попадание точки в фигуру методом IsVisible
        public bool isPointed(int x, int y)
        {
            if (path.IsVisible(x, y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Отрисовка фигуры и ее заполнение
        public void draw(Graphics graphics, RectangleF boarders, SolidBrush brush)
        {
            setPath(boarders);
            Pen pen;
            if (marked == true)
            {
                pen = new Pen(Color.Red);
                this.brush = brush;
            }
            else
            {
                pen = new Pen(Color.Black);
            }
            pen.Width = 2;
            graphics.DrawPath(pen, path);
            graphics.FillPath(this.brush, path);

        }
        //Изменение масштаба фигуры на значение delta+-
        public abstract void scale(int delta);
        public void offset(int deltaX, int deltaY)
        {
            x += deltaX;
            y += deltaY;
            lastCommand = "offset";
        }
        protected abstract void makePath();
        protected void setPath(RectangleF boarders)
        {
            makePath();

            while (!boarders.Contains(path.GetBounds()))
            {
                relocate(boarders);
                makePath();
            }
        }

        //Перемещение фигуры вправо, влево, вперед, назад
        protected void relocate(RectangleF boarders)
        {
            PointF left = boundsRec.Location;
            PointF right = new PointF(boundsRec.Right, boundsRec.Y);
            PointF bLeft = new PointF(boundsRec.X, boundsRec.Bottom);
            PointF bRight = new PointF(boundsRec.Right, boundsRec.Bottom);

            if (lastCommand == "Constructor" || lastCommand == "offset")
            {
                if (!boarders.Contains(left) && !boarders.Contains(bLeft))
                {
                    x += 1;
                }

                if (!boarders.Contains(left) && !boarders.Contains(right))
                {
                    y += 1;
                }

                if (!boarders.Contains(right) && !boarders.Contains(bRight))
                {
                    x -= 1;
                }

                if (!boarders.Contains(bLeft) && !boarders.Contains(bRight))
                {
                    y -= 1;
                }
            }
            else
            {
                scale(-1);
            }
        }

    }
}
