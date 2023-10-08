using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DirectoryApp_Sumaylo.Models;
using System.IO;

namespace DirectoryApp_Sumaylo.Services
{
    public class JSONService
    {
        private ObservableCollection<Student> studentCollection;
        readonly string filePath = FileSystem.Current.AppDataDirectory + "/USERDATABASE/Users.txt";
        readonly string filePathID = FileSystem.Current.AppDataDirectory + "/USERDATABASE/";

        public JSONService()
        {
            StudentCollection = new ObservableCollection<Student>();
            GetData();
        }

        public ObservableCollection<Student> StudentCollection { 
            get => studentCollection;
            set
            {
                studentCollection = value;
            }
        } 
        public void GetData()
        {
            var k = new FileInfo(filePath);
            if ( !File.Exists( filePath ) || k.Length == 0) {
                return;
            }
            string json = File.ReadAllText(filePath);
            StudentCollection = JsonSerializer.Deserialize<ObservableCollection<Student>>(json);
        }


        public void AddData( Student student, string data )
        {
            if (student != null)
            {
                GetData();
                studentCollection.Add(student);
                var saveToFile = string.Empty;
                var saveID = string.Empty;
                saveToFile = JsonSerializer.Serialize(studentCollection);
                saveID = JsonSerializer.Serialize( student );
                File.WriteAllText(filePath, saveToFile);
                File.WriteAllText( filePathID + $"S{student.StudentID}", saveID );
            }
        }
    }
}
