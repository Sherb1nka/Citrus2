using Microsoft.EntityFrameworkCore;
using AnimeShop.Common.DBModels;
using AnimeShop.Common.DbModels;

namespace AnimeShop.Dal.DbContexts
{
    public sealed class NpgsqlContext<T> : DbContext where T : class
	{
		public NpgsqlContext(DbContextOptions<NpgsqlContext<T>> options)
			:base(options)
		{
			// Database.EnsureDeleted();
			Database.EnsureCreated();
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			RegistrateUser(modelBuilder);
			RegistrateProduct(modelBuilder);
			RegistrateAnimeShop(modelBuilder);
            RegistrateVideo(modelBuilder);
            RegistratePresentation(modelBuilder);
            RegistratePresentationSheet(modelBuilder);
        }

        private void RegistrateUser(ModelBuilder modelBuilder)
		{
			var users = modelBuilder.Entity<User>();

			users.HasKey(u => u.Id);
			users.Property(u => u.FirstName).IsRequired();
			users.Property(u => u.SecondName).IsRequired();
			users.Property(u => u.Email).IsRequired();
			users.Property(u => u.Password).IsRequired();
		}

		private void RegistrateProduct(ModelBuilder modelBuilder)
		{
			var products = modelBuilder.Entity<Product>();

			products.HasKey(p => p.Id);
			products.Property(p => p.Name).IsRequired();
			products.Property(p => p.Amount).IsRequired();
			products.Property(p => p.Seasonal).IsRequired();
			products.Property(p => p.ProductType).IsRequired();
		}

		private void RegistrateAnimeShop(ModelBuilder modelBuilder)
		{
			var animeshops = modelBuilder.Entity<Common.DBModels.AnimeShop>();

			animeshops.HasKey(a => a.Id);
			animeshops.Property(a => a.Name).IsRequired();
			animeshops.Property(a => a.MainUrl).IsRequired();
			animeshops.Property(a => a.AssortmentUpdateDate).IsRequired();
			animeshops.HasMany(a => a.Products);
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

        public DbSet<T> Objects { get; set; }
    }
}

