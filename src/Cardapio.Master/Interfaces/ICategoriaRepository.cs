using Cardapio.Master.Models;
using System.Threading.Tasks;

namespace Cardapio.Master.Interfaces;

public interface ICategoriaRepository
{
    Task Add(Categoria categoria);
}
