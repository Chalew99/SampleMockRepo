//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Engine.Moq;
//using Moq;

//namespace TestEngine.Moq.ManualMock
//{
//    [TestClass]
//    public class TestStudent
//    {
//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void Test_CreateNewStudent_EmptyName()
//        {
//            Student student = Student.CreateNewStudent("");
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void Test_CreateNewStudent_EmptyName_MockedDataMapper()
//        {
//            MockStudentDataMapper mockStudentDataMapper = new MockStudentDataMapper();

//            Student student = Student.CreateNewStudent("", mockStudentDataMapper);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void Test_CreateNewStudent_AlreadyExistsInDatabase()
//        {
//            MockStudentDataMapper mockStudentDataMapper = new MockStudentDataMapper();

//            mockStudentDataMapper.ResultToReturn = true;

//            Student student = Student.CreateNewStudent("Test", mockStudentDataMapper);
//        }

//        [TestMethod]
//        public void Test_CreateNewStudent_DoesNotAlreadyExistInDatabase()
//        {
//            MockStudentDataMapper mockStudentDataMapper = new MockStudentDataMapper();

//            mockStudentDataMapper.ResultToReturn = false;

//            Student student = Student.CreateNewStudent("Test", mockStudentDataMapper);

//            Assert.AreEqual("Test", student.Name);
//            Assert.AreEqual(13, student.Age);
//            Assert.AreEqual(10, student.Marks);
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestEngine.Moq.UsingMoqLibrary
{
    [TestClass]
    public class TestStudentWithMock
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CreateNewStudent_EmptyName()
        {
            Student student = Student.CreateNewStudent("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CreateNewStudent_EmptyName_MockedDataMapper()
        {
            var mock = new Mock<IStudentDataMapper>();
            Student student = Student.CreateNewStudent("", mock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CreateNewStudent_AlreadyExistsInDatabase()
        {
            var mock = new Mock<IStudentDataMapper>();
            mock.Setup(x => x.StudentNameExistsInDatabase(It.IsAny<string>())).Returns(true);

            Student student = Student.CreateNewStudent("Test", mock.Object);
        }

        [TestMethod]
        public void Test_CreateNewStudent_DoesNotAlreadyExistInDatabase()
        {
            var mock = new Mock<IStudentDataMapper>();
            mock.Setup(x => x.StudentNameExistsInDatabase(It.IsAny<string>())).Returns(false);

            Student student = Student.CreateNewStudent("Test", mock.Object);

            Assert.AreEqual("Test", student.Name);
            Assert.AreEqual(13, student.Age);
            Assert.AreEqual(10, student.Marks);
        }
    }
}
