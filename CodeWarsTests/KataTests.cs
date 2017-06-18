using NUnit.Framework;
using CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.Tests
{
    [TestFixture]
    public class KataTests
    {
        [Test]
        public void DisemvowelTest()
        {
            Assert.AreEqual(Kata.Disemvowel("This website is for losers LOL!"), "Ths wbst s fr lsrs LL!");
        }

        [Test]
        public static void FindParityOutlierTest1()
        {
            int[] exampleTest1 = { 2, 6, 8, -10, 3 };
            Assert.IsTrue(3 == Kata.FindParityOutlier(exampleTest1));
        }

        [Test]
        public static void FindParityOutlierTest2()
        {
            int[] exampleTest2 = { 206847684, 1056521, 7, 17, 1901, 21104421, 7, 1, 35521, 1, 7781 };
            Assert.IsTrue(206847684 == Kata.FindParityOutlier(exampleTest2));
        }

        [Test]
        public static void FindParityOutlierTest3()
        {
            int[] exampleTest3 = { int.MaxValue, 0, 1 };
            Assert.IsTrue(0 == Kata.FindParityOutlier(exampleTest3));
        }

        [Test]
        public void XsAndOsTests()
        {
            Assert.AreEqual(true, Kata.XsAndOs("xo"));
            Assert.AreEqual(true, Kata.XsAndOs("xxOo"));
            Assert.AreEqual(false, Kata.XsAndOs("xxxm"));
            Assert.AreEqual(false, Kata.XsAndOs("Oo"));
            Assert.AreEqual(false, Kata.XsAndOs("ooom"));
        }

        [Test]
        public void GetRectangleString_3x3()
        {
            string rectangle = Kata.GetRectangleString(3, 3);
            string expected = "***\r\n" +
                              "* *\r\n" +
                              "***\r\n";
            Assert.AreEqual(expected, rectangle);
        }
    }
}