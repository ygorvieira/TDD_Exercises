using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Caelum.Leilao
{
    [TestClass]
    public class AvaliadorTest
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;

        [TestInitialize]
        public void CriaAvaliador()
        {
            leiloeiro = new Avaliador();
            joao = new Usuario("João");
            jose = new Usuario("José");
            maria = new Usuario("Maria");
        }

        [TestMethod]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 novo")
                .Lance(maria, 250.0)
                .Lance(joao, 300.0)
                .Lance(jose, 400.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(400, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(250, leiloeiro.MenorLance, 0.0001);
        }

        [TestMethod]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 novo")
                .Lance(jose, 400.0)
                .Lance(joao, 300.0)
                .Lance(maria, 250.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(400, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(250, leiloeiro.MenorLance, 0.0001);
        }


        [TestMethod]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 novo")
                .Lance(joao, 300.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(300, leiloeiro.MenorLance, 0.0001);
            Assert.AreEqual(300, leiloeiro.MaiorLance, 0.0001);
        }

        [TestMethod]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(joao, 100.0)
            .Lance(maria, 200.0)
            .Lance(joao, 300.0)
            .Lance(maria, 400.0)
            .Constroi();

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
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 novo")
                .Lance(joao, 200.0)
                .Lance(maria, 450.0)
                .Lance(joao, 120.0)
                .Lance(maria, 700.0)
                .Lance(joao, 630.0)
                .Lance(maria, 230.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(700, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(120, leiloeiro.MenorLance, 0.0001);
        }

        [TestMethod]
        public void DeveDevolverTodosLancesCasoNaoHajaNoMinimo3()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
                .Lance(joao, 100.0)
                .Lance(maria, 200.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(200, maiores[0].Valor, 0.00001);
            Assert.AreEqual(100, maiores[1].Valor, 0.00001);
        }

        //[TestMethod]
        //public void DeveDevolverListaVaziaCasoNaoHajaLances()
        //{
        //    Leilao leilao = new Leilao("Playstation 3 Novo");

        //    leiloeiro.Avalia(leilao);

        //    var maiores = leiloeiro.TresMaiores;

        //    Assert.AreEqual(0, maiores.Count);
        //}

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NaoDeveAvaliarCasoNaoHajaLances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation")
                .Constroi();
            leiloeiro.Avalia(leilao);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NaoDeveAceitarLancesComValorZero()
        {
            new Lance(joao, 0.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NaoDeveAceitarLancesComValorNegativo()
        {
            new Lance(joao, -10.0);
        }
    }
}
