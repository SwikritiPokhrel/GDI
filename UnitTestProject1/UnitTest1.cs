using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPLA;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        Validation VS = new Validation();
        [TestMethod]
        public void valid_command_parameter()
        {
            //valid commands
            Assert.IsTrue(VS.check_command("run"));
            Assert.IsTrue(VS.check_command("clear"));
            Assert.IsTrue(VS.check_command("reset"));

            //valid command
            Assert.IsTrue(VS.checkprogram_command("triangle 20 40 50"));
            Assert.IsTrue(VS.checkprogram_command("pen red"));
            Assert.IsTrue(VS.checkprogram_command("fill on"));
            Assert.IsTrue(VS.checkprogram_command("moveto 20 30"));
            Assert.IsTrue(VS.checkprogram_command("drawto 50 70)"));
        }
        [TestMethod]
        public void valid_parameter()
        {
            //command with wrong number of parameters or invalid parameters
            Assert.IsFalse(VS.checkprogram_command("rectangle 20 30 40"));
            Assert.IsFalse(VS.checkprogram_command("pen no color"));
            Assert.IsFalse(VS.checkprogram_command("fill on off"));
            Assert.IsFalse(VS.checkprogram_command("moveto 20 y 40"));
            Assert.IsFalse(VS.checkprogram_command("drawto xx 70 90"));
        }
        [TestMethod]
        public void valid_command_name()
        {
            //invalid command name
       
            Assert.IsFalse(VS.checkprogram_command("rectanglesc 20 30"));
            Assert.IsFalse(VS.checkprogram_command("pn red"));
            Assert.IsFalse(VS.checkprogram_command("filsl on"));
            Assert.IsFalse(VS.checkprogram_command("movto 20 30"));
            Assert.IsFalse(VS.checkprogram_command("drwto 50 70"));
        }
    }
}
