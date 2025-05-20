using NewMAUiApp.Models;
using NewMAUiApp.ViewModels;

namespace NewMAUiApp;

public partial class DetailsPage : ContentPage
{
	private int id;
	public DetailsPage(int Id)
	{
		InitializeComponent();
		id = Id;
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		DVM.LoadDataAsync(id);
    }
}