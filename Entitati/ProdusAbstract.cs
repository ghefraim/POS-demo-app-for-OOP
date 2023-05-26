using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entitati
{
    public abstract class ProdusAbstract : IPackageable
    {
        public uint Id { get; set; }
        public string? Nume { get; set; }
        public string? CodIntern { get; set; }
        public uint? Pret { get; set; }
        public string? Categorie { get; set; }


        public ProdusAbstract(uint id, string? nume, string? codIntern, uint? pret, string? categorie)
        {
            Id = id;
            Nume = nume;
            CodIntern = codIntern;
            Pret = pret;
            Categorie = categorie;
        }

        protected ProdusAbstract()
        {
        }

        protected ProdusAbstract(uint id, string? nume, string? codIntern, string? categorie)
        {
            Id = id;
            Nume = nume;
            CodIntern = codIntern;
            Categorie = categorie;
        }

        public abstract void Descriere();
        public virtual bool canAddToPackage(List<IPackageable> elementePachet, ProdusAbstract produsAbstract)
        {
            return true;
        }
    }
}
