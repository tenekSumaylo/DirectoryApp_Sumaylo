using DirectoryApp_Sumaylo.ViewModels;

namespace DirectoryApp_Sumaylo;

public partial class ContactPage : ContentPage
{
	public ContactViewModel ViewModel { get; set; }
	public ContactPage()
	{
		ViewModel = new ContactViewModel();
		BindingContext = ViewModel;
		Shell.Current.Title = "Add Contact";
		InitializeComponent();
	}
}