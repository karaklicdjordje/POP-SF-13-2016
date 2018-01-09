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
    /// Interaction logic for FormaProdaja.xaml
    /// </summary>
    public partial class FormaProdaja : Window
    {

        private Namestaj namestajProdaja;
        public FormaProdaja(Namestaj namestajProdaja)
        {
            this.namestajProdaja = namestajProdaja;
            InitializeComponent();
            txtPrevozCena.IsEnabled = false;
            txtMontazaCena.IsEnabled = false;

            lbIdNazivNamestaja.Content = "Id namestaja: " + namestajProdaja.Id + "  Naziv: " + namestajProdaja.Naziv;

        }

        private void chPrevoz_Checked(object sender, RoutedEventArgs e)
        {
            if (chPrevoz.IsChecked == true)
                txtPrevozCena.IsEnabled = true;
            else
                txtPrevozCena.IsEnabled = false;

        }

        private void chMontaza_Checked(object sender, RoutedEventArgs e)
        {
            if (chMontaza.IsChecked == true)
                txtMontazaCena.IsEnabled = true;
            else
                txtMontazaCena.IsEnabled = false;
        }

        private void btZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btDodaj_Click(object sender, RoutedEventArgs e)
        {
            double cenaMontaza = 0, cenaPrevoz = 0, cenaArtikla=0;

            if (txtBrojKomada.Text != null && !txtBrojKomada.Text.Equals("") &&
                Regex.IsMatch(txtBrojKomada.Text, @"^\d+$") &&
                txtBrojRacuna.Text != null && !txtBrojRacuna.Text.Equals("") &&
                txtImePrezimeKupca.Text != null && !txtImePrezimeKupca.Text.Equals(""))
            {


                 int id=noviIdProdaja();
                 int idNamestaja=namestajProdaja.Id;
                 int brKomada=Convert.ToInt32(txtBrojKomada.Text);
                 DateTime datumProdaje=DateTime.Now;
                 string brojRacuna=txtBrojRacuna.Text;
                 string imePrezimeKupca=txtImePrezimeKupca.Text;

                 bool prevoz=false;
                 bool montaza=false;
                 double ukupnaCena=0;

                 bool obrisan=false;

                if (chPrevoz.IsChecked==true)
                {
                    prevoz = true;

                    if (txtPrevozCena.Text != null && !txtPrevozCena.Text.Equals("") &&
                    Regex.IsMatch(txtPrevozCena.Text, @"^\d+$"))
                    {

                        cenaPrevoz = Convert.ToDouble(txtPrevozCena.Text);

                    }
                    else {
                        cenaPrevoz = 1000;
                    }

                }

                if (chMontaza.IsChecked == true)
                {
                    montaza = true;

                    if (txtMontazaCena.Text != null && !txtMontazaCena.Text.Equals("") &&
                    Regex.IsMatch(txtMontazaCena.Text, @"^\d+$"))
                    {

                        cenaMontaza = Convert.ToDouble(txtMontazaCena.Text);

                    }
                    else {
                        cenaMontaza = 500;
                    }

                }

                foreach (AkcijskaProdaja akc in Kolekcije.lstAkcijskaProdaja) {
                    if (akc.IdNamestaja == namestajProdaja.Id)
                        cenaArtikla = akc.CenaPopust;
                }
                if (cenaArtikla == 0)
                    cenaArtikla = namestajProdaja.Cena;

                ukupnaCena = cenaArtikla + cenaPrevoz + cenaMontaza;
                lbUkupnaCena.Content = "Ukupna cena: " + ukupnaCena;


                Prodaja novaProdaja = new Prodaja(id, idNamestaja, brKomada, datumProdaje, brojRacuna, imePrezimeKupca, prevoz, montaza, ukupnaCena, obrisan);
                Kolekcije.lstProdaja.Add(novaProdaja);

                UpisUBazu.Instance.upisiRedPodataka(
                    "insert into Prodaja(id,idNamestaja,brKomada,datumProdaje,brojRacuna," +
                    "imePrezimeKupca,prevoz,montaza,ukupnaCena,obrisan) values('"
                    + id + "','"
                    + idNamestaja + "','"
                    + brKomada + "','"
                    + datumProdaje + "','"
                    + brojRacuna + "','"
                    + imePrezimeKupca + "','"
                    + prevoz + "','"
                    + montaza + "','"
                    + ukupnaCena + "','"
                    + obrisan + "');");

            }
            else {
                MessageBox.Show("Neke od podataka niste pravilno uneli!");
            }
        }

        public int noviIdProdaja()
        {

            int max = 0;
            foreach (Prodaja prod in Kolekcije.lstProdaja)
            {
                if (prod.Id > max)
                    max = prod.Id;
            }
            max++;

            return max;
        }
    }
}
