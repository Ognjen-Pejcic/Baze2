using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Dobavljac : DomenskiObjekat.DomenskiObjekat
    {
        public int DobavljacId { get; set; }
        public string NazivDobavljaca { get; set; }
        public string PoreskiBroj { get; set; }
        [Browsable(false)]
        public Adresa Adresa { get; set; }
        [Browsable(false)]
        public string NazivTabele => "Dobavljac";
        [Browsable(false)]
        public string InsertVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string UpdateVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string Join => $"WITH(INDEX(nazivDobavljaca_indeks))  where nazivDobavljaca like '%{NazivDobavljaca}%'";
        [Browsable(false)]
        public string Where => "";
        [Browsable(false)]
        public string SelectVrednosti => "*";

        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> dobavljaci = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                Dobavljac d = new Dobavljac();
                d.DobavljacId = reader.GetInt32(0);
                d.NazivDobavljaca = reader.GetString(1);    
                d.PoreskiBroj = reader.GetString(2);
                dobavljaci.Add(d);
            }
            return dobavljaci; 
        }
        public override string ToString()
        {
            return NazivDobavljaca;
        }
    }
}
