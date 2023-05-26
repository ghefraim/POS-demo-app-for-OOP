using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitati
{
    public class FiltrarePret : IFiltrare<string, uint?>
    {
        public uint? Pret { get; set; }

        public FiltrarePret(uint? pret)
        {
            Pret = pret;
        }

        public bool isFulfilled(string operatie, uint? criteriu)
        {
            if (operatie.Equals(">"))
            {
                return Pret > criteriu;
            }
            else if (operatie.Equals("<"))
            {
                return Pret < criteriu;
            }
            else if (operatie.Equals("=="))
            {
                return Pret == criteriu;
            }
            else if (operatie.Equals("!="))
            {
                return Pret != criteriu;
            }
            return false; // null makes more sense here
        }

        public IEnumerable<ProdusAbstract> Filtrare(IEnumerable<ProdusAbstract> elemente, string operatie, uint? criteriu)
        {
            List<ProdusAbstract> filteredElemente = new List<ProdusAbstract>();

            foreach (ProdusAbstract element in elemente) 
            { 
                if (isFulfilled(operatie, criteriu))
                {
                    filteredElemente.Add(element);
                }
            }

            return filteredElemente;
        }
    }
}
