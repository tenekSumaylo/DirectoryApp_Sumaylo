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

    public class HomeViewModel : BaseViewModel
    {
        public ICommand goToContacts => new Command( AddContacts );
        public ICommand onBackwards => new Command(ReturnBack);
        public ObservableCollection<ContactPerson> ContactCollectionK { get; set; }
        private ContactService serviceMode;
        public HomeViewModel()
        {
            ServiceMode = new ContactService();
            ContactCollectionK = new ObservableCollection<ContactPerson>();
            ContactCollectionK = ServiceMode.GetData();
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

        private async void AddContacts() { await Shell.Current.GoToAsync(nameof(ContactPage)); }
        private async void ReturnBack() { await Shell.Current.GoToAsync(".."); }
    }
}
