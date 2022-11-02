using Cardapio.Master;
using Cardapio.Master.Interfaces;
using Cardapio.Master.Models;
using static System.Console;

ICategoriaRepository _categoriaRepository = DIConteiner.InjectCategoriaRepository();

TelaPrincipal();

void TelaPrincipal()
{
    WriteLine("|=============================================|");
    WriteLine("|=========== Olá, Administrador ==============|");
    WriteLine("|=============================================|");
    WriteLine("");
    WriteLine("1 - Gerenciar Categoria");

    WriteLine("");
    Write("Selecione a opção: ");
    ReadLine();
    Clear();
    GerenciarCategoria();
}

async void GerenciarCategoria()
{
    WriteLine("|=============================================|");
    WriteLine("|================ Categorias =================|");
    WriteLine("|=============================================|");
    WriteLine("");
    WriteLine("1 - Criar Categoria");

    WriteLine("");
    Write("Selecione a opção: ");
    ReadLine();
    Clear();
    await CriarCategoria();
}

async Task CriarCategoria()
{
    WriteLine("=== Criando Categoria ====");
    WriteLine("");
    Write("Nome: ");
    var nome = ReadLine();

    await _categoriaRepository.Add(new Categoria { Nome = nome});
    WriteLine($"");
    WriteLine($"*** {nome} criado com sucesso ***");

    Thread.Sleep(2000);
    Clear();
    GerenciarCategoria();
}