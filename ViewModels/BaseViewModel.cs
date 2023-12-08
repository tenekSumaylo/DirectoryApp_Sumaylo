using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DirectoryApp_Sumaylo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    { 
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime _date;
        public static bool CheckNumbers(string word) => Regex.IsMatch(word, @"^\d+$") ? true : false;
        protected static bool EmailCheck(string word) => new EmailAddressAttribute().IsValid(word);
        private List<string> schoolDept;
        private List<string> schoolCourse;
        private int selectedIndex1;
        private int selectedIndex2;
        private int selectedIndex3;
        public List<string> Year { get; set; }
        public BaseViewModel() {
            Year = new List<string>() { "+-SELECT-+", "1st", "2nd", "3rd", "4th" };
            SchoolDept = Schools();
            SchoolCourse = SchoolPrograms(0);
            SelectedIndex1 = 0;
            SelectedIndex2 = 0;
            SelectedIndex3 = 0;
        }

        public int SelectedIndex3
        {
            get => selectedIndex3;
            set
            {
                selectedIndex3 = value;
                OnPropertyChanged(nameof(SelectedIndex3));
            }
        }
        public List<string> SchoolDept
        {
            get => schoolDept;
            set
            {
                schoolDept = value;
                SchoolCourse = SchoolPrograms( SelectedIndex1 );
                OnPropertyChanged(nameof(SchoolDept));
            }
        }

        public int SelectedIndex1
        {
            get => selectedIndex1;
            set
            {
                selectedIndex1 = value;
                SchoolCourse = SchoolPrograms(value);
                SelectedIndex2 = 0;
                OnPropertyChanged(nameof(SelectedIndex1));
            }
        }

        public int SelectedIndex2
        {
            get => selectedIndex2;
            set
            {
                selectedIndex2 = value;
                OnPropertyChanged(nameof(SelectedIndex2));
            }
        }

        public List<string> SchoolCourse
        {
            get => schoolCourse;
            set
            {
                schoolCourse = value;
                OnPropertyChanged( nameof(SchoolCourse));
            }
        }
        public DateTime DateTa
        {
            get => _date;
            set
            {
                _date = value;
            }
        }

    public static List<string> Schools() => new List<string>() { "+-SELECT-+", "School of Allied Medical Sciences", "School of Arts and Sciences", "School of Business and Management", "School of Computer Studies", "School of Education", "School Of Engineering" };

    public static List<string> SchoolPrograms(int index) {
            if (index == 1)
            {
                return new List<string>() { "Bachelor of Science in Nursing", "Bachelor of of Science in Medical Technology" };
            }
            else if (index == 2)
            {
                return new List<string>() { "Bachelor of Arts in Communication", "Bachelor of Arts in English Language Studies", "Bachelor of Arts in Journalism", "Bachelor of Arts in Marketing Communication", "Bachelor of Science in Biology major in Medical Biology", "Bachelor of Sience in Biology major in Microbiology", "Bachelor of Arts in Political Science", "Bachelor of Arts in Internation Studies", "Bachelor of Arts in Philosophy", "Bachelor of Science in Psychology" };
            }
            else if (index == 3)
            {
                return new List<string>() { "Bachelor of Science in Business Administration - Operation Management", "Bachelor of Science in Business Administration - Human Resource Development Management", "Bachelor of Science in Business Management - Marketing Management", "Bachelor of Science in Business Management - Financial Management", "Bachelor of Science in Entrepreneurship", "Bachelor of Science in Accountancy", " Bachelor of Science in Management Accounting", "Bachelor of Science in Hospitality Management", "Bachelor of Science in Tourism", "Bachelor of Science in Hospitality Management - Food and Beverages", "Bachelor of Science in Hospitality Management", "Tourism Associate Degree" };
            }
            else if (index == 4)
            {
                return new List<string>() { "Bachelor of Science in Computer Science", "Bachelor of Science in Information Technology", "Bachelor of Science in Information Systems", "Associate Degree Computer Technology", "Entertainment and Multimedia Computing" };
            }
            else if (index == 5)
            {
                return new List<string>() { "Bachelor of Elementary Education", "Bachelor of Early Chilhood Education", "Bachelor of Physical Education", "Bachelor of Secondary Education Major in English", "Bachelor of Secondary Education Major in Filipino", "Bachelor of Secondary Education Major in Mathematics", "Bachelor of Secondary Education Major in Science", "Bachelor of Special Needs Education - Generalist", "Bachelor of Special Needs Education Major in Early Childhood Education", "Bachelor of Special Needs Education Major in Elementary School Teaching" };
            }
            else if (index == 6)
            {
                return new List<string>() { "Bachelor of Science in Civil Engineering", "Bachelor of Science in Computer Engineering", "Bachelor of Science in Electrical Engineering", "Bachelor of Science in Electronics Engineering", "Bachelor of Science in Industrial Engineering", "Bachelor of Science in Mechanical Engineering" };
            }
            else
            {
                return new List<string>() { "+-SELECT-+" };
            }
        }
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
