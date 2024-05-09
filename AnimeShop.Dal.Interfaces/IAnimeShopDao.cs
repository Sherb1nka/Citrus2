using AnimeShop.Common.DBModels;

namespace AnimeShop.Dal.Interfaces
{
    public interface IAnimeShopDao
    {
        Task<IEnumerable<Product>> GetProductsOfAnimeShopAsync(int id);
        IEnumerable<Common.DBModels.AnimeShop> GetAllAnimeShops();
        Task CreateAnimeShopAsync(Common.DBModels.AnimeShop animeShop);
        Task<bool> RemoveAnimeShopAsync(int id);
        Task UpdateAnimeShopAsync(Common.DBModels.AnimeShop animeShop);
    }
}
