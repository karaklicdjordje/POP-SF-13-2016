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
using System.Windows.Shapes;

namespace SF13_2016_SalonNamestaja
{
    /// <summary>
    /// Interaction logic for FormaKorisnik.xaml
    /// </summary>
    public partial class FormaKorisnik : Window
    {
        private string upisIzmena = "";
        private Korisnik korisnik = null;
        public FormaKorisnik(string upisIzmena, Korisnik korisnik)
        {
            this.upisIzmena = upisIzmena;
            this.korisnik = korisnik;
            InitializeComponent();

            comboTipKorisnika.Items.Add("Prodavac");
            comboTipKorisnika.Items.Add("Administrator");

            if (upisIzmena == "izmena" && korisnik!=null) {

                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtKorisnickoIme.Text = korisnik.KorisnickoIme;
                txtLozinka.Text = korisnik.Lozinka;
                comboTipKorisnika.SelectedItem = korisnik.TipKorisnika;

                btDodaj.Content = "Izmeni";

            }

            /*
                private int id;
                private string ime;
                private string prezime;
                private string korisnickoIme;
                private string lozinka;
                private string tipKorisnika;

             */
        }

        private void btZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (txtIme.Text != null && !txtIme.Text.Equals("") &&
                txtPrezime.Text != null && !txtPrezime.Text.Equals("") &&
                txtKorisnickoIme.Text != null && !txtKorisnickoIme.Text.Equals("") &&
                txtLozinka.Text != null && !txtLozinka.Text.Equals(""))
            {
                if (upisIzmena == "upis")
                {
                    Korisnik korisnik = new Korisnik();
                    korisnik.Id = noviIdKorisnik();
                    korisnik.Ime = txtIme.Text;
                    korisnik.Prezime = txtPrezime.Text;
                    korisnik.KorisnickoIme = txtKorisnickoIme.Text;
                    korisnik.Lozinka = txtLozinka.Text;
                    korisnik.TipKorisnika = comboTipKorisnika.SelectedItem.ToString();
                    korisnik.Obrisan = false;
                    Kolekcije.lstKorisnici.Add(korisnik);
                }
                if (upisIzmena == "izmena" && korisnik != null)
                {

                    foreach (Korisnik kor in Kolekcije.lstKorisnici)
                    {
                        if (kor.Id == korisnik.Id)
                        {

                            kor.Ime = txtIme.Text;
                            kor.Prezime = txtPrezime.Text;
                            kor.KorisnickoIme = txtKorisnickoIme.Text;
                            kor.Lozinka = txtLozinka.Text;
                            kor.TipKorisnika = comboTipKorisnika.SelectedItem.ToString();
                        }
                    }
                }

                this.Close();
            }
            else {
                MessageBox.Show("Niste uneli sve podatke!");
            }
        }

        public int noviIdKorisnik()
        {

            int max = 0;
            foreach (Korisnik korisnik in Kolekcije.lstKorisnici)
            {
                if (korisnik.Id > max)
                    max = korisnik.Id;
            }
            max++;

            return max;
        }
    }
}
