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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();

            comboPrikazTabela.Items.Add("Prodaja");
            comboPrikazTabela.Items.Add("Namestaj");
            comboPrikazTabela.Items.Add("Akcijske prodaje");
            comboPrikazTabela.Items.Add("Korisnici");

            Kolekcije.lstKorisnici.Add(new Korisnik(1, "Petar", "Petrovic", "petar", "petrovic", "prodavac", false));
            Kolekcije.lstNamestaj.Add(new Namestaj(1, "Krevet No3", "SDSA432", 23444, 45, "kreveti", false));

            dataGrid.ItemsSource = Kolekcije.lstProdaja;
        }

        private void btUpis_Click(object sender, RoutedEventArgs e)
        {
            if (comboPrikazTabela.SelectedItem.ToString() == "Korisnici") {
                FormaKorisnik forma = new FormaKorisnik("upis", null);
                forma.ShowDialog();
            }

            if (comboPrikazTabela.SelectedItem.ToString() == "Namestaj")
            {
                FormaNamestaj forma = new FormaNamestaj("upis", null);
                forma.ShowDialog();
            }

            if (comboPrikazTabela.SelectedItem.ToString() == "Akcijske prodaje")
            {
                FormaAkcijskaProdaja forma = new FormaAkcijskaProdaja("upis", null);
                forma.ShowDialog();
            }
        }

        private void btIzmena_Click(object sender, RoutedEventArgs e)
        {
            if (comboPrikazTabela.SelectedItem.ToString() == "Korisnici")
            {
                if (Kolekcije.lstKorisnici.Count > 0 && dataGrid.SelectedIndex != -1)
                {

                    Korisnik korisnik = (Korisnik)dataGrid.SelectedItem;

                    FormaKorisnik izmenaKorisnika = new FormaKorisnik("izmena", korisnik);
                    izmenaKorisnika.Owner = this;
                    izmenaKorisnika.ShowDialog();

                    dataGrid.Items.Refresh();

                }
            }

            if (comboPrikazTabela.SelectedItem.ToString() == "Namestaj")
            {
                if (Kolekcije.lstNamestaj.Count > 0 && dataGrid.SelectedIndex != -1)
                {

                    Namestaj namestaj = (Namestaj)dataGrid.SelectedItem;

                    FormaNamestaj izmenaNamestaj = new FormaNamestaj("izmena", namestaj);
                    izmenaNamestaj.Owner = this;
                    izmenaNamestaj.ShowDialog();

                    dataGrid.Items.Refresh();

                }
            }

            if (comboPrikazTabela.SelectedItem.ToString() == "Akcijske prodaje")
            {
                if (Kolekcije.lstAkcijskaProdaja.Count > 0 && dataGrid.SelectedIndex != -1)
                {

                    AkcijskaProdaja akcProd = (AkcijskaProdaja)dataGrid.SelectedItem;

                    FormaAkcijskaProdaja izmenaAkcProd = new FormaAkcijskaProdaja("izmena", akcProd);
                    izmenaAkcProd.Owner = this;
                    izmenaAkcProd.ShowDialog();

                    dataGrid.Items.Refresh();

                }
            }
        }

        private void btBrisanje_Click(object sender, RoutedEventArgs e)
        {
            if (comboPrikazTabela.SelectedItem.ToString() == "Korisnici")
            {
                if (Kolekcije.lstKorisnici.Count > 0 && dataGrid.SelectedIndex != -1)
                {
                    Korisnik korisnik = (Korisnik)dataGrid.SelectedItem;
                    for (int i = 0; i < Kolekcije.lstKorisnici.Count; i++) {
                        if (Kolekcije.lstKorisnici.ElementAt(i).Id == korisnik.Id)
                            Kolekcije.lstKorisnici.ElementAt(i).Obrisan = true;
                    }

                    dataGrid.Items.Refresh();
                }
            }

            if (comboPrikazTabela.SelectedItem.ToString() == "Namestaj")
            {
                if (Kolekcije.lstNamestaj.Count > 0 && dataGrid.SelectedIndex != -1)
                {
                    Namestaj namestaj = (Namestaj)dataGrid.SelectedItem;
                    for (int i = 0; i < Kolekcije.lstNamestaj.Count; i++)
                    {
                        if (Kolekcije.lstNamestaj.ElementAt(i).Id == namestaj.Id)
                            Kolekcije.lstNamestaj.ElementAt(i).Obrisan = true;
                    }

                    dataGrid.Items.Refresh();
                }
            }

            if (comboPrikazTabela.SelectedItem.ToString() == "Akcijske prodaje")
            {
                if (Kolekcije.lstAkcijskaProdaja.Count > 0 && dataGrid.SelectedIndex != -1)
                {
                    AkcijskaProdaja akcProd = (AkcijskaProdaja)dataGrid.SelectedItem;
                    for (int i = 0; i < Kolekcije.lstAkcijskaProdaja.Count; i++)
                    {
                        if (Kolekcije.lstAkcijskaProdaja.ElementAt(i).Id == akcProd.Id)
                            Kolekcije.lstAkcijskaProdaja.ElementAt(i).Obrisan = true;
                    }

                    dataGrid.Items.Refresh();
                }
            }
        }

        private void comboPrikazTabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboPrikazTabela.SelectedItem.ToString() == "Prodaja")
            {
                dataGrid.ItemsSource = Kolekcije.lstProdaja;
                dataGrid.Items.Refresh();
            }
            if (comboPrikazTabela.SelectedItem.ToString() == "Namestaj")
            {
                dataGrid.ItemsSource = Kolekcije.lstNamestaj;
                dataGrid.Items.Refresh();
            }
            if (comboPrikazTabela.SelectedItem.ToString() == "Akcijske prodaje")
            {
                dataGrid.ItemsSource = Kolekcije.lstAkcijskaProdaja;
                dataGrid.Items.Refresh();
            }
            if (comboPrikazTabela.SelectedItem.ToString() == "Korisnici")
            {
                dataGrid.ItemsSource = Kolekcije.lstKorisnici;
                dataGrid.Items.Refresh();
            }
        }
    }
}
