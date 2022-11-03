namespace Cardapio.View.Administrador;
public static class Entrada
{
    public static int ReceberInteiro(string mensagem)
    {
        Console.Write(mensagem);
        int valorEntrada;
        while (!int.TryParse(Console.ReadLine(), out valorEntrada))
        {
            Console.Write("Insira apenas números inteiros: ");
        }

        return valorEntrada;
    }

    public static int ReceberInteiro(string mensagem, int min, int max)
    {
        Console.Write(mensagem);
        int valorEntrada;
        while (!IsValid(min,max, out valorEntrada))
        {
            Console.Write($"Insira apenas números inteiros de {min} a {max}: ");
        }
        
        return valorEntrada;
    }

    static bool IsValid(int min, int max, out int valor)
    {
        if(int.TryParse(Console.ReadLine(), out int valorEntrada))
        {
            if (min <= valorEntrada && max >= valorEntrada)
            {
                valor = valorEntrada;
                return true;
            }
        }
        valor = valorEntrada;
        return false;
    }
}
