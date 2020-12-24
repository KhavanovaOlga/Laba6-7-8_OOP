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
using System.IO;

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
        string pathToTheFileOfShapes = @"";
        string pathToTheFileOfFormsParams = @"";

        public Form1()
        {
            InitializeComponent();
            brush = new SolidBrush(Color.White); //по умолчанию заливка белая
            lastShapeButton = btn_circle;
            deltaX = deltaY = 0;
            isControlPressed = false;
            container = new Container();
            //boarders-задаем активную зону, за которую не может выйти объект
            boarders = new RectangleF(canvas.Location.X - 10, canvas.Location.Y - 10, canvas.Width - 5, canvas.Height - 5);
            bitmap = new Bitmap(canvas.Width, canvas.Height);
            graphics = Graphics.FromImage(bitmap);
            canvas.Image = bitmap;
        }

        public virtual void save(StreamWriter writer)
        {
            writer.WriteLine(this.Width.ToString());
            writer.WriteLine(this.Height.ToString());

            string color = brush.Color.ToString().Substring(7);
            color = color.Remove(color.Length - 1);
            writer.WriteLine(color);
        }

        public virtual void load(StreamReader reader)
        {
            this.Width = int.Parse(reader.ReadLine());
            this.Height = int.Parse(reader.ReadLine());

            switch (reader.ReadLine())
            {
                case "White":
                    {
                        brush = new SolidBrush(Color.White);
                        break;
                    }
                case "Black":
                    {
                        brush = new SolidBrush(Color.Black);
                        break;
                    }
                case "Green":
                    {
                        brush = new SolidBrush(Color.LightGreen);
                        break;
                    }
                case "Yellow":
                    {
                        brush = new SolidBrush(Color.Yellow);
                        break;
                    }
            }
        }

        //Перерисовка элемента управления
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics.Clear(Color.White);
            for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
            {
                it.getNode().key.draw(graphics, brush);
            }
            canvas.Image = bitmap;
        }

        //Снятие выделения объекта
        private void unmarkAll()
        {
            for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
            {
                it.getNode().key.marked = false;
            }
        }


        //Обработчик события MouseClick. Вызывается при щелчке мышью элемента управления Canvas.
        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            //если происходит нажатие левой кнопки мыши
            if (e.Button == MouseButtons.Left)
            {
                ContainerIterator it = container.Last();
                while (it != container.End())
                {
                    Shape current = it.getNode().key;
                    if (current.isPointed(e.X, e.Y))
                    {
                        if (!isControlPressed)
                        {
                            bool tmp = (current.marked == true ? false : true);
                            unmarkAll();
                            current.marked = tmp;
                        }
                        else
                        {
                            current.marked = (current.marked ? false : true);
                        }

                        this.Invalidate();
                        return;
                    }

                    if (it == container.Begin())
                    {
                        break;
                    }
                    --it;
                }
                unmarkAll();
                Shape newShape = null;

                //Выбираем по кнопкам,какой именно объект необходимо отрисовать на Canvas
                switch (lastShapeButton.Text)
                {
                    case "Круг":
                        {
                            newShape = new CCircle(e.X, e.Y, boarders);  //создание круга
                            break;
                        }
                    case "Прямоугольник":
                        {
                            newShape = new СRectangle(e.X, e.Y, boarders); //создание прямоугольника
                            break;
                        }
                    case "Квадрат":
                        {
                            newShape = new CSquare(e.X, e.Y, boarders); //создание квадрата
                            break;
                        }
                    case "Треугольник":
                        {
                            newShape = new CTriangle(e.X, e.Y, boarders); //создание треугольника
                            break;
                        }

                }
                container.push_back(newShape); //добавляем объект в список

                this.Invalidate(); //перерисовываем рабочее пространство
            }
        }

        //Обработчик события KeyDown. Происходит при нажатии клавиши, если элемент управления имеет фокус.
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //нажатие на ctrl
            if (e.Control)
            {
                isControlPressed = true;
            }

            //нажатие на delete
            if (e.KeyCode == Keys.Delete)
            {
                for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
                {
                    if ((it.getNode().key.marked))
                    {
                        container.Remove(it.getNode().key);
                    }
                }
            }
            //нажатие на L-увеличение или K- уменьшение
            if (e.KeyCode == Keys.L || e.KeyCode == Keys.K)
            {
                for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
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

            //нажатие на A-влево или D- вправо или S-вниз или W-вверх
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

                for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
                {
                    if (it.getNode().key.marked == true)
                    {
                        it.getNode().key.offset(deltaX, deltaY);
                    }
                }
            }
            else
            {
                deltaX = deltaY = 0; //иначе зануляем дельту
            }

            this.Invalidate(); //перерисовываем форму
        }

        //Обработчик события keyUp. Происходит, когда отпускается клавиша, если элемент управления имеет фокус.
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //после нажатия клавиши зануляем все счетчики
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
        
        //если нажата одна кнопка, нажатие на другие блокируется
        private void btn_click(object sender, EventArgs e)
        {
            lastShapeButton.Enabled = true;
            (sender as Button).Enabled = false;
            lastShapeButton = (sender as Button);
        }

        //Выбор цвета заливки фигуры при нажатии на соответствующую кнопку на форме
        private void btnColor_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Text)
            {
                case "Черный":
                    {
                        brush = new SolidBrush(Color.Black); //задаем цвет заливки черного цвета
                        break;
                    }
                case "Белый":
                    {
                        brush = new SolidBrush(Color.White); //задаем цвет заливки белого цвета
                        break;
                    }
                case "Зеленый":
                    {
                        brush = new SolidBrush(Color.LightGreen); //задаем цвет заливки зеленого цвета
                        break;
                    }
                case "Желтый":
                    {
                        brush = new SolidBrush(Color.Yellow); //задаем цвет заливки желтого цвета
                        break;
                    }
            }
            this.Invalidate();

        }
        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "make a group")
            {
                CGroup group = new CGroup(100, boarders);
                bool IsThereSomething = false;
                ContainerIterator it = container.Begin();
                while (it != container.End())
                {
                    if (it.getNode().key.marked == true)
                    {
                        IsThereSomething = true;
                        group.addShape(it.getNode().key);
                        container.Remove(it.getNode().key);
                        if (container.Count() != 0)
                        {
                            it = container.Begin();
                        }
                        else
                        {
                            it = container.End();
                        }
                    }
                    else
                    {
                        it++;
                    }
                }

                if (IsThereSomething)
                {
                    container.Push_back(group);
                }
                return;
            }

            if (e.ClickedItem.Text == "split the group")
            {
                Container extractedShapes = new Container();
                for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
                {
                    if (it.getNode().key.marked == true && (it.getNode().key is CGroup))
                    {
                        Container shapes = ((CGroup)it.getNode().key).split();
                        for (ContainerIterator it2 = shapes.Begin(); it2 != shapes.End(); ++it2)
                        {
                            extractedShapes.Push_back(it2.getNode().key);
                        }
                        container.Remove(it.getNode().key);
                    }
                }

                for (ContainerIterator it = extractedShapes.Begin(); it != extractedShapes.End(); ++it)
                {
                    container.Push_back(it.getNode().key);
                }

                return;
            }

            if (e.ClickedItem.Text == "save this state")
            {
                container.saveShapes(pathToTheFileOfShapes);
                using (StreamWriter writer = new StreamWriter(pathToTheFileOfFormsParams, false, System.Text.Encoding.Default))
                {
                    this.save(writer);
                }
                return;
            }

            if (e.ClickedItem.Text == "load a last saved state")
            {
                using (StreamReader reader = new StreamReader(pathToTheFileOfFormsParams, System.Text.Encoding.Default))
                {
                    this.load(reader);
                }

                ShapeFactory factory = new MyShapeFactory();
                container = new Container();
                container.loadShapes(pathToTheFileOfShapes, factory);
                this.Invalidate();
            }

        }

        //обработчик события Resize. Происходит при изменении размеров элемента управления Form1.
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (canvas.Width != 0 && canvas.Height != 0)
            {
                boarders = new RectangleF(canvas.Location.X - 10, canvas.Location.Y - 10, canvas.Width - 5, canvas.Height - 5);
                bitmap = new Bitmap(canvas.Width, canvas.Height);
                graphics = Graphics.FromImage(bitmap);

                for (ContainerIterator it = container.Begin(); it != container.End(); ++it)
                {
                    it.getNode().key.updateBoarders(boarders);
                }
            }
        }
    }
}
