namespace Cardapio.Master.Models;
public class Comida : Base
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public bool IsAtivo { get; set; }

    public int CategoriaId { get; set; }

    public Comida(){}

    public Comida(string nome, string descricao, decimal preco, int categoriaId)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        CategoriaId = categoriaId;
        IsAtivo = true; 
    }

    public void Atualizar(string nome, string descricao, decimal preco, int categoriaId)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        CategoriaId = categoriaId;
    }

    public override string ToString()
    {
        return $"ID: {Id} |Nome: {Nome} |Preço: {Preco} |CategoriaID: {CategoriaId}";
    }
}
