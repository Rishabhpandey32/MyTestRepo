using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using NewMAUiApp.Models;
using NewMAUiApp.Services;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace NewMAUiApp.ViewModels;

public class ProductDetailViewModel : BindableObject
{
    APIServices _apiService;
    public Command ShareCommand { get; set; }

    public ProductDetailViewModel()
    {
        _apiService = new APIServices();
        ShareCommand = new Command(async() =>
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {
    Title = "Share ",
    Text = Title+ " , " +Summary+" , "+ Price
});
        });

    }

    public async Task LoadDataAsync(int Id)
    {
        try
        {
            var posts = await _apiService.GetDetailsAsync(Id);
            Price = posts.price;
            Title = posts.title;
            Description = posts.description;
            Summary = posts.summary;
            ImageUrl = posts.imageUrl;

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

   
    
    private string price;
    public string Price
    {
        get { return price; }
        set
        {
            if (price != value)
            {
                price = value;
                OnPropertyChanged();
            }
        }
    }
    private string description;
    public string Description
    {
        get { return description; }
        set
        {
            if (description != value)
            {
                description = value;
                OnPropertyChanged();
            }
        }
    }
    private string summary;
    public string Summary
    {
        get { return summary; }
        set
        {
            if (summary != value)
            {
                summary = value;
                OnPropertyChanged();
            }
        }
    }
    private string title;
    public string Title
    {
        get { return title; }
        set
        {
            if (title != value)
            {
                title = value;
                OnPropertyChanged();
            }
        }
    }
    private string imageUrl;
    public string ImageUrl
    {
        get { return imageUrl; }
        set
        {
            if (imageUrl != value)
            {
                imageUrl = value;
                OnPropertyChanged();
            }
        }
    }
}
