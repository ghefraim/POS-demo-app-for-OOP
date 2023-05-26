using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entitati
{
    public class Serviciu : ProdusAbstract
    {
        public Serviciu(uint id, string? nume, string? codIntern, uint? pret, string? categorie) 
            : base(id, nume, codIntern, pret, categorie)
        {

        }

        public Serviciu() : base()
        {
        }

        public override void Descriere()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return "Serviciu: " + this.CodIntern + " - " + this.Nume + " [" + this.Categorie + "] - " + this.Pret + "$\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Serviciu serviciu = (Serviciu)obj;

            if (this.Nume == serviciu.Nume &&
                this.CodIntern == serviciu.CodIntern)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
