using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMVVM18112019.Common;
using StudentMVVM18112019.Exceptions;
using StudentMVVM18112019.Model;
using StudentMVVM18112019.ViewModel;

namespace StudentMVVM18112019.Handler
{
    public class CreateStudentHandler
    {
        public CreateStudentViewModel CreateStudentViewModel { get; set; }

        public CreateStudentHandler(CreateStudentViewModel createStudentViewModel)
        {
            CreateStudentViewModel = createStudentViewModel;
        }

        public void AddStudent()
        {
            try
            {
                Student newStudent = new Student(CreateStudentViewModel.SelectedStudent.No, CreateStudentViewModel.SelectedStudent.Name, CreateStudentViewModel.SelectedStudent.YearOfBirth,
                    CreateStudentViewModel.SelectedStudent.Address, CreateStudentViewModel.SelectedStudent.Email,
                    CreateStudentViewModel.SelectedStudent.ImageSource);
                CreateStudentViewModel.StudentCatalog.Add(newStudent);
            }
            catch (YearOfBirthTooLow yex)
            {
                MessageDialogHelper.Show("Inden studenter må være født før 1950!", "Født alt for tidligt");
            }
            
        }

    }
}
