using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestClass]
    public class LeilaoTest
    {
        [TestMethod]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new Leilao("Mac Book Pro 500");
            Assert.AreEqual(0, leilao.Lances.Count());

            Usuario usuario = new Usuario("Ygor");
            leilao.Propoe(new Lance(usuario, 100.0));
            Assert.AreEqual(1, leilao.Lances.Count());
            Assert.AreEqual(100, leilao.Lances[0].Valor, 0.0001);
        }

        [TestMethod]
        public void DeveReceberVariosLances()
        {
            Leilao leilao = new Leilao("Mac Book Pro 500");
            Usuario ygor = new Usuario("Ygor");
            Usuario roberta = new Usuario("Roberta");

            leilao.Propoe(new Lance(ygor, 100.0));
            leilao.Propoe(new Lance(roberta, 200.0));

            Assert.AreEqual(2, leilao.Lances.Count());
            Assert.AreEqual(100, leilao.Lances[0].Valor, 0.0001);
            Assert.AreEqual(200, leilao.Lances[1].Valor, 0.0001);
        }

        [TestMethod]
        public void DeveRecusarDoisLancesSeguidosDoMesmoUsuario()
        {
            Leilao leilao = new Leilao("Mac Book Pro 500");
            Usuario ygor = new Usuario("Ygor");

            leilao.Propoe(new Lance(ygor, 100.0));
            leilao.Propoe(new Lance(ygor, 200.0));

            Assert.AreEqual(1, leilao.Lances.Count());
            Assert.AreEqual(100, leilao.Lances[0].Valor, 0.0001);
        }

        [TestMethod]
        public void NaoDeveAceitarMaisDe5LancesDeUmMesmoUsuario()
        {
            Leilao leilao = new Leilao("Mac Book Pro 500");
            Usuario ygor = new Usuario("Ygor");
            Usuario roberta = new Usuario("Roberta");

            leilao.Propoe(new Lance(ygor, 100.0));
            leilao.Propoe(new Lance(roberta, 200.0));
            leilao.Propoe(new Lance(ygor, 300.0));
            leilao.Propoe(new Lance(roberta, 400.0));
            leilao.Propoe(new Lance(ygor, 500.0));
            leilao.Propoe(new Lance(roberta, 600.0));
            leilao.Propoe(new Lance(ygor, 700.0));
            leilao.Propoe(new Lance(roberta, 800.0));
            leilao.Propoe(new Lance(ygor, 900.0));
            leilao.Propoe(new Lance(roberta, 800.0));
            leilao.Propoe(new Lance(ygor, 900.0));

            Assert.AreEqual(10, leilao.Lances.Count());

            var ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];
            Assert.AreEqual(800, ultimoLance.Valor, 0.0001);
        }

        [TestMethod]
        public void DeveDobrarLanceAnterior()
        {
            Leilao leilao = new Leilao("Mac Book Pro 500");
            Usuario ygor = new Usuario("Ygor");
            Usuario roberta = new Usuario("Roberta");

            leilao.Propoe(new Lance(ygor, 150.0));
            leilao.Propoe(new Lance(roberta, 250.0));
            leilao.DobraLance(ygor);

            Assert.AreEqual(300, leilao.Lances[2].Valor, 0.0001);
        }

        [TestMethod]
        public void NaoDeveDobrarLancesConsecutivos()
        {
            Leilao leilao = new Leilao("Mac Book Pro 500");
            Usuario ygor = new Usuario("Ygor");

            leilao.DobraLance(ygor);

            Assert.AreEqual(0, leilao.Lances.Count());
    }
    }
}
