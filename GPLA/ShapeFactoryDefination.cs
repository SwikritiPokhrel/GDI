using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    /// <summary>
    /// simple shape factory definition class
    /// </summary>
    public class ShapeFactoryDefination
    {
        /// <summary>
        /// method to check if shape is circle
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public bool isCircle(string shape)
        {
            if (shape == "circle")
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// method to check if shape is rectangle
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public bool isRectangle(string shape)
        {
            if (shape == "rectangle")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// method to check if shape is triangle
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public bool isTriangle(string shape)
        {
            if (shape == "triangle")
            {
                return true;
            }
            return false;
        }
    }

}
