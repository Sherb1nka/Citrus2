using CitrusWeb.Api.DataAccess;
using CitrusWeb.Api.DataAccess.DomainObjects;
using CitrusWeb.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Services.Presentation
{
    public class PresentationService : IPresentationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PresentationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PresentationModel> AddPresentation(PresentationModel presentation)
        {
            var newObj = _unitOfWork.Presentations.Add(presentation);
            await _unitOfWork.CommitAsync();

            return await GetPresentationQuerry().FirstOrDefaultAsync(x => x.Id == newObj.Entity.Id);
        }

        public Task<List<PresentationModel>> GetAllPresentations()
        {
            throw new NotImplementedException();
        }

        private IQueryable<PresentationModel> GetPresentationQuerry()
        {
            return _unitOfWork.Presentations
                .Include(x => x.PresentationSheets)
                .Include(x => x.Video);
        }
    }
}
