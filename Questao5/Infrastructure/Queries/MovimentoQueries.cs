namespace Questao5.Infrastructure.Queries
{
    public static class MovimentoQueries
    {
        public static string GetMovimentos() =>
            @"Select * from Movimento";

        public static string AddMovimento() =>
            @"Insert into Movimento (idcontacorrente, datamovimento, tipomovimento, valor) values (:idcontacorrente, :datamovimento, :tipomovimento, :valor)";
    }
}
