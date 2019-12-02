
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentMVVM18112019.Model;
using StudentMVVM18112019.Exceptions;

namespace UnitTestProject2019
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddAStudentToCollecttion()
        {
            //Arrange
            StudentCatalogSingleton cat = StudentCatalogSingleton.Instance;
            int numberOFStundetsBefore = cat.Students.Count;
            Student newStudent = new Student(12,"Test", 1950, "vej 122", "email@email.dk", "assets/ann.jpg");
            //Act
            cat.Add(newStudent);
            int numberOfStundetsAfter = cat.Students.Count;
            //Assert
            Assert.AreEqual(numberOFStundetsBefore+1, numberOfStundetsAfter);
        }

        [TestMethod]
        public void TestRemoveAStudentToCollecttion()
        {
            //Arrange
            StudentCatalogSingleton cat = StudentCatalogSingleton.Instance;
            //Student student1 = new Student(12, "Test", 1950, "vej 122", "email@email.dk", "assets/ann.jpg");
            //Student student2 = new Student(13, "Test", 1950, "vej 122", "email@email.dk", "assets/ann.jpg");
            //Student student3 = new Student(14, "Test", 1950, "vej 122", "email@email.dk", "assets/ann.jpg");
            //cat.Add(student1);
            //cat.Add(student2);
            //cat.Add(student2);
            int numberOFStundetsBefore = cat.Students.Count;
            //Act
            cat.RemoveAt(0);
            int numberOfStundetsAfter = cat.Students.Count;
            //Assert
            Assert.AreEqual(numberOFStundetsBefore -1, numberOfStundetsAfter);
        }

        [TestMethod]
        public void TestUpdateStudentToCollecttion()
        {
            //Arrange
            StudentCatalogSingleton cat = StudentCatalogSingleton.Instance;
            Student student1 = new Student(12, "Test", 1950, "vej 122", "email@email.dk", "assets/ann.jpg");
            Student student2 = new Student(13, "Test", 1950, "vej 122", "email@email.dk", "assets/ann.jpg");
            Student student3 = new Student(14, "Test", 1950, "vej 122", "email@email.dk", "assets/ann.jpg");
            cat.Add(student1);
            cat.Add(student2);
            cat.Add(student2);
            string nameBefore = student1.Name;
            int numberOFStundetsBefore = cat.Students.Count;
            //Act
            Student updatedStudent = new Student(cat.Students[0].No, "UpdatedName", cat.Students[0].YearOfBirth, cat.Students[0].Address,cat.Students[0].Email, cat.Students[0].ImageSource);
            cat.Update(updatedStudent,0);
            int numberOfStudentsAfter = cat.Students.Count;
            //Assert
            Assert.AreEqual(cat.Students[0].Name, updatedStudent.Name);
            Assert.AreNotEqual(nameBefore, updatedStudent.Name);
            Assert.AreEqual(numberOFStundetsBefore, numberOfStudentsAfter);
        }


        [TestMethod]
        public void TestTooShortRegnrException()
        {
            //Arrange
            StudentCatalogSingleton cat = StudentCatalogSingleton.Instance;
            Student student1 = new Student(12, "Test", 1949, "vej 122", "email@email.dk", "assets/ann.jpg");

            //Act og Assert
            Assert.ThrowsException<YearOfBirthTooLow>(

                () =>
                {
                    cat.Add(student1);
                }
            );
        }

        [TestMethod]
        [ExpectedException(typeof(YearOfBirthTooLow), "Årstallet er for lavt - ikke før 1950")]
        public void TestTooShortRegnrExceptionV2()
        {
            //Arrange
            StudentCatalogSingleton cat = StudentCatalogSingleton.Instance;
            Student student1 = new Student(12, "Test", 1949, "vej 122", "email@email.dk", "assets/ann.jpg");

            //Act og Assert
            
            cat.Add(student1);
            
        }
    }
}
