using System;
using NewMAUiApp.Models;

namespace NewMAUiApp.Services;

public interface IAPIServices
{

    Task<List<ProductlistModel>> GetPostsAsync();
    Task <ProductDetailsModel> GetDetailsAsync(int Id);

}
