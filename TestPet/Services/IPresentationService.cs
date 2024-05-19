using CitrusWeb.Api.DataAccess.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrusWeb.Shared.Services
{
    public interface IPresentationService
    {
        Task<List<PresentationModel>> GetAllPresentations();

        Task<PresentationModel> AddPresentation(PresentationModel presentationDto);
    }
}
