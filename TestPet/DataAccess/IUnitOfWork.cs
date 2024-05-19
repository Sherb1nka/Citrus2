using CitrusWeb.Api.DataAccess.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace CitrusWeb.Api.DataAccess
{
    public interface IUnitOfWork
    {
        DbSet<PresentationModel> Presentations { get; set; }

        DbSet<PresentationSheetModel> PresentationSheets { get; set; }

        DbSet<VideoModel> Videos { get; set; }

        Task CommitAsync();

    }
}
