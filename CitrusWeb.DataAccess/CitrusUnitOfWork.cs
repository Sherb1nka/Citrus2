using CitrusWeb.DataAccess.DomainObjects;
using CitrusWeb.Shared.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CitrusWeb.DataAccess
{
    public class CitrusUnitOfWork : DbContext, IUnitOfWork
    {
        private readonly IDataAccessConfig _dataAccessConfig;

        public virtual DbSet<PresentationDO> Presentations { get; set; }

        public virtual DbSet<PresentationSheetDO> PresentationSheets { get; set; }

        public virtual DbSet<VideoDO> Videos { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

            modelBuilder.Entity<PresentationDO>(entity =>
            {
                entity.ToTable("Presentation");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Video).WithMany(p => p.Presentations)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<PresentationSheetDO>(entity =>
            {
                entity.ToTable("PresentationSheet");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.HtmlText).HasColumnType("character varying");
                entity.Property(e => e.ImgUrl).HasColumnType("character varying");

                entity.HasOne(d => d.Presentation).WithMany(p => p.PresentationSheets)
                    .HasForeignKey(d => d.PresentationId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<VideoDO>(entity =>
            {
                entity.ToTable("Video");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }

}

