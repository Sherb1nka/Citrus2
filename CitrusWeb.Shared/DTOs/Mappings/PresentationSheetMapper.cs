using CitrusWeb.DataAccess.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrusWeb.Shared.DTOs.Mappings
{
    public static class PresentationSheetMapper
    {
        public static PresentationSheetDTO ToDto(this PresentationSheetDO obj)
        {
            return new PresentationSheetDTO()
            {
                Id = obj.Id,
                ImgUrl = obj.ImgUrl,
                HtmlText = obj.HtmlText,
                PresentationId = obj.Presentation?.Id,
            };
        }

        public static PresentationSheetDO ToObj(this PresentationSheetDTO dto) 
        {
            return new PresentationSheetDO()
            {
                ImgUrl = dto.ImgUrl,
                HtmlText = dto.HtmlText,
                PresentationId = dto.PresentationId,
            };
        }
    }
}
