namespace br.com.rdc.financeiro.domain.Financeiro.Interfaces
{
    public interface ILancamento
    {
        void Atualiza(string data, decimal valor, string descricao, string conta, string tipo);
    }
}
