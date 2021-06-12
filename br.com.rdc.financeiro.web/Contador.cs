namespace br.com.rdc.financeiro.web
{
    public class Contador
    {
        private int valorAtual = 0;

        public int ValorAtual { get => valorAtual; }

        public void Incrementar()
        {
            valorAtual++;
        }
    }
}
