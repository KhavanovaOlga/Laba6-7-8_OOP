using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba6_OOP
{
    public partial class Form1 : Form
    {
        Container container;
        Bitmap bitmap;
        Graphics graphics;
        RectangleF boarders;
        bool isControlPressed;
        int deltaX, deltaY;
        Button lastShapeButton;
        SolidBrush brush;
        public Form1()
        {
            InitializeComponent();
            brush = new SolidBrush(Color.White);
            lastShapeButton = btn_circle;
            deltaX = deltaY = 0;
            isControlPressed = false;
            container = new Container();
            boarders = new RectangleF(canvas.Location.X - 10, canvas.Location.Y - 10, canvas.Width - 5, canvas.Height - 5);
            bitmap = new Bitmap(canvas.Width, canvas.Height);
            graphics = Graphics.FromImage(bitmap);
            canvas.Image = bitmap;
        }

        //Перерисовка элемента управления
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics.Clear(Color.White);
            for (ContainerIterator it = container.begin(); it != container.end(); ++it)
            {
                it.getNode().key.draw(graphics, boarders, brush);
            }
            canvas.Image = bitmap;
        }

        //Снятие выделения
        private void unmarkAll()
        {
            for (ContainerIterator it = container.begin(); it != container.end(); ++it)
            {
                it.getNode().key.marked = false;
            }
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ContainerIterator it = container.last();
                while (it != container.end())
                {
                    Shape current = it.getNode().key;
                    if (current.isPointed(e.X, e.Y))
                    {
                        if (!isControlPressed)
                        {
                            unmarkAll();
                        }
                        current.marked = (current.marked ? false : true);
                        this.Invalidate();
                        return;
                    }

                    if (it == container.begin())
                    {
                        break;
                    }
                    --it;
                }
                unmarkAll();
                Shape newShape = null;

                switch (lastShapeButton.Text)
                {
                    case "Круг":
                        {
                            newShape = new CCircle(e.X, e.Y);
                            break;
                        }
                    case "Прямоугольник":
                        {
                            newShape = new СRectangle(e.X, e.Y);
                            break;
                        }
                    case "Квадрат":
                        {
                            newShape = new CSquare(e.X, e.Y);
                            break;
                        }
                    case "Треугольник":
                        {
                            newShape = new CTriangle(e.X, e.Y);
                            break;
                        }

                }
                container.push_back(newShape);

                this.Invalidate();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                isControlPressed = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                for (ContainerIterator it = container.begin(); it != container.end(); ++it)
                {
                    if ((it.getNode().key.marked))
                    {
                        container.remove(it.getNode().key);
                    }
                }
            }

            if (e.KeyCode == Keys.L || e.KeyCode == Keys.K)
            {
                for (ContainerIterator it = container.begin(); it != container.end(); ++it)
                {
                    if (it.getNode().key.marked == true)
                    {
                        if (e.KeyCode == Keys.L)
                        {
                            it.getNode().key.scale(1);
                        }
                        else
                        {
                            it.getNode().key.scale(-1);
                        }

                    }
                }
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.D || e.KeyCode == Keys.S || e.KeyCode == Keys.W)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        deltaX = -10;
                        break;
                    case Keys.D:
                        deltaX = 10;
                        break;
                    case Keys.W:
                        deltaY = -10;
                        break;
                    case Keys.S:
                        deltaY = 10;
                        break;
                }

                for (ContainerIterator it = container.begin(); it != container.end(); ++it)
                {
                    if (it.getNode().key.marked == true)
                    {
                        it.getNode().key.offset(deltaX, deltaY);
                    }
                }
            }
            else
            {
                deltaX = deltaY = 0;
            }

            this.Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    deltaX = 0;
                    break;
                case Keys.D:
                    deltaX = 0;
                    break;
                case Keys.W:
                    deltaY = 0;
                    break;
                case Keys.S:
                    deltaY = 0;
                    break;
                case Keys.ControlKey:
                    {
                        isControlPressed = false;
                        break;
                    }
            }
        }
        private void btn_click(object sender, EventArgs e)
        {
            lastShapeButton.Enabled = true;
            (sender as Button).Enabled = false;
            lastShapeButton = (sender as Button);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Text)
            {
                case "Черный":
                    {
                        brush = new SolidBrush(Color.Black);
                        break;
                    }
                case "Белый":
                    {
                        brush = new SolidBrush(Color.White);
                        break;
                    }
                case "Зеленый":
                    {
                        brush = new SolidBrush(Color.Green);
                        break;
                    }
                case "Желтый":
                    {
                        brush = new SolidBrush(Color.Yellow);
                        break;
                    }
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            boarders = new RectangleF(canvas.Location.X - 10, canvas.Location.Y - 10, canvas.Width - 5, canvas.Height - 5);
            bitmap = new Bitmap(canvas.Width, canvas.Height);
            graphics = Graphics.FromImage(bitmap);
        }
    }
}
