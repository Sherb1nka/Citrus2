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
            VideoModel obj;
            
            if (!_unitOfWork.Videos.Any(e => e.Id == video.Id))
            {
                obj = _unitOfWork.Videos.Add(video).Entity;
            }
            else
            {
                obj = _unitOfWork.Videos.Update(video).Entity;
            }

            await _unitOfWork.CommitAsync();

            return await GetVideoQuery().FirstOrDefaultAsync(x => x.Id == obj.Id);
        }

        public async Task<VideoModel> GetVideoById(int id)
        {
            var obj = await GetVideoQuery()
                .FirstOrDefaultAsync(x => x.Id == id);

            return obj;
        }

        private IQueryable<VideoModel> GetVideoQuery()
        {
            return _unitOfWork.Videos
                .Include(x => x.Presentations);
        }
    }
}
