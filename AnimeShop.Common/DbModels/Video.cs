using AnimeShop.Common.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeShop.Common.DbModels
{
    public class Video : IDbModel
    {
        public int Id { get; set; }

        public IEnumerable<Presentation> Presentations { get; set; }
    }
}
