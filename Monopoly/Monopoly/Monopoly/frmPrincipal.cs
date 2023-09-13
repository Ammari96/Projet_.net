using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{   //Propriétés de la fenetre du jeu
    public partial class frmPrincipal : Form
    {
        int x = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        int y = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        float rx = (float)System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / (float)1920;
        float ry = (float)System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / (float)1080;
        private List<Joueur> listeJoueur = new List<Joueur>();
        PictureBox[] boxes;
        Point[] pointsJoueur = new Point[] {
    new Point { X = 334, Y = 170 },
    new Point { X = 334, Y = 440 },
    new Point { X = 334, Y = 670 },
    new Point { X = 334, Y = 920 },
    new Point { X = 1800, Y = 440 },
    new Point { X = 1800, Y = 670 },
    new Point { X = 1800, Y = 920 }
};
        private int index = 0;
        private Boolean enJeux = false;

        //Initialisation des variables pour les propriétés et nb de maisons
        int[] propriete = new int[] {-1,-1,-1,-1,-1,-1,-1, -1, -1, -1, -1, -1, -1, - 1, -1, -1, -1, -1, -1, -1, - 1, -1, -1, -1, -1, -1, -1 ,- 1, -1, -1, -1, -1, -1, -1 ,- 1, -1, -1, -1, -1, -1, -1, - 1 };
        int[] maison = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public frmPrincipal()
        {
            InitializeComponent();
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox6.Enabled = false;
            groupBox7.Enabled = false;
            groupBox8.Enabled = false;
            button9.Hide();
            pictureBox6.Hide();
            pictureBox10.Hide();
            pictureBox11.Hide();
            pictureBox12.Hide();
            pictureBox13.Hide();
            pictureBox14.Hide();
            pictureBox15.Hide();
            PictureBox[] boxes2 = {pictureBox6, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14,pictureBox15};
            boxes = boxes2;
        }

        //Ajout de nouveau joueur 1 avec vérification que les infos sont bien renseignées
        private void button1_Click(object sender, EventArgs e)
        {
            Joueur j = new Joueur();
            frmJoueur frmj = new frmJoueur(listeJoueur);
            frmj.joueur = j;
            frmj.ShowDialog();
            if(! string.IsNullOrWhiteSpace(j.Nom))
            {
                listeJoueur.Add(j);
                button1.Hide();
                afficheJoueur();
                groupBox2.Enabled = true;
            }
            
        }
        //Affichage des joueurs créés avec leurs infos de jeu
        public void afficheJoueur()
        {
            if (listeJoueur.ElementAt(0)!=null)
            { 
            label1.Text = listeJoueur.ElementAt(0).Nom;
                pictureBox2.Image = listeJoueur.ElementAt(0).Img;
                label2.Text = "Solde: " + listeJoueur.ElementAt(0).Solde + " euros";
            }
            try
            {
                label4.Text = listeJoueur.ElementAt(1).Nom;
                pictureBox3.Image =listeJoueur.ElementAt(1).Img;
                label3.Text = "Solde: " + listeJoueur.ElementAt(1).Solde + " euros";
            }
            catch(Exception ex) { }
            try
            {
                label6.Text = listeJoueur.ElementAt(2).Nom;
                pictureBox4.Image =listeJoueur.ElementAt(2).Img;
                label5.Text = "Solde: " + listeJoueur.ElementAt(2).Solde + " euros";
            }
            catch (Exception ex) { }
            try
            {
                label8.Text = listeJoueur.ElementAt(3).Nom;
                pictureBox5.Image =listeJoueur.ElementAt(3).Img;
                label7.Text = "Solde: " + listeJoueur.ElementAt(3).Solde + " euros";
            }
            catch (Exception ex) { }
            try
            {
                label12.Text = listeJoueur.ElementAt(4).Nom;
                pictureBox7.Image = listeJoueur.ElementAt(4).Img;
                label11.Text = "Solde: " + listeJoueur.ElementAt(4).Solde + " euros";
            }
            catch (Exception ex) { }
            try
            {
                label14.Text = listeJoueur.ElementAt(5).Nom;
                pictureBox8.Image =listeJoueur.ElementAt(5).Img;
                label13.Text = "Solde: " + listeJoueur.ElementAt(5).Solde + " euros";
            }
            catch (Exception ex) { }
            try
            {
                label16.Text = listeJoueur.ElementAt(6).Nom;
                pictureBox9.Image = listeJoueur.ElementAt(6).Img;
                label15.Text = "Solde: " + listeJoueur.ElementAt(6).Solde + " euros";
            }
            catch (Exception ex) { }
        }

        //ajout joueur numero 2
        private void button2_Click(object sender, EventArgs e)
        {
            Joueur j = new Joueur();
            frmJoueur frmj = new frmJoueur(listeJoueur);
            frmj.joueur = j;
            frmj.ShowDialog();
            if (!string.IsNullOrWhiteSpace(j.Nom))
            {
                listeJoueur.Add(j);
                button2.Hide();
                afficheJoueur();
                groupBox3.Enabled = true;
            }
        }

        //début de la partie si les conditions sont ok (nb de joueurs >= 2)
        private void button5_Click(object sender, EventArgs e)
        {
            if(listeJoueur.Count<2)
            {
                MessageBox.Show("Il faut au moins deux joueurs pour débuter une partie");
            }
            else
            {
                button20.Enabled = true;
                button17.Enabled = true;
                button19.Enabled = true;
                button5.Enabled = false;
                switch (listeJoueur.Count)
                {
                    case 2: groupBox3.Enabled = false; break;
                    case 3: groupBox4.Enabled = false; break;
                    case 4: groupBox6.Enabled = false; break;
                    case 5: groupBox7.Enabled = false; break;
                    case 6: groupBox8.Enabled = false; break;
                }
                MessageBox.Show("La partie va débuter. Le premier jet de dés va permettre de déterminer celui qui commence");
                button9.Show();
                button9.SetBounds(pointsJoueur[0].X, pointsJoueur[0].Y, 100,50);
                button9.Bounds = resizeElement(button9.Bounds);
                for(int i=0;i<listeJoueur.Count;i++)
                {
                    boxes[i].Image=listeJoueur.ElementAt(i).Img;
                    boxes[i].Show();
                    boxes[i].SetBounds(1330 + i * 10, 900+i*10, 50, 50);
                    boxes[i].Bounds = resizeElement(boxes[i].Bounds);
                }
            }
        }

        //ajout joueur numero 3
        private void button3_Click(object sender, EventArgs e)
        {
            Joueur j = new Joueur();
            frmJoueur frmj = new frmJoueur(listeJoueur);
            frmj.joueur = j;
            frmj.ShowDialog();
            if (!string.IsNullOrWhiteSpace(j.Nom))
            {
                listeJoueur.Add(j);
                button3.Hide();
                afficheJoueur();
                groupBox4.Enabled = true;
            }
        }

        //ajout joueur numero 4
        private void button4_Click(object sender, EventArgs e)
        {
            Joueur j = new Joueur();
            frmJoueur frmj = new frmJoueur(listeJoueur);
            frmj.joueur = j;
            frmj.ShowDialog();
            if (!string.IsNullOrWhiteSpace(j.Nom))
            {
                listeJoueur.Add(j);
                button4.Hide();
                afficheJoueur();
                groupBox6.Enabled = true;
            }
        }

        //ajout joueur numero 5
        private void button6_Click(object sender, EventArgs e)
        {
            Joueur j = new Joueur();
            frmJoueur frmj = new frmJoueur(listeJoueur);
            frmj.joueur = j;
            frmj.ShowDialog();
            if (!string.IsNullOrWhiteSpace(j.Nom))
            {
                listeJoueur.Add(j);
                button6.Hide();
                afficheJoueur();
                groupBox7.Enabled = true;
            }
        }
        
        //ajout joueur numero 6
        private void button7_Click(object sender, EventArgs e)
        {
            Joueur j = new Joueur();
            frmJoueur frmj = new frmJoueur(listeJoueur);
            frmj.joueur = j;
            frmj.ShowDialog();
            if (!string.IsNullOrWhiteSpace(j.Nom))
            {
                listeJoueur.Add(j);
                button7.Hide();
                afficheJoueur();
                groupBox8.Enabled = true;
            }
        }

        //ajout joueur numero 7
        private void button8_Click(object sender, EventArgs e)
        {
            Joueur j = new Joueur();
            frmJoueur frmj = new frmJoueur(listeJoueur);
            frmj.joueur = j;
            frmj.ShowDialog();
            if (!string.IsNullOrWhiteSpace(j.Nom))
            {
                listeJoueur.Add(j);
                button8.Hide();
                afficheJoueur();
            }
        }

        //Lancement du dé et génération des valeurs aléatoires
        private void button9_Click(object sender, EventArgs e)
        {
            int lastIndex = index;
            Random rnd = new Random();
            int a = rnd.Next(1, 6);
            int b = rnd.Next(1, 6);
            listeJoueur[index].Valeur = a + b;
            FrmDe frmde = new FrmDe(a, b);
            frmde.ShowDialog();
            if(enJeux)
            {
                int nombreDouble = 0;
                // avertissement double au dé
                while(nombreDouble<3 && (a==b))
                {
                    nombreDouble++;
                    MessageBox.Show("Attention : 3 doubles successifs aura pour conséquence de vous envoyer en prison");
                    a = rnd.Next(1, 6);
                    b = rnd.Next(1, 6);
                    listeJoueur[index].Valeur = a + b;
                    frmde = new FrmDe(a, b);
                    frmde.ShowDialog();
                }
                // 3 double = en prison
                if(nombreDouble==3)
                {
                    MessageBox.Show("Aller simple pour la prison ! ");
                    if(listeJoueur[index].Position<=10)
                    {
                        listeJoueur[index].Valeur = 10 - listeJoueur[index].Position;
                    }
                    else
                    {
                        listeJoueur[index].Valeur = 40 - (listeJoueur[index].Position-10);
                    }
                    placer(listeJoueur[index]);
                }
                else
                {
                    placer(listeJoueur[index]);
                }
            }
            if (index == listeJoueur.Count - 1)
            {
                if (enJeux)
                { index = 0; }
                // si partie pas lancée, détermine qui commence en choisissant celui qui a fait le plus gros jet
                else
                {
                    enJeux = true;
                    index = maxJoueur();
                    MessageBox.Show("C'est le joueur "+listeJoueur[index].Nom+" qui va commencer la partie");
                }
            }
            else
            { index++; }
            button9.SetBounds(pointsJoueur[index].X, pointsJoueur[index].Y, 100,50);
            button9.Bounds = resizeElement(button9.Bounds);
            afficheJoueur();
            afficheMaison();
            verifJoueur(lastIndex);
            
        }
        //Enregistre celui qui a fait le plus gros lancer
        public int maxJoueur()
        {
            int res = 0;
            for (int i=0;i<listeJoueur.Count;i++)
            {
                if (listeJoueur[i].Valeur > listeJoueur[res].Valeur)
                    res = i;
            }
            return res;
        }
        // Déplacement des pions en fonction des résultats des dés
        public void placer(Joueur j)
        {
            if(j.Position!=10)
            { 
            j.Position += j.Valeur;
            }
            if(j.FinPrison)
            {
                j.Position += j.Valeur;
                j.FinPrison = false;
            }
            //case départ
            if (j.Position > 39)
            { 
                j.Position -= 40;
                j.Solde += 200;
                MessageBox.Show("Jour de paie ! vous recevez 200 euros en passant par la case départ");
            }
            //Gestion individuelle des evenements chaque case du plateau (propriete, service, impot, taxe, prison etc..)
            switch (j.Position)
            {
                case 0:
                    {
                        MessageBox.Show("Vous avez reçu 200 euros");
                        //listeJoueur[index].Solde += 200;
                        boxes[index].SetBounds(1330 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        break; }
                case 1:
                    {
                        boxes[index].SetBounds(1230 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[1]==-1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 60 euros ? ", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[1] = index;
                                listeJoueur[index].Solde -= 60;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[1]==index)
                        {
                            /*if(propriete[3]==index)
                            {
                                Boolean b = true;
                                while(b)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Voulez vous construire un maison pour 50 euros", "Offre maison", MessageBoxButtons.YesNo);
                                    b = dialogResult == DialogResult.Yes;
                                }
                            }*/
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 2;
                            switch(maison[1])
                            {
                                case 1:prix = 10;break;
                                case 2: prix = 30; break;
                                case 3: prix = 90; break;
                                case 4: prix = 160; break;
                                case 5: prix = 250; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[1]].Solde += prix;
                            MessageBox.Show("La valeur est de "+prix+" euros ");
                        }
                        break; }
                case 2:
                    {
                        boxes[index].SetBounds(1150 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        Random rnd = new Random();
                        int chance =rnd.Next(1, 6);
                        String  b = "";
                        switch(chance)
                        {
                            case 1:listeJoueur[index].Solde += 200;b = "Erreur de la banque en votre faveur ! Recevez 200 euros"; break;
                            case 2: listeJoueur[index].Solde -= 50; b = "Visite fortuite chez le médecin. Payez 50 euros"; break;
                            case 3: listeJoueur[index].Solde += 25; b = "Remboursement des impôts : vous recevez 25 euros"; break;
                            case 4:b = "C'est votre anniveraire! chaque joueur vous donne 25 euros";
                                for (int i=0;i<listeJoueur.Count;i++)
                                {
                                    if(index==i)
                                    {
                                        listeJoueur[index].Solde += (25* (listeJoueur.Count-1));
                                    }
                                    else
                                    {
                                        listeJoueur[i].Solde -= 25;
                                    }
                                }
                                break;
                            case 5: listeJoueur[index].Solde -= 100; b = "Vous devez payer vos frais d'assurance pour un montant de 100 euros"; break;
                            case 6: listeJoueur[index].Solde += 250; b = "Vous heritez de 250 euros"; break;
                        }
                        FrmChance fc = new FrmChance("Carte de caisse communautée tirée",b);
                        fc.ShowDialog();
                        break; }
                case 3:
                    {
                        boxes[index].SetBounds(1070 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[3] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 60 euros ? ", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[3] = index;
                                listeJoueur[index].Solde -= 60;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[3] == index)
                        {
                           
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 4;
                            switch (maison[3])
                            {
                                case 1: prix = 20; break;
                                case 2: prix = 60; break;
                                case 3: prix = 180; break;
                                case 4: prix = 320; break;
                                case 5: prix = 450; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[3]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 4:
                    {
                        boxes[index].SetBounds(980 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        int prix= listeJoueur[index].Solde/10;
                        MessageBox.Show("Vous devez payer une taxe de 10% "+prix);
                        listeJoueur[index].Solde -= prix;
                        break; }
                case 5:
                    {
                        boxes[index].SetBounds(900 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[5] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce service pour 200 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[5] = index;
                                listeJoueur[index].Solde -= 200;
                                label17.Text = listeJoueur[index].Nom;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[5] == index)
                        {
                           
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 25;
                            if (propriete[5] == propriete[15])
                            {
                                prix *= 2;
                            }
                            if (propriete[5] == propriete[25])
                            {
                                prix *= 2;
                            }
                            if (propriete[5] == propriete[35])
                            {
                                prix *= 2;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[5]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 6:
                    {
                        boxes[index].SetBounds(820 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[6] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 100 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[6] = index;
                                listeJoueur[index].Solde -= 100;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[3] == index)
                        {
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 6;
                            switch (maison[6])
                            {
                                case 1: prix = 30; break;
                                case 2: prix = 90; break;
                                case 3: prix = 270; break;
                                case 4: prix = 400; break;
                                case 5: prix = 550; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[6]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 7:
                    {
                        boxes[index].SetBounds(740 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        Random rnd = new Random();
                        int chance = rnd.Next(1, 6);
                        String b = "";
                        switch (chance)
                        {
                            case 1: listeJoueur[index].Solde += 1000; b = "Vous gagnez 1000 euros"; break;
                            case 2: listeJoueur[index].Solde += 75; b = "La banque vous rembourse 75 euros"; break;
                            case 3: listeJoueur[index].Solde -= 100; b = "Amende pour excès de vitesse. Vous payez 100 euros"; break;
                            case 4: listeJoueur[index].Solde -= 1000; b = "Vous devez payer les frais de scolarité de 1000 euros"; break;
                            case 5: listeJoueur[index].Solde -= 20; b = "Vous payez une amende de 20 euros pour stationnement interdit"; break;
                            case 6: listeJoueur[index].Solde += 1200; b = "Felicitation! vous avez gagné 1200 euros au casino"; break;
                        }
                        FrmChance fc = new FrmChance("Carte de chance tirée", b);
                        fc.ShowDialog();
                        break; }
                case 8:
                    {
                        boxes[index].SetBounds(660 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[8] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 100 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[8] = index;
                                listeJoueur[index].Solde -= 100;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[8] == index)
                        {
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 6;
                            switch (maison[8])
                            {
                                case 1: prix = 30; break;
                                case 2: prix = 90; break;
                                case 3: prix = 270; break;
                                case 4: prix = 400; break;
                                case 5: prix = 550; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[8]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 9:
                    {
                        boxes[index].SetBounds(570 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[9] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 120 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[9] = index;
                                listeJoueur[index].Solde -= 120;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[9] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 8;
                            switch (maison[9])
                            {
                                case 1: prix = 40; break;
                                case 2: prix = 100; break;
                                case 3: prix = 300; break;
                                case 4: prix = 450; break;
                                case 5: prix = 600; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[9]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 10:
                    {
                        boxes[index].SetBounds(450 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        if (listeJoueur[index].PrisonEssaie==3)
                        {
                            listeJoueur[index].PrisonEssaie = 0;
                            MessageBox.Show("Vous payez 400 euros pour être libéré de prison");
                            listeJoueur[index].Solde -= 400;
                            listeJoueur[index].FinPrison = true;
                            index--;
                            
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous payer 400 euros pour être libéré immédiatement ?", "Offre de choix", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                listeJoueur[index].Solde -= 400;
                                listeJoueur[index].PrisonEssaie = 0;
                                listeJoueur[index].FinPrison = true;
                                index--;

                            }
                            else
                            {

                                listeJoueur[index].PrisonEssaie++;
                                Random rnd = new Random();
                                int a = rnd.Next(1, 6);
                                int b = rnd.Next(1, 6);
                                FrmDe frmde = new FrmDe(a, b);
                                frmde.ShowDialog();
                                if(a==b)
                                {
                                    listeJoueur[index].FinPrison = true;
                                }
                            }
                        }
                        break; }
                case 11:
                    {
                        boxes[index].SetBounds(450 + index * 10, 820 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[11] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 140 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[11] = index;
                                listeJoueur[index].Solde -= 140;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[11] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 10;
                            switch (maison[11])
                            {
                                case 1: prix = 50; break;
                                case 2: prix = 150; break;
                                case 3: prix = 450; break;
                                case 4: prix = 625; break;
                                case 5: prix = 750; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[11]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 12:
                    {
                        boxes[index].SetBounds(450 + index * 10, 740 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[12] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce service pour 150 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[12] = index;
                                listeJoueur[index].Solde -= 150;
                                label22.Text = listeJoueur[index].Nom;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[12] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 4;
                            if(propriete[12]== propriete[28])
                            {
                                prix = 10;
                            }
                            MessageBox.Show("Lancez les dés pour connaitre le montant à payer");
                            Random rnd = new Random();
                            int a = rnd.Next(1, 6);
                            int b = rnd.Next(1, 6);
                            FrmDe frmde = new FrmDe(a, b);
                            frmde.ShowDialog();
                            prix = prix*(a + b);
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[12]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 13:
                    {
                        boxes[index].SetBounds(450 + index * 10, 660 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[13] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 140 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[13] = index;
                                listeJoueur[index].Solde -= 140;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[13] == index)
                        {
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 10;
                            switch (maison[13])
                            {
                                case 1: prix = 50; break;
                                case 2: prix = 150; break;
                                case 3: prix = 450; break;
                                case 4: prix = 625; break;
                                case 5: prix = 750; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[13]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 14:
                    {
                        boxes[index].SetBounds(450 + index * 10, 570 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[14] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 160 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[14] = index;
                                listeJoueur[index].Solde -= 160;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[14] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 12;
                            switch (maison[14])
                            {
                                case 1: prix = 60; break;
                                case 2: prix = 180; break;
                                case 3: prix = 500; break;
                                case 4: prix = 700; break;
                                case 5: prix = 900; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[14]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 15:
                    {
                        boxes[index].SetBounds(450 + index * 10, 500 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[15] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce service pour 200 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[15] = index;
                                listeJoueur[index].Solde -= 200;
                                label25.Text = listeJoueur[index].Nom;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[15] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 25;
                            if (propriete[5] == propriete[15])
                            {
                                prix *= 2;
                            }
                            if (propriete[15] == propriete[25])
                            {
                                prix *= 2;
                            }
                            if (propriete[15] == propriete[35])
                            {
                                prix *= 2;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[15]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 16:
                    {
                        boxes[index].SetBounds(450 + index * 10, 405 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[16] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 180 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[16] = index;
                                listeJoueur[index].Solde -= 180;
                            }
                           
                        }
                        //le terrain appartient au joueur
                        else if (propriete[16] == index)
                        {
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 14;
                            switch (maison[16])
                            {
                                case 1: prix = 70; break;
                                case 2: prix = 200; break;
                                case 3: prix = 550; break;
                                case 4: prix = 750; break;
                                case 5: prix = 950; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[16]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 17:
                    {
                        boxes[index].SetBounds(450 + index * 10, 325 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        Random rnd = new Random();
                        int chance = rnd.Next(1, 6);
                        String b = "";
                        switch (chance)
                        {
                            case 1: listeJoueur[index].Solde += 200; b = "Erreur de la banque en votre faveur ! recevez 200 euros"; break;
                            case 2: listeJoueur[index].Solde -= 50; b = "Vous devez payer les frais médicaux de 50 euros"; break;
                            case 3: listeJoueur[index].Solde += 25; b = "Vous recevez 25 euros de dividende"; break;
                            case 4:
                                b = "C'est votre anniveraire! chaque joueur vous donne 25 euros";
                                for (int i = 0; i < listeJoueur.Count; i++)
                                {
                                    if (index == i)
                                    {
                                        listeJoueur[index].Solde += (25 * (listeJoueur.Count - 1));
                                    }
                                    else
                                    {
                                        listeJoueur[i].Solde -= 25;
                                    }
                                }
                                break;
                            case 5: listeJoueur[index].Solde -= 100; b = "Vous payez les frais d'assurance de 100 euros"; break;
                            case 6: listeJoueur[index].Solde += 250; b = "Vous heritez de 250 euros"; break;
                        }
                        FrmChance fc = new FrmChance("Carte de caisse communautée tirée", b);
                        fc.ShowDialog();
                        
                        break; }
                case 18:
                    {
                        boxes[index].SetBounds(450 + index * 10, 245 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[18] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 180 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[18] = index;
                                listeJoueur[index].Solde -= 180;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[18] == index)
                        {
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 14;
                            switch (maison[18])
                            {
                                case 1: prix = 70; break;
                                case 2: prix = 200; break;
                                case 3: prix = 550; break;
                                case 4: prix = 750; break;
                                case 5: prix = 950; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[18]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 19:
                    {
                        boxes[index].SetBounds(450 + index * 10, 160 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[19] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 200 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[19] = index;
                                listeJoueur[index].Solde -= 200;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[19] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 16;
                            switch (maison[19])
                            {
                                case 1: prix = 80; break;
                                case 2: prix = 220; break;
                                case 3: prix = 600; break;
                                case 4: prix = 800; break;
                                case 5: prix = 1000; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[19]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 20:
                    {
                        boxes[index].SetBounds(450 + index * 10, 30 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        break; }
                case 21:
                    {
                        boxes[index].SetBounds(570 + index * 10, 30 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[21] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 220 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[21] = index;
                                listeJoueur[index].Solde -= 220;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[21] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 18;
                            switch (maison[21])
                            {
                                case 1: prix = 90; break;
                                case 2: prix = 250; break;
                                case 3: prix = 700; break;
                                case 4: prix = 875; break;
                                case 5: prix = 1050; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[21]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 22:
                    {
                        boxes[index].SetBounds(655 + index * 10, 30 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        Random rnd = new Random();
                        int chance = rnd.Next(1, 6);
                        String b = "";
                        switch (chance)
                        {
                            case 1: listeJoueur[index].Solde += 1000; b = "Vous gagnez 1000 euros"; break;
                            case 2: listeJoueur[index].Solde += 75; b = "La banque vous rembourse 75 euros"; break;
                            case 3: listeJoueur[index].Solde -= 100; b = "Amende pour excès de vitesse. Vous payez 100 euros"; break;
                            case 4: listeJoueur[index].Solde -= 1000; b = "Vous devez payer les frais de scolarité de 1000 euros"; break;
                            case 5: listeJoueur[index].Solde -= 20; b = "Vous payez une amende de 20 euros pour stationnement interdit"; break;
                            case 6: listeJoueur[index].Solde += 1200; b = "Felicitation! vous avez gagné 1200 euros au casino"; break;
                        }
                        FrmChance fc = new FrmChance("carte de chance tirée", b);
                        fc.ShowDialog();
                        
                        break; }
                case 23:
                    {
                        boxes[index].SetBounds(740 + index * 10, 30 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[23] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 220 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[23] = index;
                                listeJoueur[index].Solde -= 220;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[23] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 18;
                            switch (maison[23])
                            {
                                case 1: prix = 90; break;
                                case 2: prix = 250; break;
                                case 3: prix = 700; break;
                                case 4: prix = 875; break;
                                case 5: prix = 1050; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[23]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 24:
                    {
                        boxes[index].SetBounds(820 + index * 10, 30 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[24] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 240 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[24] = index;
                                listeJoueur[index].Solde -= 240;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[24] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 20;
                            switch (maison[24])
                            {
                                case 1: prix = 100; break;
                                case 2: prix = 300; break;
                                case 3: prix = 750; break;
                                case 4: prix = 925; break;
                                case 5: prix = 1100; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[24]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 25:
                    {
                        boxes[index].SetBounds(900 + index * 10, 30 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[25] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce service pour 200 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[25] = index;
                                listeJoueur[index].Solde -= 200;
                                label33.Text = listeJoueur[index].Nom;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[25] == index)
                        {
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 25;
                            if (propriete[25] == propriete[15])
                            {
                                prix *= 2;
                            }
                            if (propriete[25] == propriete[5])
                            {
                                prix *= 2;
                            }
                            if (propriete[25] == propriete[35])
                            {
                                prix *= 2;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[25]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 26:
                    {
                        boxes[index].SetBounds(985 + index * 10, 30 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[26] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 260 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[26] = index;
                                listeJoueur[index].Solde -= 260;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[26] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 22;
                            switch (maison[26])
                            {
                                case 1: prix = 110; break;
                                case 2: prix = 330; break;
                                case 3: prix = 800; break;
                                case 4: prix = 975; break;
                                case 5: prix = 1150; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[26]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 27:
                    {
                        boxes[index].SetBounds(1065 + index * 10, 30 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[27] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain avec 260 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[27] = index;
                                listeJoueur[index].Solde -= 260;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[27] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 22;
                            switch (maison[27])
                            {
                                case 1: prix = 110; break;
                                case 2: prix = 330; break;
                                case 3: prix = 800; break;
                                case 4: prix = 975; break;
                                case 5: prix = 1150; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[27]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 28:
                    {
                        boxes[index].SetBounds(1150 + index * 10, 30 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[28] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce service pour 150 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[28] = index;
                                listeJoueur[index].Solde -= 150;
                                label36.Text = listeJoueur[index].Nom;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[28] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 4;
                            if (propriete[12] == propriete[28])
                            {
                                prix = 10;
                            }
                            MessageBox.Show("Lancez les dés pour connaitre le montant à payer");
                            Random rnd = new Random();
                            int a = rnd.Next(1, 6);
                            int b = rnd.Next(1, 6);
                            FrmDe frmde = new FrmDe(a, b);
                            frmde.ShowDialog();
                            prix = prix * (a + b);
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[28]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 29:
                    {
                        boxes[index].SetBounds(1230 + index * 10, 30 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[29] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 280 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[29] = index;
                                listeJoueur[index].Solde -= 280;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[29] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 24;
                            switch (maison[29])
                            {
                                case 1: prix = 120; break;
                                case 2: prix = 360; break;
                                case 3: prix = 850; break;
                                case 4: prix = 1025; break;
                                case 5: prix = 1200; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[29]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 30:
                    {
                        boxes[index].SetBounds(1310 + index * 10, 30 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        Thread.Sleep(1000);
                        MessageBox.Show("Aller simple pour la prison !");
                        boxes[index].SetBounds(440 + index * 10, 900 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        listeJoueur[index].Position = 10;
                        break; }
                case 31:
                    {
                        boxes[index].SetBounds(1340 + index * 10, 160 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[31] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 300 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[31] = index;
                                listeJoueur[index].Solde -= 300;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[31] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 26;
                            switch (maison[31])
                            {
                                case 1: prix = 130; break;
                                case 2: prix = 390; break;
                                case 3: prix = 900; break;
                                case 4: prix = 1100; break;
                                case 5: prix = 1225; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[31]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 32:
                    {
                        boxes[index].SetBounds(1340 + index * 10, 245 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[32] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 300 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[32] = index;
                                listeJoueur[index].Solde -= 300;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[32] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 26;
                            switch (maison[32])
                            {
                                case 1: prix = 130; break;
                                case 2: prix = 390; break;
                                case 3: prix = 900; break;
                                case 4: prix = 1100; break;
                                case 5: prix = 1225; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[32]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 33:
                    {
                        boxes[index].SetBounds(1320 + index * 10, 330 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        Random rnd = new Random();
                        int chance = rnd.Next(1, 6);
                        String b = "";
                        switch (chance)
                        {
                            case 1: listeJoueur[index].Solde += 200; b = "Erreur de la banque en votre faveur ! recevez 200 euros"; break;
                            case 2: listeJoueur[index].Solde -= 50; b = "Vous devez payer les frais médicaux de 50 euros"; break;
                            case 3: listeJoueur[index].Solde += 25; b = "Vous recevez un revenu annuel de 25 euros"; break;
                            case 4:
                                b = "C'est votre anniveraire! chaque joueur vous donne 25";
                                for (int i = 0; i < listeJoueur.Count; i++)
                                {
                                    if (index == i)
                                    {
                                        listeJoueur[index].Solde += (25 * (listeJoueur.Count - 1));
                                    }
                                    else
                                    {
                                        listeJoueur[i].Solde -= 25;
                                    }
                                }
                                break;
                            case 5: listeJoueur[index].Solde -= 100; b = "Vous devez payer les frais d'assurance de 100 euros"; break;
                            case 6: listeJoueur[index].Solde += 250; b = "Vous héritez de 250 euros"; break;
                        }
                        FrmChance fc = new FrmChance("Carte de caisse communautée tirée", b);
                        fc.ShowDialog();
                        
                        break; }
                case 34:
                    {
                        boxes[index].SetBounds(1340 + index * 10, 410 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[34] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 320 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[34] = index;
                                listeJoueur[index].Solde -= 320;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[34] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 28;
                            switch (maison[34])
                            {
                                case 1: prix = 150; break;
                                case 2: prix = 450; break;
                                case 3: prix = 1000; break;
                                case 4: prix = 1200; break;
                                case 5: prix = 1400; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[34]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 35:
                    {
                        boxes[index].SetBounds(1330 + index * 10, 500 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[35] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce service pour 200 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[35] = index;
                                listeJoueur[index].Solde -= 200;
                                label41.Text = listeJoueur[index].Nom;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[35] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 25;
                            if (propriete[35] == propriete[15])
                            {
                                prix *= 2;
                            }
                            if (propriete[35] == propriete[25])
                            {
                                prix *= 2;
                            }
                            if (propriete[35] == propriete[5])
                            {
                                prix *= 2;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[35]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 36:
                    {
                        boxes[index].SetBounds(1310 + index * 10, 570 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        Random rnd = new Random();
                        int chance = rnd.Next(1, 6);
                        String b = "";
                        switch (chance)
                        {
                            case 1: listeJoueur[index].Solde += 1000; b = "Vous gagnez 1000 euros"; break;
                            case 2: listeJoueur[index].Solde += 75; b = "La banque vous rembourse 75 euros"; break;
                            case 3: listeJoueur[index].Solde -= 100; b = "Amende pour excès de vitesse. Vous payez 100 euros"; break;
                            case 4: listeJoueur[index].Solde -= 1000; b = "Vous devez payer les frais de scolarité de 1000 euros"; break;
                            case 5: listeJoueur[index].Solde -= 20; b = "Vous payez une amende de 20 euros pour stationnement interdit"; break;
                            case 6: listeJoueur[index].Solde += 1200; b = "Felicitation! vous avez gagné 1200 euros au casino"; break;
                        }
                        FrmChance fc = new FrmChance("Carte de chance tirée", b);
                        fc.ShowDialog();
                       
                        break; }
                case 37:
                    {
                        boxes[index].SetBounds(1340 + index * 10, 650 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[37] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 350 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[37] = index;
                                listeJoueur[index].Solde -= 350;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[37] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 35;
                            switch (maison[37])
                            {
                                case 1: prix = 175; break;
                                case 2: prix = 500; break;
                                case 3: prix = 1100; break;
                                case 4: prix = 1300; break;
                                case 5: prix = 1500; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[37]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
                case 38:
                    {
                        boxes[index].SetBounds(1340 + index * 10, 740 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        MessageBox.Show("Vous devez payer 10% de taxe. Vous vous acquittez de 75 euros");
                        listeJoueur[index].Solde -= 75;
                        break; }
                case 39:
                    {
                        boxes[index].SetBounds(1340 + index * 10, 820 + index * 10, 50, 50);
                        boxes[index].Bounds = resizeElement(boxes[index].Bounds);
                        //le terrain appartient à la banque
                        if (propriete[39] == -1)
                        {
                            DialogResult dialogResult = MessageBox.Show("Voulez vous acheter ce terrain pour 400 euros ?", "Offre d'achat", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                propriete[39] = index;
                                listeJoueur[index].Solde -= 400;
                            }
                            
                        }
                        //le terrain appartient au joueur
                        else if (propriete[39] == index)
                        {
                            
                        }
                        //le terrain appartient à un autre joueur
                        else
                        {
                            int prix = 50;
                            switch (maison[39])
                            {
                                case 1: prix = 200; break;
                                case 2: prix = 600; break;
                                case 3: prix = 1400; break;
                                case 4: prix = 1700; break;
                                case 5: prix = 2000; break;
                            }
                            listeJoueur[index].Solde -= prix;
                            listeJoueur[propriete[39]].Solde += prix;
                            MessageBox.Show("Vous devez payer " + prix + " euros");
                        }
                        break; }
            }
        }
        //Affiche le proprietaire ainsi que le nombre de maison d'un terrain pour chaque case propriété
        public void afficheMaison()
        {
            if(propriete[1]==-1)
            { label9.Text = "Banque"; }
            else
            {
                label9.Text = listeJoueur[propriete[1]].Nom+"("+maison[1]+" maison)";
            }
            if (propriete[3] == -1)
            { label10.Text = "Banque"; }
            else
            {
                label10.Text = listeJoueur[propriete[3]].Nom + "(" + maison[3] + " maison)";
            }
            if (propriete[6] == -1)
            { label18.Text = "Banque"; }
            else
            {
                label18.Text = listeJoueur[propriete[6]].Nom + "(" + maison[6] + " maison)";
            }
            if (propriete[8] == -1)
            { label19.Text = "Banque"; }
            else
            {
                label19.Text = listeJoueur[propriete[8]].Nom + "(" + maison[8] + " maison)";
            }
            if (propriete[9] == -1)
            { label20.Text = "Banque"; }
            else
            {
                label20.Text = listeJoueur[propriete[9]].Nom + "(" + maison[9] + " maison)";
            }
            if (propriete[11] == -1)
            { label21.Text = "Banque"; }
            else
            {
                label21.Text = listeJoueur[propriete[11]].Nom + "(" + maison[11] + " maison)";
            }
            if (propriete[13] == -1)
            { label23.Text = "Banque"; }
            else
            {
                label23.Text = listeJoueur[propriete[13]].Nom + "(" + maison[13] + " maison)";
            }
            if (propriete[14] == -1)
            { label24.Text = "Banque"; }
            else
            {
                label24.Text = listeJoueur[propriete[14]].Nom + "(" + maison[14] + " maison)";
            }
            if (propriete[16] == -1)
            { label26.Text = "Banque"; }
            else
            {
                label26.Text = listeJoueur[propriete[16]].Nom + "(" + maison[16] + " maison)";
            }
            if (propriete[18] == -1)
            { label28.Text = "Banque"; }
            else
            {
                label28.Text = listeJoueur[propriete[18]].Nom + "(" + maison[18] + " maison)";
            }
            if (propriete[19] == -1)
            { label29.Text = "Banque"; }
            else
            {
                label29.Text = listeJoueur[propriete[19]].Nom + "(" + maison[19] + " maison)";
            }
            if (propriete[21] == -1)
            { label30.Text = "Banque"; }
            else
            {
                label30.Text = listeJoueur[propriete[21]].Nom + "(" + maison[21] + " maison)";
            }
            if (propriete[23] == -1)
            { label31.Text = "Banque"; }
            else
            {
                label31.Text = listeJoueur[propriete[23]].Nom + "(" + maison[23] + " maison)";
            }
            if (propriete[24] == -1)
            { label32.Text = "Banque"; }
            else
            {
                label32.Text = listeJoueur[propriete[24]].Nom + "(" + maison[24] + " maison)";
            }
            if (propriete[26] == -1)
            { label34.Text = "Banque"; }
            else
            {
                label34.Text = listeJoueur[propriete[26]].Nom + "(" + maison[26] + " maison)";
            }
            if (propriete[27] == -1)
            { label35.Text = "Banque"; }
            else
            {
                label35.Text = listeJoueur[propriete[27]].Nom + "(" + maison[27] + " maison)";
            }
            if (propriete[29] == -1)
            { label37.Text = "Banque"; }
            else
            {
                label37.Text = listeJoueur[propriete[29]].Nom + "(" + maison[29] + " maison)";
            }
            if (propriete[31] == -1)
            { label38.Text = "Banque"; }
            else
            {
                label38.Text = listeJoueur[propriete[31]].Nom + "(" + maison[31] + " maison)";
            }
            if (propriete[32] == -1)
            { label39.Text = "Banque"; }
            else
            {
                label39.Text = listeJoueur[propriete[32]].Nom + "(" + maison[32] + " maison)";
            }
            if (propriete[34] == -1)
            { label40.Text = "Banque"; }
            else
            {
                label40.Text = listeJoueur[propriete[34]].Nom + "(" + maison[34] + " maison)";
            }
            if (propriete[37] == -1)
            { label42.Text = "Banque"; }
            else
            {
                label42.Text = listeJoueur[propriete[37]].Nom + "(" + maison[37] + " maison)";
            }
            if (propriete[39] == -1)
            { label43.Text = "Banque"; }
            else
            {
                label43.Text = listeJoueur[propriete[39]].Nom + "(" + maison[39] + " maison)";
            }

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            { 
            FrmMaison frmm = new FrmMaison();
            frmm.idJoueur = 0;
            frmm.idTerrain = listeJoueur[0].Position;
            frmm.propriete = propriete;
            frmm.maison = maison;
            frmm.afficheInfo();
            frmm.ShowDialog();
            frmm.propriete = propriete;
            frmm.maison = maison;
            listeJoueur[0].Solde -= frmm.prixTotal;
            afficheJoueur();
            afficheMaison();
            }
            catch (Exception) { MessageBox.Show("Joueur non disponible"); }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMaison frmm = new FrmMaison();
                frmm.idJoueur = 1;
                frmm.idTerrain = listeJoueur[1].Position;
                frmm.propriete = propriete;
                frmm.maison = maison;
                frmm.afficheInfo();
                frmm.ShowDialog();
                frmm.propriete = propriete;
                listeJoueur[1].Solde -= frmm.prixTotal;
                afficheJoueur();
                afficheMaison();
            }
            catch (Exception) { MessageBox.Show("Joueur non disponible"); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMaison frmm = new FrmMaison();
                frmm.idJoueur = 2;
                frmm.idTerrain = listeJoueur[2].Position;
                frmm.propriete = propriete;
                frmm.maison = maison;
                frmm.afficheInfo();
                frmm.ShowDialog();
                frmm.propriete = propriete;
                frmm.maison = maison;
                listeJoueur[2].Solde -= frmm.prixTotal;
                afficheJoueur();
                afficheMaison();
            }
            catch (Exception) { MessageBox.Show("Joueur non disponible"); }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            { 
            FrmMaison frmm = new FrmMaison();
            frmm.idJoueur = 3;
            frmm.idTerrain = listeJoueur[3].Position;
            frmm.propriete = propriete;
            frmm.maison = maison;
            frmm.afficheInfo();
            frmm.ShowDialog();
            frmm.propriete = propriete;
            frmm.maison = maison;
            listeJoueur[3].Solde -= frmm.prixTotal;
            afficheJoueur();
            afficheMaison();
            }
        catch (Exception) { MessageBox.Show("Joueur non disponible"); }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            FrmMaison frmm = new FrmMaison();
            frmm.idJoueur = 4;
            frmm.idTerrain = listeJoueur[4].Position;
            frmm.propriete = propriete;
            frmm.maison = maison;
            frmm.afficheInfo();
            frmm.ShowDialog();
            frmm.propriete = propriete;
            frmm.maison = maison;
            listeJoueur[4].Solde -= frmm.prixTotal;
            afficheJoueur();
            afficheMaison();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FrmMaison frmm = new FrmMaison();
            frmm.idJoueur = 5;
            frmm.idTerrain = listeJoueur[5].Position;
            frmm.propriete = propriete;
            frmm.maison = maison;
            frmm.afficheInfo();
            frmm.ShowDialog();
            frmm.propriete = propriete;
            frmm.maison = maison;
            listeJoueur[5].Solde -= frmm.prixTotal;
            afficheJoueur();
            afficheMaison();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FrmMaison frmm = new FrmMaison();
            frmm.idJoueur = 6;
            frmm.idTerrain = listeJoueur[6].Position;
            frmm.propriete = propriete;
            frmm.maison = maison;
            frmm.afficheInfo();
            frmm.ShowDialog();
            frmm.propriete = propriete;
            frmm.maison = maison;
            listeJoueur[6].Solde -= frmm.prixTotal;
            afficheJoueur();
            afficheMaison();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Width = x;
            this.Height = y;
            button20.Enabled = false;
            button17.Enabled = false;
            foreach (Control control in this.Controls)
            {
                control.Bounds = resizeElement(control.Bounds);
            }
            foreach (Control control in groupBox1.Controls)
            {
                control.Bounds = resizeElement(control.Bounds);
            }
            foreach (Control control in groupBox2.Controls)
            {
                control.Bounds = resizeElement(control.Bounds);
            }
            foreach (Control control in groupBox3.Controls)
            {
                control.Bounds = resizeElement(control.Bounds);
            }
            foreach (Control control in groupBox4.Controls)
            {
                control.Bounds = resizeElement(control.Bounds);
            }
            foreach (Control control in groupBox5.Controls)
            {
                control.Bounds = resizeElement(control.Bounds);
            }
            foreach (Control control in groupBox6.Controls)
            {
                control.Bounds = resizeElement(control.Bounds);
            }
            foreach (Control control in groupBox7.Controls)
            {
                control.Bounds = resizeElement(control.Bounds);
            }
            foreach (Control control in groupBox8.Controls)
            {
                control.Bounds = resizeElement(control.Bounds);
            }

        }
        public Rectangle resizeElement(Rectangle r)
        {
            r.X = (int)(r.X * rx);
            r.Y = (int)(r.Y * ry);
            r.Width = (int)(r.Width * rx);
            r.Height = (int)(r.Height * ry);
            return r;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button20.Enabled = false;
            button17.Enabled = false;
            button19.Enabled = true;
            button5.Enabled = true;
            propriete = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            maison = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox6.Enabled = false;
            groupBox7.Enabled = false;
            groupBox8.Enabled = false;
            button9.Hide();
            pictureBox6.Hide();
            pictureBox10.Hide();
            pictureBox11.Hide();
            pictureBox12.Hide();
            pictureBox13.Hide();
            pictureBox14.Hide();
            pictureBox15.Hide();
            PictureBox[] boxes2 = { pictureBox6, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15 };
            boxes = boxes2;
            afficheMaison();
            listeJoueur.Clear();
            button1.Show();
            enJeux = false;
            //écraser les groupboxe joueurs
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
            label1.Text = "Aucun Joueur";
            label2.Text = "Solde : 0 euros";
            label4.Text = "Aucun Joueur";
            label3.Text = "Solde : 0 euros";
            label6.Text = "Aucun Joueur";
            label5.Text = "Solde : 0 euros";
            label8.Text = "Aucun Joueur";
            label7.Text = "Solde : 0 euros";
            label12.Text = "Aucun Joueur";
            label11.Text = "Solde : 0 euros";
            label14.Text = "Aucun Joueur";
            label13.Text = "Solde : 0 euros";
            label16.Text = "Aucun Joueur";
            label15.Text = "Solde : 0 euros";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            FrmRegles fr = new FrmRegles();
            fr.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            FrmContrat fc = new FrmContrat();
            fc.lj = listeJoueur;
            fc.propriete = propriete;
            fc.maison = maison;
            fc.afficher();
            fc.ShowDialog();
            listeJoueur = fc.lj;
            propriete = fc.propriete;
            maison = fc.maison;
            afficheJoueur();
            afficheMaison();
        }
        //verifie que le joueur a bien un solde > 0, sinon hypothèque/vente, sinon perdu
        public void verifJoueur(int idJ)
        {
            if(listeJoueur[idJ].Solde < 0)
            {
                Boolean b = true;
                while(b)
                {
                    DialogResult dialogResult = MessageBox.Show("Vous êtes ruiné. Pour continuer, vous devez vendre ou hypothéquer des terrains ou des maisons", "Hypothequer ou vendre", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        FrmContrat fc = new FrmContrat();
                        fc.lj = listeJoueur;
                        fc.propriete = propriete;
                        fc.maison = maison;
                        fc.afficher();
                        fc.ShowDialog();
                        listeJoueur = fc.lj;
                        propriete = fc.propriete;
                        maison = fc.maison;
                        afficheJoueur();
                        afficheMaison();
                    }
                    else
                    {
                        b = false;
                    }
                }

            }
            if (listeJoueur[idJ].Solde < 0)
            {
                MessageBox.Show("Vous êtes ruiné. Vous avez perdu la partie");
                listeJoueur.Remove(listeJoueur[idJ]);
                switch(idJ)
                {
                    case 0: groupBox1.Enabled = false;break;
                    case 1: groupBox2.Enabled = false; break;
                    case 2: groupBox3.Enabled = false; break;
                    case 3: groupBox4.Enabled = false; break;
                    case 4: groupBox6.Enabled = false; break;
                    case 5: groupBox7.Enabled = false; break;
                    case 6: groupBox8.Enabled = false; break;
                }
                afficheJoueur();
                afficheMaison();

            }
        }
    }
}
