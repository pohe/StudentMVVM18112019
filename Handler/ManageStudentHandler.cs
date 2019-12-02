using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMVVM18112019.Common;
using StudentMVVM18112019.Exceptions;
using StudentMVVM18112019.Persistency;
using StudentMVVM18112019.ViewModel;

namespace StudentMVVM18112019.Handler
{
    public class ManageStudentHandler
    {
        public StudentViewModel StudentViewModel { get; set; }

        public ManageStudentHandler(StudentViewModel studentViewModel)
        {
            StudentViewModel = studentViewModel;
        }

        public void RemoveStudent()
        {
            StudentViewModel.StudentCatalog.RemoveAt(StudentViewModel.SelectedIndex);
        }

        public void UpdateStudent()
        {
            try
            {
                if (StudentViewModel.SelectedStudent != null)
                    StudentViewModel.StudentCatalog.Update(StudentViewModel.SelectedStudent,
                        StudentViewModel.SelectedIndex);

            }
            catch (YearOfBirthTooLow yex)
            {
                MessageDialogHelper.Show("Inden studenter må være født før 1950!", "Født alt for tidligt");
            }
        }


        public async void SaveStudentsAsync()
        {
             await PersistencyFacade.SaveStudentsAsJsonAsync(StudentViewModel.StudentCatalog.Students);
        }

        public async void LoadPersonsAsync()
        {
            var students = await PersistencyFacade.LoadStudentsFromJsonAsync();
            StudentViewModel.StudentCatalog.Students.Clear();
            if (students != null)
                foreach (var student in students)
                {
                    StudentViewModel.StudentCatalog.Students.Add(student);
                }
        }

    }
}
