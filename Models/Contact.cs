using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp_Sumaylo.Models
{
    public class ContactPerson : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string ID;
        private string firstName;
        private string lastName;
        private string email;
        private string schoolProgram;
        private string course;
        private string mobileNo;
        private string type;

        public ContactPerson()
        {
            PersonID = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            Email = String.Empty;
            SchoolProgram = String.Empty;
            Course = String.Empty;
            Type = String.Empty;
            MobileNo = String.Empty;
 
        }

        public string Type
        {
            get => type;
            set
            {
                type = value;
            }
        }
        public string PersonID
        {
            get => ID;
            set
            {
                ID = value;
                OnPropertyChanged(nameof(PersonID));
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

        public string SchoolProgram
        {
            get => schoolProgram;
            set
            {
                schoolProgram = value;
                OnPropertyChanged(nameof(SchoolProgram));
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


        public void ClearAllFields()
        {
            PersonID = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Type = string.Empty;
            SchoolProgram = string.Empty;
            Course = string.Empty;
            MobileNo = string.Empty;

        }
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

