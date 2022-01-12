using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using UserDefinedTypes;

namespace Domen
{
    public class Prodavac : DomenskiObjekat.DomenskiObjekat
    {
        public int ProdavacId { get; set; }
        public string NazivProdavca { get; set; }
        [Browsable(false)]
        public int PIB{ get; set; }
        [Browsable(false)]
        public int MaticniBroj { get; set; }

        public string Obelezja { get; set; }
        public string BrojTelefona { get; set; }
        public string EmailAdresa { get; set; }
        public Adresa Adresa { get; set; }
        [Browsable(false)]
        public string NazivTabele => "Prodavac_pogled";
        [Browsable(false)]
        public string InsertVrednosti => $" {ProdavacId}, '{Obelezja}','{NazivProdavca}', '{BrojTelefona}', '{EmailAdresa}', {Adresa.DrzavaId}, {Adresa.GradId}, {Adresa.UlicaId}, {Adresa.Broj}";
        [Browsable(false)]
        public string UpdateVrednosti => $"obelezja = '{Obelezja}', nazivProdavca = '{NazivProdavca}', emailAdresa = '{EmailAdresa}', brojtelefona = '{BrojTelefona}', broj = {Adresa.Broj}, ulicaId = {Adresa.UlicaId}, drzavaId = {Adresa.DrzavaId}, postanskiBroj = {Adresa.GradId}";
        [Browsable(false)]
        public string Join => "p join adresa a on (p.broj = a.broj and p.ulicaid = a.ulicaid and p.postanskibroj = a.postanskibroj and p.drzavaid = a.drzavaid) join ulica u on (a.ulicaId = u.ulicaId) join grad g on (g.postanskiBroj = u.postanskibroj) join drzava d on (d.drzavaid = g.drzavaId)";
        [Browsable(false)]
        public string Where => $"prodavacId = {ProdavacId}";
        [Browsable(false)]
        public string SelectVrednosti => "p.ProdavacId, p.NazivProdavca,p.Obelezja.Spojeno() AS sumirano, p.brojTelefona, p.EmailAdresa, p.Broj, p.UlicaId, u.NazivUlice, p.PostanskiBroj, g.NazivGrada, p.DrzavaId, d.NazivDrzave ";
        [Browsable(false)]
        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> result = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                Prodavac b = new Prodavac();
                b.ProdavacId = reader.GetInt32(0);
                b.NazivProdavca = reader.GetString(1);
                b.Obelezja = reader.GetString(2);   
                b.BrojTelefona = reader.GetString(3);
                b.EmailAdresa = reader.GetString(4);    
                Adresa adresa = new Adresa();
                adresa.Broj = reader.GetInt32(5);
                adresa.UlicaId = reader.GetInt32(6);
                adresa.NazivUlice = reader.GetString(7);    
                adresa.GradId = reader.GetInt32(8); 
                adresa.NazivGrada = reader.GetString(9);
                adresa.DrzavaId = reader.GetInt32(10);  
                adresa.NazivDrzave = reader.GetString(11);
                b.Adresa = adresa;
                result.Add(b);
            }
            return result;
        }
        public override string ToString()
        {
            return NazivProdavca;
        }
    }
}