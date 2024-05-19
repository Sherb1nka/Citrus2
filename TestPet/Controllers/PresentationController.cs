using CitrusWeb.Shared.DTOs;
using CitrusWeb.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestPet.Controllers
{
    [Route("api/presentation")]
    [ApiController]
    public class PresentationController : ControllerBase
    {
        private readonly IPresentationService _presentationService;

        public PresentationController(IPresentationService presentationService)
        {
            _presentationService = presentationService;
        }

        [HttpGet]
        [Route("getAllProducts")]
        [AllowAnonymous]
        public async Task<List<PresentationDTO>> GetAllProducts()
        {
            var presentations = await _presentationService.GetAllPresentations();

            return presentations;
        }

        [HttpPost]
        [Route("addPresentation")]
        [AllowAnonymous]
        public async Task<PresentationDTO> AddPresentationAsync(PresentationDTO presentation)
        {
            return await _presentationService.AddPresentation(presentation);
        }

    }
}
