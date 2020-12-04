using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    public class Circle : Shape
    {


        int radius;//declaration of the radius
        bool fill;
        Color c;
        /// <summary>
        /// circle parameterized constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        public Circle(int x, int y, int radius) : base(x, y)
        {
            this.radius = radius;

        }

        /// <summary>
        /// default constructor
        /// </summary>
        public Circle()
        {

        }

        public Circle(int radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// circle parameterized constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Circle(int x, int y) : base(x, y)
        {

        }

        public void setFill(bool fill)
        {
            this.fill = fill;
        }

        public void setColor(Color c)
        {
            this.c = c;
        }


        /// <summary>
        /// draw method
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(c, 3);
            SolidBrush b = new SolidBrush(c);
            if (fill)
            {
                g.FillEllipse(b, x, y, radius, radius);
            }
            else
            {
                g.DrawEllipse(p, x, y, radius, radius);
            }
           
        }


        /// <summary>
        /// radius setter method
        /// </summary>
        /// <param name="radius"></param>
        public void setRadius(int radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// radius getter method
        /// </summary>
        /// <returns></returns>
        public int getRadius()
        {
            return this.radius;
        }
    }
}
