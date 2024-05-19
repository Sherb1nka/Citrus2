using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitrusWeb.DataAccess.DomainObjects;

public partial class VideoDO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public virtual ICollection<PresentationDO> Presentations { get; set; } = new List<PresentationDO>();
}
