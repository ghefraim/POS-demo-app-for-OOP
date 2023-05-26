using Entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace App1
{
    public class ProdusManager : ProdusAbstractManager
    {
        //Citeste datele din fisierul "XMLProduse.xml"
        public override List<ProdusAbstract> GetListFromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Faculta\\poo\\POS\\app1\\XMLProduse.xml"); 
            XmlNodeList lista_noduri = doc.SelectNodes("/produse/Produs");

            foreach (XmlNode nod in lista_noduri)
            {
                Produs produs = (Produs)ReadElementFromXML(nod);

                if (!elemente.Contains(produs))
                {
                    elemente.Add(produs);
                }
            }

            return elemente;
        }

        public override ProdusAbstract ReadElementFromXML(XmlNode nod)
        {
            string nume = nod["Nume"].InnerText;
            string codIntern = nod["CodIntern"].InnerText;
            string producator = nod["Producator"].InnerText;
            uint pret = uint.Parse(nod["Pret"].InnerText);
            string categorie = nod["Categorie"].InnerText;

            return new Produs(
                            (uint)elemente.Count + 1,
                            nume,
                            codIntern,
                            pret,
                            categorie,
                            producator
                        );
        }

        //Citeste un numar de @nr produse de la tastatura si le adauga in tabloul de produse
        public override void GetListFromConsole()
        {
            Console.Write("Numar produse >> ");
            uint nr = uint.Parse(Console.ReadLine() ?? string.Empty);

            int countInitial = (int)elemente.Count;
            for (int cnt = countInitial; cnt < countInitial + nr; cnt++)
            {
                Produs prod = (Produs)ReadElementFromConsole((uint)cnt);

                // Compararea produselor deja existente
                if (!elemente.Contains(prod))
                {
                    elemente.Add(new Produs(
                           (uint)elemente.Count + 1,
                           prod.Nume,
                           prod.CodIntern,
                           prod.Pret,
                           prod.Categorie,
                           prod.Producator
                       ));
                }
            }
        }

        //Citeste un singur produs de la tastatura si il adauga in tabloul de produse
        public override ProdusAbstract ReadElementFromConsole(uint id)
        {
            // instantierea unui Produs
            Console.WriteLine("\nIntrodu un produs:");

            Console.Write("Numele >> ");
            string? nume = Console.ReadLine();

            Console.Write("Codul intern >> ");
            string? codIntern = Console.ReadLine();

            Console.Write("Pret >> ");
            uint? pret = uint.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Categorie >> ");
            string? categorie = Console.ReadLine();

            Console.Write("Producator >> ");
            string? producator = Console.ReadLine();

            return new Produs(id, nume, codIntern, pret, categorie, producator);
        }
    }
}
