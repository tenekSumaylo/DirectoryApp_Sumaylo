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
        readonly string filePath = FileSystem.Current.AppDataDirectory + "/USERDATABASE/Users.txt";
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
            var k = new FileInfo( filePath );
            if (FindMatch() == 1 ) {
                Output = "Login Successful";
                await Shell.Current.GoToAsync($"{nameof(HomePage)}?StudentID={StudentID}");
            }
            else if ( FindMatch() == 2 || k.Length == 0 )
            {
                Output = "User does not exist. Please Register";
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

        int FindMatch()
        {
            int k = 0;
            serviceLog.GetData();
            foreach( Student stud in serviceLog.StudentCollection )
            {
                if ( stud.StudentID == StudentID && stud.Password == Password )
                {
                    return 1;
                }
                else if ( stud.StudentID != StudentID )
                {
                    k = 2;
                }
                else if ( stud.StudentID == StudentID )
                {
                    k = 0;
                }
            }
            return k;
        }
    }
}
