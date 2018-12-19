using System;

namespace Caelum.Leilao
{
    public class CriadorDeLeilao
    {
        private Leilao leilao;

        public CriadorDeLeilao()
        {
        }

        public CriadorDeLeilao Para(string descricao)
        {
            leilao = new Leilao(descricao);
            return this;
        }

        public CriadorDeLeilao Lance(Usuario usuario, double valor)
        {
            leilao.Propoe(new Lance(usuario, valor));
            return this;
        }

        public Leilao Constroi()
        {
            return leilao;
        }
    }
}