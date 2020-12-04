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

namespace GPLA
{
    /// <summary>
    /// frmGDI class inherits from the base class Form
    /// </summary>
    public partial class frmGDI : Form
    {


        Shape shape1, shape2; //declaration 
        Validation v = new Validation();
        //list 
        List<Circle> circleObjects;
        List<Rectangle> rectangleObjects;
        List<Line> lineObjects;
        List<Polygon> polygonObjects;
        List<MoveDirection> moveObjects;


        Circle circle; //declaration 
        Rectangle rectangle; 
        Line line;
        Boolean drawCircle, drawRect, drawPolgon, drawLine; //boolean to check whether to make objects or not
       
        int moveX, moveY; //axis
        int counter;
        


        /// <summary>
        /// For creating all the shapes given by the user
        /// </summary>
        /// <param name="sender">reference object</param>
        /// <param name="e">event data</param>
        private void FrmGPLA_Load(object sender, EventArgs e)
        {
            circle = new Circle(); //creates new circle
            rectangle = new Rectangle(); //creates new rectangle

            circleObjects = new List<Circle>(); //creates array of new circle objects
            rectangleObjects = new List<Rectangle>(); //creates array of new rectangle objects
            lineObjects = new List<Line>();

            moveObjects = new List<MoveDirection>(); //creates array of new move objects
            polygonObjects = new List<Polygon>();

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

        private void rtxt_code_TextChanged(object sender, EventArgs e)
        {

        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            rtxt_code.Clear();
        }

        private void txt_ActionCmd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                actionCmd = txt_ActionCmd.Text;
                if (v.check_command(actionCmd))
                {
                    String program; //string to hold textarea info
                    String[] words; //words of the individual program
                    String[] lines = rtxt_code.Text.Trim().ToLower().Split(new String[] { Environment.NewLine },
                                StringSplitOptions.None);
                    foreach (string line in lines)
                    {
                        //c1.cjec(line);
                        //c1.cjec(line);
                    }
                    switch (actionCmd)
                    {
                        case "run":

                            try
                            {

                                program = rtxt_code.Text;


                                char[] delimiters = new char[] { '\r', '\n' };
                                string[] parts = program.Split(delimiters, StringSplitOptions.RemoveEmptyEntries); //holds invididuals code line
                                console_text = "Program code: \n";
                                foreach (string part in parts)
                                {
                                    console_text += part + "\n";
                                }
                                console_text += "\n\n";


                                //loop 
                                for (int i = 0; i < parts.Length; i++)
                                {

                                    //single code line
                                    String code_line = parts[i];

                                    if (v.checkprogram_command(code_line)) { 

                                    char[] code_delimiters = new char[] { ' ' };
                                    words = code_line.Split(code_delimiters, StringSplitOptions.RemoveEmptyEntries); //holds invididuals code line

                                       
                                    //condition to check if "draw" then


                                    counter += 1;

                                    if (code_line.Contains("circle") || code_line.Contains("rectangle") || code_line.Contains("triangle") || code_line.Contains("pen") || code_line.Contains("moveto") || code_line.Contains("drawto") || code_line.Contains("fill"))
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
                                                circle.setRadius(Convert.ToInt32(words[1]));
                                                circle.setColor(c);
                                                circle.setFill(fill);
                                                circleObjects.Add(circle);
                                                drawCircle = true;
                                                console_text += "Adding new circle\n\n";

                                            }
                                        }
                                            else
                                            {
                                                MessageBox.Show("please enter correct command");
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
                                                line.setX2(Convert.ToInt32(words[1]));
                                                line.setY2(Convert.ToInt32(words[2]));
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
                                                {//if not exists then creates new rectangle and add to rectangleObjects and draws rectangle
                                                    Rectangle rect = new Rectangle();
                                                    rect.setX(moveX);
                                                    rect.setY(moveY);
                                                    rect.setColor(c);
                                                    rect.setFill(fill);
                                                    rect.setHeight(Convert.ToInt32(words[1]));
                                                    rect.setWidth(Convert.ToInt32(words[2]));
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
                                                Polygon poly = new Polygon();
                                                poly.set(c, fill, Convert.ToInt32(words[1]), Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), moveX, moveY);
                                                polygonObjects.Add(poly);
                                                drawPolgon = true;
                                                console_text += "Adding new Triangle\n\n";

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
                                            if (Convert.ToInt32(words[1]) == pbOutput.Location.X &&
                                                Convert.ToInt32(words[2]) == pbOutput.Location.Y)//checks if cursor is in different position
                                            {
                                                //MessageBox.Show("don't move");
                                                console_text += "Its in requested position\n\n";
                                            }
                                            else
                                            {
                                                moveX = Convert.ToInt32(words[1]);
                                                moveY = Convert.ToInt32(words[2]);
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
                                    
                                }
                                    else
                                    {
                                        MessageBox.Show("To execute the program\n" +
            "draw 'circle 15' or 'triangle 20 20 20'  or 'rectangle 20 40' \n" +
            "'moveto 150 150' for changing the position\n" +
            "'pen red' to change the colour\n" +
            "'fill on' to fill color to the shapes");
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
                            this.drawCircle = false;
                            this.drawRect = false;
                            this.drawPolgon = false;
                            this.drawLine = false;

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
        /// helos to know about the application
        /// </summary>
        /// <param name="sender">reference object</param>
        /// <param name="e">event data</param>
        private void hELPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To execute the program\n" +
    "draw 'circle 15' or 'triangle 20 20 20'  or 'rectangle 20 40' \n" +
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

            if (drawPolgon == true)
            {
                foreach (Polygon polygonObject in polygonObjects)
                {
                    console_text += "Drawing Line\n\n";
                    polygonObject.draw(g); //draw line with given graphics
                }
            }
         
        }
       

    }
}
