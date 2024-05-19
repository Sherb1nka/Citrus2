using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrusWeb.Shared.DTOs
{
    public class VideoDTO
    {
        public int? Id { get; set; }

        public List<PresentationDTO> Presentations { get; set; }
    }
}
