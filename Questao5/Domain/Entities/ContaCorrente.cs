namespace Questao5.Domain.Entities
{
    public class ContaCorrente
    {
        public Guid Idcontacorrente { get; set; }

        public int Numero { get; set; }

        public string Nome { get; set; } = string.Empty;

        public int Ativo { get; set; }
    }
}
