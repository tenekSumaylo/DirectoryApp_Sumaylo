using DirectoryApp_Sumaylo.ViewModels;

namespace DirectoryApp_Sumaylo
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }
        string FilePath = FileSystem.Current.AppDataDirectory;
        public MainPage()
        {
            Shell.Current.Title = "Login Page";
            InitializeComponent();
            ViewModel = new MainPageViewModel();
            BindingContext = ViewModel;
            if ( !Directory.Exists( FilePath + @"/USERDATABASE"))
            {
                Directory.CreateDirectory(FilePath + @"/USERDATABASE");
                File.Create(FilePath + @"/USERDATABASE/Users.txt");
            }
        }
    }
}