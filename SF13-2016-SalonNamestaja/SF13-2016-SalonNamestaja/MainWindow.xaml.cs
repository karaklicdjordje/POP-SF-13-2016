using SF13_2016_SalonNamestaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SF13_2016_SalonNamestaja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Kolekcije.lstKorisnici.Add(new Korisnik(1, "Petar", "Petrovic", "petar", "petrovic", "prodavac", false));
            Kolekcije.lstKorisnici.Add(new Korisnik(2, "Nikola", "Nikolic", "nikola", "nikolic", "administrator", false));

            Kolekcije.lstNamestaj.Add(new Namestaj(1, "Krevet No3", "12", 23444, 45, "kreveti", false));
            Kolekcije.lstNamestaj.Add(new Namestaj(2, "Krevet No2", "23", 21000, 45, "kreveti", false));
            Kolekcije.lstNamestaj.Add(new Namestaj(3, "Krevet No1", "34", 25000, 45, "kreveti", false));

        }

        private void btPrijava_Click(object sender, RoutedEventArgs e)
        {

            bool postojiKorisnik = false;
            string tipKorisnika = "";
            foreach (Korisnik k in Kolekcije.lstKorisnici) {

                if (k.KorisnickoIme == txtKorisnikoIme.Text && k.Lozinka == txtLozinka.Text) {
                    postojiKorisnik = true;
                    tipKorisnika = k.TipKorisnika;

                    if (k.Obrisan)
                        postojiKorisnik = false;
                }
            }

            if (postojiKorisnik)
            {
                if (chCitajIzBaze.IsChecked == true) {

                    Kolekcije.lstNamestaj.Clear();
                    Kolekcije.lstNamestaj = UpisUBazu.Instance.listaNamestajaIzBaze();

                    Kolekcije.lstAkcijskaProdaja.Clear();
                    Kolekcije.lstAkcijskaProdaja = UpisUBazu.Instance.listaAkcijskihProdajaIzBaze();

                    Kolekcije.lstProdaja.Clear();
                    Kolekcije.lstProdaja = UpisUBazu.Instance.listaProdajaIzBaze();

                }
                Main proz = new Main(tipKorisnika);
                proz.ShowDialog();
            }
            else {
                MessageBox.Show("Pogresno korisnicko ime i/ili lozinka!");
            }
            
            //Main proz = new Main("administrator");
            //Main proz = new Main("prodavac");
            //proz.ShowDialog();
            
        }
    }
}
