using System;

namespace Caelum.Leilao
{
    public class Palindromo
    {
        public bool EhPalindromo(String frase)
        {
            String fraseFiltrada = frase
                    .ToUpper().Replace(" ", "").Replace("-", "");

            for (int i = 0; i < fraseFiltrada.Length; i++)
            {
                int outroLado = fraseFiltrada.Length - i - 1;
                if (fraseFiltrada[i] != fraseFiltrada[outroLado])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
