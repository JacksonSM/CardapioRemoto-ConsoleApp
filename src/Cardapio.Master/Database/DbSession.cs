using Microsoft.Data.SqlClient;

namespace Cardapio.Master.Database;
public sealed class DbSession
{
    public SqlConnection Connection { get; }

    public DbSession()
    {
        Connection = new SqlConnection("Server=localhost;Database=CardapioDB;Trusted_Connection=True; TrustServerCertificate=True;");
    }
}