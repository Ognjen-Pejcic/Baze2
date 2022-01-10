using Forme.Racun;

namespace Forme
{
    public partial class FormGlavna : Form
    {
        public FormGlavna()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void insertRacunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertRacunaUC frm = new InsertRacunaUC();
            pnlGlavni.Controls.Clear();
            frm.Parent = pnlGlavni;
            frm.Dock = DockStyle.Fill;
        }
    }
}