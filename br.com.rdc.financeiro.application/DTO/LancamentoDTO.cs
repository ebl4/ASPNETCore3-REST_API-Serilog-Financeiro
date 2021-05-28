namespace br.com.rdc.financeiro.application.DTO
{
    public class LancamentoDTO
    {
        public string Data { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string Conta { get; set; }
        public string Tipo { get; set; }
    }
}