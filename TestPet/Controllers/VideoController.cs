using CitrusWeb.Api.DataAccess.DomainObjects;
using CitrusWeb.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CitrusWeb.Api.Controllers
{
    [Route("api/video")]
    [ApiController]
    public class VideoController: ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        [Route("getVideoById")]
        [AllowAnonymous]
        public async Task<VideoModel> GetVideoById(int id)
        {
            var penis =  await _videoService.GetVideoById(id);
            return penis;
        }
    }
}
