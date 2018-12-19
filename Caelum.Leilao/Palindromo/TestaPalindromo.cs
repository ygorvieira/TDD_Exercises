using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caelum.Leilao
{
    [TestClass]
    public class TestaPalindromo
    {
        [TestMethod]
        public void TesteDoPalindromo()
        {
            Palindromo p = new Palindromo();
            var resultado = p.EhPalindromo("Socorram-me subi no onibus em Marrocos");

            Assert.IsTrue(resultado);

        }
    }
}
