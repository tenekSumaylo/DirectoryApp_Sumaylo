using DirectoryApp_Sumaylo.ViewModels;

namespace DirectoryApp_Sumaylo;

public partial class RegisterPage : ContentPage
{
	public RegisterViewModel ViewModel { get; set; }
	public RegisterPage()
	{
		InitializeComponent();
		ViewModel = new RegisterViewModel();
		BindingContext = ViewModel;
		Shell.Current.Title = "Register Page";
	}
}