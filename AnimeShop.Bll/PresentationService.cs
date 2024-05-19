using AnimeShop.Common.DBModels;
using AnimeShop.Dal.Interfaces;
using Citrus.BLL.Shared;
using Microsoft.EntityFrameworkCore;

namespace AnimeShop.Bll
{
    public class PresentationService : IPresentationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PresentationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Presentation>> GetAllPresentationsAsync()
        {
            return await _unitOfWork.Presentations.ToListAsync();
        }
    }
}
