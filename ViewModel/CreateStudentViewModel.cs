using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudentMVVM18112019.Annotations;
using StudentMVVM18112019.Common;
using StudentMVVM18112019.Handler;
using StudentMVVM18112019.Model;

namespace StudentMVVM18112019.ViewModel
{
    public class CreateStudentViewModel: INotifyPropertyChanged
    {
        public StudentCatalogSingleton StudentCatalog { get; set; }

        public int SelectedIndex { get; set; }
        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
               
            }
        }

        public CreateStudentViewModel()
        {
            SelectedStudent = new Student();
            StudentCatalog = StudentCatalogSingleton.Instance;
            CreateStudentHandler = new CreateStudentHandler(this);
            _addCommand = new RelayCommand(CreateStudentHandler.AddStudent);
            
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        public CreateStudentHandler CreateStudentHandler { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
