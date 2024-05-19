using System.ComponentModel.DataAnnotations.Schema;

namespace CitrusWeb.Shared.DTOs
{
    public class PresentationDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public List<PresentationSheetDTO> PresentationSheets { get; set; }

        public int VideoId { get; set; }
    }
}
