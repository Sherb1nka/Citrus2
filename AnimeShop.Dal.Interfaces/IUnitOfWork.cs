using AnimeShop.Common.DbModels;
using AnimeShop.Common.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeShop.Dal.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public DbSet<Video> Videos { get; set; }
        
        public DbSet<Presentation> Presentations { get; set; }
        
        public DbSet<PresentationSheet> PresentationSheets { get; set; }
    }
}
