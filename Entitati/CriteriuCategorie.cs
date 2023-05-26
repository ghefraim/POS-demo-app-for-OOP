using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitati
{
    public class CriteriuCategorie : ICriteriu<string, string>
    {
        public string Categorie { get; set; }

        public CriteriuCategorie(string categorie)
        {
            Categorie = categorie;
        }

        public bool isFulfilled(string operatie, string criteriu)
        {
            if (operatie.Equals("=="))
            {
                return Categorie.Equals(criteriu);
            }
            else if (operatie.Equals("!="))
            {
                return !Categorie.Equals(criteriu);
            }
            return false; // null makes more sense here
        }
    }
}
