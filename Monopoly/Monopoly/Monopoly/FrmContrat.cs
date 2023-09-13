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
    public partial class FrmContrat : Form
    {
        private int idTerrain=0;
        private int prixTerrain = 0;
        public List<Joueur> lj = new List<Joueur>();
        public int[] propriete = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        public int[] maison = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public FrmContrat()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //pré-remplissage des liste déroulantes
        public void afficher()
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            for (int i=0; i<lj.Count;i++)
            {
                comboBox2.Items.Add(lj[i].Nom);
                comboBox3.Items.Add(lj[i].Nom);
            }
            comboBox2.Items.Add("banque");
            comboBox3.Items.Add("banque");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if(comboBox2.SelectedItem.Equals(comboBox3.SelectedItem))
            {
                MessageBox.Show("Le contrat doit être fait entre deux personnes différentes !");
            }
            else
            {
                int a = comboBox2.SelectedIndex;
                int b = comboBox3.SelectedIndex;
                switch (comboBox1.SelectedIndex)
                {
                    case 0: {
                            if(propriete[idTerrain]==a)
                            {
                                propriete[idTerrain] = b;
                                lj[a].Solde += int.Parse(textBox1.Text);
                                lj[b].Solde -= int.Parse(textBox1.Text);
                                MessageBox.Show(comboBox4.SelectedItem.ToString()+" a été acheté par "+lj[b].Nom+" avec le montant "+ textBox1.Text);
                            }
                            else
                            {
                                MessageBox.Show("Le joueur n'est pas le propriétaire de ce terrain!");
                            }
                            break; }
                    case 1: { //vente des maison à la banque
                            if (propriete[idTerrain] == a)
                            {
                                if(maison[idTerrain]>0)
                                {
                                    // prix d'une maison
                                    int prixMaison = 0;
                                    switch (idTerrain)
                                    {
                                        case 1: case 3: prixMaison = 50; ; break;
                                        case 6: case 8: case 9: prixMaison = 50; break;
                                        case 11: case 13: case 14: prixMaison = 100; break;
                                        case 16: case 18: case 19: prixMaison = 100; break;
                                        case 21: case 23: case 24: prixMaison = 150; break;
                                        case 26: case 27: case 29: prixMaison = 150; break;
                                        case 31: case 32: case 34: prixMaison = 200; break;
                                        case 37: case 39: prixMaison = 200; ; break;
                                    }
                                    
                                    maison[idTerrain]--;
                                    lj[a].Solde += prixMaison;
                                    MessageBox.Show(lj[a].Nom + " vend une maison pour " + prixMaison);
                                }
                                else
                                {
                                    MessageBox.Show("Pas de maison disponible pour vendre à la banque sur ce terrain");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Le joueur n'est pas le propriétaire de ce terrain!");
                            }
                                break; }
                    case 2:
                        {
                            //hypothéquer terrain
                            if (propriete[idTerrain] == a)
                            {
                                propriete[idTerrain] = -1;
                                lj[a].Solde += prixTerrain;
                                MessageBox.Show(lj[a].Nom + " hypothéquer le terrain pour " + prixTerrain);
                               
                            }
                            else
                            {
                                MessageBox.Show("Le joueur n'est pas le propriétaire de ce terrain!");
                            }
                        
                        break;
                        }
                    case 3: {
                            //liberer hypothèque terrain
                            if (propriete[idTerrain] == -1)
                            {
                                propriete[idTerrain] = a;
                                lj[a].Solde -= prixTerrain;
                                MessageBox.Show(lj[a].Nom + " a libéré l'hypothèque du terrain pour " + prixTerrain);

                            }
                            else
                            {
                                MessageBox.Show("Le joueur n'est pas le propriétaire de ce terrain!");
                            }
                            break;
                                }
                }
            }
            this.Close();
        }

        //definition des prix des terrains de tout le plateau
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {   
            switch(comboBox4.SelectedIndex)
            {
                case 0: idTerrain = 1;prixTerrain = 35; break;
                case 1: idTerrain = 3; prixTerrain = 35; break;
                case 2: idTerrain = 5; prixTerrain = 100; break;
                case 3: idTerrain = 6; prixTerrain = 60; break;
                case 4: idTerrain = 8; prixTerrain = 60; break;
                case 5: idTerrain = 9; prixTerrain = 60; break;
                case 6: idTerrain = 11; prixTerrain = 70; break;
                case 7: idTerrain = 12; prixTerrain = 80; break;
                case 8: idTerrain = 13; prixTerrain = 70; break;
                case 9: idTerrain = 14; prixTerrain = 70; break;
                case 10: idTerrain = 15; prixTerrain = 100; break;
                case 11: idTerrain = 16; prixTerrain = 100; break;
                case 12: idTerrain = 18; prixTerrain = 100; break;
                case 13: idTerrain = 19; prixTerrain = 100; break;
                case 14: idTerrain = 21; prixTerrain = 120; break;
                case 15: idTerrain = 23; prixTerrain = 120; break;
                case 16: idTerrain = 24; prixTerrain = 120; break;
                case 17: idTerrain = 25; prixTerrain = 100; break;
                case 18: idTerrain = 26; prixTerrain = 140; break;
                case 19: idTerrain = 27; prixTerrain = 140; break;
                case 20: idTerrain = 28; prixTerrain = 80; break;
                case 21: idTerrain = 29; prixTerrain = 140; break;
                case 22: idTerrain = 31; prixTerrain = 160; break;
                case 23: idTerrain = 32; prixTerrain = 160; break;
                case 24: idTerrain = 34; prixTerrain = 160; break;
                case 25: idTerrain = 35; prixTerrain = 100; break;
                case 26: idTerrain = 37; prixTerrain = 200; break;
                case 27: idTerrain = 39; prixTerrain = 200; break;
            }
        }
    }
}
