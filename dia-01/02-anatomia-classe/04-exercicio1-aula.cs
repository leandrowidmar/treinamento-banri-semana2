using System;
using System.Collections.Generic;

// ----------------------------
// Classe que representa um registro de extrato
// ----------------------------
namespace Boilerplate
{
    public class Movimentacao
    {
        public string CpfPessoa;        // CPF da pessoa (para referência)
        public DateTime DataInclusao;   // Data da transação
        public double ValorTransacao;   // 

        // Construtor
        public Movimentacao(string cpf, DateTime data, double valor)
        {
            CpfPessoa = cpf;
            DataInclusao = data;
            ValorTransacao = valor;
        }
    }

    // ----------------------------
    // Classe que representa o extrato
    // ----------------------------
    public class ExtratoBancario
    {
        public string CpfPessoa;       // CPF da pessoa
        public string NomePessoa;      // Nome da pessoa
        public double ValorInicial;    // Saldo inicial
        protected List<Movimentacao> Movimentacoes;

        // Construtor
        public ExtratoBancario(string cpf, string nome, double valorInicial, List<Movimentacao> movimentacoes)
        {
            CpfPessoa = cpf;
            NomePessoa = nome;
            ValorInicial = valorInicial;
            Movimentacoes = movimentacoes ?? new List<Movimentacao>() ;
        }

        // ----------------------------
        // Método para calcular saldo final
        // ----------------------------
        public double CalcularSaldo()
        {
            double saldoFinal = ValorInicial;
            for(int indice = 0; indice < Movimentacoes.Count; indice++)
            {
                saldoFinal += Movimentacoes[indice].ValorTransacao;
            }
            return saldoFinal; 
        }

        // ----------------------------
        // Método para obter saldos diários
        // ----------------------------
        public List<string> ObterSaldosDiarios()
        {
            Dictionary<DateTime, double> valoresPorDia = new Dictionary<DateTime, double>();
            double saldo = ValorInicial;

            for (int indice = 0; indice < Movimentacoes.Count; indice++)
            {
                DateTime dia = Movimentacoes[indice].DataInclusao.Date;

                if (!valoresPorDia.ContainsKey(dia))
                {   
                    valoresPorDia[dia] = saldo;
                }

                valoresPorDia[dia] += Movimentacoes[indice].ValorTransacao;
                saldo += Movimentacoes[indice].ValorTransacao;
            }

            List<string> extratoPorDia = new List<string>();
            foreach(DateTime dia in valoresPorDia.Keys)
            {
                string texto = $"valor no dia {dia.Date} é {valoresPorDia[dia.Date]}";
                extratoPorDia.Add(texto);
            }

            return extratoPorDia;
        }
    }

    // ----------------------------
    // Classe App com método Main
    // ----------------------------
    public class App
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Sistema de Extrato Bancário ===\n");

            // TODO: Instanciar ExtratoBancario e Movimentacoes conforme o exercício
            // Exemplo de comentário:
            string cpfGabriel = "123456789";
            List<Movimentacao> movimentacoes = new List<Movimentacao>();

            Movimentacao mov1 = new Movimentacao(cpfGabriel, DateTime.Now, 19.2);
            Movimentacao mov2 = new Movimentacao(cpfGabriel, DateTime.Now.AddDays(1), -10.2);
            Movimentacao mov3 = new Movimentacao(cpfGabriel, DateTime.Now.AddDays(2), 23.9);
            Movimentacao mov4 = new Movimentacao(cpfGabriel, DateTime.Now.AddDays(3), 11.2);
            Movimentacao mov5 = new Movimentacao(cpfGabriel, DateTime.Now.AddDays(4), 19.2);
            Movimentacao mov6 = new Movimentacao(cpfGabriel, DateTime.Now.AddDays(4), -5.5);

            movimentacoes.Add(mov1);
            movimentacoes.Add(mov2);
            movimentacoes.Add(mov3);
            movimentacoes.Add(mov4);
            movimentacoes.Add(mov5);
            movimentacoes.Add(mov6);

            ExtratoBancario extratoGabriel = new ExtratoBancario(cpfGabriel, "Gabriel", 50, null);

            // TODO: Chamar CalcularSaldo e ObterSaldosDiarios, imprimir resultados
            Console.WriteLine("\nFim do programa. Implemente as funcionalidades solicitadas no exercício.");
        }
    }

}
