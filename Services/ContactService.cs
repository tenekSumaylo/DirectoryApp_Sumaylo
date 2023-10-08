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
        string filePath = FileSystem.Current.AppDataDirectory + "/CONTACTDATABASE/";
        public ContactService()
        {
            ContactP = new ObservableCollection<ContactPerson>();
            GetData();
        }

        public ObservableCollection<ContactPerson> ContactP
        {
            get => contactP;
            set
            {
                contactP = value;
            }
        }
        public ObservableCollection<ContactPerson> GetData()
        {
            var k = new FileInfo(filePath + "Contacts.txt");
            if ( !File.Exists(filePath + "Contacts.txt" ) || !Directory.Exists( filePath) )
            {
                Directory.CreateDirectory(filePath);
                File.Create(filePath + "Contacts.txt");

            }
            if (k.Length == 0)
                return new ObservableCollection<ContactPerson>();
            string json = File.ReadAllText(filePath + "Contacts.txt");
            ContactP = JsonSerializer.Deserialize<ObservableCollection<ContactPerson>>(json);
            return ContactP;
        }


        public void AddData(ContactPerson ContactK, string data)
        {
            if (ContactK != null)
            {
                GetData();
                ContactP.Add(ContactK);
                var saveToFile = string.Empty;
                var saveID = string.Empty;
                saveToFile = JsonSerializer.Serialize(ContactP);
                saveID = JsonSerializer.Serialize(ContactK);
                File.WriteAllText(filePath + "Contacts.txt", saveToFile);
                File.WriteAllText(filePath + $"S{ContactK.PersonID}", saveID);
            }
        }
    }
}

