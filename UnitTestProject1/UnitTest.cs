
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentMVVM18112019.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStudentCatalogAddOne()
        {
            //Arrange
            StudentCatalogSingleton catalog = StudentCatalogSingleton.Instance;
            Student newStudent = new Student(0, "test", 1950, "Testvej", "testemail@dr.dk", "Ann.jpg");
            int numberOfStudentsBefore = catalog.Students.Count;
            //Act
            catalog.Add(newStudent);
            int numberOfStundetsAfterAdd = catalog.Students.Count;

            //Assert
            Assert.AreEqual(numberOfStudentsBefore, numberOfStundetsAfterAdd - 1);

        }

        [TestMethod]
        public void TestStudentCatalogRemove()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod]
        public void TestStudentCatalogUpdate()
        {
            //Arrange

            //Act

            //Assert

        }
    }
}
