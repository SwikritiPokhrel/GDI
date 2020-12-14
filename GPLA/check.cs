using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;

namespace GPLA
{
    /// <summary>
    /// Check if given commands are valid
    /// </summary>
    public class check
    {
        //store if statement operator
        static string operator_used = null;

        //store variables
        IDictionary<string,
        int> variable = new Dictionary<string,
        int>();

        //store method signature
        IDictionary<string,
        ArrayList> method_signature = new Dictionary<string,
        ArrayList>();

        //store errors
        ArrayList errors = new ArrayList();


        /// <summary>
        /// Default Constructor
        /// </summary>
        public check()
        {

        }

        /// <summary>
        /// clear error list
        /// </summary>
        public void clear_error_list()
        {
            errors.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool check_variable(string command)
        {
            command = Regex.Replace(command, @"\s+", "");
            string variable_name = command.Split('=')[0];
            string first_char = variable_name.Substring(0, 1);
            try
            {
                if (Regex.IsMatch(first_char, @"^[a-zA-Z]+$"))
                {
                    if (Regex.IsMatch(variable_name, @"^[a-zA-Z0-9]+$"))
                    {
                        int.Parse(command.Split('=')[1]);
                        return true;
                    }
                    else
                    {
                        throw new InvalidVariableNameException("Variable name is invalid");
                    }
                }
                else
                {
                    throw new InvalidVariableNameException("Variable name should start with alphabet");
                }
            }
            catch (InvalidVariableNameException e)
            {
                errors.Add(e.Message);
                return false;
            }
            catch (FormatException)
            {
                errors.Add("Variable value should be in number format.");
                return false;
            }
        }

        /// <summary>
        /// check variable operations validity
        /// </summary>
        /// <param name="cmd">command to be checked</param>
        /// <returns>true if variable exist else false</returns>
        public bool check_variable_operation(string cmd)
        {
            variable = Commands.getVariables();
            cmd = Regex.Replace(cmd, @"\s+", "");
            string[] parameter = cmd.Trim().Split(new Char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (variable.ContainsKey(parameter[0]))
                {
                    return true;
                }
                else
                {
                    throw new InvalidCommandException("Variable not found");
                }
            }
            catch (InvalidCommandException e)
            {
                errors.Add(e.Message);  /// message box
                return false;
            }
        }

        /// <summary>
        /// Check validity of if command
        /// </summary>
        /// <param name="command">command to be checked</param>
        /// <returns>true if command is valid else false</returns>
        public bool check_if_command(string command, frmGDI fm)
        {
            command = Regex.Replace(command, @"\s+", "");
            string[] command_parts = command.Trim().Split(new string[] { "(" }, StringSplitOptions.RemoveEmptyEntries);
            string condition;
            try
            {
                if (command_parts[0].Equals("if"))
                {
                    if (command_parts.Length == 2)
                    {
                        condition = command.Split('(', ')')[1].Trim();
                        //check for operator
                        if (condition.Contains("<=") && !condition.Contains(">"))
                        {
                            operator_used = "<=";
                            return true;
                        }
                        else if (condition.Contains(">=") && !condition.Contains("<"))
                        {
                            operator_used = ">=";
                            return true;
                        }
                        else if (condition.Contains("!="))
                        {
                            operator_used = "!=";
                            return true;
                        }
                        else if (condition.Contains("==") && !condition.Contains(">") && !condition.Contains("<"))
                        {
                            operator_used = "==";
                            return true;
                        }
                        else if (!condition.Contains("==") && condition.Contains(">") && !condition.Contains("<"))
                        {
                            operator_used = ">";
                            return true;

                        }
                        else if (!condition.Contains("==") && !condition.Contains(">") && condition.Contains("<"))
                        {
                            operator_used = "<";
                            return true;
                        }
                        else
                        {
                            throw new InvalidParameterException("Invalid Operator Used.");
                        }
                    }
                    else
                    {
                        throw new InvalidCommandException("Invalid If Command Syntax");
                    }

                }
                else
                {
                    throw new InvalidCommandException("Invalid Command Name.");
                }
            }
            catch (InvalidCommandException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (InvalidParameterException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        /// <summary>
        /// get if condition operator
        /// </summary>
        /// <returns>operator used in if command</returns>
        public static string getOperator()
        {
            return operator_used;
        }

        /// <summary>
        /// check loop command validity
        /// </summary>
        /// <param name="command">command to be checked</param>
        /// <returns>true if command is valid else false</returns>
        public bool check_loop(string command)
        {
            variable = Commands.getVariables();
            command = Regex.Replace(command, @"\s+", "");
            string[] check_cmd = command.Split(new string[] {
        "for"
      },

            StringSplitOptions.RemoveEmptyEntries);
            string[] loopCondition = { };
            try
            {
                if (!check_cmd[0].Equals("loop"))
                {
                    throw new InvalidCommandException("Invalid Command Name");
                }

                if (check_cmd.Length != 2)
                {
                    throw new InvalidCommandException("Invalid Loop Command Syntax");
                }

                loopCondition = check_cmd[1].Split(new string[] { "<=", ">=", "<", ">" }, StringSplitOptions.RemoveEmptyEntries);
                if (loopCondition.Length == 1)
                {
                    throw new InvalidParameterException("Invalid loop statement. Operator should be <= or => or < or >");
                }

                if (!Regex.IsMatch(check_cmd[1], @"^[0-9]+$"))
                {
                    string variable_name = loopCondition[0].ToLower().Trim();
                    if (!variable.ContainsKey(variable_name))
                    {
                        throw new VariableNotFoundException("Variable: " + variable_name + " not found.");
                    }
                }
            }
            catch (InvalidCommandException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (VariableNotFoundException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (InvalidParameterException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// check validity of method command
        /// </summary>
        /// <param name="command">command to be checked</param>
        /// <returns>true if command is valid else false</returns>
        public bool check_method(string command)
        {
            string[] command_parts = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string parameter_inside_method = "";
            try
            {
                if (command_parts[0].Equals("method"))
                {
                    if (command_parts.Length == 3)
                    {
                        if (Regex.IsMatch(command_parts[1], @"^[a-zA-Z0-9]+$"))
                        {
                            string first_char = command_parts[1].Substring(0, 1);

                            if (Regex.IsMatch(first_char, @"^[a-zA-Z]+$"))
                            {
                                string check_param = command_parts[2];
                                if (!check_param[0].Equals('(') || !check_param[check_param.Length - 1].Equals(')'))
                                {
                                    throw new InvalidMethodNameException("Invalid Method Command Syntax");
                                }
                                else
                                {
                                    parameter_inside_method = command_parts[2].Trim().Split('(', ')')[1];
                                    if (parameter_inside_method.Length > 0)
                                    {
                                        //check for alphanumeric or , inside ()
                                        for (int i = 1; i < check_param.Length - 1; i++)
                                        {
                                            if (!(Char.IsLetter(check_param[i]) || check_param[i].Equals(',')))
                                            {
                                                throw new InvalidParameterException("Invalid parameters");
                                            }
                                        }

                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                            }
                            else
                            {
                                throw new InvalidMethodNameException("Method name cannot start with number");
                            }
                        }
                        else
                        {
                            throw new InvalidMethodNameException("Method name cannot contain special characters");
                        }

                    }
                    else
                    {
                        throw new InvalidCommandException("Invalid Method Command Syntax");
                    }
                }
                else
                {
                    throw new InvalidCommandException("Invalid method Command Name");
                }
            }
            catch (InvalidCommandException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (InvalidMethodNameException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (InvalidParameterException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool check_methodcall(string command)
        {
            method_signature = Commands.getMethodSignature();
            string methodname = command.Split('(')[0];
            methodname = Regex.Replace(methodname, @"\s+", "");
            string parameter_inside_method = command.Trim().Split('(', ')')[1];
            int parameter_count = 0;
            if (parameter_inside_method.Contains(','))
            {
                parameter_count = parameter_inside_method.Split(',').Length;
            }
            else
            {
                if (parameter_inside_method.Length > 0)
                {
                    parameter_count = 1;
                }
                else
                {
                    parameter_count = 0;
                }

            }

            string signature = methodname + "," + parameter_count;
            //check for method signature;
            try
            {
                if (method_signature.ContainsKey(signature))
                {
                    return true;
                }
                else
                {
                    throw new MethodNotFoundException("method not found");
                }

            }
            catch (MethodNotFoundException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
