using System;

namespace AnimeShop.Common.DBModels
{
    public class Discount
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}

