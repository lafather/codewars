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

        int[] Test1 = new int[] { 0, 0, 0, 0 };
        int[] Test2 = new int[] { 1, 1, 1, 1 };
        int[] Test3 = new int[] { 0, 1, 1, 0 };
        int[] Test4 = new int[] { 0, 1, 0, 1 };
        [Test]
        public void BinaryArrayToNumberTest()
        {
            var test1 = new int[] { 0, 0, 0, 0 };
            var test2 = new int[] { 1, 1, 1, 1 };
            var test3 = new int[] { 0, 1, 1, 0 };
            var test4 = new int[] { 0, 1, 0, 1 };

            Assert.AreEqual(0, Kata.BinaryArrayToNumber(test1));
            Assert.AreEqual(15, Kata.BinaryArrayToNumber(test2));
            Assert.AreEqual(6, Kata.BinaryArrayToNumber(test3));
            Assert.AreEqual(5, Kata.BinaryArrayToNumber(test4));
        }

        [Test]
        public void GetLengthOfMissingArrayTests()
        {
            Assert.AreEqual(3, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 1, 2 }, new object[] { 4, 5, 1, 1 }, new object[] { 1 }, new object[] { 5, 6, 7, 8, 9 } }));
            Assert.AreEqual(2, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 5, 2, 9 }, new object[] { 4, 5, 1, 1 }, new object[] { 1 }, new object[] { 5, 6, 7, 8, 9 } }));
            Assert.AreEqual(2, Kata.GetLengthOfMissingArray(new object[][] { new object[] { null }, new object[] { null, null, null } }));
            Assert.AreEqual(5, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 'a', 'a', 'a' }, new object[] { 'a', 'a' }, new object[] { 'a', 'a', 'a', 'a' }, new object[] { 'a' }, new object[] { 'a', 'a', 'a', 'a', 'a', 'a' } }));

            Assert.AreEqual(0, Kata.GetLengthOfMissingArray(new object[][] { }));
        }

        [Test]
        public void RevRotTests()
        {
            StringAssert.IsMatch(string.Empty, Kata.RevRot("1234", 0));
            StringAssert.IsMatch(string.Empty, Kata.RevRot("1234", 5));
            StringAssert.IsMatch(string.Empty, Kata.RevRot(string.Empty, 0));
            StringAssert.IsMatch("330479108928157", Kata.RevRot("733049910872815764", 5));
        }

        [Test]
        public void ToCamelCaseTests()
        {
            Assert.AreEqual("theStealthWarrior", Kata.ToCamelCase("the_stealth_warrior"), "Kata.ToCamelCase('the_stealth_warrior') did not return correct value");
            Assert.AreEqual("TheStealthWarrior", Kata.ToCamelCase("The-Stealth-Warrior"), "Kata.ToCamelCase('The-Stealth-Warrior') did not return correct value");
        }

        [Test]
        public void BouncingBallTests()
        {
            Assert.AreEqual(3, Kata.BouncingBall(3.0, 0.66, 1.5));
            Assert.AreEqual(15, Kata.BouncingBall(30.0, 0.66, 1.5));
        }

        [Test]
        public void IsMergeTests()
        {
            Assert.IsTrue(Kata.IsMerge("codewars", "code", "wars"), "codewars can be created from code and wars");
            Assert.IsTrue(Kata.IsMerge("codewars", "cdwr", "oeas"), "codewars can be created from cdwr and oeas");
            Assert.IsFalse(Kata.IsMerge("codewars", "cod", "wars"), "Codewars are not codwars");
        }
    }
}