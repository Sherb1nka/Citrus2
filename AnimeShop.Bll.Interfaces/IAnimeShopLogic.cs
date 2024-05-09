using AnimeShop.Common.DBModels;

namespace AnimeShop.Bll.Interfaces;

public interface IAnimeShopLogic
{
    Task<Common.DBModels.AnimeShop?> GetAnimeShopByIdAsync(int id);
    Task<IEnumerable<Product>> GetProductsOfAnimeShopsAsync(int id);
    IEnumerable<Common.DBModels.AnimeShop> GetAllAnimeShops();
    Task CreateAnimeShopAsync(Common.DBModels.AnimeShop animeShop);
    Task<bool> RemoveAnimeShopAsync(int id);
    Task UpdateAnimeShopAsync(Common.DBModels.AnimeShop animeShop);
}