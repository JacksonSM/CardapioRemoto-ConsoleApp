namespace Cardapio.Master.Models;
public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public List<Comida> Comidas { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}| Nome: {Nome}";
    }
}
