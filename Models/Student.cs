using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp_Sumaylo.Models
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string studentID;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string schoolProgram;
        private string course;
        private string yearLevel;
        private string gender;
        private string birthDate;
        private string mobileNo;
        private string city;

        public Student()
        {
            StudentID = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            Email = String.Empty;
            Password = String.Empty;
            SchoolProgram = String.Empty;
            Course = String.Empty;
            YearLevel = String.Empty;
            Gender = String.Empty;
            BirthDate = String.Empty;
            MobileNo = String.Empty;
            City = String.Empty;
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

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));

            }
        }

        public string Course
        {
            get => course;
            set
            {
                course = value;
                OnPropertyChanged(nameof(Course));
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

        public string SchoolProgram
        {
            get => schoolProgram;
            set
            {
                schoolProgram = value;
                OnPropertyChanged(nameof(SchoolProgram));
            }
        }

        public string YearLevel
        {
            get => yearLevel;
            set
            {
                yearLevel = value;
                OnPropertyChanged(nameof(YearLevel));
            }
        }

        public string Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public string BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        public string MobileNo
        {
            get => mobileNo;
            set
            {
                mobileNo = value;
                OnPropertyChanged(nameof(MobileNo));
            }
        }

        public string City
        {
            get => city;
            set
            {

                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public void ClearAllFields()
        {
            StudentID = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            SchoolProgram = string.Empty;
            Course = string.Empty;
            YearLevel = string.Empty;
            Gender = string.Empty;
            BirthDate = string.Empty;
            MobileNo = string.Empty;
            City = string.Empty;
        }
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
