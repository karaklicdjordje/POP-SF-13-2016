using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF13_2016_SalonNamestaja.Model
{
    public class Prodaja : INotifyPropertyChanged
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
        private int idNamestaja;
        private int brKomada;
        private DateTime datumProdaje;
        private string brojRacuna;
        private string imePrezimeKupca;
        private bool prevoz;
        private bool montaza;
        private double ukupnaCena;

        public Prodaja(int id, int idNamestaja, int brKomada, DateTime datumProdaje, string brojRacuna, string imePrezimeKupca, bool prevoz, bool montaza, double ukupnaCena)
        {
            this.id = id;
            this.idNamestaja = idNamestaja;
            this.brKomada = brKomada;
            this.datumProdaje = datumProdaje;
            this.brojRacuna = brojRacuna;
            this.imePrezimeKupca = imePrezimeKupca;
            this.prevoz = prevoz;
            this.montaza = montaza;
            this.ukupnaCena = ukupnaCena;
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public int IdNamestaja
        {
            get { return idNamestaja; }
            set
            {
                if (value != idNamestaja)
                {
                    idNamestaja = value;
                    OnPropertyChanged("IdNamestaja");
                }
            }
        }

        public int BrKomada
        {
            get { return brKomada; }
            set
            {
                if (value != brKomada)
                {
                    brKomada = value;
                    OnPropertyChanged("BrKomada");
                }
            }
        }

        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                if (value != datumProdaje)
                {
                    datumProdaje = value;
                    OnPropertyChanged("DatumProdaje");
                }
            }
        }

        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                if (value != brojRacuna)
                {
                    brojRacuna = value;
                    OnPropertyChanged("BrojRacuna");
                }
            }
        }

        public string ImePrezimeKupca
        {
            get { return imePrezimeKupca; }
            set
            {
                if (value != imePrezimeKupca)
                {
                    imePrezimeKupca = value;
                    OnPropertyChanged("ImePrezimeKupca");
                }
            }
        }

        public bool Prevoz
        {
            get { return prevoz; }
            set
            {
                if (value != prevoz)
                {
                    prevoz = value;
                    OnPropertyChanged("Prevoz");
                }
            }
        }

        public bool Montaza
        {
            get { return montaza; }
            set
            {
                if (value != montaza)
                {
                    montaza = value;
                    OnPropertyChanged("Montaza");
                }
            }
        }

        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set
            {
                if (value != ukupnaCena)
                {
                    ukupnaCena = value;
                    OnPropertyChanged("UkupnaCena");
                }
            }
        }

    }
}
