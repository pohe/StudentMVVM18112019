using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMVVM18112019.Exceptions;

namespace StudentMVVM18112019.Model
{
    /// <summary>
    /// Denne klasse indeholder en collection af student objekter
    /// Er implementeret som en singleton
    /// </summary>
    public class StudentCatalogSingleton
    {
        private static StudentCatalogSingleton instance;

        public static StudentCatalogSingleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new StudentCatalogSingleton();// her er valgt Lazy initialization - ikke thread safe
                return instance;
            }
        }

        public ObservableCollection<Student> Students { get; set; }

        private StudentCatalogSingleton()
        {
            Students = new ObservableCollection<Student>();

            //Students.Add(new Student(1, "Charlotte", 1903, "Bakken 1", "chhe@easj.dk", "/assets/ann.jpg"));
            //Students.Add(new Student(2, "Peter", 2003, "Gade 112", "pele@easj.dk", "/assets/benny.jpg"));
            //Students.Add(new Student(3, "Micheal", 1963, "Vej 112", "micl@easj.dk", "/assets/daniel.jpg"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStudent"></param>
        public void Add(Student newStudent)
        {
            //Students.Add(newStudent);
            if (newStudent.YearOfBirth < 1950) // Da der ikke ønskes studerende der er født før 1950 kastes en exception
            {
                throw new YearOfBirthTooLow("Årstallet er for lavt - ikke før 1950");
            }
            else
            {
                Students.Add(newStudent);

            }
        }
       
        public void RemoveAt(int index)
        {
            if (index > -1)
                Students.RemoveAt(index);
        }

        public void Update(Student updateStudent, int index)
        {
            if (updateStudent.YearOfBirth < 1950)
            {   //TODO: klassen mangler en ordentlig implementation af .......
                throw new YearOfBirthTooLow("Årstallet er for lavt - ikke før 1950");
            }
            else
            {
                Students[index] = updateStudent;

            }
            
        }

    }
}
