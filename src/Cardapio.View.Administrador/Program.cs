using Cardapio.Shared;
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
    WriteLine("2 - Gerenciar Comida");

    WriteLine("");
    var escolha = Entrada.ReceberInteiro("Selecione a opção: ", 1, 2);

    switch (escolha)
    {
        case 1:
            var gerirCategoria = new OpcoesCategoria();
            gerirCategoria.GerenciarCategoria();
            break;
        case 2:
            var gerirComida = new OpcoesComida();
            gerirComida.GerenciarComida();
            break;
    }

}




