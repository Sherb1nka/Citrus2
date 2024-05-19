using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitrusWeb.Api.DataAccess.DomainObjects;

public class PresentationModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int VideoId { get; set; }

    public virtual ICollection<PresentationSheetModel> PresentationSheets { get; set; } = new List<PresentationSheetModel>();

    public virtual VideoModel? Video { get; set; }
}
