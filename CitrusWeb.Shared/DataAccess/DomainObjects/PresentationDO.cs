using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CitrusWeb.DataAccess.DomainObjects;

public partial class PresentationDO
{
    [Key]
    public int Id { get; set; }

    public int? VideoId { get; set; }

    public virtual ICollection<PresentationSheetDO> PresentationSheets { get; set; } = new List<PresentationSheetDO>();

    public virtual VideoDO? Video { get; set; }
}
