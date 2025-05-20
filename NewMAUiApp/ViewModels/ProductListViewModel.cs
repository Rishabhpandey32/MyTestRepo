using System.Collections.ObjectModel;
using System.Windows.Input;
using NewMAUiApp.Models;
using NewMAUiApp.Services;

namespace NewMAUiApp.ViewModels;

public class ProductListViewModel: BindableObject
{
    private readonly IAPIServices _apiService;
    public ICommand ItemCommand{ get; set; }
    public ObservableCollection<ProductlistModel> productlistModels { get; set; } = new();

    public ProductListViewModel()
    {
        _apiService = new APIServices();
        ItemCommand = new Command((args) =>
            {
                var s= args as ProductlistModel;
                Application.Current.MainPage.Navigation.PushAsync(new DetailsPage(s.id));
            });
    }


    public async Task LoadDataAsync()
    {
        try
        {
            var posts = await _apiService.GetPostsAsync();
            productlistModels.Clear();
            foreach (var post in posts)
            {
                ProductlistModel productlistModel = new ProductlistModel()
                {
                    id = post.id,
                    TapCommand = ItemCommand,
                    ImageUrl = post.ImageUrl,
                    Summary = post.Summary,
                    Title = post.Title
                };
                productlistModels.Add(productlistModel);
            }

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }
    

}
