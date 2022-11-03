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
        WriteLine("4 - Alterar Categoria");

        WriteLine("");
        Write("Selecione a opção: ");
        int escolha = int.Parse(ReadLine());

        Clear();
        switch (escolha)
        {
            case 1:
                CriarCategoria();
                break;
            case 2:
                ListarCategoria();
                break;
            case 3:
                ObterCategoriaPorId();
                break;
            case 4:
                AlterarCategoria();
                break;
        }



    }


    void CriarCategoria()
    {
        WriteLine("=== Criando Categoria ====");
        WriteLine("");
        Write("Nome: ");
        var nome = ReadLine();

        _categoriaRepository.Add(new Categoria { Nome = nome });
        WriteLine($"");
        WriteLine($"*** {nome} criado com sucesso ***");

        Thread.Sleep(2000);
        Clear();
        GerenciarCategoria();
    }

    void ListarCategoria()
    {
        var categorias = _categoriaRepository.GetAll();
        WriteLine("+--------------------+");
        WriteLine("| ID |     NOME      |");
        WriteLine("+--------------------+");

        foreach (var categoria in categorias)
        {
            WriteLine($"{categoria.Id} | {categoria.Nome}");
        }
    }

    void ObterCategoriaPorId()
    {
        Write("Digite um ID: ");
        int id = int.Parse(ReadLine());

        var categoria = _categoriaRepository.GetById(id);
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
    void AlterarCategoria()
    {
        Write("Digete o ID da categoria: ");
        int id = int.Parse(ReadLine());

        var categoria = _categoriaRepository.GetById(id);
        if (categoria == null)
        {
            WriteLine("Categoria não foi encontrada. Pressione enter para retorna a buscar.");
        }
        else
        {
            Write($"Alterar [{categoria.Nome}] para: ");
            categoria.Nome = ReadLine();
            _categoriaRepository.Update(categoria.Id, categoria);
        }
    }
}
