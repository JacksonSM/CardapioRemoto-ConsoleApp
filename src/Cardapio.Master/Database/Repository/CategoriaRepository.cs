using Cardapio.Master.Interfaces;
using Cardapio.Master.Models;
using Dapper;
using System.Data;

namespace Cardapio.Master.Database.Repository;
public class CategoriaRepository : ICategoriaRepository
{

    public async Task AddAsync(Categoria categoria)
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            connection.Open();  
            var query =
                @"INSERT INTO [CardapioDB].[dbo].[Categoria] (Nome) VALUES (@nome)";

            connection.Execute(query, new { nome = categoria.Nome });
        }
    }

    public async Task<IEnumerable<Categoria>> GetAllAysnc()
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            connection.Open();

            var query = "SELECT * FROM [CardapioDB].[dbo].[Categoria];";

            return connection.Query<Categoria>(query);
        }
    }

    public async Task<Categoria> GetByIdAysnc(int id)
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            var query = "SELECT * FROM [CardapioDB].[dbo].[Categoria] WHERE Id = @Id";

            var parameters = new { Id = id };

            return connection.QueryFirstOrDefault<Categoria>(query, parameters);
        }
    }
}
