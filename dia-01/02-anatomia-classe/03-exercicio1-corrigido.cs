// ExtratoBancarioDemo.cs
using System;
using System.Collections.Generic;

// ----------------------------
//  Domínio
// ----------------------------
public class Movimentacao
{
    public DateTime data;          // Data da transação
    public double valor;           // Valor positivo = entrada; negativo = saída
    public string tipo;            // "Entrada" ou "Saída"

    public Movimentacao(DateTime data, double valor, string tipo)
    {
        this.data = data;
        this.valor = valor;
        this.tipo = tipo.Trim();
    }
}

public class ExtratoBancario
{
    public string cpfPessoa;
    public string nomePessoa;
    public double valorInicial;
    public List<Movimentacao> movimentacoes;

    // ----------------------------
    // Construtor
    // ----------------------------
    public ExtratoBancario(string cpf, string nome, double valorInicial, List<Movimentacao> movimentacoes)
    {
        this.cpfPessoa = cpf.Trim();
        this.nomePessoa = nome.Trim();
        this.valorInicial = valorInicial;
        this.movimentacoes = movimentacoes;
    }

    // ----------------------------
    // Método para calcular saldo final
    // ----------------------------
    public double CalcularSaldo()
    {
        double saldo = valorInicial;
        foreach (var m in movimentacoes)
        {
            saldo += m.valor;
        }
        return saldo;
    }

    // ----------------------------
    // Método para obter saldos diários
    // ----------------------------
    public List<string> ObterSaldosDiarios()
    {
        var saldosPorDia = new Dictionary<DateTime, double>();
        double saldoAcumulado = valorInicial;

        // Ordena as movimentações por data
        movimentacoes.Sort((m1, m2) => m1.data.CompareTo(m2.data));

        foreach (var mov in movimentacoes)
        {
            var dia = mov.data.Date;

            if (!saldosPorDia.ContainsKey(dia))
                saldosPorDia[dia] = saldoAcumulado;

            saldosPorDia[dia] += mov.valor;
            saldoAcumulado += mov.valor;
        }

        // Ordena as datas e constrói a lista de strings
        var diasOrdenados = new List<DateTime>(saldosPorDia.Keys);
        diasOrdenados.Sort();

        var resultado = new List<string>();
        foreach (var dia in diasOrdenados)
        {
            resultado.Add($"{dia:dd/MM/yyyy} - Saldo: {saldosPorDia[dia]:C}");
        }

        return resultado;
    }
}

// ----------------------------
// Demonstração / Fluxo de Teste
// ----------------------------
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var hoje = DateTime.Today;

        // 1) Instanciar Extrato com pelo menos 5 dias e 1 dia com múltiplas movimentações
        var movimentacoes = new List<Movimentacao>
        {
            new Movimentacao(hoje.AddDays(-6), 500, "Entrada"),
            new Movimentacao(hoje.AddDays(-5), 300, "Entrada"),
            new Movimentacao(hoje.AddDays(-4), -120, "Saída"),
            // Dia com múltiplas movimentações
            new Movimentacao(hoje.AddDays(-3), -80, "Saída"),
            new Movimentacao(hoje.AddDays(-3), 150, "Entrada"),
            new Movimentacao(hoje.AddDays(-2), -50, "Saída"),
            new Movimentacao(hoje.AddDays(-1), -100, "Saída")
        };

        var extrato = new ExtratoBancario("123.456.789-00", "Maria Souza", 1000, movimentacoes);

        Console.WriteLine($"Titular: {extrato.nomePessoa} | CPF: {extrato.cpfPessoa}");

        // 2) Cálculo do saldo
        double saldoFinal = extrato.CalcularSaldo();
        Console.WriteLine($"Saldo final: {saldoFinal:C}");

        // 3) Lista pública com saldo atualizado diariamente
        var saldosDiarios = extrato.ObterSaldosDiarios();
        Console.WriteLine("\nSaldos diários:");
        foreach (var linha in saldosDiarios)
        {
            Console.WriteLine(linha);
        }
    }
}
