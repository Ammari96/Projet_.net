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
    public partial class frmJoueur : Form
    {   
        //Création des joueurs de la partie avec choix du pion
        public Joueur joueur;
        public frmJoueur(List<Joueur> listJoueur)
        {
            InitializeComponent();
            joueur = new Joueur();
            foreach(Joueur j in listJoueur)
            {
                comboBox1.Items.Remove(j.Pion);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //cast du choix de pion et update de la liste des pions
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String pion=comboBox1.SelectedItem.ToString();
            switch(pion[pion.Length-1])
            {
                case '1':pictureBox1.Image = Monopoly.Properties.Resources.pion1;break;
                case '2': pictureBox1.Image = Monopoly.Properties.Resources.pion2; break;
                case '3': pictureBox1.Image = Monopoly.Properties.Resources.pion3; break;
                case '4': pictureBox1.Image = Monopoly.Properties.Resources.pion4; break;
                case '5': pictureBox1.Image = Monopoly.Properties.Resources.pion5; break;
                case '6': pictureBox1.Image = Monopoly.Properties.Resources.pion6; break;
                case '7': pictureBox1.Image = Monopoly.Properties.Resources.pion7; break;
                case '8': pictureBox1.Image = Monopoly.Properties.Resources.pion8; break;
            }
        }

        //gestion des erreurs de remplissage
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                errorProvider1.SetError(textBox1, "Vous devez écrire le nom du joueur !");
            }
            else if(comboBox1.SelectedIndex==-1)
            {
                errorProvider1.SetError(comboBox1, "Vous devez selectionner un pion !");
            }
            else
            {
                joueur.Nom = textBox1.Text;
                joueur.Pion = comboBox1.SelectedItem.ToString();
                String choix=comboBox1.SelectedItem.ToString();
                Char el = choix[choix.Length-1];
                switch (el)
                {
                    case '1':joueur.Img = Monopoly.Properties.Resources.pion1;break;
                    case '2': joueur.Img = Monopoly.Properties.Resources.pion2; break;
                    case '3': joueur.Img = Monopoly.Properties.Resources.pion3; break;
                    case '4': joueur.Img = Monopoly.Properties.Resources.pion4; break;
                    case '5': joueur.Img = Monopoly.Properties.Resources.pion5; break;
                    case '6': joueur.Img = Monopoly.Properties.Resources.pion6; break;
                    case '7': joueur.Img = Monopoly.Properties.Resources.pion7; break;
                    case '8': joueur.Img = Monopoly.Properties.Resources.pion8; break;
                }
                joueur.Solde = 1500;
                this.Close();
            }
           
        }

        private void frmJoueur_Load(object sender, EventArgs e)
        {

        }
    }
}
