using AnimeShop.Common.DbModels;

namespace AnimeShop.Common.DBModels
{
    public class Presentation : IDbModel
    {
        public int Id { get; set; }

        public IEnumerable<PresentationSheet> Sheets { get; set; }

        public virtual Video Video { get; set; }
    }
}
