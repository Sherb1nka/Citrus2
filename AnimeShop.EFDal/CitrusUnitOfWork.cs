using AnimeShop.Common;
using AnimeShop.Common.DbModels;
using AnimeShop.Common.DBModels;
using AnimeShop.Dal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimeShop.Dal
{
    public class CitrusUnitOfWork : DbContext, IUnitOfWork
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<PresentationSheet> PresentationSheets { get; set; }
        
        private readonly IConfigSection _configSection;

        public CitrusUnitOfWork(
            IConfigSection dataAccessConfigSection)
        {
            _configSection = dataAccessConfigSection;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseNpgsql(_configSection.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            RegistratePresentationSheet(modelBuilder);
            RegistratePresentation(modelBuilder);
            RegistrateVideo(modelBuilder);
        }

        private void RegistrateVideo(ModelBuilder modelBuilder)
        {
            var video = modelBuilder.Entity<Video>();

            video.HasKey(obj => obj.Id);
            video.HasMany(v => v.Presentations);
        }

        private void RegistratePresentation(ModelBuilder modelBuilder)
        {
            var presentation = modelBuilder.Entity<Presentation>();

            presentation.HasKey(obj => obj.Id);
            presentation.HasMany(obj => obj.Sheets);
            presentation.HasOne(obj => obj.Video);
        }

        private void RegistratePresentationSheet(ModelBuilder modelBuilder)
        {
            var presentationSheet = modelBuilder.Entity<PresentationSheet>();

            presentationSheet.HasKey(obj => obj.Id);
            presentationSheet.HasOne(obj => obj.Presentation);
        }
    }
}
