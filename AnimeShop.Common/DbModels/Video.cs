using AnimeShop.Common.DBModels;

namespace AnimeShop.Common.DbModels
{
    public class Video : DomainObject   
    {
        public int Id { get; set; }

        public ICollection<Presentation> Presentations { get; set; }
    }
}
