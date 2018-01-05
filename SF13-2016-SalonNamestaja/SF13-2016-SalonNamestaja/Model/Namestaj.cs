using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF13_2016_SalonNamestaja.Model
{
    public class Namestaj: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private int id;
        private string naziv;
        private string sifra;
        private double cena;
        private int kolicina;
        private string tipNamestaja;
        private bool obrisan;

        public Namestaj() { }

        public Namestaj(int id, string naziv, string sifra, double cena, int kolicina, string tipNamestaja, bool obrisan)
        {
            this.id = id;
            this.naziv = naziv;
            this.sifra = sifra;
            this.cena = cena;
            this.kolicina = kolicina;
            this.tipNamestaja = tipNamestaja;
            this.obrisan = obrisan;
        }

        public int Id
        {
            get{ return id; }
            set{
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                if (value != naziv)
                {
                    naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        public string Sifra
        {
            get { return sifra; }
            set
            {
                if (value != sifra)
                {
                    sifra = value;
                    OnPropertyChanged("Sifra");
                }
            }
        }

        public double Cena
        {
            get { return cena; }
            set
            {
                if (value != cena)
                {
                    cena = value;
                    OnPropertyChanged("Cena");
                }
            }
        }

        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                if (value != kolicina)
                {
                    kolicina = value;
                    OnPropertyChanged("Kolicina");
                }
            }
        }

        public string TipNamestaja
        {
            get { return tipNamestaja; }
            set
            {
                if (value != tipNamestaja)
                {
                    tipNamestaja = value;
                    OnPropertyChanged("TipNamestaja");
                }
            }
        }

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                if (value != obrisan)
                {
                    obrisan = value;
                    OnPropertyChanged("Obrisan");
                }
            }
        }
    }
}
