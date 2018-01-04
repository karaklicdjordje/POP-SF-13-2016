using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF13_2016_SalonNamestaja.Model
{
    public class ModifikacijePodataka
    {
        private static ModifikacijePodataka instance;
        public static ModifikacijePodataka Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModifikacijePodataka();

                }

                return instance;
            }
        }

        public static ObservableCollection<Namestaj> lstNamestaj = new ObservableCollection<Namestaj>();
        public static ObservableCollection<Prodaja> lstProdaja = new ObservableCollection<Prodaja>();
        public static ObservableCollection<AkcijskaProdaja> lstAkcijskaProdaja = new ObservableCollection<AkcijskaProdaja>();
        public static ObservableCollection<Korisnik> lstKorisnici = new ObservableCollection<Korisnik>();

        public static int noviIdKorisnik() {

            int max = 0;
            foreach (Korisnik korisnik in lstKorisnici) {
                if (korisnik.Id > max)
                    max = korisnik.Id;
            }
            max++;

            return max;
        }

        public static int noviIdNamestaj()
        {

            int max = 0;
            foreach (Namestaj namestaj in lstNamestaj)
            {
                if (namestaj.Id > max)
                    max = namestaj.Id;
            }
            max++;

            return max;
        }
    }
}
