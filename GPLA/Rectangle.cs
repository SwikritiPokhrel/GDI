using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    class Rectangle : Shape
    {
        //declaration of variables
        int height, width;
        Color c;
        bool fill;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public Rectangle(int x, int y, int height, int width) : base(x, y)
        {
            this.height = height;
            this.width = width;
        }


        /// <summary>
        /// another parameterized constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Rectangle(int x, int y) : base(x, y)
        {

        }


        /// <summary>
        /// default constructor
        /// </summary>
        public Rectangle()
        {
        }

        public void setColor(Color c)
        {
            this.c = c;
        }

        public void setFill(bool f)
        {
            fill = f;
        }
        /// <summary>
        /// draw method
        /// </summary>
        /// <param name="g">graphics</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(c, 3);
            SolidBrush sb = new SolidBrush(c);
            if (fill)
            {
                g.FillRectangle(sb, x, y, height, width);
            }
            else
            {
                g.DrawRectangle(p, x, y, height, width);
            }
            

        }


        /// <summary>
        /// height setter
        /// </summary>
        /// <param name="height"></param>
        public void setHeight(int height)
        {
            this.height = height;
        }


        /// <summary>
        /// height getter
        /// </summary>
        /// <returns></returns>
        public int getHeight()
        {
            return this.height;
        }

        /// <summary>
        /// width setter
        /// </summary>
        /// <param name="width"></param>
        public void setWidth(int width)
        {
            this.width = width;
        }


        /// <summary>
        /// width getter
        /// </summary>
        /// <returns></returns>
        public int getWidth()
        {
            return this.width;
        }

    }
}
