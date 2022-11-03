using Cardapio.Master;
using Cardapio.Master.Interfaces;
using Cardapio.Master.Models;
using static System.Console;

namespace Cardapio.View.Administrador;
public class CategoriaOptions : IDisposable
{
    ICategoriaRepository _categoriaRepository;

    public CategoriaOptions()
    {
        _categoriaRepository = DIConteiner.InjectCategoriaRepository();
    }

    public void Dispose()
    {
        this.Dispose();
    }

    public async void GerenciarCategoria()
    {
        WriteLine("|=============================================|");
        WriteLine("|================ Categorias =================|");
        WriteLine("|=============================================|");
        WriteLine("");
        WriteLine("1 - Criar Categoria");
        WriteLine("2 - Listar Categoria");
        WriteLine("3 - Obter Categoria por Id");

        WriteLine("");
        Write("Selecione a opção: ");
        int escolha = int.Parse(ReadLine());

        Clear();
        switch (escolha)
        {
            case 1:
                await CriarCategoria();
                break;
            case 2:
                ListarCategoria();
                break;
            case 3:
                ObterCategoriaPorId();
                break;
        }



    }

    async Task CriarCategoria()
    {
        WriteLine("=== Criando Categoria ====");
        WriteLine("");
        Write("Nome: ");
        var nome = ReadLine();

        await _categoriaRepository.AddAsync(new Categoria { Nome = nome });
        WriteLine($"");
        WriteLine($"*** {nome} criado com sucesso ***");

        Thread.Sleep(2000);
        Clear();
        GerenciarCategoria();
    }

    async void ListarCategoria()
    {
        var categorias = await _categoriaRepository.GetAllAysnc();
        WriteLine("+--------------------+");
        WriteLine("| ID |     NOME      |");
        WriteLine("+--------------------+");

        foreach (var categoria in categorias)
        {
            WriteLine($"{categoria.Id} | {categoria.Nome}");
        }
    }

    async void ObterCategoriaPorId()
    {
        Write("Digite um ID: ");
        int id = int.Parse(ReadLine());

        var categoria = await _categoriaRepository.GetByIdAysnc(id);
        if (categoria == null)
        {
            WriteLine("Categoria não foi encontrada. Pressione enter para retorna a buscar.");
        }
        else
        {
            WriteLine("");
            WriteLine(categoria);
        }

    }
}
