using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class ProprieteInfo
    {
        public  List<Propriete> listPropriete = new List<Propriete>();
        public ProprieteInfo()
        {
            Propriete p = new Propriete();
            p.Nom = "Aller";
            listPropriete.Add(p);
        }
        
    }
}
