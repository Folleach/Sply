using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sply.Tests
{
    [TestClass]
    public class Tests
    {
        private const string TestFolder = "../../../../TestsResources/";

        [TestMethod]
        public void Default()
        {
            string file = $"{TestFolder}Default.txt";

            Config config = new Config();
            config.Load(file);

            Assert.AreEqual(config["key"], "value");
            Assert.AreEqual(config["i"], "j");
            Assert.AreEqual(config.Length, 2);
        }

        [TestMethod]
        public void Comment()
        {
            string file = $"{TestFolder}Comment.txt";

            Config config = new Config();
            config.Load(file);

            Assert.AreEqual(config["temp"], "variable");
            Assert.AreEqual(config["and"], "other");
            Assert.AreEqual(config["variables"], "here");
            Assert.AreEqual(config.Length, 3);
        }

        [TestMethod]
        public void EmptyLines()
        {
            string file = $"{TestFolder}EmptyLines.txt";

            Config config = new Config();
            config.Load(file);

            Assert.AreEqual(config["hello"], "I am curious...");
            Assert.AreEqual(config.Length, 1);
        }

        [TestMethod]
        public void WhiteSpace()
        {
            string file = $"{TestFolder}WhiteSpace.txt";

            Config config = new Config();
            config.Load(file);

            Assert.AreEqual(config[" k e y "], " almost");
            Assert.AreEqual(config["a b   "], "o");
            Assert.AreEqual(config["a"], "b");
            Assert.AreEqual(config["c"], "d ");
            Assert.AreEqual(config.Length, 4);
        }

        [TestMethod]
        public void ManySeparators()
        {
            string file = $"{TestFolder}ManySeparators.txt";

            Config config = new Config();
            config.Load(file);

            Assert.AreEqual(config["Many"], "S=e=p=a=r=a=t=o=r=s=");
            Assert.AreEqual(config["a"], "c=b");
            Assert.AreEqual(config.Length, 2);
        }

        [TestMethod]
        public void OtherSeparators()
        {
            string file = $"{TestFolder}OtherSeparators.txt";

            Config config = new Config(':');
            config.Load(file);

            Assert.AreEqual(config["key"], "value");
            Assert.AreEqual(config["how"], "json");
            Assert.AreEqual(config.Length, 2);
        }

        [TestMethod]
        public void OtherComments()
        {
            string file = $"{TestFolder}OtherComments.txt";

            Config config = new Config(commentCharacter: 'a');
            config.Load(file);

            Assert.AreEqual(config["u"], "v");
            Assert.AreEqual(config.Length, 1);
        }

        [TestMethod]
        public void EmptyValue()
        {
            string file = $"{TestFolder}EmptyValue.txt";

            Config config = new Config(commentCharacter: 'a');
            config.Load(file);

            Assert.AreEqual(config["key"], "");
            Assert.AreEqual(config["otherKey"], "a");
            Assert.AreEqual(config.Length, 2);
        }

        [TestMethod]
        public void EmptyKey()
        {
            string file = $"{TestFolder}EmptyKey.txt";

            Config config = new Config(commentCharacter: 'a');
            config.Load(file);

            Assert.AreEqual(config[""], "It's false, and cake");
            Assert.AreEqual(config.Length, 1);
        }

        [TestMethod]
        public void EmptyFile()
        {
            string file = $"{TestFolder}EmptyFile.txt";

            Config config = new Config(commentCharacter: 'a');
            config.Load(file);

            Assert.AreEqual(config.Length, 0);
        }
    }
}
