using Cardapio.Master.Database.Repository;
using Cardapio.Master.Interfaces;

namespace Cardapio.Master;
public static class DIConteiner
{
    public static ICategoriaRepository InjectCategoriaRepository()
    {
        return new CategoriaRepository();
    }

    public static IComidaRepository InjectComidaRepository()
    {
        return new ComidaRepository();
    }
}
