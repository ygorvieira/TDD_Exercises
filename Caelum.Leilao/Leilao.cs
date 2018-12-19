using System.Collections.Generic;
namespace Caelum.Leilao
{

    public class Leilao
    {

        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            if (PodeDarLance(lance))
            {
                Lances.Add(lance);
            }
        }

        private bool PodeDarLance(Lance lance)
        {
            return Lances.Count == 0 || (!UltimoLanceDado().Usuario.Equals(lance.Usuario) && QuantidadeDeLances(lance.Usuario) < 5);
        }

        private int QuantidadeDeLances(Usuario usuario)
        {
            int total = 0;
            foreach (var l in Lances)
            {
                if (l.Usuario.Equals(usuario))
                {
                    total++;
                }
            }

            return total;
        }

        private Lance UltimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }

        public void DobraLance(Usuario usuario)
        {
            Lance ultimo = UltimoLance(usuario);
            if (ultimo != null)
            {
                Propoe(new Lance(usuario, ultimo.Valor * 2));
            }
        }

        private Lance UltimoLance(Usuario usuario)
        {
            Lance ultimo = null;
            foreach (Lance lance in Lances)
            {
                if (lance.Usuario.Equals(usuario))
                {
                    ultimo = lance;
                }
            }
            return ultimo;
        }
    }
}