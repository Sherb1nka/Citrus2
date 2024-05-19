using CitrusWeb.Api.DataAccess.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace CitrusWeb.Api.DataAccess
{
    public class CitrusUnitOfWork : DbContext, IUnitOfWork
    {
        private readonly IDataAccessConfig _dataAccessConfig;

        public virtual DbSet<PresentationModel> Presentations { get; set; }

        public virtual DbSet<PresentationSheetModel> PresentationSheets { get; set; }

        public virtual DbSet<VideoModel> Videos { get; set; }

        public CitrusUnitOfWork(IDataAccessConfig dataAccessConfig)
        {
            _dataAccessConfig = dataAccessConfig;

            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(_dataAccessConfig.ConnectionString);
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }

}

