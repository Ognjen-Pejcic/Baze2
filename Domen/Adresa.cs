using System.Data.SqlClient;

namespace Domen
{
    public class Adresa : DomenskiObjekat.DomenskiObjekat
    {
        public int Broj { get; set; }
        public int UlicaId { get; set; } 
        public string NazivUlice { get; set; }
        public int GradId { get; set; }
        public string NazivGrada { get; set; }
        public int DrzavaId { get; set; }
        public string NazivDrzave { get; set; }

        public string NazivTabele => "Adresa";

        public string InsertVrednosti => throw new NotImplementedException();

        public string UpdateVrednosti => throw new NotImplementedException();

        public string Join => " a join ulica u on (a.ulicaId = u.ulicaId) join grad g on (g.postanskiBroj = u.postanskibroj) join drzava d on (d.drzavaid = g.drzavaId)";

        public string Where => throw new NotImplementedException();

        public string SelectVrednosti => "*";

        List<DomenskiObjekat.DomenskiObjekat> DomenskiObjekat.DomenskiObjekat.GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> result = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                Adresa a = new Adresa();
                a.Broj = reader.GetInt32(0);
                a.DrzavaId = reader.GetInt32(1);
                a.GradId = reader.GetInt32(2);  
                a.UlicaId = reader.GetInt32(3);
                a.NazivUlice = reader.GetString(5);
                a.NazivDrzave = reader.GetString(12);
                a.NazivGrada = reader.GetString(9);

                result.Add(a);
            }
            return result;
        }
        public override string ToString()
        {
            return NazivUlice + " " + Broj +". " + GradId + " " + NazivGrada + ", " + NazivDrzave;
        }

    }
}