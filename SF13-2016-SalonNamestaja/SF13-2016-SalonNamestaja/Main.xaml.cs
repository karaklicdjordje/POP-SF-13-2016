using SF13_2016_SalonNamestaja.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string tipKorisnika;
        public Main(string tipKorisnika)
        {
            this.tipKorisnika = tipKorisnika;
            InitializeComponent();

            if (tipKorisnika == "prodavac") {

                comboPrikazTabela.Items.Add("Namestaj");
                comboPrikazTabela.Items.Add("Prodaje");

                buttonUpisProdaje.IsEnabled = true;
                btUpis.IsEnabled = false;
                btIzmena.IsEnabled = false;
                btBrisanje.IsEnabled = false;

            }

            if (tipKorisnika == "administrator") {

                comboPrikazTabela.Items.Add("Namestaj");
                comboPrikazTabela.Items.Add("Prodaje");
                comboPrikazTabela.Items.Add("Akcijske prodaje");
                comboPrikazTabela.Items.Add("Korisnici");

                buttonUpisProdaje.IsEnabled = false;

            }




            dataGrid.ItemsSource = Kolekcije.lstNamestaj;

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
                        {
                            Kolekcije.lstNamestaj.ElementAt(i).Obrisan = true;

                            UpisUBazu.Instance.upisiRedPodataka(
                            "update Namestaj set obrisan='true' where id='" + 
                            Kolekcije.lstNamestaj.ElementAt(i).Id + "';");

                        }
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
                        {
                            Kolekcije.lstAkcijskaProdaja.ElementAt(i).Obrisan = true;

                            UpisUBazu.Instance.upisiRedPodataka(
                            "update AkcijskaProdaja set obrisan='true' where id='" +
                            Kolekcije.lstAkcijskaProdaja.ElementAt(i).Id + "';");

                        }
                    }

                    dataGrid.Items.Refresh();
                }
            }
        }

        private void comboPrikazTabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboPrikazTabela.SelectedItem.ToString() != "Prodaje") {

                if (tipKorisnika == "prodavac") {

                    buttonUpisProdaje.IsEnabled = false;
                    btUpis.IsEnabled = false;
                    btIzmena.IsEnabled = false;
                    btBrisanje.IsEnabled = false;
                }
                if (tipKorisnika == "administrator")
                {

                    buttonUpisProdaje.IsEnabled = false;
                    btUpis.IsEnabled = true;
                    btIzmena.IsEnabled = true;
                    btBrisanje.IsEnabled = true;
                }
            }

            if (comboPrikazTabela.SelectedItem.ToString() != "Namestaj") {
                if (tipKorisnika == "prodavac") {
                    buttonUpisProdaje.IsEnabled = false;
                    btUpis.IsEnabled = false;
                    btIzmena.IsEnabled = false;
                    btBrisanje.IsEnabled = false;
                }
                if (tipKorisnika == "administrator")
                {
                    buttonUpisProdaje.IsEnabled = false;
                    btUpis.IsEnabled = true;
                    btIzmena.IsEnabled = true;
                    btBrisanje.IsEnabled = true;
                }
            }

            if (comboPrikazTabela.SelectedItem.ToString() == "Prodaje")
            {
                dataGrid.ItemsSource = Kolekcije.lstProdaja;
                dataGrid.Items.Refresh();
                if (tipKorisnika == "prodavac")
                {
                    buttonUpisProdaje.IsEnabled = false;
                    btUpis.IsEnabled = false;
                    btIzmena.IsEnabled = false;
                    btBrisanje.IsEnabled = false;
                }
                if (tipKorisnika == "administrator") {

                    buttonUpisProdaje.IsEnabled = false;
                    btUpis.IsEnabled = false;
                    btIzmena.IsEnabled = false;
                    btBrisanje.IsEnabled = false;
                }
            }
            if (comboPrikazTabela.SelectedItem.ToString() == "Namestaj")
            {
                dataGrid.ItemsSource = Kolekcije.lstNamestaj;
                dataGrid.Items.Refresh();
                if (tipKorisnika == "prodavac")
                {
                    buttonUpisProdaje.IsEnabled = true;
                    btUpis.IsEnabled = false;
                    btIzmena.IsEnabled = false;
                    btBrisanje.IsEnabled = false;
                }
                if (tipKorisnika == "administrator")
                {
                    buttonUpisProdaje.IsEnabled = false;
                    btUpis.IsEnabled = true;
                    btIzmena.IsEnabled = true;
                    btBrisanje.IsEnabled = true;
                }
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

        private void buttonUpisProdaje_Click(object sender, RoutedEventArgs e)
        {

            if (Kolekcije.lstNamestaj.Count > 0 && dataGrid.SelectedIndex != -1)
            {

                Namestaj namestaj = (Namestaj)dataGrid.SelectedItem;

                FormaProdaja frm = new FormaProdaja(namestaj);
                //izmenaNamestaj.Owner = this;
                frm.ShowDialog();

                //dataGrid.Items.Refresh();

            }

        }

        private void btPrikaziSve_Click(object sender, RoutedEventArgs e)
        {
            txtPretraga.Text = "";

            if (comboPrikazTabela.SelectedItem.ToString() == "Namestaj")
            {
                dataGrid.ItemsSource = Kolekcije.lstNamestaj;
                dataGrid.Items.Refresh();
            }
            if (comboPrikazTabela.SelectedItem.ToString() == "Prodaje")
            {
                dataGrid.ItemsSource = Kolekcije.lstProdaja;
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

        private void btPretrazi_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Namestaj> lstNamestajFilter = new ObservableCollection<Namestaj>();
            ObservableCollection<Prodaja> lstProdajaFilter = new ObservableCollection<Prodaja>();
            ObservableCollection<AkcijskaProdaja> lstAkcijskaProdajaFilter = new ObservableCollection<AkcijskaProdaja>();
            ObservableCollection<Korisnik> lstKorisniciFilter = new ObservableCollection<Korisnik>();

            if (txtPretraga.Text != null && !txtPretraga.Text.Equals("")) {

                if (comboPrikazTabela.SelectedItem.ToString() == "Namestaj")
                {
                    foreach (Namestaj nam in Kolekcije.lstNamestaj) {

                        if (nam.TipNamestaja == txtPretraga.Text ||
                            nam.Sifra == txtPretraga.Text ||
                            nam.Naziv == txtPretraga.Text) {

                            lstNamestajFilter.Add(nam);
                        }
                    }

                    if (lstNamestajFilter.Count > 0)
                    {
                        dataGrid.ItemsSource = lstNamestajFilter;
                        dataGrid.Items.Refresh();
                    }
                }

                if (comboPrikazTabela.SelectedItem.ToString() == "Prodaje")
                {

                    foreach (Prodaja prod in Kolekcije.lstProdaja) {

                        if (prod.ImePrezimeKupca == txtPretraga.Text || prod.BrojRacuna == txtPretraga.Text) {

                            lstProdajaFilter.Add(prod);
                        }
                    }
                    if (lstProdajaFilter.Count > 0)
                    {
                        dataGrid.ItemsSource = lstProdajaFilter;
                        dataGrid.Items.Refresh();
                    }
                }
                if (comboPrikazTabela.SelectedItem.ToString() == "Akcijske prodaje")
                {

                    foreach (AkcijskaProdaja akc in Kolekcije.lstAkcijskaProdaja) {

                        if (akc.DatumPocetka <= DateTime.Now && akc.DatumZavrsetka >= DateTime.Now) {
                            lstAkcijskaProdajaFilter.Add(akc);
                        }
                    }
                    if (lstAkcijskaProdajaFilter.Count > 0)
                    {
                        dataGrid.ItemsSource = lstAkcijskaProdajaFilter;
                        dataGrid.Items.Refresh();
                    }
                }
                if (comboPrikazTabela.SelectedItem.ToString() == "Korisnici")
                {
                    foreach (Korisnik k in Kolekcije.lstKorisnici) {

                        if (k.Ime == txtPretraga.Text || k.Prezime == txtPretraga.Text || k.KorisnickoIme == txtPretraga.Text) {

                            lstKorisniciFilter.Add(k);
                        }
                    }
                    if (lstKorisniciFilter.Count > 0)
                    {
                        dataGrid.ItemsSource = lstKorisniciFilter;
                        dataGrid.Items.Refresh();
                    }
                }
            }
        }
    }
}
