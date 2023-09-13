using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class FrmDe : Form
    {   //initialisation du délai d'affichage pour les lancers de dés
        Stopwatch stopwatch = Stopwatch.StartNew();
        public FrmDe(int a,int b)
        {
            InitializeComponent();
            textBox1.Text = "" + a;
            textBox2.Text = "" + b;
            textBox1.Hide();
            textBox2.Hide();
            timer1.Start();
        }

        private void FrmDe_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //affichage du résultat fdes dés
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            textBox1.Show();
            textBox2.Show();
        }
    }
}
