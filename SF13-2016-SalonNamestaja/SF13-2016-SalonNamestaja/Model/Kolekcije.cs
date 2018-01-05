using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF13_2016_SalonNamestaja.Model
{
    public class Kolekcije
    {

        public static ObservableCollection<Namestaj> lstNamestaj = new ObservableCollection<Namestaj>();
        public static ObservableCollection<Prodaja> lstProdaja = new ObservableCollection<Prodaja>();
        public static ObservableCollection<AkcijskaProdaja> lstAkcijskaProdaja = new ObservableCollection<AkcijskaProdaja>();
        public static ObservableCollection<Korisnik> lstKorisnici = new ObservableCollection<Korisnik>();

    }
}
