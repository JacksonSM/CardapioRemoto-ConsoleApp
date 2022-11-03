using Cardapio.Master;
using Cardapio.Master.Interfaces;
using Cardapio.Master.Models;
using static System.Console;

namespace Cardapio.View.Administrador;
public class OpcoesCategoria : IDisposable
{
    ICategoriaRepository _categoriaRepository;

    public OpcoesCategoria()
    {
        _categoriaRepository = DIConteiner.InjectCategoriaRepository();
    }

    public void Dispose()
    {
        this.Dispose();
    }

    public void GerenciarCategoria()
    {
        Clear();
        WriteLine("|=============================================|");
        WriteLine("|================ Categorias =================|");
        WriteLine("|=============================================|");
        WriteLine("");
        WriteLine("1 - Criar Categoria");
        WriteLine("2 - Listar Categoria");
        WriteLine("3 - Obter Categoria por Id");
        WriteLine("4 - Alterar Categoria");

        WriteLine("");
        var escolha = Entrada.ReceberInteiro("Selecione a opção: ", 1, 4);

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

        Voltar();
    }

    void ObterCategoriaPorId()
    {
        int id = Entrada.ReceberInteiro("Digite um ID: ");

        var categoria = _categoriaRepository.GetById(id);
        if (categoria == null)
        {
            Voltar("Categoria não foi encontrada. Pressione qualquer tecla para voltar.");
        }
        else
        {
            WriteLine("");
            WriteLine(categoria);
            Voltar();
        }

    }
    void AlterarCategoria() { 

        int id = Entrada.ReceberInteiro("Digite o ID da categoria: ");
        var categoria = _categoriaRepository.GetById(id);
        if (categoria == null)
        {
            Voltar("Categoria não foi encontrada. Pressione qualquer tecla para voltar.");
        }
        else
        {
            Write($"Alterar [{categoria.Nome}] para: ");
            categoria.Nome = ReadLine();
            _categoriaRepository.Update(categoria.Id, categoria);

            WriteLine($"");
            WriteLine($"*** {categoria.Nome} alterado com sucesso ***");

            Thread.Sleep(2000);
            GerenciarCategoria();
        }
    }
    void Voltar(string mensagem = "Pressione qualquer tecla para voltar.")
    {
        WriteLine("");
        Write(mensagem);
        ReadKey();
        GerenciarCategoria();
    }

}
