using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPLA;

namespace UnitTestProject2
{
    [TestClass]
    public class check_commands

    {
        frmGDI fm1 = new frmGDI();
        check ck = new check();
        Commands cd = new Commands();

        [TestMethod]
        public void check_if()
        {
            //set variables
            string var = "radius=10";
            Assert.IsTrue(ck.check_variable(var));
            Assert.IsTrue(cd.run_variable_command(var));
            string if_command = "if (radius==10)";

            Assert.IsTrue(ck.check_if_command(if_command));


        }
        [TestMethod]
        public void check_loop()
        {
            //set variable
            string[] variable = { "count = 1", "radius = 20" };
            foreach (string var in variable)
            {
                Assert.IsTrue(ck.check_variable(var));
                Assert.IsTrue(cd.run_variable_command(var));
            }

            string text = "loop for count <=5\ncircle radius\nradius+10\ncount+1\nendloop";
            string loop_command = "loop for count <=5";
            //check if loop command is valid or not
            Assert.IsTrue(ck.check_loop(loop_command));
      

        }

        [TestMethod]
        public void check_method()
        {
            
   

            //without parameter
            string method_line = "method test ()";
              
                    //with parameter
                   string method_line1 = "method test1 (radius, width, height)";
                
                Assert.IsTrue(ck.check_method(method_line));
            Assert.IsTrue(ck.check_method(method_line1));

        

        }

        [TestMethod]
        public void check_variable()
        {
            //set variable
            string[] variable = { "count = 1", "radius = 20" };
            foreach (string var in variable)
            {
                Assert.IsTrue(ck.check_variable(var));
                Assert.IsTrue(cd.run_variable_command(var));
            }

        }
    }

}
