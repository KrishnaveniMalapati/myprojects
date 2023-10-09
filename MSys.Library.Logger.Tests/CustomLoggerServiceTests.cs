using MSys.Library.Logger.Interface;

namespace MSys.Library.Logger.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ILoggerService loggerService = new CustomLoggerService("krish.log");
            loggerService.Write("Testdddddddddddddddddddd");


            Assert.Pass();
        }
    }
}