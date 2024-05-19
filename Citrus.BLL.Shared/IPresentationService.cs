using AnimeShop.Common.DBModels;

namespace Citrus.BLL.Shared
{
    public interface IPresentationService
    {
       Task<List<Presentation>> GetAllPresentationsAsync();
    }
}
