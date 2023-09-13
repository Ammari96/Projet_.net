using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Creation de l'objet propriété, avec les propritées liées

namespace Monopoly
{
    public class Propriete
    {
        private String nom;
        private int prixAchat;
        private int proprietere = -1;
        private int type;
        private int x;
        private int y;

        public string Nom { get => nom; set => nom = value; }
        public int PrixAchat { get => prixAchat; set => prixAchat = value; }
        public int Proprietere { get => proprietere; set => proprietere = value; }
        public int Type { get => type; set => type = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}
