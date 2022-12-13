using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public Guid IdMovimento { get; set; }

        public Guid IdContaCorrente { get; set; }

        public DateTime DataMovimento { get; set; }

        public EnumsTipoMovimento TipoMovimento { get; set; }

        public double Valor { get; set; }
    }
}
