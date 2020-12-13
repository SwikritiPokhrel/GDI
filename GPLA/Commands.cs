﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;

namespace GPLA
{
    class Commands
    {

        Validation check_cmd = new Validation();

        //IDictionary<ArrayList, int> loops = new Dictionary<ArrayList, int>();

        static IDictionary<string, ArrayList> methods = new Dictionary<string, ArrayList>();

        static IDictionary<string, int> variable = new Dictionary<string, int>();

        static string operators = "";

        ArrayList method_parameter_variables = new ArrayList();

        public Commands()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, ArrayList> getMethodSignature()
        {
            return methods;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Draw"></param>
        /// <param name="lines"></param>
        /// <param name="line_found_in"></param>
        /// <param name="fm"></param>
        public void run_if_command(string Draw, string[] lines, int line_found_in, frmGDI fm)
        {
            operators = check.getOperator();
            string condition = Draw.Split('(', ')')[1].Trim();
            string[] splitCondition = condition.Split(new string[] {
                    operators
                  },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (splitCondition.Length == 2)
                {
                    string conditionKey = splitCondition[0].Trim();
                    int conditionValue = int.Parse(splitCondition[1].Trim());
                    foreach (KeyValuePair<string, int> kvp in variable)
                    {
                        if (conditionKey == kvp.Key)
                        {
                            int variableValue = kvp.Value;

                            bool conditionStatus = false;

                            int value1 = variableValue; 
                            int value2 = conditionValue; 

                            if (operators == "<=")
                            {
                                if (value1 <= value2) conditionStatus = true;
                            }
                            else if (operators == ">=")
                            {
                                if (value1 >= value2) conditionStatus = true;
                            }
                            else if (operators == "==")
                            {
                                if (value1 == value2) conditionStatus = true;
                            }
                            else if (operators == ">")
                            {
                                if (value1 > value2) conditionStatus = true;
                            }
                            else if (operators == "<")
                            {
                                if (value1 < value2) conditionStatus = true;
                            }
                            else if (operators == "!=")
                            {
                                if (value1 != value2) conditionStatus = true;
                            }
                            
                            if (conditionStatus)
                            {
                                if (lines[line_found_in].Equals("then"))
                                {                                    
                                   
                                        if (check_cmd.checkprogram_command(lines[line_found_in + 1]))
                                        {
                                            fm.draw_basic(lines[line_found_in + 1]);
                                        }
                                   
                                }
                                else
                                {
                                    for (int i = (line_found_in); i < lines.Length; i++)
                                    {
                                        if (!(lines[i].Equals("endif")))
                                        {

                                            if (lines[i].Contains("=")){
                                                runVariableOperation(lines[i]);
                                            }
                                            else
                                            {
                                                if (check_cmd.checkprogram_command(lines[i]))
                                                {
                                                    fm.draw_basic(lines[i]);
                                                }
                                            }

                                        }
                                        else
                                        {
                                            break;
                                        }

                                    }
                                }

                            }
                        }
                        else
                        {
                            throw new VariableNotFoundException("Variable: " + conditionKey + " does not exist");
                        }
                    }
                }
                else
                {
                    throw new InvalidParameterException("Syntax error in if condition.");
                }
            }
            catch (InvalidParameterException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (VariableNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Draw"></param>
        /// <param name="lines"></param>
        /// <param name="loop_found_in_line"></param>
        /// <param name="fm"></param>
        public void run_loop_command(string Draw, string[] lines, int loop_found_in_line, frmGDI fm)
        {
            string[] store_command = Draw.Split(new string[] { "for" }, StringSplitOptions.RemoveEmptyEntries);
            string variable_name = store_command[1].Trim();
            int loop_count = 0;
            if (variable.ContainsKey(variable_name))
            {
                variable.TryGetValue(variable_name, out loop_count);

                for (int loop = 0; loop < loop_count; loop++)
                {
                    for (int i = (loop_found_in_line); i < lines.Length; i++)
                    {
                        if (!(lines[i].Equals("endloop")))
                        {

                            if (lines[i].Contains("=")){
                                runVariableOperation(lines[i]);
                            }
                            else
                            {
                                if (check_cmd.checkprogram_command(lines[i]))
                                {
                                    fm.draw_basic(lines[i]);
                                }
                            }

                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Draw"></param>
        /// <param name="lines"></param>
        /// <param name="loop_found_in_line"></param>
        /// <param name="fm"></param>
        public void run_method_command(string Draw, string[] lines, int loop_found_in_line)
        {
            //method             
            string[] command_parts = Draw.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string method_name = command_parts[1].Trim();
            method_name = Regex.Replace(method_name, @"\s+", "");
            int parameter_count = 0;
            string parameter_inside_method = command_parts[2].Trim().Split('(', ')')[1];
            ArrayList commands_inside_method = new ArrayList();
            for (int i = loop_found_in_line; i < lines.Length; i++)
            {
                if (!lines.Equals("endmethod"))
                {
                    commands_inside_method.Add(lines[i]);
                }
                else
                {
                    break;
                }
            }
            if (parameter_inside_method.Contains(','))
            {
                parameter_count = parameter_inside_method.Split(',').Length;
                foreach (string variable_name in parameter_inside_method.Split(','))
                {
                    method_parameter_variables.Add(variable_name);
                }
            }
            else
            {
                parameter_count = 1;
                if (parameter_count > 0)
                {
                    method_parameter_variables.Add(parameter_inside_method);
                }
            }
            string signature = method_name + "," + parameter_count;
            if (!methods.ContainsKey(signature))
            {
                methods.Add(signature, commands_inside_method);
            }
            else
            {
                MessageBox.Show("Method already exist");
            }


        }



        public void run_method_call(String Draw, frmGDI fm)
        {
            string methodname = Draw.Split('(')[0];
            methodname = Regex.Replace(methodname, @"\s+", "");
            string parameter_inside_method = Draw.Trim().Split('(', ')')[1];
            int parameter_count = 0;
            if (parameter_inside_method.Contains(','))
            {
                parameter_count = parameter_inside_method.Split(',').Length;
                for (int i = 0; i < parameter_count; i++)
                {
                    if (!variable.ContainsKey((string)method_parameter_variables[i]))
                    {
                        variable.Add((string)method_parameter_variables[i], int.Parse(parameter_inside_method.Split(',')[i]));
                    }
                    else
                    {
                        variable[(string)method_parameter_variables[i]] = int.Parse(parameter_inside_method.Split(',')[i]);
                    }
                }
            }
            else
            {
                parameter_count = 1;
                if (parameter_count > 0)
                {
                    if (!variable.ContainsKey((string)method_parameter_variables[0]))
                    {
                        variable.Add((string)method_parameter_variables[0], int.Parse(parameter_inside_method));
                    }
                    else
                    {
                        variable[(string)method_parameter_variables[0]] = int.Parse(parameter_inside_method);
                    }
                }
            }
            string signature = methodname.Trim() + "," + parameter_count;

            ArrayList commands = new ArrayList();

            methods.TryGetValue(signature, out commands);
            foreach (string cmd in commands)
            {
                if (cmd.Contains("="))
                {
                    runVariableOperation(cmd);
                }
                else
                {
                    if (check_cmd.checkprogram_command(cmd))
                    {
                        fm.draw_basic(cmd);
                    }
                }

            }
        }


        ///
        public static IDictionary<string, int> getVariables()
        {
            return variable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Draw"></param>
        public void run_variable_command(string Draw)
        {
            string variable_name = Draw.Split('=')[0].Trim();
            int variable_value = int.Parse(Draw.Split('=')[1].Trim());
            if (!variable.ContainsKey(variable_name))
            {
                variable.Add(variable_name, variable_value);
            }
            else
            {
                variable[variable_name] = variable_value;
            }
        }


        public bool runVariableOperation(string line)
        {

            try
            {
                //splits by + = or -
                line = Regex.Replace(line, @"\s+", "");
                string[] variables = line.Split(new Char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
                int number_of_operator = 0;
                if (variables.Length != 2)
                {
                    return false;
                }

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].Equals('+') || line[i].Equals('-') || line[i].Equals('*') || line[i].Equals('/'))
                    {
                        number_of_operator++;
                    }
                }
                if (number_of_operator > 1)
                {
                    return false;
                }
                string vrKey = variables[0].Trim();
                string vrValue = variables[1].Trim();
                int vrValuenum = Int32.Parse(vrValue);
                int dictValue = 0;

                if (variable.ContainsKey(vrKey))
                {
                    variable.TryGetValue(vrKey, out dictValue);
                    if (line.Contains("+"))
                    {
                        variable[vrKey] = dictValue + vrValuenum;
                    }
                    else if (line.Contains("-"))
                    {
                        variable[vrKey] = dictValue - vrValuenum;
                    }
                    else if (line.Contains("*"))
                    {
                        variable[vrKey] = dictValue * vrValuenum;
                    }
                    else if (line.Contains("/"))
                    {
                        variable[vrKey] = dictValue / vrValuenum;
                    }
                }
                else
                {
                    throw new VariableNotFoundException("Variable: " + vrKey + "doesnot exist");
                }
                return true;
            }
            catch (VariableNotFoundException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }


    }
}
