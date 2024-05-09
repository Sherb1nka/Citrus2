using AnimeShop.Common.DbModels;
using AnimeShop.Dal.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AnimeShop.EFDal;

public class BaseDao<T> : IAsyncDisposable, IDisposable 
    where T : class, IDbModel
{
    protected readonly NpgsqlContext<T> DNpgsqlContext;

    protected BaseDao(NpgsqlContext<T> context)
    {
        DNpgsqlContext = context;
    }

    public async ValueTask DisposeAsync()
    {
        await DNpgsqlContext.DisposeAsync();
    }

    public void Dispose()
    {
        DNpgsqlContext.Dispose();
    }

    public async Task<T> GetObjectByIdAsync(int id)
    {
        return await DNpgsqlContext.Objects.FirstOrDefaultAsync(obj => obj.Id == id);
    }

    public IEnumerable<T> GetAllObjects()
    {
        return DNpgsqlContext.Objects;
    }

    public async Task CreateObjectAsync(T obj)
    {
        await DNpgsqlContext.AddAsync(obj);
        await DNpgsqlContext.SaveChangesAsync();
    }

    public async Task<bool> RemoveOject(int id)
    {
        var obj = await DNpgsqlContext.Objects.FirstOrDefaultAsync(obj => obj.Id == id);
        DNpgsqlContext.Objects.Remove(obj);

        return await DNpgsqlContext.SaveChangesAsync() != 0;
    }

    public async Task UpdateObject(T obj)
    {
        DNpgsqlContext.Update(obj);
        await DNpgsqlContext.SaveChangesAsync();
    }

}