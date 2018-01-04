using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF13_2016_SalonNamestaja.Model
{
    public class Salon
    {
        private int id;
        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string sajt;
        private string pib;
        private string maticniBroj;
        private string brZiroRacuna;

        public Salon(int id, string naziv, string adresa, string telefon, string email, string sajt, string pib, string maticniBroj, string brZiroRacuna)
        {
            this.id = id;
            this.naziv = naziv;
            this.adresa = adresa;
            this.telefon = telefon;
            this.email = email;
            this.sajt = sajt;
            this.pib = pib;
            this.maticniBroj = maticniBroj;
            this.brZiroRacuna = brZiroRacuna;
        }
    }
}
