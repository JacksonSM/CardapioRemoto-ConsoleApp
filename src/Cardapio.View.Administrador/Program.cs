using Cardapio.View.Administrador;
using static System.Console;



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
    var gerirCategoria = new CategoriaOptions();
    gerirCategoria.GerenciarCategoria();


}




