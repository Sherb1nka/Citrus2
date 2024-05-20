using System.ComponentModel.DataAnnotations.Schema;

namespace CitrusWeb.Api.DataAccess.DomainObjects;

public partial class PresentationSheetModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int PresentationId { get; set; }

    public string? ImgUrl { get; set; }

    public string? HtmlText { get; set; }

    public int? TimeCodeHours { get; set; }

    public int? TimeCodeMinutes { get; set; }

    public int? TimeCodeSeconds { get; set; }

    public virtual PresentationModel? Presentation { get; set; }
}
