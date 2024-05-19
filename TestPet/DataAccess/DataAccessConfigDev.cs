using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitrusWeb.Api.DataAccess
{
    public class DataAccessConfigDev : IDataAccessConfig
    {
        public string ConnectionString { get; set; } = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=qwe123";
    }
}
