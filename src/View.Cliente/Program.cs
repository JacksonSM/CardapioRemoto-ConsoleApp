using Cardapio.Shared;
using Cardapio.View.Cliente;
using static System.Console;

TelaPrincipal();

void TelaPrincipal()
{
    WriteLine("|=============================================|");
    WriteLine("|============ Olá, Bem-vindo ! ===============|");
    WriteLine("|=============================================|");
    WriteLine("");
    WriteLine("1 - Cadapio");

    WriteLine("");
    var escolha = Entrada.ReceberInteiro("Selecione a opção: ", 1, 1);

    switch (escolha)
    {
        case 1:
            var cardapio = new OpcoesCardapio();
            cardapio.InicioCardapio();
            break;
    }

}



