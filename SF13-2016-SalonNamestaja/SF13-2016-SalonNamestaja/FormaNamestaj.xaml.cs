using SF13_2016_SalonNamestaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (txtNaziv.Text != null && !txtNaziv.Text.Equals("") &&
                txtSifra.Text != null && !txtSifra.Text.Equals("") &&
                txtCena.Text != null && !txtCena.Text.Equals("") &&
                Regex.IsMatch(txtCena.Text, @"^\d+$")&&
                txtKolicina.Text != null && !txtKolicina.Text.Equals("") &&
                Regex.IsMatch(txtKolicina.Text, @"^\d+$"))
            {
                if (upisIzmena == "upis")
                {

                    Namestaj namestaj = new Namestaj();
                    namestaj.Id = noviIdNamestaj();
                    namestaj.Naziv = txtNaziv.Text;
                    namestaj.Sifra = txtSifra.Text;
                    namestaj.Cena = Convert.ToDouble(txtCena.Text);
                    namestaj.Kolicina = Convert.ToInt32(txtKolicina.Text);
                    namestaj.TipNamestaja = comboTipNamestaja.SelectedItem.ToString();
                    namestaj.Obrisan = false;
                    Kolekcije.lstNamestaj.Add(namestaj);

                }

                if (upisIzmena == "izmena" && namestaj != null)
                {

                    foreach (Namestaj nam in Kolekcije.lstNamestaj)
                    {
                        if (nam.Id == namestaj.Id)
                        {

                            nam.Naziv = txtNaziv.Text;
                            nam.Sifra = txtSifra.Text;
                            nam.Cena = Convert.ToDouble(txtCena.Text);
                            nam.Kolicina = Convert.ToInt32(txtKolicina.Text);
                            nam.TipNamestaja = comboTipNamestaja.SelectedItem.ToString();

                        }
                    }
                }

                this.Close();
            }
            else {
                MessageBox.Show("Niste uneli sve podatke ili niste uneli brojeve za cenu i/ili kolicinu!");
            }
        }

        public int noviIdNamestaj()
        {

            int max = 0;
            foreach (Namestaj namestaj in Kolekcije.lstNamestaj)
            {
                if (namestaj.Id > max)
                    max = namestaj.Id;
            }
            max++;

            return max;
        }
    }
}
