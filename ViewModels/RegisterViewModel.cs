using DirectoryApp_Sumaylo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.RegularExpressions;
using DirectoryApp_Sumaylo;
using DirectoryApp_Sumaylo.Services;

namespace DirectoryApp_Sumaylo.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        JSONService _SaveService;
        private string confirmPass;
        public ICommand OnReturn => new Command(ReturnToMain);
        public ICommand OnReset => new Command(OnResetForm);
        public ICommand OnSubmit => new Command(DisplayMessage);
        public Student StudInfo { get; set; }
        private bool maleCheck;
        private bool femaleCheck;

        public RegisterViewModel()
        {
            DateTa = DateTime.Now;
            StudInfo = new Student();
            SchoolCourse = SchoolPrograms( 0 );
            _SaveService = new JSONService();
        }

        public bool MaleCheck
        {
            get => maleCheck;
            set { 
                maleCheck = value;
                OnPropertyChanged( nameof( MaleCheck ) );
            }
        }

        public bool FemaleCheck
        {
            get => femaleCheck;
            set
            {
                femaleCheck = value;
                OnPropertyChanged( nameof( FemaleCheck ) );
            }
        }

        public string ConfirmPass { 
            get => confirmPass; 
            set
            {
                confirmPass = value;
                OnPropertyChanged(nameof( ConfirmPass));
            }
        }

        public async void ReturnToMain() { await Shell.Current.GoToAsync(".."); Shell.Current.Title = "Login Page"; }

        private int ValidateForm()
        {
            if (isExistingUser())
            {
                return 0;
            }
            else if (!CheckNumbers(StudInfo.StudentID) || string.IsNullOrEmpty(StudInfo.StudentID) || string.IsNullOrEmpty(StudInfo.FirstName) || string.IsNullOrEmpty(StudInfo.LastName) || !EmailCheck(StudInfo.Email) || string.IsNullOrEmpty(StudInfo.Email) || string.IsNullOrEmpty(StudInfo.Password) || string.IsNullOrEmpty(ConfirmPass) || SelectedIndex1 == 0 || SelectedIndex3 == 0) {
                return -1;
            }
            else if (!string.IsNullOrEmpty(StudInfo.MobileNo) && !CheckNumbers(StudInfo.MobileNo))
            {
                return -1;
            }
            else if (StudInfo.Password != ConfirmPass)
            {
                return -1;
            }
            else if ( StudInfo.Password.Length <= 7 )
            {
                return -1;
            }
            else if (MaleCheck == false && FemaleCheck == false)
            {
                return -1;
            }

            if (MaleCheck == true)
                StudInfo.Gender = "Male";
            else
                StudInfo.Gender = "Female";

            StudInfo.YearLevel = Rewrite(SelectedIndex3, Year);
            StudInfo.Course = Rewrite(SelectedIndex2, SchoolCourse);
            StudInfo.SchoolProgram = Rewrite(SelectedIndex1, SchoolDept);
            StudInfo.BirthDate = DateTa.ToString();
            return 1;
        }

        public void DisplayMessage()
        {
            
            if ( ValidateForm() == -1 )
            {
                _ = Shell.Current.DisplayAlert("Error", "Invalid input. Please complete all required fields.", "Close");
            }
            else if ( ValidateForm() == 0 )
            {
                _ = Shell.Current.DisplayAlert("Error", "ID and user already exists. Please enter a new user to register", "Close");
            }
            else
            {
                _ = Shell.Current.DisplayAlert("SUCCESS!!!", "SUCCESSFUL REGISTRATION", "Close");
                _SaveService.AddData(StudInfo, StudInfo.StudentID);
                ReturnToMain();
            }
        }

        public string Rewrite( int index, List<string> j )
        {
            int i = 0;

            foreach ( string s in j )
            {
                if ( index == i ) { return s; }
                ++i;
            }
            return "";

        }

        private void OnResetForm()
        {
            SelectedIndex1 = 0;
            SelectedIndex3 = 0;
            DateTa = DateTime.Now;
            MaleCheck = false;
            FemaleCheck = false;
            StudInfo.ClearAllFields();
        }

        private bool isExistingUser()
        {
            foreach ( Student i in _SaveService.StudentCollection)
            {
                if ( i.StudentID.Equals( StudInfo.StudentID ) )
                {
                    return true;
                }
            }
            return false; 
        }
    }

}
