using AnimeShop.Common.DBModels;
using AnimeShop.Dal.DbContexts;
using AnimeShop.Dal.Interfaces;
using AnimeShop.EFDal;
using Microsoft.EntityFrameworkCore;

namespace AnimeShop.Dal;

public class AnimeShopDao : BaseDao<Common.DBModels.AnimeShop>, IAnimeShopDao
{
    public AnimeShopDao(NpgsqlContext<Common.DBModels.AnimeShop> context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsOfAnimeShopAsync(int id)
    {
        var animeShop = await GetObjectByIdAsync(id);

        return animeShop.Products;
    }

    public async Task UpdateAnimeShopAsync(Common.DBModels.AnimeShop animeShop)
    {
        DNpgsqlContext.Update(animeShop);
        await DNpgsqlContext.SaveChangesAsync();
    }
}