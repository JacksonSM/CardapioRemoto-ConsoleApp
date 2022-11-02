namespace Cardapio.Master.Models;
public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"ID: {Id}| Nome: {Nome}";
    }
}
