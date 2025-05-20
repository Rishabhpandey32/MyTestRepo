using System;
using System.Windows.Input;

namespace NewMAUiApp.Models;

public class ProductlistModel
{
    public int id { get; set; }
    public string ImageUrl { get; set; }
    public ICommand TapCommand { get; set; }
    public string Summary { get; set; }
    public string Title { get; set; }
    
}
