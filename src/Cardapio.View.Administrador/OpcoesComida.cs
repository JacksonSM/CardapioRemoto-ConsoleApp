using Cardapio.Master;
using Cardapio.Master.Interfaces;
using Cardapio.Master.Models;
using Cardapio.Shared;
using static System.Console;

namespace Cardapio.View.Administrador;
public class OpcoesComida : IDisposable
{
    IComidaRepository _comidaRepository;

    public OpcoesComida()
    {
        _comidaRepository = DIConteiner.InjectComidaRepository();
    }

    public void Dispose()
    {
        this.Dispose();
    }

    public void GerenciarComida()
    {
        Clear();
        WriteLine("|=============================================|");
        WriteLine("|================== Comida ===================|");
        WriteLine("|=============================================|");
        WriteLine("");
        WriteLine("1 - Adicionar Comida");
        WriteLine("2 - Listar Comida");
        WriteLine("3 - Obter Comida por Id");
        WriteLine("4 - Alterar Categoria");

        WriteLine("");
        var escolha = Entrada.ReceberInteiro("Selecione a opção: ", 1, 4);

        Clear();
        switch (escolha)
        {
            case 1:
                AdicionarComida();
                break;
            case 2:
                ListarComida();
                break;
            case 3:
                ObterComidaPorId();
                break;
            case 4:
                AlterarComida();
                break;
        }
    }

    void AdicionarComida()
    {
        WriteLine("=== Adicionado Comida ====");
        WriteLine("");
        Write("Nome: ");
        var nome = ReadLine();

        Write("Descricao: ");
        var descricao = ReadLine();

        Write("Preço: ");
        var preco = decimal.Parse(ReadLine());

        Write("Digite o ID da categoria: ");
        var categoriaId = Entrada.ReceberInteiro("Selecione a opção: ");

        _comidaRepository.Add(new Comida (nome, descricao, preco, categoriaId));
        WriteLine($"");
        WriteLine($"*** {nome} criado com sucesso ***");

        Thread.Sleep(2000);
        GerenciarComida();
    }

    void ListarComida()
    {
        var comidas = _comidaRepository.GetAll();
        WriteLine("+----------------------------------------------------------------------+");
        WriteLine("| ID |NOME        |Descrição        |Preço       |CategoriaId          |");
        WriteLine("+----------------------------------------------------------------------+");

        foreach (var comida in comidas)
        {
            WriteLine($"{comida.Id} | {comida.Nome} | {comida.Descricao} | R$ {comida.Preco} | {comida.CategoriaId}");
        }

        Voltar();
    }

    void ObterComidaPorId()
    {
        int id = Entrada.ReceberInteiro("Digite um ID: ");

        var comida = _comidaRepository.GetById(id);
        if (comida == null)
        {
            Voltar("Comida não foi encontrada. Pressione qualquer tecla para voltar.");
        }
        else
        {
            WriteLine("");
            WriteLine(comida);
            Voltar();
        }

    }
    void AlterarComida() { 

        int id = Entrada.ReceberInteiro("Digite o ID da Comida: ");
        var comida = _comidaRepository.GetById(id);
        if (comida == null)
        {
            Voltar("Comida não foi encontrada. Pressione qualquer tecla para voltar.");
        }
        else
        {

            if(!CodicionalSimOuNao($"Quer mesmo alterar [{comida.Nome}] ? S/N: "))
            {
                Voltar();
            }

            WriteLine($"=== Alterando {comida.Nome} ====");
            WriteLine("");
            Write("Nome: ");
            var nome = ReadLine();

            Write("Descricao: ");
            var descricao = ReadLine();

            Write("Preço: ");
            var preco = decimal.Parse(ReadLine());

            var categoriaId = Entrada.ReceberInteiro("Digite o ID da categoria: ");

            comida.Atualizar(nome, descricao, preco, categoriaId);

            _comidaRepository.Update(comida.Id, comida);

            WriteLine($"");
            WriteLine($"*** {comida.Nome} alterado com sucesso ***");

            Thread.Sleep(2000);
            GerenciarComida();
        }
    }
    void Voltar(string mensagem = "Pressione qualquer tecla para voltar.")
    {
        WriteLine("");
        Write(mensagem);
        ReadKey();
        GerenciarComida();
    }

    bool CodicionalSimOuNao(string mensagem)
    {
        string entrada = "";
        bool isValid = false;
        while (!isValid)
        {
            Write(mensagem);
            entrada = ReadLine();

            if (entrada.Equals("s", StringComparison.InvariantCultureIgnoreCase) ||
                entrada.Equals("n", StringComparison.InvariantCultureIgnoreCase))
            {
                isValid = true;
            }
        }

        return entrada.Equals("s", StringComparison.InvariantCultureIgnoreCase) ?
            true : false;
    }
 

}
