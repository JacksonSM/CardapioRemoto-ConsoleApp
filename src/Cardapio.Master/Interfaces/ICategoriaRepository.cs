using Cardapio.Master.Models;

namespace Cardapio.Master.Interfaces;

public interface ICategoriaRepository
{
    Task Add(Categoria categoria);
    Task<IEnumerable<Categoria>> GetAll();
}
