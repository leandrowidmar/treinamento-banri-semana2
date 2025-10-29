using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Heranca

{

    public class Program

    {

        static void Main(string[] args)

        {
            List<Conta> contas = new List<Conta>();
            ContaCorrente contaCorrente1 = new ContaCorrente("Leandro Widmar", "1000");
            Poupanca poupanca1 = new Poupanca("LeandroPoupança", "5,000,00");
            ContaConjunta conjunta1 = new ContaConjunta("Leandro","500","Julia");

            contas.Add(contaCorrente1);
            contas.Add(poupanca1);
            contas.Add(conjunta1);
            foreach(var conta in contas) 
                {
                    conta.Resumo();
                }


        }

    }

    public class Conta

    {

        protected string titular;

        protected string numeroConta;

        protected decimal saldo;

        public Conta(string titular, string numeroConta)

        {

            this.titular = titular;

            this.numeroConta = numeroConta;

            this.saldo = 0;

        }

        public virtual void Depositar(decimal valor)

        {

            if (valor >= 0)

            {

                saldo += valor;

            }

            else

            {

                Console.WriteLine("Valor dado é menor do que zero! Operação não foi feita.");

                return;

            }

        }

        public virtual void Sacar(decimal valor)

        {

            if (valor > 0 && saldo > valor)

            {

                saldo -= valor;

            }

            else

            {

                Console.WriteLine("Valor dado é menor do que zero! Operação não foi feita.");

                return;

            }

        }

        public virtual void Resumo()

        {

            Console.WriteLine($"Número da conta: {numeroConta}\nNome titular: {titular}\nSaldo: {saldo:F2}");

        }

    }

    public class ContaCorrente : Conta

    {

        private const decimal tarifaSaque = 1;

        public ContaCorrente(string titular, string numeroConta) : base(titular, numeroConta) { }

        public override void Sacar(decimal valor)

        {

            if (valor > 0 && saldo >= valor + tarifaSaque)

            {

                saldo -= valor + tarifaSaque;

            }

            else

            {

                Console.WriteLine("Valor dado é menor do que zero! Operação não foi feita.");

                return;

            }

        }

    }

    public class Poupanca : Conta

    {

        private const decimal taxaRendimentoAnual = 0.08m;

        public Poupanca(string titular, string numeroConta) : base(titular, numeroConta) { }


        private void RenderJuro(int dias)

        {

            decimal rendimento = saldo * taxaRendimentoAnual * dias / 365;

            base.Depositar(rendimento);

        }

    }

    public class ContaConjunta : ContaCorrente

    {

        private string segundoTitular;

        public ContaConjunta(string titular, string numeroConta, string segundoTitular) : base(titular, numeroConta)

        {

            this.segundoTitular = segundoTitular;


        }

        public override void Resumo()

        {

            Console.WriteLine($"Número da conta: {numeroConta}\nNome primeiro titular: {titular}\n Nome segundo titular: {segundoTitular}\nSaldo: {saldo:F2}");

        }

    }

}

