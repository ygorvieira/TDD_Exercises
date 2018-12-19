using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Caelum.Leilao
{
    [TestClass]
    public class TesteDoAvaliador
    {
        [TestMethod]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            //1a parte: Cenário
            Usuario joao = new Usuario("João");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            //2a parte: Ação
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            //3a parte: Validação
            Assert.AreEqual(400, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(250, leiloeiro.MenorLance, 0.0001);
        }

        [TestMethod]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {
            Usuario joao = new Usuario("João");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 novo");

            leilao.Propoe(new Lance(jose, 400.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 250.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(400, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(250, leiloeiro.MenorLance, 0.0001);
        }


        [TestMethod]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Usuario joao = new Usuario("João");

            Leilao leilao = new Leilao("Playstation 3 novo");

            leilao.Propoe(new Lance(joao, 300.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(300, leiloeiro.MenorLance, 0.0001);
            Assert.AreEqual(300, leiloeiro.MaiorLance, 0.0001);
        }

        [TestMethod]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 400.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            IList<Lance> maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }

        [TestMethod]
        public void DeveEntenderLancesEmOrdemAleatoria()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 novo");
            
            leilao.Propoe(new Lance(joao, 200.0));
            leilao.Propoe(new Lance(maria, 450.0));
            leilao.Propoe(new Lance(joao, 120.0));
            leilao.Propoe(new Lance(maria, 700.0));
            leilao.Propoe(new Lance(joao, 630.0));
            leilao.Propoe(new Lance(maria, 230.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(700, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(120, leiloeiro.MenorLance, 0.0001);
        }

        [TestMethod]
        public void DeveDevolverTodosLancesCasoNaoHajaNoMinimo3()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(200, maiores[0].Valor, 0.00001);
            Assert.AreEqual(100, maiores[1].Valor, 0.00001);
        }

        [TestMethod]
        public void DeveDevolverListaVaziaCasoNaoHajaLances()
        {
            Leilao leilao = new Leilao("Playstation 3 Novo");

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(0, maiores.Count);
        }
    }
}
