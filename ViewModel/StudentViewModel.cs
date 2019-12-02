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
    public class StudentViewModel: INotifyPropertyChanged
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
                ((RelayCommand)_removeCommand).RaiseCanExecuteChanged();
                ((RelayCommand)_updateCommand).RaiseCanExecuteChanged();
            }
        }

        public StudentViewModel()
        {
            StudentCatalog = StudentCatalogSingleton.Instance;
            ManageStudentHandler = new ManageStudentHandler(this);
            _removeCommand = new RelayCommand(ManageStudentHandler.RemoveStudent, StudentIsSelected);
            _updateCommand = new RelayCommand(ManageStudentHandler.UpdateStudent, StudentIsSelected);
            _saveCommand = new RelayCommand(ManageStudentHandler.SaveStudentsAsync);
            _loadCommand = new RelayCommand(ManageStudentHandler.LoadPersonsAsync);
        }

        public bool StudentIsSelected()
        {
            return SelectedStudent != null;
        }

        private ICommand _removeCommand;

        public ICommand RemoveCommand
        {
            get { return _removeCommand; }
            set { _removeCommand = value; }
        }

        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
            set { _updateCommand = value; }
        }

        public ManageStudentHandler ManageStudentHandler { get; set; }


        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
            set { _saveCommand = value; }
        }

        private ICommand _loadCommand;

        public ICommand LoadCommand
        {
            get { return _loadCommand; }
            set { _loadCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
