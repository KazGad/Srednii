using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuculator.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void validateSymTest_plus()
        {
            string Sym = "+";
            int resout = 12;
            int n1 = 5;
            int n2 = 7;
            int actual = Class1.validateSym(n1, n2, Sym);
            Assert.AreEqual(resout, actual);
        }

        [TestMethod()]
        public void validateSymTest_minus()
        {
            string Sym = "-";
            int resout = 2;
            int n1 = 7;
            int n2 = 5;
            int actual = Class1.validateSym(n1, n2, Sym);
            Assert.AreEqual(resout, actual);
        }

        [TestMethod()]
        public void validateSymTest_multiplication()
        {
            string Sym = "*";
            int resout = 35;
            int n1 = 7;
            int n2 = 5;
            int actual = Class1.validateSym(n1, n2, Sym);
            Assert.AreEqual(resout, actual);
        }

        [TestMethod()]
        public void validateSymTest_share()
        {
            string Sym = "/";
            int resout = 6;
            int n1 = 30;
            int n2 = 5;
            int actual = Class1.validateSym(n1, n2, Sym);
            Assert.AreEqual(resout, actual);
        }
    }
}