using CitrusWeb.DataAccess.DomainObjects;
using CitrusWeb.Shared.DataAccess;
using CitrusWeb.Shared.DTOs;
using CitrusWeb.Shared.DTOs.Mappings;
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

        public async Task<PresentationDTO> AddPresentation(PresentationDTO presentationDto)
        {
            var presentation = await GetPresentationQuerry()
                .FirstOrDefaultAsync(x => x.Id ==  presentationDto.Id);

            if (presentation == null)
            {
                _unitOfWork.Presentations.Add(presentationDto.ToObj());
            }
            else
            {
                presentation = presentationDto.ToObj();
                _unitOfWork.Presentations.Update(presentation);
            }

            await _unitOfWork.CommitAsync();

            return (await GetPresentationQuerry().FirstOrDefaultAsync(x => x.Id == presentationDto.Id)).ToDto();
        }

        public async Task<List<PresentationDTO>> GetAllPresentations()
        {
            var result = await _unitOfWork.Presentations
                .Include(x => x.PresentationSheets)
                .Include(x => x.Video)
                .ToListAsync();

            return result.Select(p => p.ToDto()).ToList();
        }

        private IQueryable<PresentationDO> GetPresentationQuerry()
        {
            return _unitOfWork.Presentations
                .Include(x => x.PresentationSheets)
                .Include(x => x.Video);
        }
    }
}
