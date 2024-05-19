using CitrusWeb.Api.DataAccess;
using CitrusWeb.Api.DataAccess.DomainObjects;
using CitrusWeb.Shared.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Video
{
    public class VideoService : IVideoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideoService(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<VideoModel> AddVideo(VideoModel video)
        {
            var newObj = _unitOfWork.Videos.Add(video);
            await _unitOfWork.CommitAsync();

            return await GetVideoQuerry().FirstOrDefaultAsync(x => x.Id == newObj.Entity.Id);
        }

        public async Task<VideoModel> GetVideoById(int id)
        {
            var obj = await _unitOfWork.Videos
                .Include(x => x.Presentations)
                .FirstOrDefaultAsync(x => x.Id == id);

            return obj;
        }

        private IQueryable<VideoModel> GetVideoQuerry()
        {
            return _unitOfWork.Videos
                .Include(x => x.Presentations);
        }
    }
}
