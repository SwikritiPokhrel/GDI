﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    class Line : Shape
    {
        int x1, y1, x2, y2;
        Color c;
        /// <summary>
        /// Initialization of axes along with with the sides
        /// </summary>
        /// <param name="x1"> x-axis</param>
        /// <param name="x2"> side1</param>
        /// <param name="y1"> y-axis</param>
        /// <param name="y2"> side2</param>
        public Line(int x1, int x2, int y1, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        public Line(int x1, int y1)
        {
            this.x1 = x1;
            this.y1 = y1;
        }

        public Line()
        {
        }


        public void setX1(int x1)
        {
            this.x1 = x1;
        }

        public int getX1()
        {
            return x1;
        }

        public void setX2(int x2)
        {
            this.x2 = x2;
        }

        public int getX2()
        {
            return x2;
        }

        public void setY1(int y1)
        {
            this.y1 = y1;
        }

        public int getY1()
        {
            return y1;
        }

        public void setY2(int y2)
        {
            this.y2 = y2;
        }

        public int getY2()
        {

            return y2;
        }

        public void setColor(Color c)
        {
            this.c = c;
        }

        /// <summary>
        /// To draw the shape inside the panel
        /// </summary>
        /// <param name="g">Graphics</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(c, 3);
            g.DrawLine(p, x1, y1, x2, y2);
        }
    }
}
