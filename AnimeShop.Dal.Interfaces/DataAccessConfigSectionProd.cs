using AnimeShop.Common;

namespace AnimeShop.Dal.Interfaces
{
    public class DataAccessConfigSectionProd: IConfigSection
    {
        public static readonly string Name = "dataAccess";

        public string ConnectionString { get; set; } = "Server=db;Port=54321;Database=postgres;User Id=postgres;Password=qwe123";
    }
}
