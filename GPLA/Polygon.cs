using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    class Polygon : Shape
    {
        int side1, side2, side3, x_axis, y_axis;
        Color c;
        bool fill;

        public Polygon()
        {

        }
        /// <summary>
        /// declaration in list
        /// </summary>
        /// <param name="c">Colour</param>
        /// <param name="fill">Shape Color Fill</param>
        /// <param name="list">list</param>
        public void set(Color c, bool fill, params int[] list) {
            this.c = c;
            this.fill = fill;
            side1 = list[0];
            side2 = list[1];
            side3 = list[2];
            x_axis = list[3];
            y_axis = list[4];
        }

        /// <summary>
        /// To draw the shape Triangle 
        /// </summary>
        /// <param name="g">graphics</param>      
        public override void draw(Graphics g)
        {
            Pen p = new Pen(c, 3);
            SolidBrush sbs = new SolidBrush(c);
            PointF[] points = new PointF[3];
            points[0].X = x_axis;
            points[0].Y = y_axis;

            points[1].X = x_axis + side1;
            points[1].Y = y_axis;

            points[2].X = x_axis + side3;
            points[2].Y = y_axis + side2;

            if (fill)
            {
                g.FillPolygon(sbs, points);
            }
            else
            {
                g.DrawPolygon(p, points);
            }
            
        }
    }
}
