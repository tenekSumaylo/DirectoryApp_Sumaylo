using DirectoryApp_Sumaylo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DirectoryApp_Sumaylo.Services;
using System.Windows.Input;

namespace DirectoryApp_Sumaylo.ViewModels
{
    [QueryProperty(nameof(StudentID), nameof(StudentID))]
    public class HomeViewModel : BaseViewModel
    {
        private string messageOut;
        public ICommand goToContacts => new Command( AddContacts );
        public ICommand onBackwards => new Command(ReturnBack);
        private string studentID;
        private ObservableCollection<ContactPerson> contactCollectionK;
        private ContactService serviceMode;
        string filePath = FileSystem.Current.AppDataDirectory + "/USERDATABASE/";
        public HomeViewModel()
        {
            ServiceMode = new ContactService();
        }

        public ObservableCollection<ContactPerson> ContactCollectionK
        {
            get => contactCollectionK;
            set
            {
                contactCollectionK = value;
                OnPropertyChanged(nameof(ContactCollectionK));
            }
        }

        public string StudentID
        {
            get => studentID;
            set
            {
                studentID = value;
                OnPropertyChanged(nameof(StudentID));
                var k = new FileInfo(filePath + $"S[{StudentID}].txt");
                if (k.Length == 0)
                {
                    MessageOut = "No Contacts";
                    return;
                }
                ContactCollectionK = ServiceMode.GetData( StudentID );
            }
        }

        public string MessageOut
        {
            get => messageOut;
            set
            {
                messageOut = value;
                OnPropertyChanged(nameof(MessageOut));
            }
        }

        public ContactService ServiceMode
        {
            get => serviceMode;
            set
            {
                serviceMode = value;
                OnPropertyChanged(nameof(ServiceMode));
            }
        }

        private async void AddContacts() { await Shell.Current.GoToAsync($"{nameof(ContactPage)}?StudentID={StudentID}"); }
        private async void ReturnBack() { await Shell.Current.GoToAsync(".."); }
    }
}
