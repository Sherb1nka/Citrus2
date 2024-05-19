using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitrusWeb.Api.DataAccess.DomainObjects;

public partial class VideoModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public virtual ICollection<PresentationModel> Presentations { get; set; } = new List<PresentationModel>();
}
