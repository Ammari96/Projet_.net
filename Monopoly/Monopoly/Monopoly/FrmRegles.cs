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
    public partial class FrmRegles : Form
    {
        int index = 1;
        public FrmRegles()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRegles_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = Monopoly.Properties.Resources.mn1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(index>1)
            {
                index--;
                switch(index)
                {
                    case 1: pictureBox2.Image= Monopoly.Properties.Resources.mn1; break;
                    case 2: pictureBox2.Image = Monopoly.Properties.Resources.mn2; break;
                    case 3: pictureBox2.Image = Monopoly.Properties.Resources.mn3; break;
                    case 4: pictureBox2.Image = Monopoly.Properties.Resources.mn4; break;
                    case 5: pictureBox2.Image = Monopoly.Properties.Resources.mn5; break;
                    case 6: pictureBox2.Image = Monopoly.Properties.Resources.mn6; break;
                    case 7: pictureBox2.Image = Monopoly.Properties.Resources.mn7; break;
                    case 8: pictureBox2.Image = Monopoly.Properties.Resources.mn8; break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index < 9)
            {
                index++;
                switch (index)
                {
                    case 1: pictureBox2.Image = Monopoly.Properties.Resources.mn1; break;
                    case 2: pictureBox2.Image = Monopoly.Properties.Resources.mn2; break;
                    case 3: pictureBox2.Image = Monopoly.Properties.Resources.mn3; break;
                    case 4: pictureBox2.Image = Monopoly.Properties.Resources.mn4; break;
                    case 5: pictureBox2.Image = Monopoly.Properties.Resources.mn5; break;
                    case 6: pictureBox2.Image = Monopoly.Properties.Resources.mn6; break;
                    case 7: pictureBox2.Image = Monopoly.Properties.Resources.mn7; break;
                    case 8: pictureBox2.Image = Monopoly.Properties.Resources.mn8; break;
                }
            }
        }
    }
}
