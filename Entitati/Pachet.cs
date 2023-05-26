using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entitati
{
    public class Pachet : ProdusAbstract
    {
        public List<IPackageable>? ElementePachet = new List<IPackageable>();
       
        public Pachet(uint id, string? nume, string? codIntern, string? categorie, List<IPackageable> elementePachet, double? discount=0) 
            : base(id, nume, codIntern, categorie)
        {
            Id = id;
            Nume = nume;
            CodIntern = codIntern;
            Categorie = categorie;
            ElementePachet = elementePachet;
            Pret = calculatePachetPrice(discount);
        }

        public Pachet() : base()
        {
        }

        private uint? calculatePachetPrice(double? discount)
        {
            uint? totalPrice = 0;
            if (ElementePachet == null)
            {
                return null;
            }

            //adunarea tuturor preturilor elementelor
            foreach (ProdusAbstract element in ElementePachet)
            {
                totalPrice += element.Pret;
            }
            //scaderea % reducerii (daca exista) din totalPrice
            totalPrice = (uint?)(totalPrice - (discount / 100) * totalPrice);
            return totalPrice;
        }

        public override void Descriere()
        {
            Console.WriteLine(this.ToString());
        }
        public override string ToString()
        {
            if (ElementePachet == null)
            {
                return null;
            }

            string output = "Pachet: " + this.CodIntern + " - " + this.Nume + " [" + this.Categorie + "] - " + this.Pret + "$\n{\n";
            foreach (ProdusAbstract element in ElementePachet)
            {
                output += "    " + element.ToString();
            }
            output += "}\n";
            return output;
        }
        public override bool canAddToPackage(List<IPackageable> elementePachet, ProdusAbstract produsAbstract)
        {
            int produseMax = 1;
            int serviciiMax = 2;

            if (elementePachet.Contains(produsAbstract))
            {
                return false;
            }

            int produseCount =
               (from element in elementePachet
                where element.GetType() == typeof(Produs)
                select element)
               .Count();

            if(produsAbstract.GetType() == typeof(Produs) && produseCount >= produseMax) 
            {
                return false;
            }

            /*if (produseAbstractCount >= produseMax)

                var countsByType = elementePachet
                    .GroupBy(element => element.GetType())
                    .Select(group => new { Type = group.Key, Count = group.Count() });

            foreach (var countByType in countsByType)
            {
                if (produsAbstract.GetType() == typeof(Produs) && countByType.Type.Name == "Produs" && countByType.Count >= 1)
                {
                    return false;
                }
            }*/


            return true;
        }
    }
}
