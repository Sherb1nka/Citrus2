using Microsoft.EntityFrameworkCore;

namespace Services.Presentation
{
    public class PresentationService/* : IPresentationService*/
    {
        private readonly IUnitOfWork _unitOfWork;

        public PresentationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<PresentationModel> AddPresentation(PresentationModel presentationDto)
        //{
        //}

        //public async Task<List<PresentationModel>> GetAllPresentations()
        //{
        //}

        private IQueryable<PresentationModel> GetPresentationQuerry()
        {
            return _unitOfWork.Presentations
                .Include(x => x.PresentationSheets)
                .Include(x => x.Video);
        }
    }
}
