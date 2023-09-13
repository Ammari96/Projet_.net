using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class FrmChance : Form
    {
        public FrmChance(String a,String b)
        {
            InitializeComponent();
            label1.Text = a;
            label2.Text = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
