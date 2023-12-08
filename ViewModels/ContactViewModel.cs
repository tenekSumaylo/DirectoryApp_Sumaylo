using DirectoryApp_Sumaylo.Models;
using DirectoryApp_Sumaylo.Services;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DirectoryApp_Sumaylo.ViewModels
{
    [QueryProperty(nameof(StudentID), nameof(StudentID))]
    public class ContactViewModel : BaseViewModel
    {
        public ContactPerson ContactP { get; set; }
        private bool studentCheck;
        private bool facultyCheck;
        private string studentID;
        public ICommand OnReset => new Command(OnResetForm);
        public ICommand OnSubmit => new Command(DisplayMessage);
        public ContactService ServiceMode;
        public ContactViewModel()
        {
            ServiceMode = new ContactService();
            ContactP = new ContactPerson();
        }

        public async void GoBack() => await Shell.Current.GoToAsync($"{nameof(HomePage)}?StudentID={StudentID}");

        public string StudentID
        {
            get => studentID;
            set
            {
                studentID = value;
                OnPropertyChanged(nameof(StudentID));
            }
        }

        private void OnResetForm()
        {
            SelectedIndex1 = 0;
            FacultyCheck = false;
            StudentCheck = false;
            ContactP.ClearAllFields();
        }
        public bool StudentCheck { 
            get => studentCheck; 
            set 
            { 
                studentCheck = value; 
                OnPropertyChanged(nameof(StudentCheck));
                if (value == true)
                {
                    SchoolDept = Schools();
                    SelectedIndex1 = 0;
                    SelectedIndex2 = 0;
                }
            }
        }
        public bool FacultyCheck
        {
            get => facultyCheck;
            set {
                facultyCheck = value; 
                OnPropertyChanged(nameof(FacultyCheck));
                if (value == true)
                {
                    SchoolDept = new List<string>() {};
                    SchoolCourse = new List<string>() {};
                }
            }
        }
        private int ValidateForm()
        {
            if (!CheckNumbers(ContactP.PersonID)  || string.IsNullOrEmpty(ContactP.FirstName) || string.IsNullOrEmpty(ContactP.LastName) || !EmailCheck(ContactP.Email) )
            {
                return -1;
            }
            else if ( SelectedIndex1 == 0 && FacultyCheck == false )
            {
                return -1;
            }
            else if ( FacultyCheck == true && ContactP.PersonID.Length != 4 )
            {
                return -1;
            }
            else if ( StudentCheck == true && ContactP.PersonID.Length != 5 )
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
                ServiceMode.AddData(ContactP, ContactP.PersonID, StudentID);
                GoBack();
            }
        }
    }
}
