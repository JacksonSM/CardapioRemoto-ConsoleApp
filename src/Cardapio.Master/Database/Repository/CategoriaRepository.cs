using Cardapio.Master.Interfaces;
using Cardapio.Master.Models;
using Dapper;
using System.Data;

namespace Cardapio.Master.Database.Repository;
public class CategoriaRepository : ICategoriaRepository
{

    public async Task Add(Categoria categoria)
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            connection.Open();  
            var query =
                @"INSERT INTO [CardapioDB].[dbo].[Categoria] (Nome) VALUES (@nome)";

            connection.Execute(query, new { nome = categoria.Nome });
        }
    }

    public async Task<IEnumerable<Categoria>> GetAll()
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            connection.Open();

            var query = "SELECT * FROM [CardapioDB].[dbo].[Categoria];";

            return connection.Query<Categoria>(query);
        }
    }
}
