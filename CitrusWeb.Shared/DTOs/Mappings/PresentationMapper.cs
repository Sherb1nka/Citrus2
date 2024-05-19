using CitrusWeb.DataAccess.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrusWeb.Shared.DTOs.Mappings
{
    public static class PresentationMapper
    {
        public static PresentationDTO ToDto(this PresentationDO obj)
        {
            return new PresentationDTO()
            {
                Id = obj.Id,
                VideoId = obj.Video.Id,
                PresentationSheets = obj.PresentationSheets.Select(ps => ps.ToDto()).ToList(),
            };
        }

        public static PresentationDO ToObj(this PresentationDTO dto)
        {
            return new PresentationDO()
            {
                VideoId = dto.VideoId,
                PresentationSheets = dto.PresentationSheets.Select(ps => ps.ToObj()).ToList(),
            };
        }
    }
}
