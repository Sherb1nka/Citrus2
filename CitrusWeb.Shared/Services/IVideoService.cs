using CitrusWeb.DataAccess.DomainObjects;
using CitrusWeb.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrusWeb.Shared.Services
{
    public interface IVideoService
    {
        Task<VideoDO> GetVideoById(int id);
    }
}
