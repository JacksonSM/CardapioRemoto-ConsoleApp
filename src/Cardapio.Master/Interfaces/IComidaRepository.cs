using Cardapio.Master.Models;

namespace Cardapio.Master.Interfaces;
public interface IComidaRepository
{
    void Add(Comida comida);
    IEnumerable<Comida> GetAll();
    Comida GetById(int id);
    void Update(int id, Comida comida);
}
