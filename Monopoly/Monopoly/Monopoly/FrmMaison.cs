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
    public partial class FrmMaison : Form
    {
        public int prixMaison = 0;
        public int prixTotal = 0;
        public int idJoueur = 0;
        public int idTerrain = 0;
        public String nomJoueur = "";
        public int[] propriete = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        public int[] maison = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public FrmMaison()
        {
            InitializeComponent();
        }
        //Affiche le prix de la maison en fonction de la propriété sur laquelle se trouve le joueur
        public void afficheInfo()
        {
            label1.Text = nomJoueur;
            switch(idTerrain)
            {
                case 1: case 3: prixMaison = 50;eliminer(); break;
                case 6: case 8: case 9: prixMaison = 50; break;
                case 11: case 13: case 14: prixMaison = 100; break;
                case 16: case 18: case 19: prixMaison = 100; break;
                case 21: case 23: case 24: prixMaison = 150; break;
                case 26: case 27: case 29: prixMaison = 150; break;
                case 31: case 32: case 34: prixMaison = 200; break;
                case 37: case 39: prixMaison = 200; eliminer(); break;
            }
            label2.Text = label2.Text +" "+ prixMaison + " euros";
        }
        public void eliminer()
        {
            comboBox1.Items.RemoveAt(14);
            comboBox1.Items.RemoveAt(13);
            comboBox1.Items.RemoveAt(12);
            comboBox1.Items.RemoveAt(11);
            comboBox1.Items.RemoveAt(10);
        }

        private void FrmMaison_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Achat de maisons sur propriete achetées
        //L'achat de maison se fait en fonction de l'ID du terrain sur lequel le joueur est
        //Chaque terrain est géré individuellement à travers le switch qui reçoit en entrée l'id du terrain (= sa position dans l'ordre du plateau)
        private void button1_Click(object sender, EventArgs e)
        {
            int nombreMaison = comboBox1.SelectedIndex + 1;
            switch(idTerrain)
            {   
                // 1 3
                case 1:
                    { 
                    if(propriete[1]==idJoueur && propriete[3]==idJoueur)
                    {
                            int nombremax = (5 - maison[1]) + (5 - maison[3]);
                            if(nombreMaison>nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for(int i=0;i<nombreMaison;i++)
                            {
                                if (maison[1] > maison[3])
                                    maison[3]++;
                                else
                                    maison[1]++;
                            }
                            prixTotal = prixMaison * nombreMaison;
                            
                    }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                    break;
                    }
                case 3:
                    {
                        if (propriete[1] == idJoueur && propriete[3] == idJoueur)
                        {
                            int nombremax = (5 - maison[1]) + (5 - maison[3]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[3] > maison[1])
                                    maison[1]++;
                                else
                                    maison[3]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                // 6 8 9
                case 6:
                    {
                        if (propriete[6] == idJoueur && propriete[8] == idJoueur && propriete[9] == idJoueur)
                        {
                            int nombremax = (5 - maison[6]) + (5 - maison[8]) + (5 - maison[9]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            int somme = maison[6] + maison[8] + maison[9]+nombreMaison;
                            maison[8] = somme / 3;
                            maison[9] = somme / 3;
                            maison[6] = somme -(maison[8]+ maison[9]);
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }

                case 8:
                    {
                        if (propriete[6] == idJoueur && propriete[8] == idJoueur && propriete[9] == idJoueur)
                        {
                            int nombremax = (5 - maison[6]) + (5 - maison[8]) + (5 - maison[9]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            int somme = maison[6] + maison[8] + maison[9] + nombreMaison;
                            maison[6] = somme / 3;
                            maison[9] = somme / 3;
                            maison[8] = somme - (maison[6] + maison[9]);
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                case 9:
                    {
                        if (propriete[6] == idJoueur && propriete[8] == idJoueur && propriete[9] == idJoueur)
                        {
                            int nombremax = (5 - maison[6]) + (5 - maison[8]) + (5 - maison[9]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            int somme = maison[6] + maison[8] + maison[9] + nombreMaison;
                            maison[8] = somme / 3;
                            maison[6] = somme / 3;
                            maison[9] = somme - (maison[8] + maison[6]);
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                // 11 13 14
                case 11:
                    {
                        if (propriete[11] == idJoueur && propriete[13] == idJoueur && propriete[14] == idJoueur)
                        {
                            int nombremax = (5 - maison[11]) + (5 - maison[13]) + (5 - maison[14]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[11] < 6)
                                    maison[11]++;
                                else if (maison[13] < 6)
                                    maison[13]++;
                                else
                                    maison[14]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }

                case 13:
                    {
                        if (propriete[11] == idJoueur && propriete[13] == idJoueur && propriete[14] == idJoueur)
                        {
                            int nombremax = (5 - maison[11]) + (5 - maison[13]) + (5 - maison[14]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[13] < 6)
                                    maison[13]++;
                                else if (maison[11] < 6)
                                    maison[11]++;
                                else
                                    maison[14]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                case 14:
                    {
                        if (propriete[11] == idJoueur && propriete[13] == idJoueur && propriete[14] == idJoueur)
                        {
                            int nombremax = (5 - maison[11]) + (5 - maison[13]) + (5 - maison[14]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[14] < 6)
                                    maison[14]++;
                                else if (maison[11] < 6)
                                    maison[11]++;
                                else
                                    maison[13]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                //16 18 19
                case 16:
                    {
                        if (propriete[16] == idJoueur && propriete[18] == idJoueur && propriete[19] == idJoueur)
                        {
                            int nombremax = (5 - maison[16]) + (5 - maison[18]) + (5 - maison[19]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[16] < 6)
                                    maison[16]++;
                                else if (maison[18] < 6)
                                    maison[18]++;
                                else
                                    maison[19]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }

                case 18:
                    {
                        if (propriete[16] == idJoueur && propriete[18] == idJoueur && propriete[19] == idJoueur)
                        {
                            int nombremax = (5 - maison[16]) + (5 - maison[18]) + (5 - maison[19]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[18] < 6)
                                    maison[18]++;
                                else if (maison[16] < 6)
                                    maison[16]++;
                                else
                                    maison[19]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                case 19:
                    {
                        if (propriete[16] == idJoueur && propriete[18] == idJoueur && propriete[19] == idJoueur)
                        {
                            int nombremax = (5 - maison[16]) + (5 - maison[18]) + (5 - maison[19]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[19] < 6)
                                    maison[19]++;
                                else if (maison[18] < 6)
                                    maison[18]++;
                                else
                                    maison[16]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                //21 23 24
                case 21:
                    {
                        if (propriete[21] == idJoueur && propriete[23] == idJoueur && propriete[24] == idJoueur)
                        {
                            int nombremax = (5 - maison[21]) + (5 - maison[23]) + (5 - maison[24]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[21] < 6)
                                    maison[21]++;
                                else if (maison[23] < 6)
                                    maison[23]++;
                                else
                                    maison[24]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }

                case 23:
                    {
                        if (propriete[21] == idJoueur && propriete[23] == idJoueur && propriete[24] == idJoueur)
                        {
                            int nombremax = (5 - maison[21]) + (5 - maison[23]) + (5 - maison[24]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[23] < 6)
                                    maison[23]++;
                                else if (maison[21] < 6)
                                    maison[21]++;
                                else
                                    maison[24]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                case 24:
                    {
                        if (propriete[21] == idJoueur && propriete[23] == idJoueur && propriete[24] == idJoueur)
                        {
                            int nombremax = (5 - maison[21]) + (5 - maison[23]) + (5 - maison[24]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[24] < 6)
                                    maison[24]++;
                                else if (maison[21] < 6)
                                    maison[21]++;
                                else
                                    maison[23]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                // 26 27 29
                case 26:
                    {
                        if (propriete[26] == idJoueur && propriete[27] == idJoueur && propriete[29] == idJoueur)
                        {
                            int nombremax = (5 - maison[26]) + (5 - maison[27]) + (5 - maison[29]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[26] < 6)
                                    maison[26]++;
                                else if (maison[27] < 6)
                                    maison[27]++;
                                else
                                    maison[29]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }

                case 27:
                    {
                        if (propriete[26] == idJoueur && propriete[27] == idJoueur && propriete[29] == idJoueur)
                        {
                            int nombremax = (5 - maison[26]) + (5 - maison[27]) + (5 - maison[29]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[27] < 6)
                                    maison[27]++;
                                else if (maison[26] < 6)
                                    maison[26]++;
                                else
                                    maison[29]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                case 29:
                    {
                        if (propriete[26] == idJoueur && propriete[27] == idJoueur && propriete[29] == idJoueur)
                        {
                            int nombremax = (5 - maison[26]) + (5 - maison[27]) + (5 - maison[29]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[29] < 6)
                                    maison[29]++;
                                else if (maison[27] < 6)
                                    maison[27]++;
                                else
                                    maison[26]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                    //31 32 34
                case 31:
                    {
                        if (propriete[31] == idJoueur && propriete[32] == idJoueur && propriete[34] == idJoueur)
                        {
                            int nombremax = (5 - maison[31]) + (5 - maison[32]) + (5 - maison[34]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[31] < 6)
                                    maison[31]++;
                                else if (maison[32] < 6)
                                    maison[32]++;
                                else
                                    maison[34]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }

                case 32:
                    {
                        if (propriete[31] == idJoueur && propriete[32] == idJoueur && propriete[34] == idJoueur)
                        {
                            int nombremax = (5 - maison[31]) + (5 - maison[32]) + (5 - maison[34]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[32] < 6)
                                    maison[32]++;
                                else if (maison[31] < 6)
                                    maison[31]++;
                                else
                                    maison[34]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                case 34:
                    {
                        if (propriete[31] == idJoueur && propriete[32] == idJoueur && propriete[34] == idJoueur)
                        {
                            int nombremax = (5 - maison[31]) + (5 - maison[32]) + (5 - maison[34]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[34] < 6)
                                    maison[34]++;
                                else if (maison[31] < 6)
                                    maison[31]++;
                                else
                                    maison[32]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                case 37:
                    {
                        if (propriete[37] == idJoueur && propriete[39] == idJoueur)
                        {
                            int nombremax = (5 - maison[37]) + (5 - maison[39]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[39] > maison[37])
                                    maison[37]++;
                                else
                                    maison[39]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                case 39:
                    {
                        if (propriete[39] == idJoueur && propriete[37] == idJoueur)
                        {
                            int nombremax = (5 - maison[37]) + (5 - maison[39]);
                            if (nombreMaison > nombremax)
                            {
                                nombreMaison = nombremax;
                            }
                            for (int i = 0; i < nombreMaison; i++)
                            {
                                if (maison[37] > maison[39])
                                    maison[39]++;
                                else
                                    maison[37]++;
                            }
                            prixTotal = prixMaison * nombreMaison;

                        }
                        else { MessageBox.Show("Vous devez posséder tous les terrains d'une même rue pour acheter une maison"); }
                        break;
                    }
                default:MessageBox.Show("Il est impossible d'acheter des maisons sur ce terrain"); break;
            }
            this.Close();
        }

    }
}
