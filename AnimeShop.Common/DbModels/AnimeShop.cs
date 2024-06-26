﻿namespace AnimeShop.Common.DBModels
{
    public class AnimeShop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainUrl { get; set; }
        public DateOnly AssortmentUpdateDate { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}