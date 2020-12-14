using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    class User_defined_exception
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class InvalidVariableNameException : Exception
    {
      
        public InvalidVariableNameException(string message) : base(message)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class InvalidCommandException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public InvalidCommandException(string message) : base(message)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class InvalidParameterException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public InvalidParameterException(string message) : base(message)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VariableNotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public VariableNotFoundException(string message) : base(message)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class InvalidMethodNameException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public InvalidMethodNameException(string message) : base(message)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MethodNotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public MethodNotFoundException(string message) : base(message)
        {

        }
    }

}
