namespace CitrusWeb.Api.DataAccess
{
    public class DataAccessConfigProd : IDataAccessConfig
    {
    public string ConnectionString { get; set; } = "Server=db;Port=54321;Database=postgres;User Id=postgres;Password=qwe123";
    }
}
