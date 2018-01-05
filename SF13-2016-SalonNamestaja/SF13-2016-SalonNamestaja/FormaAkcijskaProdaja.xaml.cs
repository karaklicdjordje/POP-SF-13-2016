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
    /// Interaction logic for FormaAkcijskaProdaja.xaml
    /// </summary>
    public partial class FormaAkcijskaProdaja : Window
    {
        private string upisIzmena;
        private AkcijskaProdaja akcijskaProdIzmena;
        public FormaAkcijskaProdaja(string upisIzmena, AkcijskaProdaja akcijskaProdIzmena)
        {
            this.upisIzmena = upisIzmena;
            this.akcijskaProdIzmena = akcijskaProdIzmena;
            InitializeComponent();

            if (Kolekcije.lstNamestaj.Count > 0) {

                foreach (Namestaj nam in Kolekcije.lstNamestaj)
                {
                    comboNamestajId.Items.Add(nam.Id);
                }
            }

            if (upisIzmena == "izmena" && akcijskaProdIzmena != null)
            {

                comboNamestajId.SelectedItem = akcijskaProdIzmena.IdNamestaja;
                txtAkcijskaCena.Text = akcijskaProdIzmena.CenaPopust.ToString();
                dateDatumPocetka.SelectedDate = akcijskaProdIzmena.DatumPocetka;
                dateDatumZavrsetka.SelectedDate = akcijskaProdIzmena.DatumZavrsetka;

                buttonDodaj.Content = "Izmeni";

            }
        }

        private void buttonZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {

            if (comboNamestajId.SelectedIndex > -1 &&
                txtAkcijskaCena.Text.Trim() != null && !txtAkcijskaCena.Text.Trim().Equals("") &&
                Regex.IsMatch(txtAkcijskaCena.Text.Trim(), @"^\d+$") &&
                dateDatumPocetka.SelectedDate != null &&
                dateDatumZavrsetka.SelectedDate != null)
            {

                if (upisIzmena == "upis")
                {
                    AkcijskaProdaja novaAkcProd = new AkcijskaProdaja();
                    novaAkcProd.Id = noviIdAkcijskaProdaja();
                    novaAkcProd.IdNamestaja = Convert.ToInt32(comboNamestajId.SelectedItem.ToString());
                    novaAkcProd.CenaPopust = Convert.ToDouble(txtAkcijskaCena.Text);
                    novaAkcProd.DatumPocetka = dateDatumPocetka.SelectedDate.Value;
                    novaAkcProd.DatumZavrsetka = dateDatumZavrsetka.SelectedDate.Value;
                    novaAkcProd.Obrisan = false;
                    Kolekcije.lstAkcijskaProdaja.Add(novaAkcProd);

                }
                else if (upisIzmena == "izmena")
                {
                    foreach (AkcijskaProdaja akc in Kolekcije.lstAkcijskaProdaja)
                    {
                        if (akc.Id == akcijskaProdIzmena.Id)
                        {
                            akc.IdNamestaja = Convert.ToInt32(comboNamestajId.SelectedItem.ToString());
                            akc.CenaPopust = Convert.ToDouble(txtAkcijskaCena.Text);
                            akc.DatumPocetka = dateDatumPocetka.SelectedDate.Value;
                            akc.DatumZavrsetka = dateDatumZavrsetka.SelectedDate.Value;

                        }
                    }
                }

                this.Close();
            }
            else {
                MessageBox.Show("Niste uneli/odabrali neki od podataka ili niste upisali broj u predvidjeno polje!");
            }
        }

        public int noviIdAkcijskaProdaja()
        {

            int max = 0;
            foreach (AkcijskaProdaja akc in Kolekcije.lstAkcijskaProdaja)
            {
                if (akc.Id > max)
                    max = akc.Id;
            }
            max++;

            return max;
        }
    }
}
