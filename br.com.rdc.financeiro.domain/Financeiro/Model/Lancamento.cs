using br.com.rdc.financeiro.domain.Financeiro.Interfaces;
using System;

namespace br.com.rdc.financeiro.domain.Financeiro.Model
{
    public class Lancamento : Verifiable, ILancamento
    {
        public int Id { get; private set; }
        public string Data { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }
        public string Conta { get; private set; }
        public string Tipo { get; private set; }

        public Lancamento(int id, string data, decimal valor, string descricao, string conta, string tipo)
        {
            FieldsOk(data, descricao, conta);
            VerificaTipo(tipo);
            VerificaValor(valor);

            Id = id;
            Data = data;
            Valor = valor;
            Descricao = descricao;
            Conta = conta;
            Tipo = tipo;
        }

        public Lancamento(string data, decimal valor, string descricao, string conta, string tipo)
        {
            FieldsOk(data, descricao, conta);
            VerificaTipo(tipo);
            VerificaValor(valor);

            Data = data;
            Valor = valor;
            Descricao = descricao;
            Conta = conta;
            Tipo = tipo;
        }

        public void Atualiza(string data, decimal valor, string descricao, string conta, string tipo)
        {
            FieldsOk(data, descricao, conta);

            Data = data;
            Valor = valor;
            Descricao = descricao;
            Conta = conta;
            Tipo = tipo;
        }

        public void VerificaTipo(string tipo)
        {
            Assert(() => tipo == "c" || tipo == "d");
        }

        public void VerificaValor(decimal valor)
        {
            Assert(() => valor > 0);
        }

        public void FieldsOk(string data, string descricao, string conta)
        {
            Assert(() => !string.IsNullOrWhiteSpace(data));
            Assert(() => !string.IsNullOrWhiteSpace(descricao));
            Assert(() => !string.IsNullOrWhiteSpace(conta));
        }
    }
}
