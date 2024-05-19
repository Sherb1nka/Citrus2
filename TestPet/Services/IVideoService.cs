using CitrusWeb.Api.DataAccess.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrusWeb.Shared.Services
{
    public interface IVideoService
    {
        Task<VideoModel> GetVideoById(int id);

        Task<VideoModel> AddVideo(VideoModel video);
    }
}
