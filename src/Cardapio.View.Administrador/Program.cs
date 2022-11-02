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
    WriteLine("2 - Listar Categoria");

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
    }



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

async void ListarCategoria()
{
    var categorias = await _categoriaRepository.GetAll();
    WriteLine("+--------------------+");
    WriteLine("| ID |     NOME      |");
    WriteLine("+--------------------+");

    foreach (var categoria in categorias)
    {
        WriteLine($"{categoria.Id} | {categoria.Nome}");
    }
}