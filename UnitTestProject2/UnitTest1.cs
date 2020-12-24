using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPLA;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        frmGDI fm = new frmGDI();

        Validation VS = new Validation();

        [TestMethod]
        public void valid_command_parameter()
        {
            //valid commands
            Assert.IsTrue(VS.check_command("run"));
            Assert.IsTrue(VS.check_command("clear"));
            Assert.IsTrue(VS.check_command("reset"));

            //valid command
            Assert.IsTrue(VS.checkprogram_command("triangle 20 40 50",fm));
            Assert.IsTrue(VS.checkprogram_command("pen red",fm));
            Assert.IsTrue(VS.checkprogram_command("fill on", fm));
            Assert.IsTrue(VS.checkprogram_command("moveto 20 30", fm));
            Assert.IsTrue(VS.checkprogram_command("drawto 50 70)", fm));
        }
        [TestMethod]
        public void valid_parameter()
        {
            //command with wrong number of parameters or invalid parameters
            Assert.IsFalse(VS.checkprogram_command("rectangle 20 30 40", fm));
            Assert.IsFalse(VS.checkprogram_command("pen no color", fm));
            Assert.IsFalse(VS.checkprogram_command("fill on off", fm));
            Assert.IsFalse(VS.checkprogram_command("moveto 20 y 40", fm));
            Assert.IsFalse(VS.checkprogram_command("drawto xx 70 90", fm));
        }
        [TestMethod]
        public void valid_command_name()
        {
            //invalid command name

            Assert.IsFalse(VS.checkprogram_command("rectanglesc 20 30", fm));
            Assert.IsFalse(VS.checkprogram_command("pn red", fm));
            Assert.IsFalse(VS.checkprogram_command("filsl on", fm));
            Assert.IsFalse(VS.checkprogram_command("movto 20 30", fm));
            Assert.IsFalse(VS.checkprogram_command("drwto 50 70", fm));
        }
    }


}

