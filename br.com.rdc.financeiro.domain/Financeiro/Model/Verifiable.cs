using System;

namespace br.com.rdc.financeiro.domain.Financeiro.Model
{
    public abstract class Verifiable
    {
        public bool Valid { get; private set; }
        public void Assert(Func<bool> expression) => Valid = expression?.Invoke() ?? false;
    }
}
