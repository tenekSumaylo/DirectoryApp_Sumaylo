using DirectoryApp_Sumaylo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DirectoryApp_Sumaylo.Services
{
    public class ContactService
    {
        private ObservableCollection<ContactPerson> contactP;
        string filePath = FileSystem.Current.AppDataDirectory + "/USERDATABASE/";
        public ContactService()
        {
            ContactP = new ObservableCollection<ContactPerson>();
        }

        public ObservableCollection<ContactPerson> ContactP
        {
            get => contactP;
            set
            {
                contactP = value;
            }
        }
        public ObservableCollection<ContactPerson> GetData( string ID )
        {
            var k = new FileInfo(filePath + $"S[{ID}].txt");
            if ( !File.Exists(filePath + $"S[{ID}].txt" ) )
            {
                return new ObservableCollection<ContactPerson>();
            }
            if (k.Length == 0)
                return new ObservableCollection<ContactPerson>();
            string json = File.ReadAllText(filePath + $"S[{ID}].txt");
            ContactP = JsonSerializer.Deserialize<ObservableCollection<ContactPerson>>(json);
            return ContactP;
        }


        public void AddData(ContactPerson ContactK, string data, string ID)
        {
            if (ContactK != null)
            {
                GetData( ID );
                ContactP.Add(ContactK);
                var saveToFile = string.Empty;
                var saveID = string.Empty;
                saveToFile = JsonSerializer.Serialize(ContactP);
                File.WriteAllText(filePath + $"S[{ID}].txt", saveToFile);

            }
        }
    }
}

