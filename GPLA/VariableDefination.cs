using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GPLA
{
    class VariableDefination
    {
        /// <summary>
        /// method to check if variable is alphabetical or not
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool isAlphabeticalVariable(String word)
        {
            if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }

    }
}

