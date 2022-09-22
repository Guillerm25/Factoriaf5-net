using NUnit.Framework;
using System;
using System.IO;

namespace HelloWorldTests
{
    [TestClass]
    public class UnitTest1
    {
        private const string Expected = "TEST!";
        [TestMethod]
        public void TestMethod1()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                ImagesAppHelpers.Program();

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);
            }
        }

        private class CarouselImagesApp
        {
            public static object Program { get; internal set; }
        }
    }

    internal class TestMethodAttribute : Attribute
    {
    }
}