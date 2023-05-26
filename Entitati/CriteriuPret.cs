using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitati
{
    public class CriteriuPret : ICriteriu<string, uint?>
    {
        public uint? Pret {  get; set; }

        public CriteriuPret(uint? pret)
        {
            Pret = pret;
        }

        public bool isFulfilled(string operatie, uint? criteriu)
        {
            if (operatie.Equals(">"))
            {
                return Pret > criteriu;
            }
            else if(operatie.Equals("<"))
            {
                return Pret < criteriu;
            }
            else if(operatie.Equals("=="))
            {
                return Pret == criteriu;
            }
            else if (operatie.Equals("!="))
            {
                return Pret != criteriu;
            }
            return false; // null makes more sense here
        }
    }
}
