using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class ProdavacGlavno : DomenskiObjekat.DomenskiObjekat
    {
        public int ProdavacId { get; set; }
        public string Obelezja { get; set; }
        public string ProdavacName { get; set; }

        [Browsable(false)]
        public string NazivTabele => "prodavac_glavno";
        [Browsable(false)]
        public string InsertVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string UpdateVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string Join => "";
        [Browsable(false)]
        public string Where => throw new NotImplementedException();
        [Browsable(false)]
        public string SelectVrednosti => "ProdavacId, NazivProdavca,Obelezja.Spojeno() AS sumirano";

        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> prodavac = new List<DomenskiObjekat.DomenskiObjekat>();
            while(reader.Read())
            {
                ProdavacGlavno prodavacGlavno = new ProdavacGlavno();
                prodavacGlavno.ProdavacId = reader.GetInt32(0);
                prodavacGlavno.ProdavacName =  reader.GetString(1);
                prodavacGlavno.Obelezja = reader.GetString(2);
                
                prodavac.Add(prodavacGlavno);
            }
            return prodavac;
        }
    }
}
