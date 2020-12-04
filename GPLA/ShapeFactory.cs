using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    /// <summary>
    /// Factory class to get required shape
    /// </summary>
    public class ShapeFactory : AbstractFactory
    {
        /// <summary>
        /// Method to get the input given by the user for shape
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public override Shape getShape(String shapeType)
        {
            if (shapeType.Equals("Triangle"))
            {
                return new Polygon();
            }

            if (shapeType.Equals("Circle"))
            {
                return new Circle();

            }
            else if (shapeType.Equals("Rectangle"))
            {
                return new Rectangle();
            }            
            return null;
        }
    }
}
