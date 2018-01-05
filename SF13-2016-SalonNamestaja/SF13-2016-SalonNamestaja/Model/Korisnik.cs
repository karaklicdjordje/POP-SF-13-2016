using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF13_2016_SalonNamestaja.Model
{
    public class Korisnik : INotifyPropertyChanged
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
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string lozinka;
        private string tipKorisnika;
        private bool obrisan;

        public Korisnik() { }

        public Korisnik(int id, string ime, string prezime, string korisnickoIme, string lozinka, string tipKorisnika, bool obrisan)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.tipKorisnika = tipKorisnika;
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

        public string Ime
        {
            get { return ime; }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (value != prezime)
                {
                    prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                if (value != korisnickoIme)
                {
                    korisnickoIme = value;
                    OnPropertyChanged("KorisnickoIme");
                }
            }
        }

        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                if (value != lozinka)
                {
                    lozinka = value;
                    OnPropertyChanged("Lozinka");
                }
            }
        }

        public string TipKorisnika
        {
            get { return tipKorisnika; }
            set
            {
                if (value != tipKorisnika)
                {
                    tipKorisnika = value;
                    OnPropertyChanged("TipKorisnika");
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
