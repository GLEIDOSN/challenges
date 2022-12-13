using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;

namespace Questao5.Infrastructure.Repository.Interfaces
{
    public interface IMovimentoRepository
    {
        public Task<IEnumerable<Movimento>> GetMovimentos();

        public Task<int> AddMovimento(Guid IdRequisicao, Guid IdContaCorrent, double valor, EnumsTipoMovimento tipoMovimento);
    }
}
