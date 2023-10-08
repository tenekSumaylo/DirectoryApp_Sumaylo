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
    public class MainPageViewModel : BaseViewModel
    {
        private string output;
        private string studentID;
        private string password;
        public ICommand OnNavigateToRegister => new Command(NavigateToRegister);
        public ICommand OnLog => new Command(OnLogging);
        JSONService serviceLog;
        public MainPageViewModel() { serviceLog = new JSONService(); }


        public async void NavigateToRegister()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }


        public string StudentID
        {
            get => studentID;
            set
            {
                studentID = value;
                OnPropertyChanged(nameof(StudentID));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Output {
            get => output; 
            set
            {
                output = value;
                OnPropertyChanged(nameof(Output));
            }
        }
        public async void OnLogging()
        {
            if (FindMatch()) {
                Output = "Login Successful";
                await Shell.Current.GoToAsync(nameof(HomePage));
            }
            else if ( string.IsNullOrEmpty(StudentID) || string.IsNullOrEmpty(Password ) )
            {
                Output = $"Username and/or Password should not be empty. Please try again.";
            }
            else
            {
                Output = $"Username and/or Password is incorrect. Please try again.";
            }

        }

        bool FindMatch()
        {
            serviceLog.GetData();
            foreach( Student stud in serviceLog.StudentCollection )
            {
                if ( stud.StudentID == StudentID && stud.Password == Password )
                {
                    return true;
                }
            }

            return false;
        }
    }
}
