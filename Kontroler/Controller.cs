using DbBroker;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kontroler
{
    public class Controller
    {
        Broker broker = new Broker();
        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }

        public object VratiSvePorudzbine()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var porudzbina = broker.VratiSve(new Porudzbina()).Cast<Porudzbina>().ToList();
                broker.Commit();
                return porudzbina;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool IzmeniStavku(StavkaFakture stavka)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                broker.Azuriraj(stavka);
                broker.Commit();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public object VratiFakture()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var faktura = broker.VratiSve(new Faktura()).Cast<Faktura>().ToList();
                foreach (var f in faktura)
                {
                    f.Stavke = broker.VratiSve(new StavkaFakture
                    {
                        Faktura = f
                    }).Cast<StavkaFakture>()
                      .ToList();  
                }
                broker.Commit();
                return faktura;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void IzmeniFakturu(Faktura faktura)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                broker.Azuriraj(faktura);
                broker.Commit();

            }
            catch (Exception e)
            {
                broker.Rollback();
                MessageBox.Show(e.ToString());  
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool UnesiStavku(StavkaFakture stavka)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                broker.Sacuvaj(stavka);
                broker.Commit();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool IzbrisiStavku(StavkaFakture stavka)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var prodavci = broker.Izbrisi(stavka);
                broker.Commit();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); 
                return false;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public object VratiProdavacKontakt()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var prodavci = broker.VratiSve(new ProdavacKontakt()).Cast<ProdavacKontakt>().ToList();
                broker.Commit();
                return prodavci;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool IzmeniProdavca(Prodavac p)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                broker.Azuriraj(p);
                broker.Commit();
                return true;
            }
            catch (Exception)
            {
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void IzbrisiProdavca(Prodavac prodavac)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var prodavci = broker.Izbrisi(prodavac);
                broker.Commit();
            }
            catch (Exception)
            {
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public object VratiProdavacGlavno()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var prodavci = broker.VratiSve(new ProdavacGlavno()).Cast<ProdavacGlavno>().ToList();
                broker.Commit();
                return prodavci;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public object VratiDobavljaca(Dobavljac d)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var dobavljaci = broker.VratiSve(d).Cast<Dobavljac>().ToList();
                broker.Commit();
                return dobavljaci;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool InsertRacuna(Racun racun)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                broker.Sacuvaj(racun);
                broker.Commit();
                return true;
            }
            catch (Exception)
            {
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.CloseConnection();
            }

        }

        public bool InsertProdavca(Prodavac prodavac)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                broker.Sacuvaj(prodavac);
                broker.Commit();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public object VratiAdrese()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var adrese = broker.VratiSve(new Adresa()).Cast<Adresa>().ToList();
                broker.Commit();
                return adrese;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public object VratiTipove()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var tipovi = broker.VratiSve(new TipProizvoda()).Cast<TipProizvoda>().ToList();
                broker.Commit();
                return tipovi;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool IzmeniProizvodajca(Proizvodjac p)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                broker.Azuriraj(p);
                broker.Commit();
                return true;
            }
            catch (Exception)
            {
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Proizvod> VratiProizvode()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var proizvod = broker.VratiSve(new Proizvod()).Cast<Proizvod>().ToList();
                broker.Commit();
                return proizvod;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public object VratiJediniceMere()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var jedinica = broker.VratiSve(new JedinicaMere()).Cast<JedinicaMere>().ToList();
                broker.Commit();
                return jedinica;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool UpdateBanke(Banka banka)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                broker.Azuriraj(banka);
                broker.Commit();
                return true;
            }
            catch (Exception)
            {
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Racun> VratiRacune()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var racuni = broker.VratiSve(new Racun()).Cast<Racun>().ToList();
                broker.Commit();
                return racuni;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool UnesiProizvod(Proizvod p)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                broker.Sacuvaj(p);
                broker.Commit();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool UpdateRacuna(Racun racun)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                broker.Azuriraj(racun);
                broker.Commit();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool IzmeniProizvod(Proizvod p)
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                broker.Azuriraj(p);
                broker.Commit();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                broker.Rollback();
                return false;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Banka> VratiBanke()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var banke = broker.VratiSve(new Banka()).Cast<Banka>().ToList();
                broker.Commit();
                return banke;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Prodavac> VratiProdavce()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
               var prodavac = broker.VratiSve(new Prodavac());
                broker.Commit();
                return prodavac.Cast<Prodavac>().ToList();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Proizvodjac> VratiProizvodjace()
        {
            broker.OpenConnection();
            broker.BeginTransaction();
            try
            {
                var proizvodjac = broker.VratiSve(new Proizvodjac()).Cast<Proizvodjac>().ToList();
                broker.Commit();
                return proizvodjac;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}
