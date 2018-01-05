using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF13_2016_SalonNamestaja.Model
{
    public class AkcijskaProdaja : INotifyPropertyChanged
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
        private double cenaPopust;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private bool obrisan;

        public AkcijskaProdaja() { }
        public AkcijskaProdaja(int id, int idNamestaja, double cenaPopust, DateTime datumPocetka, DateTime datumZavrsetka, bool obrisan)
        {
            this.id = id;
            this.idNamestaja = idNamestaja;
            this.cenaPopust = cenaPopust;
            this.datumPocetka = datumPocetka;
            this.datumZavrsetka = datumZavrsetka;
            this.obrisan = obrisan;
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

        public double CenaPopust
        {
            get { return cenaPopust; }
            set
            {
                if (value != cenaPopust)
                {
                    cenaPopust = value;
                    OnPropertyChanged("CenaPopust");
                }
            }
        }

        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                if (value != datumPocetka)
                {
                    datumPocetka = value;
                    OnPropertyChanged("DatumPocetka");
                }
            }
        }

        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                if (value != datumZavrsetka)
                {
                    datumZavrsetka = value;
                    OnPropertyChanged("DatumZavrsetka");
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
