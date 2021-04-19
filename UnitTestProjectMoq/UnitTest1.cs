using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjectLibrary;
using Moq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod2()
        {
            Mock<checkEmployee> chk = new Mock<checkEmployee>();
            chk.Setup(x => x.checkEmp()).Returns(true);

            processEmployee obje = new processEmployee();
            Assert.AreEqual(obje.insertEmployee(chk.Object), true);
        }
    }
}
