using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace SF13_2016_SalonNamestaja.Model
{
    public class UpisUBazu
    {
        private static UpisUBazu instance;
        private string connectionString = "Server=DJORDJE-PC\\INSTANCA; Database=salonnamestaja; Integrated Security=True;";

        private UpisUBazu() { }

        public static UpisUBazu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UpisUBazu();
                }
                return instance;
            }
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


        public void upisiRedPodataka(string upis)
        {


            using (SqlConnection connection = new SqlConnection(ConnectionString))

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = upis;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public ObservableCollection<Namestaj> listaNamestajaIzBaze()
        {

            ObservableCollection<Namestaj> lstNamestaj = new ObservableCollection<Namestaj>();
            SqlConnection connection;
            SqlCommand command;
            string sql = "select * from namestaj;";
            SqlDataReader dataReader;

            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id= Convert.ToInt32(dataReader.GetValue(0).ToString());
                    string naziv= dataReader.GetValue(1).ToString();
                    string sifra= dataReader.GetValue(2).ToString();
                    double cena=Convert.ToDouble(dataReader.GetValue(3).ToString());
                    int kolicina=Convert.ToInt32(dataReader.GetValue(4).ToString());
                    string tipNamestaja= dataReader.GetValue(5).ToString();
                    bool obrisan=Convert.ToBoolean(dataReader.GetValue(6).ToString());

                    Namestaj namestaj = new Namestaj(id, naziv, sifra, cena, kolicina, tipNamestaja, obrisan);
                    lstNamestaj.Add(namestaj);


                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {

            }

            return lstNamestaj;

        }

        public ObservableCollection<AkcijskaProdaja> listaAkcijskihProdajaIzBaze()
        {

            ObservableCollection<AkcijskaProdaja> lstAkcijskaProdaja = new ObservableCollection<AkcijskaProdaja>();
            SqlConnection connection;
            SqlCommand command;
            string sql = "select * from AkcijskaProdaja;";
            SqlDataReader dataReader;

            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader.GetValue(0).ToString());
                    int idNamestaja = Convert.ToInt32(dataReader.GetValue(1).ToString());
                    double cenaPopust = Convert.ToDouble(dataReader.GetValue(2).ToString());
                    DateTime datumPocetka = Convert.ToDateTime(dataReader.GetValue(3).ToString());
                    DateTime datumZavrsetka = Convert.ToDateTime(dataReader.GetValue(4).ToString());
                    bool obrisan = Convert.ToBoolean(dataReader.GetValue(5).ToString());

                    AkcijskaProdaja akcProd = new AkcijskaProdaja(id, idNamestaja, cenaPopust, datumPocetka, datumZavrsetka, obrisan);
                    lstAkcijskaProdaja.Add(akcProd);

                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {

            }

            return lstAkcijskaProdaja;

        }


        public ObservableCollection<Prodaja> listaProdajaIzBaze()
        {

            ObservableCollection<Prodaja> lstProdaja = new ObservableCollection<Prodaja>();
            SqlConnection connection;
            SqlCommand command;
            string sql = "select * from Prodaja;";
            SqlDataReader dataReader;

            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader.GetValue(0).ToString());
                    int idNamestaja = Convert.ToInt32(dataReader.GetValue(1).ToString());
                    int brKomada = Convert.ToInt32(dataReader.GetValue(2).ToString());
                    DateTime datumProdaje = Convert.ToDateTime(dataReader.GetValue(3).ToString());
                    string brojRacuna = dataReader.GetValue(4).ToString();
                    string imePrezimeKupca = dataReader.GetValue(5).ToString();
                    bool prevoz = Convert.ToBoolean(dataReader.GetValue(6).ToString());
                    bool montaza = Convert.ToBoolean(dataReader.GetValue(7).ToString());
                    double ukupnaCena = Convert.ToDouble(dataReader.GetValue(8).ToString());
                    bool obrisan = Convert.ToBoolean(dataReader.GetValue(9).ToString());

                    Prodaja prodaja = new Prodaja(id, idNamestaja, brKomada, 
                        datumProdaje, brojRacuna, imePrezimeKupca, prevoz, montaza, ukupnaCena, obrisan);
                    lstProdaja.Add(prodaja);

                        /*    private int id;
                        private int idNamestaja;
                        private int brKomada;
                        private DateTime datumProdaje;
                        private string brojRacuna;
                        private string imePrezimeKupca;
                        private bool prevoz;
                        private bool montaza;
                        private double ukupnaCena;
                        private bool obrisan;*/

                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {

            }

            return lstProdaja;

        }




    }
}
