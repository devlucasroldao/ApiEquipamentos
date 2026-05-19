namespace ApiEquipamentos;

public class Equipamento
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Tipo { get; set; } = "";
    public decimal ValorPatrimonio { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
}