using DirectoryApp_Sumaylo.ViewModels;

namespace DirectoryApp_Sumaylo;

public partial class HomePage : ContentPage
{
	public HomeViewModel viewModel { get; set; }
	public HomePage()
	{
		viewModel = new HomeViewModel();
		BindingContext = viewModel;
		InitializeComponent();
		Shell.Current.Title = "Home";
	}
}