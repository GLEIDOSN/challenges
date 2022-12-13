using Microsoft.Data.Sqlite;

namespace Questao5.Infrastructure.Sqlite
{
    public interface IDatabaseBanco
    {
        void Setup();

        SqliteConnection GetConnection();
    }
}