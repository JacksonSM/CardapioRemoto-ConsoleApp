using Cardapio.Master.Interfaces;
using Cardapio.Master.Models;
using Dapper;
using System.Data;

namespace Cardapio.Master.Database.Repository;
public class CategoriaRepository : ICategoriaRepository
{
    private readonly DbSession _dbSession;
    public CategoriaRepository()
    {
        _dbSession = new DbSession();
    }
    public async Task Add(Categoria categoria)
    {
        using (IDbConnection connection = _dbSession.Connection)
        {
            connection.Open();  
            var query =
                @"INSERT INTO [CardapioDB].[dbo].[Categoria] (Nome) VALUES (@nome)";

            connection.Execute(query, new { nome = categoria.Nome });
        }
    }
}
