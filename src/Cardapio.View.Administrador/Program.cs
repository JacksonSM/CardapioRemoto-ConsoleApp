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
    var escolha = Entrada.ReceberInteiro("Selecione a opção: ",1,1);

    switch (escolha)
    {
        case 1:
            var gerirCategoria = new OpcoesCategoria();
            gerirCategoria.GerenciarCategoria();
            break;
    }

}




