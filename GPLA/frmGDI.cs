using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace GPLA
{
    /// <summary>
    /// frmGDI class inherits from the base class Form
    /// </summary>
    public partial class frmGDI : Form
    {
        Commands cmds = new Commands();

        Shape shape1, shape2, shape3; //declaration 
        Validation v = new Validation();
        //list 
        List<Circle> circleObjects;
        List<Rectangle> rectangleObjects;
        List<Line> lineObjects;
        List<Triangle> triangleobjects;
        List<Polygon> polygonObjects;
        List<MoveDirection> moveObjects;


        Circle circle; //declaration 
        Rectangle rectangle;
        Polygon polygon;
        Line line;
        Boolean drawCircle, drawRect, drawPolygon, drawLine, drawTriangle; //boolean to check whether to make objects or not

        static IDictionary<string, int> variable = new Dictionary<string, int>();

        ArrayList comms = new ArrayList() { "moveto", "drawto", "pen", "fill", "circle", "rectangle", "triangle", "polygon" };

        int moveX, moveY; //axis
        int counter = 0;



        /// <summary>
        /// For creating all the shapes given by the user
        /// </summary>
        /// <param name="sender">reference object</param>
        /// <param name="e">event data</param>
        private void FrmGPLA_Load(object sender, EventArgs e)
        {
            circle = new Circle(); //creates new circle
            rectangle = new Rectangle(); //creates new rectangle
            polygon = new Polygon();

            circleObjects = new List<Circle>(); //creates array of new circle objects
            rectangleObjects = new List<Rectangle>(); //creates array of new rectangle objects
            lineObjects = new List<Line>();

            moveObjects = new List<MoveDirection>(); //creates array of new move objects
            polygonObjects = new List<Polygon>();
            triangleobjects = new List<Triangle>();

            c = Color.Black;


        }
        Color c;
        Point point; //defines points 
        string actionCmd;
        string console_text;
        bool fill = false;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public frmGDI()
        {
            InitializeComponent();
            //Shape creation and initialization
            AbstractFactory shapeFactory = FactoryProducer.getFactory("Shape");
            shape1 = shapeFactory.getShape("Circle");
            shape2 = shapeFactory.getShape("Rectangle");
            shape3 = shapeFactory.getShape("Polygon");
        }


        private void pbOutput_Click(object sender, EventArgs e)
        {

        }

        private void txt_ActionCmd_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Save commands into text file
        /// </summary>
        /// <param name="sender">reference object</param>
        /// <param name="e">event data</param>
        private void sAVEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, rtxt_code.Text);
            }
        }

        private void txt_ActionCmd_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void rtxt_code_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void rtxt_code_TextChanged(object sender, EventArgs e)
        {

        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            rtxt_code.Clear();
        }

        private void txt_ActionCmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                e.SuppressKeyPress = true;

                actionCmd = txt_ActionCmd.Text;
                if (v.check_command(actionCmd))
                {

                    switch (actionCmd)
                    {
                        case "run":

                            try
                            {
                                counter = 0;
                                string[] lines = rtxt_code.Text.Trim().ToLower().Split(new string[] { Environment.NewLine },
                                StringSplitOptions.None);
                                bool simple_draw = true;
                                int single_if_break = 0;
                                //loop 
                                foreach (string code_line in lines)
                                {
                                    string hi = code_line;
                                    //single code line                                    
                                    counter++;
                                    if (code_line.StartsWith("endloop") || code_line.StartsWith("endif") || code_line.StartsWith("endmethod"))
                                    {
                                        simple_draw = true;
                                        continue;
                                    }

                                    if (simple_draw)
                                    {
                                        string[] cmd = code_line.Split(' ');
                                        if (comms.Contains(cmd[0]))
                                        {
                                            if (v.checkprogram_command(code_line, this))
                                            {
                                                draw_basic(code_line);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Command: ( "+code_line+ " )is not valid\n" + 
                                                    "To execute the program\n" +
    "draw 'circle 15' or 'triangle 20 20 20'  \n" +
    "or 'rectangle 20 40' or 'polygon 30 30 30 30 30 30 30 30' \n" +
    "'moveto 150 150' for changing the position\n" +
    "'pen red' to change the colour\n" +
    "'fill on' to fill color to the shapes");
                                                 
                                            }

                                        }
                                    }
                                    if (code_line.StartsWith("then"))
                                    {
                                        single_if_break = counter + 1;
                                        continue;
                                    }

                                    if (code_line.StartsWith("if"))
                                    {
                                        simple_draw = false;
                                        if (v.checkprogram_command(code_line, this))
                                        {

                                            cmds.run_if_command(code_line, lines, counter, this);
                                        }
                                    }
                                    else if ((code_line.StartsWith("loop") && code_line.Contains("for")))
                                    {
                                        simple_draw = false;
                                        if (v.checkprogram_command(code_line, this))
                                        {
                                            cmds.run_loop_command(code_line, lines, counter, this);
                                        }

                                    }
                                    else if (code_line.StartsWith("method"))
                                    {
                                        simple_draw = false;
                                        if (v.checkprogram_command(code_line, this))
                                        {
                                            cmds.run_method_command(code_line, lines, counter);
                                        }

                                    }
                                    else if ((code_line.Contains("+") || code_line.Contains("-") || code_line.Contains("*") || code_line.Contains("/")))
                                    {
                                        if (v.checkprogram_command(code_line, this))
                                        {
                                            cmds.runVariableOperation(code_line);
                                        }
                                    }
                                    else if (code_line.Contains("=") && !code_line.Contains("if"))
                                    {
                                        if (v.checkprogram_command(code_line, this))
                                        {
                                            cmds.run_variable_command(code_line);
                                        }
                                    }
                                    else if (code_line.Contains("(") && code_line.Contains(")"))
                                    {
                                        if (v.checkprogram_command(code_line, this))
                                        {
                                            cmds.run_method_call(code_line, this);
                                        }
                                    }

                                    if (single_if_break == counter)
                                    {
                                        simple_draw = true;
                                    }
                                }
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                console_text += "Error: " + ex.Message + "\n\n";
                            }
                            catch (FormatException ex)
                            {
                                console_text += "!!Please input correct parameter!!\n\n";
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                console_text += "!!Please input correct parameter!!\n\n";
                            }
                            panel_output.Refresh(); //refresh with every drawing equals to true
                            break;
                        case "clear":
                            circleObjects.Clear();
                            rectangleObjects.Clear();
                            moveObjects.Clear();
                            polygonObjects.Clear();
                            triangleobjects.Clear();
                            this.drawCircle = false;
                            this.drawRect = false;
                            this.drawPolygon = false;
                            this.drawLine = false;
                            this.drawTriangle = false;
                            panel_output.Refresh();
                            fill = false;
                            break;
                        case "reset":
                            moveX = 0;
                            moveY = 0;
                            break;
                        default:
                            MessageBox.Show("The command box is empty\n" +
                                "Or\n" +
                                "Type 'Run' to Execute the program\n" +
                                "Type 'Clear' to Fresh Start" +
                                "Type 'Reset' to initialize axis");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("put the command 'run' to run the program \n" +
"put the command 'reset' to put on 0,0 axis \n" +
"put the command 'clear' to clear  the panel");

                }


            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code_line"></param>
        public void draw_basic(string code_line)
        {
            variable = Commands.getVariables();
            string[] words = code_line.Trim().Split(' ');
            if (code_line.Contains("circle") || code_line.Contains("rectangle") || code_line.Contains("triangle") || code_line.Contains("pen") || code_line.Contains("moveto") || code_line.Contains("drawto") || code_line.Contains("fill") || code_line.Contains("polygon"))
            {

                if (words[0] == "circle")
                {
                    if (!(words.Length == 2))
                    {
                        MessageBox.Show("!!Please enter correct command!!");
                        console_text += "Correct code be like: \n e.g. draw circle 100 \n\n";
                    }
                    else
                    {

                        Circle circle = new Circle();
                        circle.setX(moveX);
                        circle.setY(moveY);
                        int radius = 0;
                        //circle radius
                        if (!Regex.IsMatch(words[1], @"^[0-9]+$"))
                        {
                            variable.TryGetValue(words[1], out radius);
                        }
                        else
                        {
                            radius = Convert.ToInt32(words[1]);
                        }
                        circle.setRadius(radius);
                        circle.setColor(c);
                        circle.setFill(fill);
                        circleObjects.Add(circle);
                        drawCircle = true;
                        console_text += "Adding new circle\n\n";


                    }
                }

                if (words[0].Equals("drawto"))
                {
                    if ((words.Length != 3))
                    {
                        MessageBox.Show("!!Please enter correct command!!");
                        console_text += "Correct code be like: \n e.g. drawto 100 100 \n\n";
                    }
                    else
                    {
                        Line line = new Line();
                        line.setColor(c);
                        line.setX1(moveX);
                        line.setY1(moveY);
                        int pointX2 = 0;
                        int pointY2 = 0;
                        if (!Regex.IsMatch(words[1], @"^[0-9]+$"))
                        {
                            variable.TryGetValue(words[1], out pointX2);
                        }
                        else
                        {
                            pointX2 = int.Parse(words[1]);
                        }
                        if (!Regex.IsMatch(words[2], @"^[0-9]+$"))
                        {
                            variable.TryGetValue(words[2], out pointY2);
                        }
                        else
                        {
                            pointY2 = int.Parse(words[2]);
                        }
                        line.setX2(pointX2);
                        line.setY2(pointY2);
                        lineObjects.Add(line);
                        drawLine = true;
                        console_text += "Adding new line\n\n";
                    }
                }
                if (words[0].Equals("rectangle"))
                {
                    //MessageBox.Show(moveX.ToString());
                    if (!(words.Length == 3)) //extending parameter values
                    {
                        MessageBox.Show("!!Please enter correct command!!");
                        console_text += "Correct code be like: \n e.g. draw rectangle 100 100 \n\n";
                    }
                    else
                    {
                        if (rectangleObjects.Exists(x => x.getX() == moveX && x.getY() == moveY
                        && x.getHeight() == Convert.ToInt32(words[1]) && x.getWidth() ==
                        Convert.ToInt32(words[2])) == true)//checks if rectangle with x,y,height,width parameter exists or not
                        {
                            console_text += "!!rectangle object exists with given parameters!!\n\n";
                        }
                        else
                        {
                            //if not exists then creates new rectangle and add to rectangleObjects and draws rectangle
                            Rectangle rect = new Rectangle();
                            rect.setX(moveX);
                            rect.setY(moveY);
                            rect.setColor(c);
                            rect.setFill(fill);
                            int width = 0;
                            int height = 0;
                            if (!Regex.IsMatch(words[1], @"^[0-9]+$"))
                            {
                                variable.TryGetValue(words[1], out width);
                            }
                            else
                            {
                                width = int.Parse(words[1]);
                            }

                            if (!Regex.IsMatch(words[2], @"^[0-9]+$"))
                            {
                                variable.TryGetValue(words[2], out height);
                            }
                            else
                            {
                                height = int.Parse(words[2]);
                            }
                            rect.setHeight(height);
                            rect.setWidth(width);
                            rectangleObjects.Add(rect);
                            drawRect = true;
                            console_text += "Adding new rectangle\n\n";
                        }
                    }
                }

                if (words[0].Equals("triangle"))
                {
                    //MessageBox.Show(moveX.ToString());
                    if (!(words.Length == 4)) //extending parameter values
                    {
                        MessageBox.Show("!!Please enter correct command!! ");
                        console_text += "Correct code be like: \n e.g. draw triagnle 100 100 100  \n\n";
                    }
                    else
                    {

                        //if not exists then creates new polygon and add to polygon Objects and draws polygon
                        Triangle triangle = new Triangle();
                        int side1 = 0;
                        int side2 = 0;
                        int side3 = 0;

                        if (!Regex.IsMatch(words[1], @"^[0-9]+$"))
                        {
                            variable.TryGetValue(words[1], out side1);
                        }
                        else
                        {
                            side1 = int.Parse(words[1]);
                        }
                        if (!Regex.IsMatch(words[2], @"^[0-9]+$"))
                        {
                            variable.TryGetValue(words[2], out side2);
                        }
                        else
                        {
                            side2 = int.Parse(words[2]);
                        }

                        if (!Regex.IsMatch(words[3], @"^[0-9]+$"))
                        {
                            variable.TryGetValue(words[3], out side3);
                        }
                        else
                        {
                            side3 = int.Parse(words[3]);
                        }
                        triangle.set(c, fill, side1, side2, side3, moveX, moveY);
                        triangleobjects.Add(triangle);
                        drawTriangle = true;
                        console_text += "Adding new Triangle\n\n";

                    }
                }

                if (words[0].Equals("polygon"))
                {
                    if (!(words.Length > 4)) //extending parameter values
                    {
                        MessageBox.Show("!!Please enter correct command!! Minimum four parameters i.e. two points ");
                        console_text += "Correct code be like: \n e.g. draw polygon 100 100 100 100  \n\n";
                    }
                    else
                    {
                        Polygon poly = new Polygon();
                        string[] param = code_line.Trim().Split(' ');
                        int[] points = new int[param.Length + 2];
                        points[0] = moveX;
                        points[1] = moveY;
                        for (int i = 0; i < param.Length; i++)
                        {
                            if (!Regex.IsMatch(param[i], @"^[0-9]+$"))
                            {
                                if (!param[i].Equals("polygon"))
                                {
                                    variable.TryGetValue(param[i], out points[i + 2]);
                                }
                            }
                            else
                            {
                                points[i + 2] = int.Parse(param[i]);
                            }
                        }
                        poly.set(c, fill, points);
                        polygonObjects.Add(poly);
                        drawPolygon = true;
                        console_text += "Adding new Polygon\n\n";
                    }
                }

                if (words[0].Equals("fill"))
                {
                    if (words[1].Equals("on"))
                    {
                        fill = true;
                    }
                    else if (words[1].Equals("off"))
                    {
                        fill = false;
                    }
                }
                if (words[0] == "moveto") // condition to check if "move" then
                {
                    int x = 0;
                    int y = 0;
                    if (!Regex.IsMatch(words[1], @"^[0-9]+$"))
                    {
                        variable.TryGetValue(words[1], out x);
                    }
                    else
                    {
                        x = int.Parse(words[1]);
                    }
                    if (!Regex.IsMatch(words[2], @"^[0-9]+$"))
                    {
                        variable.TryGetValue(words[2], out y);
                    }
                    else
                    {
                        y = int.Parse(words[2]);
                    }

                    if (x == pbOutput.Location.X &&
                        y == pbOutput.Location.Y)//checks if cursor is in different position
                    {
                        //MessageBox.Show("don't move");
                        console_text += "Its in requested position\n\n";
                    }
                    else
                    {
                        moveX = x;
                        moveY = y;
                        console_text += "X=" + moveX + "\n" + "Y=" + moveY + "\n\n";
                    }
                }
                if (words[0] == "pen")
                {


                    if (words[1] == "red")
                    {
                        c = Color.Red;
                        console_text += "Pen is of red color\n\n";
                    }
                    else if (words[1] == "blue")
                    {
                        c = Color.Blue;
                        console_text += "Pen is of blue color\n\n";
                    }
                    else if (words[1] == "yellow")
                    {
                        c = Color.Yellow;
                        console_text += "Pen is of yellow color\n\n";
                    }
                    else
                    {
                        c = Color.Green;
                        console_text += "Pen is of green color\n\n";
                    }
                }
            }
            panel1.Refresh();
        }


        /// <summary>
        /// helos to know about the application
        /// </summary>
        /// <param name="sender">reference object</param>
        /// <param name="e">event data</param>
        private void hELPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To execute the program\n" +
    "draw 'circle 15' or 'triangle 20 20 20'\n" +
    "  or 'rectangle 20 40' or polygon 30 30 30 30 30 30 30 30 \n" +
    "'moveto 150 150' for changing the position\n" +
    "'pen red' to change the colour\n" +
    "'fill on' to fill color to the shapes");
        }


        /// <summary>
        /// Load the saved text file
        /// </summary>
        /// <param name="sender">reference object</param>
        /// <param name="e">event data</param>
        /// 

        private void lOADToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //opens diaglog box when button click to load the code.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtxt_code.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }




        /// <summary>
        /// To make shapes in the panel
        /// </summary>
        /// <param name="sender">Reference object</param>
        /// <param name="e">Object</param>
        private void Panel_output_Paint(object sender, PaintEventArgs e)
        {
            //Graphics to draw in panel
            Graphics g = e.Graphics;

            if (drawCircle == true)//draw circle condition
            {
                foreach (Circle circleObject in circleObjects)
                {
                    console_text += "Drawing Circle\n\n";
                    circleObject.draw(g); //draw circle with given graphics
                }
            }

            if (drawRect == true) //draw rectangle condition
            {
                foreach (Rectangle rectangleObject in rectangleObjects)
                {
                    console_text += "Drawing Rectangle\n\n";
                    rectangleObject.draw(g); //draw circle with given graphics
                }
            }
            if (drawLine == true)
            {
                foreach (Line lineObject in lineObjects)
                {
                    console_text += "Drawing Line\n\n";
                    lineObject.draw(g); //draw line with given graphics
                }
            }

            if (drawTriangle == true)
            {
                foreach (Triangle trian in triangleobjects)
                {
                    console_text += "Drawing Triangle\n\n";
                    trian.draw(g); //draw line with given graphics
                }
            }

            if (drawPolygon == true)
            {
                foreach (Polygon polygonObject in polygonObjects)
                {
                    console_text += "Drawing Polygon\n\n";
                    polygonObject.draw(g); //draw line with given graphics
                }
            }

        }


    }
}
