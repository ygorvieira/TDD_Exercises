using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Matematica
{
    [TestClass]
    public class TestaConta
    {
        [TestMethod]
        public void DeveRetornarVezesQuatroSeMaiorQueTrinta()
        {
            Matematica matematica = new Matematica();
            Assert.AreEqual(50 * 4, matematica.ContaMaluca(50));
        }

        [TestMethod]
        public void DeveRetornarVezesTresSeMaiorQueDez()
        {
            Matematica matematica = new Matematica();
            Assert.AreEqual(12 * 3, matematica.ContaMaluca(12));
        }

        [TestMethod]
        public void DeveDobrarSeMenorQueDez()
        {
            Matematica matematica = new Matematica();
            Assert.AreEqual(9 * 2, matematica.ContaMaluca(9));
        }
    }
}
