using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitrusWeb.DataAccess.DomainObjects;

public partial class PresentationSheetDO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? PresentationId { get; set; }

    public string? ImgUrl { get; set; }

    public string? HtmlText { get; set; }

    public virtual PresentationDO? Presentation { get; set; }
}
