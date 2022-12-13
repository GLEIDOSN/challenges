using Dapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Queries;
using Questao5.Infrastructure.Repository.Interfaces;
using Questao5.Infrastructure.Sqlite;
using System.Data;

namespace Questao5.Infrastructure.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        public readonly DatabaseBanco databaseBanco;

        public MovimentoRepository(DatabaseBanco databaseBanco)
        {
            this.databaseBanco = databaseBanco;
        }
    
        public async Task<int> AddMovimento(Guid IdRequisicao, Guid IdContaCorrent, double valor, EnumsTipoMovimento tipoMovimento)
        {
            var paremeters = new DynamicParameters();

            paremeters.Add("idcontacorrente", IdContaCorrent, DbType.Guid);
            paremeters.Add("datamovimento", DateTime.Now, DbType.DateTime);
            paremeters.Add("tipomovimento", tipoMovimento, DbType.Int16);
            paremeters.Add("valor", IdContaCorrent, DbType.Double);

            var listaMovimentos = await databaseBanco.GetConnection().ExecuteAsync(MovimentoQueries.AddMovimento(), commandTimeout: 1800);

            return listaMovimentos;
        }

        public async Task<IEnumerable<Movimento>> GetMovimentos()
        {
            var listaMovimentos = await databaseBanco.GetConnection().QueryAsync<Movimento>(MovimentoQueries.GetMovimentos(), commandTimeout: 1800);

            return listaMovimentos;
        }
    }
}
