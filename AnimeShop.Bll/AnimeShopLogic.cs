using AnimeShop.Bll.Interfaces;
using AnimeShop.Common.DBModels;
using AnimeShop.Dal.Interfaces;
using Microsoft.Extensions.Logging;

namespace AnimeShop.Bll;

public class AnimeShopLogic : BaseLogic, IAnimeShopLogic
{
    private readonly IAnimeShopDao _animeShopDao;
    
    public AnimeShopLogic(
        ILogger<AnimeShopLogic> logger,
        IAnimeShopDao animeShopDao
        ) : base(logger)
    {
        _animeShopDao = animeShopDao;
    }

    public async Task<Common.DBModels.AnimeShop?> GetAnimeShopByIdAsync(int id)
    {
        return await _animeShopDao.GetAnimeShopByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsOfAnimeShopsAsync(int id)
    {
        return await _animeShopDao.GetProductsOfAnimeShopAsync(id);
    }

    public IEnumerable<Common.DBModels.AnimeShop> GetAllAnimeShops()
    {
        return _animeShopDao.GetAllAnimeShops();
    }

    public async Task CreateAnimeShopAsync(Common.DBModels.AnimeShop animeShop)
    {
        await _animeShopDao.CreateAnimeShopAsync(animeShop);
    }

    public async Task<bool> RemoveAnimeShopAsync(int id)
    {
        return await _animeShopDao.RemoveAnimeShopAsync(id);
    }

    public async Task UpdateAnimeShopAsync(Common.DBModels.AnimeShop animeShop)
    {
        await _animeShopDao.UpdateAnimeShopAsync(animeShop);
    }
}