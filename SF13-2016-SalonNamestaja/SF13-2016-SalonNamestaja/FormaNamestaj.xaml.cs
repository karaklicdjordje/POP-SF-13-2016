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
    /// Interaction logic for FormaNamestaj.xaml
    /// </summary>
    public partial class FormaNamestaj : Window
    {

        private string upisIzmena = "";
        private Namestaj namestaj = null;
        public FormaNamestaj(string upisIzmena, Namestaj namestaj)
        {
            this.upisIzmena = upisIzmena;
            this.namestaj = namestaj;
            InitializeComponent();

            comboTipNamestaja.Items.Add("kreveti");
            comboTipNamestaja.Items.Add("predsoblja");
            comboTipNamestaja.Items.Add("kuhinjski namestaj");

            if (upisIzmena == "izmena" && namestaj != null)
            {
                txtNaziv.Text = namestaj.Naziv;
                txtSifra.Text = namestaj.Sifra;
                txtCena.Text = namestaj.Cena.ToString();
                txtKolicina.Text = namestaj.Kolicina.ToString();
                comboTipNamestaja.SelectedItem = namestaj.TipNamestaja;

                btDodaj.Content = "Izmeni";

            }

            /*
                private int id;
                private string naziv;
                private string sifra;
                private double cena;
                private int kolicina;
                private string tipNamestaja;
             */
        }

        private void btZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (upisIzmena == "upis") {

                Namestaj namestaj = new Namestaj();
                namestaj.Id = ModifikacijePodataka.noviIdNamestaj();
                namestaj.Naziv = txtNaziv.Text.Trim();
                namestaj.Sifra = txtSifra.Text.Trim();
                namestaj.Cena = Convert.ToDouble(txtCena.Text.Trim());
                namestaj.Kolicina = Convert.ToInt32(txtKolicina.Text.Trim());
                namestaj.TipNamestaja = comboTipNamestaja.SelectedItem.ToString();
                ModifikacijePodataka.lstNamestaj.Add(namestaj);

            }

            if (upisIzmena == "izmena" && namestaj != null)
            {

                foreach (Namestaj nam in ModifikacijePodataka.lstNamestaj)
                {
                    if (nam.Id == namestaj.Id) {

                        nam.Naziv = txtNaziv.Text.Trim();
                        nam.Sifra = txtSifra.Text.Trim();
                        nam.Cena = Convert.ToDouble(txtCena.Text.Trim());
                        nam.Kolicina = Convert.ToInt32(txtKolicina.Text.Trim());
                        nam.TipNamestaja = comboTipNamestaja.SelectedItem.ToString();

                    }
                }
            }

            this.Close();
        }
    }
}
