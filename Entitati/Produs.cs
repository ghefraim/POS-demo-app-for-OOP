using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entitati
{
    public class Produs : ProdusAbstract
    {
        public string? Producator { get; set; }

        public Produs() : base()
        {
        }

        public Produs(uint id, string? nume, string? codIntern, uint? pret, string? categorie, string? producator)
            : base(id, nume, codIntern, pret, categorie)
        {
            Producator = producator;
        }

        public override void Descriere()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return "Produs: " + this.CodIntern + " - " + this.Nume + " [" + this.Categorie + "] - " + this.Pret + "$ (producator: " + this.Producator + ")\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Produs prod = (Produs)obj;

            return (this.Nume == prod.Nume &&
                this.CodIntern == prod.CodIntern &&
                this.Producator == prod.Producator);
        }
    }
}
