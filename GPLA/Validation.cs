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

        public  bool check_command(string cmd)
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

        public  bool checkprogram_command(string cmd)
        {
            String code_line = cmd;
            char[] code_delimiters = new char[] { ' ' };
            string[] words = code_line.Split(code_delimiters, StringSplitOptions.RemoveEmptyEntries); //holds invididuals code line
            if (code_line.Contains("circle") || code_line.Contains("rectangle") || code_line.Contains("triangle") || code_line.Contains("pen") || code_line.Contains("moveto") || code_line.Contains("drawto") || code_line.Contains("fill"))
            {

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
            else
            {
               
                if(code_line.Contains("if") && !code_line.Contains("endif"))
                {
                    MessageBox.Show("yaha chu");
                    return chk_cmd.check_if_command(cmd);
                }
                else if(code_line.Contains("loop") && code_line.Contains("for"))
                {
                    return chk_cmd.check_loop(cmd);
                }
                else if (code_line.Contains("method"))
                {
                    return chk_cmd.check_method(cmd);
                }
                else if (code_line.Contains("(") && code_line.Contains(")"))
                {
                    return chk_cmd.check_methodcall(cmd);
                }
                else if(code_line.Contains("+") && code_line.Contains("-") && code_line.Contains("*") && code_line.Contains("/"))
                {
                    return chk_cmd.check_variable_operation(cmd);
                }
                else if (code_line.Contains("="))
                {
                    if (Regex.IsMatch(code_line, @"^[a-zA-Z]+$"))
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
            }

    }
}
