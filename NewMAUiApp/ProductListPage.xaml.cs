namespace NewMAUiApp;

using NewMAUiApp.ViewModels;

public partial class ProductListPage : ContentPage
{
    private ProductListViewModel _viewModel;
    public ProductListPage()
    {
        InitializeComponent();
        _viewModel = new ProductListViewModel();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDataAsync();
    }
}