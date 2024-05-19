using AnimeShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeShop.Dal.Interfaces
{
    public class DataAccessConfigSectionDev: IConfigSection
    {
        public static readonly string Name = "dataAccess";

        public string ConnectionString { get; set; } = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=qwe123";
    }
}
