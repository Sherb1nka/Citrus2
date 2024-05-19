using CitrusWeb.DataAccess.DomainObjects;
using CitrusWeb.Shared.DataAccess;
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

        public async Task<VideoDO> GetVideoById(int id)
        {
            var obj = await _unitOfWork.Videos
                .Include(x => x.Presentations)
                .FirstOrDefaultAsync(x => x.Id == id);

            return obj;
            
        }
    }
}
