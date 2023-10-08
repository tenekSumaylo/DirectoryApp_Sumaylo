using DirectoryApp_Sumaylo.Models;
using DirectoryApp_Sumaylo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DirectoryApp_Sumaylo.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public ContactPerson ContactP { get; set; }
        private bool studentCheck;
        private bool facultyCheck;
        public ICommand OnReset => new Command(OnResetForm);
        public ICommand OnSubmit => new Command(DisplayMessage);
        public ContactService ServiceMode;
        public ContactViewModel()
        {
            ServiceMode = new ContactService();
            ContactP = new ContactPerson();
        }

        public async void GoBack() => await Shell.Current.GoToAsync("HomePage"); 

        private void OnResetForm()
        {
            SelectedIndex1 = 0;
            SelectedIndex3 = 0;
            ContactP.ClearAllFields();
        }
        public bool StudentCheck { 
            get => studentCheck; 
            set { studentCheck = value; OnPropertyChanged(nameof(StudentCheck)); }
        }
        public bool FacultyCheck
        {
            get => facultyCheck;
            set {facultyCheck = value; OnPropertyChanged(nameof(FacultyCheck)); }
        }
        private int ValidateForm()
        {
            if (!CheckNumbers(ContactP.PersonID)  || string.IsNullOrEmpty(ContactP.FirstName) || string.IsNullOrEmpty(ContactP.LastName) || !EmailCheck(ContactP.Email) ||  SelectedIndex1 == 0 || SelectedIndex2 == 0 )
            {
                return -1;
            }
            else if ( !string.IsNullOrEmpty( ContactP.MobileNo ) && !CheckNumbers(ContactP.MobileNo))
            {
                return -1;
            }
            else if (StudentCheck == false && FacultyCheck == false)
            {
                return -1;
            }

            if (FacultyCheck == true)
                ContactP.Type = "Faculty";
            else
                ContactP.Type = "Student";

            ContactP.Course = Rewrite(SelectedIndex2, SchoolCourse);
            ContactP.SchoolProgram = Rewrite(SelectedIndex1, SchoolDept);
            return 1;
        }

        public string Rewrite(int index, List<string> j)
        {
            int i = 0;

            foreach (string s in j)
            {
                if (index == i) { return s; }
                ++i;
            }
            return "";

        }
        public void DisplayMessage()
        {

            if (ValidateForm() == -1)
            {
                _ = Shell.Current.DisplayAlert("Error", "Invalid input. Please complete all required fields.", "Close");
            }
            else
            {
                _ = Shell.Current.DisplayAlert("SUCCESS!!!", "SUCCESSFUL REGISTRATION", "Close");
                ServiceMode.AddData(ContactP, ContactP.PersonID);
                GoBack();
            }
        }
    }
}
