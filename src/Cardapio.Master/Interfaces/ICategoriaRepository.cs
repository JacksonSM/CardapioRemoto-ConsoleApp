using Cardapio.Master.Models;

namespace Cardapio.Master.Interfaces;

public interface ICategoriaRepository
{
    Task AddAsync(Categoria categoria);
    Task<IEnumerable<Categoria>> GetAllAysnc();
    Task<Categoria> GetByIdAysnc(int id);
}
