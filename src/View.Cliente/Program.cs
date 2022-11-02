using static System.Console;

CardapioCategorias();


void TelaInicial()
{
    WriteLine("|=============================================|");
    WriteLine("|============= Olá, Bem-vindo !===============|");
    WriteLine("|=============================================|");
    WriteLine("");
    WriteLine("1 - Cardapio");
}

void CardapioCategorias()
{
    //provisorio
    string[] categorias = { "Pratos familia", "Acompanhamentos", "sobremesa", "petiscos" };

    WriteLine("|=======================================|");
    WriteLine("|=============  Cardapio  ==============|");
    WriteLine("|=======================================|");

    for (int i = 1; i < categorias.Length; i++)
    {
        WriteLine("");
        WriteLine($"{i} - {categorias[i]}");
    }

    CapturarEntrada("Digite o número da categoria: ", 1, categorias.Length);

}
int CapturarEntrada(string mesagem, int min, int max)
{
    int entradaUsuario = 0;
    while ()
    {
        Write("Digite o número da categoria: ");
        ReadLine();
    }
}