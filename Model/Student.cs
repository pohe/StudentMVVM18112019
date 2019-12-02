using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMVVM18112019.Model
{
    /// <summary>
    /// Student klassen indeholder oplysninger om en student
    /// </summary>

    public class Student
    {
       
        public int No { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public string ImageSource { get; 
            set; }

        public Student()
        {
            
        }

        /// <summary>
        /// Denne konstruktør initialiserer et Student objekt.
        /// Alle properties initialiseres her
        /// </summary>
        /// <param name="no">Studentens nummer</param>
        /// <param name="name">Studentens navn</param>
        /// <param name="yearOfBirth">Studentens fødselsår</param>
        /// <param name="address">Studentens adresse</param>
        /// <param name="email">Studentens email</param>
        /// <param name="imageSource">henvisning til et billed af studenten</param>
        public Student(int no, string name, int yearOfBirth, string address, string email, string imageSource)
        {
            No = no;
            Name = name;
            YearOfBirth = yearOfBirth;
            Address = address;
            Email = email;
            ImageSource = imageSource;
            
        }

        public override string ToString()
        {
            return $"Studentno {No} name {Name} born {YearOfBirth} som bor {Address} email {Email}";
        }
    }
}
