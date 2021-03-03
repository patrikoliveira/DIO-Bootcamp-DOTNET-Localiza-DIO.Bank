using DIO.Bank.Enum;

namespace DIO.Bank.Classes
{
    public class Conta
    {
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public double Credito { get; set; }

        public TipoConta TipoConta { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque < (Credito * -1))
            {
                System.Console.WriteLine("Saldo insuficiente");
                return false;
            }
            Saldo -= valorSaque;
            System.Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);
            
            return true;
        }

        public void Depositar(double valorDeposito)
        {
          Saldo += valorDeposito;
          System.Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDeposito)
        {
            if (Sacar(valorTransferencia))
            {
                contaDeposito.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            return $"TipoConta {TipoConta} | Nome {Nome} | Saldo {Saldo} | Credito {Credito}";
        }

    }
}