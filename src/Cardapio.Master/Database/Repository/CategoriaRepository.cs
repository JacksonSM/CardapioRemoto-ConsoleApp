using Cardapio.Master.Interfaces;
using Cardapio.Master.Models;
using Dapper;
using System.Data;

namespace Cardapio.Master.Database.Repository;
public class CategoriaRepository : ICategoriaRepository
{

    public void Add(Categoria categoria)
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            connection.Open();  
            var query =
                @"INSERT INTO [CardapioDB].[dbo].[Categoria] (Nome) VALUES (@nome)";

            connection.Execute(query, new { nome = categoria.Nome });
        }
    }

    public IEnumerable<Categoria> GetAll()
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            connection.Open();

            var query = "SELECT * FROM [CardapioDB].[dbo].[Categoria];";

            return connection.Query<Categoria>(query);
        }
    }

    public IEnumerable<Categoria> GetAllWithComida()
    {
        var query = @"SELECT * FROM [CardapioDB].[dbo].[Categoria] AS categoria 
                      JOIN [Comida] AS comida ON categoria.Id = comida.CategoriaId";

        using (IDbConnection connection = new DbSession().Connection)
        {
            var categorias = connection.Query<Categoria, Comida, Categoria>(query, (categoria, comida) =>
            {
                categoria.Comidas.Add(comida);
                return categoria;
            });
            return categorias;
        }
    }

    public Categoria GetById(int id)
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            var query = "SELECT * FROM [CardapioDB].[dbo].[Categoria] WHERE Id = @Id";

            var parameters = new { Id = id };

            return connection.QueryFirstOrDefault<Categoria>(query, parameters);
        }
    }

    public void Update(int id, Categoria categoria)
    {
        using (IDbConnection connection = new DbSession().Connection)
        {
            var query =
            @"UPDATE [CardapioDB].[dbo].[Categoria]
            SET [Nome] = @nome
            WHERE Id = @id";

            var parameters = new
            {
                Id = id,
                nome = categoria.Nome
            };
            connection.Execute(query, parameters);
        }
    }
}
