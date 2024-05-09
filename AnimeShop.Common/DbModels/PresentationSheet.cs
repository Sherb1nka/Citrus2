using AnimeShop.Common.DBModels;

namespace AnimeShop.Common.DbModels
{
    public class PresentationSheet : IDbModel
    {
        public int Id { get; set; }

        public string ImgUrl { get; set; }

        public string HtmlText { get; set; }
            
        public virtual Presentation Presentation { get; set; }
    }
}
