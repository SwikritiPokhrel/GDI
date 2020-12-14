using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GPLA
{
    public class Validation
    {
        check chk_cmd = new check();

        public bool check_command(string cmd)
        {
            string valid_cmd = cmd;
            if (valid_cmd.Equals("run") || valid_cmd.Equals("reset") || valid_cmd.Equals("clear"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool checkprogram_command(string cmd, frmGDI fm)
        {
            if (cmd.Contains("if") && !cmd.Equals("endif"))
            {
                return chk_cmd.check_if_command(cmd, fm);
            }
            else if (cmd.Contains("circle") || cmd.Contains("rectangle") || cmd.Contains("polygon") || cmd.Contains("triangle") || cmd.Contains("pen") || cmd.Contains("moveto") || cmd.Contains("drawto") || cmd.Contains("fill"))
            {

                string[] words = cmd.Split(' ');
                if (words[0] == "circle")
                {
                    if ((words.Length == 2))
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                //

                if (words[0] == "rectangle")
                {
                    if ((words.Length == 3))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }


                if (words[0] == "triangle")
                {
                    if ((words.Length == 4))
                    {
                        return true;
                    }
                    else
                    {
                        
                        return false;
                    }

                }

                //polygon 10 20 30 40
                if (words[0] == "polygon")
                {
                    if (words.Length > 4 && ((words.Length - 1) % 2 == 0))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                if (words[0] == "moveto")
                {
                    if ((words.Length == 3))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                if (words[0] == "pen")
                {
                    if ((words.Length == 2))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                if (words[0] == "fill")
                {
                    if ((words.Length == 2))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                //
                if (words[0] == "drawto")
                {
                    if ((words.Length == 3))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            else if (cmd.Contains("loop") && cmd.Contains("for"))
            {
                return chk_cmd.check_loop(cmd);
            }
            else if (cmd.Contains("method"))
            {
                return chk_cmd.check_method(cmd);
            }
            else if (cmd.Contains("(") && cmd.Contains(")"))
            {
                return chk_cmd.check_methodcall(cmd);
            }
            else if (cmd.Contains("+") && cmd.Contains("-") && cmd.Contains("*") && cmd.Contains("/"))
            {
                return chk_cmd.check_variable_operation(cmd);
            }
            else if (cmd.Contains("="))
            {
                if (cmd.Split('=').Length == 2)
                {
                    return chk_cmd.check_variable(cmd);
                }
            }
            return false;
        }

    }
}
