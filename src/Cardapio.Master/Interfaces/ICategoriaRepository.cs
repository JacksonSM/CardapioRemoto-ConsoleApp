using Cardapio.Master.Models;

namespace Cardapio.Master.Interfaces;

public interface ICategoriaRepository
{
    void Add(Categoria categoria);
    IEnumerable<Categoria> GetAll();
    Categoria GetById(int id);
    void Update(int id, Categoria categoria);
}
