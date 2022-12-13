using System.Globalization;

namespace Questao1
{
    public class ContaBancaria {
        public const double Taxa = 3.50;

        public ContaBancaria(int numeroConta, string nomeTitular, double valorDepositoInicial)
        {
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
            Saldo = valorDepositoInicial;
        }

        public ContaBancaria(int numeroConta, string nomeTitular)
        {
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
        }

        public int NumeroConta { get; }

        public string NomeTitular { get; set; }

        private double Saldo { get; set; } = 0.00;

        public void Deposito(double valor)
        {
            Saldo += valor;
        }

        public void Saque(double valor)
        {
            Saldo -= (valor + Taxa);
        }

        public override string ToString()
        {
            var culture = new CultureInfo("en-US", false).NumberFormat;
            return $"Conta {NumeroConta}, Titular: {NomeTitular}, Saldo: $ {Saldo.ToString("N2", culture)}";
        }
    }
}
