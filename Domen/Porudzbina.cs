using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen
{
    public class Porudzbina : DomenskiObjekat.DomenskiObjekat
    {
        public int PorudzbinaId { get; set; }
        public string SifraPorudzbine { get; set; }
        public DateTime DatumNarucivanja { get; set; }
        public decimal UkupnoBezPDVa { get; set; }
        public decimal UkupnoSaPDVom { get; set; }
        public string UsloviPlacanja { get; set; }
        public string NacinIsporuke { get; set; }

        public Porucilac Porucilac { get; set; }
        public Objekat Objekat { get; set; }
        public Dobavljac Dobavljac { get; set; }
        [Browsable(false)]
        public Narudzbenica Narudzbenica { get; set; }

        [Browsable(false)]
        public string NazivTabele => "Porudzbina";
        [Browsable(false)]
        public string InsertVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string UpdateVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string Join => "p join dobavljac d on (p.dobavljacId = d.dobavljacId) join porucilac pr on (pr.porucilacId = p.porudzbinaid) join Poslovniobjekat o on (p.objekatid = o.objekatid) join porucilac por on (p.porucilacid = por.porucilacId)";
        [Browsable(false)]
        public string Where => throw new NotImplementedException();
        [Browsable(false)]
        public string SelectVrednosti => " * ";

  

        List<DomenskiObjekat.DomenskiObjekat> DomenskiObjekat.DomenskiObjekat.GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> porudzbine = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                Porudzbina p = new Porudzbina();
                p.PorudzbinaId = reader.GetInt32(0);
                p.SifraPorudzbine = reader.GetString(1);    
                p.DatumNarucivanja = reader.GetDateTime(2); 
                p.UkupnoBezPDVa = reader.GetDecimal(3);
                p.UkupnoSaPDVom = reader.GetDecimal(4);
                p.UsloviPlacanja = reader.GetString(5);
                p.NacinIsporuke = reader.GetString(6);  
                
                Porucilac porucilac = new Porucilac();  
                porucilac.NazivPorucioca = reader.GetString(19);
                p.Porucilac =   porucilac;

                Objekat o = new Objekat();
                o.SifraObjekta = reader.GetString(26);
                p.Objekat = o;  

                Dobavljac dobavljac = new Dobavljac();  
                dobavljac.NazivDobavljaca = reader.GetString(12);
                p.Dobavljac = dobavljac;    

                porudzbine.Add(p);
            }
            return porudzbine;
        }
    }
}