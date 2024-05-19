using AnimeShop.Common.DbModels;

namespace AnimeShop.Common.DBModels
{
    public class Presentation : DomainObject
    {
        public int Id { get; set; }

        public ICollection<PresentationSheet> Sheets { get; set; }

        public virtual Video Video { get; set; }
    }
}
