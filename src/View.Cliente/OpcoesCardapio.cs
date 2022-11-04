using Cardapio.Master;
using Cardapio.Master.Interfaces;
using Cardapio.Shared;
using System;
using System.Linq;
using static System.Console;

namespace Cardapio.View.Cliente;
public class OpcoesCardapio : IDisposable
{
    ICategoriaRepository _categoriaRepository;

    public OpcoesCardapio()
    {
        _categoriaRepository = DIConteiner.InjectCategoriaRepository();
    }

    public void Dispose()
    {
        this.Dispose();
    }
    public void InicioCardapio()
    {
        Clear();
        var categorias = _categoriaRepository.GetAllWithComida().ToArray();

        WriteLine("|=======================================|");
        WriteLine("|=============  Cardapio  ==============|");
        WriteLine("|=======================================|");

        foreach (var categoria in categorias)
        {

            WriteLine("");
            WriteLine($"--{categoria.Nome}--");
            foreach (var comida in categoria.Comidas)
            {
                WriteLine("");
                WriteLine($"** COD: {comida.Id}, {comida.Nome}, Preço: R$ {comida.Preco}");
                WriteLine(comida.Descricao);
                WriteLine("");
            }
        }
        WriteLine("Escolha digitando o COD da comida separada por espaço.");
        Write("Pedido: ");
        var pedido = ReadLine();

    }

}
