using Cardapio.Master.Interfaces;
using Cardapio.Master.Models;
using Dapper;
using System.Data;

namespace Cardapio.Master.Database.Repository;
public class ComidaRepository : IComidaRepository
{
    public void Add(Comida comida)
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            connection.Open();
            var query =
                @"INSERT INTO [CardapioDB].[dbo].[Comida] (Nome, Descricao, Preco, IsAtivo, CategoriaId) 
                VALUES (@nome, @descricao, @preco, @isAtivo, @categoriaId)";

            var parameters = new 
            { 
                nome = comida.Nome, 
                descricao = comida.Descricao, 
                preco = comida.Preco, 
                isAtivo = comida.IsAtivo, 
                categoriaId = comida.CategoriaId
            };

            connection.Execute(query, parameters);
        }
    }

    public IEnumerable<Comida> GetAll()
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            connection.Open();

            var query = "SELECT * FROM [CardapioDB].[dbo].[Comida] WHERE IsAtivo = 1;";

            return connection.Query<Comida>(query);
        }
    }

    public Comida GetById(int id)
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            var query = "SELECT * FROM [CardapioDB].[dbo].[Comida] WHERE Id = @Id";

            var parameters = new { Id = id };

            return connection.QueryFirstOrDefault<Comida>(query, parameters);
        }
    }

    public void Update(int id, Comida comida)
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            var query =
            @"UPDATE [CardapioDB].[dbo].[Comida]
            SET [Nome] = @nome, [Descricao] = @descricao, [Preco] = @preco
            WHERE Id = @id";

            var parameters = new
            {
                Id = id,
                nome = comida.Nome,
                descricao = comida.Descricao,
                preco = comida.Preco
            };
            connection.Execute(query, parameters);
        }
    }
}
