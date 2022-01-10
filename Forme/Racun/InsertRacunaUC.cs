using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domen;
using Kontroler;
namespace Forme.Racun
{
    public partial class InsertRacunaUC : UserControl
    {
        public InsertRacunaUC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Domen.Racun racun = new Domen.Racun {
                BrojRacuna = textBox1.Text,
                Banka = (Banka)cbBanka.SelectedItem,
                Prodavac =  (Prodavac)cbProdavac.SelectedItem
            };

            if (Controller.Instance.InsertRacuna(racun))
            {
                MessageBox.Show("Uspesno ubacen");
            }
            else
            {
                MessageBox.Show("Greska");
            }
        }

        private void InsertRacunaUC_Load(object sender, EventArgs e)
        {
            cbBanka.DataSource = Controller.Instance.VratiBanke();
            cbBanka.DataSource = Controller.Instance.VratiProizvodjace();
            cbBanka.SelectedIndex = 0;
        }
    }
}
