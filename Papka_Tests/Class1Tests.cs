using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void validatePasswordTest_Symbols_T1()
        {
            string password = "Asd123$";
            bool actual = Class1.validatePassword(password);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void validatePasswordTest_Symbols_T2()
        {
            string password = "ASDqwe123$";
            bool expected = true;
            bool actual = Class1.validatePassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void validatePasswordTest_Symbols_T3()
        {
            string password = "ZXCaSdqwe1234567890$%";
            bool actual = Class1.validatePassword(password);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void validatePasswordTest_Num_T1()
        {
            string password = "ZXCaSdqwe$";
            bool actual = Class1.validatePassword(password);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void validatePasswordTest_Num_T2()
        {
            string password = "ASDqwe123$";
            bool expected = true;
            bool actual = Class1.validatePassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void validatePasswordTest_SpecNum_T1()
        {
            string password = "ASDqwe123";
            bool actual = Class1.validatePassword(password);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void validatePasswordTest_SpecNum_T2()
        {
            string password = "ASDqwe123$";
            bool expected = true;
            bool actual = Class1.validatePassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void validatePasswordTest_Caps_T1()
        {
            string password = "asdqwe123$";
            bool actual = Class1.validatePassword(password);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void validatePasswordTest_Caps_T2()
        {
            string password = "ASDqwe123$";
            bool expected = true;
            bool actual = Class1.validatePassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void validatePasswordTest_Low_T1()
        {
            string password = "ASDQWE123$";
            bool actual = Class1.validatePassword(password);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void validatePasswordTest_Low_T2()
        {
            string password = "ASDqwe123$";
            bool expected = true;
            bool actual = Class1.validatePassword(password);
            Assert.AreEqual(expected, actual);
        }
    }
}