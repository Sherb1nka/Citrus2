using Microsoft.EntityFrameworkCore;
using CitrusWeb.DataAccess.DomainObjects;

namespace CitrusWeb.Shared.DataAccess
{
    public interface IUnitOfWork
    {
        DbSet<PresentationDO> Presentations { get; set; }

        DbSet<PresentationSheetDO> PresentationSheets { get; set; }

        DbSet<VideoDO> Videos { get; set; }

        Task CommitAsync();
    }
}
