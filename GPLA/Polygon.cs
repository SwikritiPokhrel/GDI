﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA
{
    class Polygon : Shape
    {
        int[] points;
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
        public void set(Color c, bool fill, params int[] list)
        {
            this.c = c;
            this.fill = fill;
            points = list;

        }

        /// <summary>
        /// To draw the shape Triangle 
        /// </summary>
        /// <param name="g">graphics</param>      
        public override void draw(Graphics g)
        {
            Pen p = new Pen(c, 3);
            SolidBrush sbs = new SolidBrush(c);
            PointF[] new_point = new PointF[50];
            int point_position = 0;

            for (int i = 0; i < points.Length - 1; i += 2)
            {
                new_point[point_position] = new Point(points[i], points[i + 1]);
                point_position++;
            }
            if (fill)
            {
                g.FillPolygon(sbs, new_point);
            }
            else
            {
                g.DrawPolygon(p, new_point);
            }

        }
    }
}
