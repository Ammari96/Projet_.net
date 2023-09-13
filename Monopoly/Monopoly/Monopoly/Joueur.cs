using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Joueur
    {
        private String nom;
        private String pion;
        private int solde;
        private int valeur;
        private int position;
        private int prisonEssaie;
        private Boolean finPrison = false;
        private Image img = new Bitmap(Monopoly.Properties.Resources.pion1);

        public string Nom { get => nom; set => nom = value; }
        public string Pion { get => pion; set => pion = value; }
        public int Solde { get => solde; set => solde = value; }
        public int Valeur { get => valeur; set => valeur = value; }
        public int Position { get => position; set => position = value; }
        public int PrisonEssaie { get => prisonEssaie; set => prisonEssaie = value; }
        public bool FinPrison { get => finPrison; set => finPrison = value; }
        public Image Img { get => img; set => img = value; }
    }
}
