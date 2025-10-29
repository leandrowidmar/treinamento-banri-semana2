using System;
using System.Collections.Generic;

// ----------------------------
// Classe que representa um registro de extrato
// ----------------------------
public class Movimentacao
{
    public string CpfPessoa;        // CPF da pessoa (para referência)
    public DateTime DataInclusao;   // Data da transação
    protected double ValorTransacao;
    protected string TipoTransacao; // "Entrada" ou "Saída"

    // Construtor
    public Movimentacao(string cpf, DateTime data, double valor, string tipo)
    {
        CpfPessoa = cpf;
        DataInclusao = data;
        ValorTransacao = valor;
        TipoTransacao = tipo;
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
        Movimentacoes = movimentacoes ?? new List<Movimentacao>();
    }

    // ----------------------------
    // Método para calcular saldo final
    // ----------------------------
    public double CalcularSaldo()
    {
        // TODO: Implementar cálculo do saldo final
        return 0;
    }

    // ----------------------------
    // Método para obter saldos diários
    // ----------------------------
    public List<string> ObterSaldosDiarios()
    {
        // TODO: Implementar cálculo de saldo diário
        return new List<string>();
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
        // var movimentacoes = new List<Movimentacao> { ... };
        // var extrato = new ExtratoBancario("CPF", "Nome", 1000, movimentacoes);

        // TODO: Chamar CalcularSaldo e ObterSaldosDiarios, imprimir resultados
        Console.WriteLine("\nFim do programa. Implemente as funcionalidades solicitadas no exercício.");
    }
}
