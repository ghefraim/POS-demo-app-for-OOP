using Entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace App1
{
    public class ServiciuManager : ProdusAbstractManager
    {
        //Citeste datele din fisierul "XMLProduse.xml"
        public override List<ProdusAbstract> GetListFromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Faculta\\poo\\POS\\app1\\XMLServicii.xml");
            XmlNodeList lista_noduri = doc.SelectNodes("/servicii/Serviciu");

            foreach (XmlNode nod in lista_noduri)
            {
                Serviciu serviciu = (Serviciu)ReadElementFromXML(nod);

                if (!elemente.Contains(serviciu))
                {
                    elemente.Add(serviciu);
                }
            }

            return elemente;
        }

        public override ProdusAbstract ReadElementFromXML(XmlNode nod)
        {
            string nume = nod["Nume"].InnerText;
            string codIntern = nod["CodIntern"].InnerText;
            uint pret = uint.Parse(nod["Pret"].InnerText);
            string categorie = nod["Categorie"].InnerText;

            return new Serviciu(
                            (uint)elemente.Count + 1,
                            nume,
                            codIntern,
                            pret,
                            categorie
                        );
        }

        //Citeste un numar de @nr servicii de la tastatura si le adauga in tabloul de servicii
        public override void GetListFromConsole()
        {
            Console.Write("\n\nNumar servicii >> ");
            uint nr = uint.Parse(Console.ReadLine() ?? string.Empty);

            int countInitial = (int)elemente.Count;
            for (int cnt = countInitial; cnt < countInitial + nr; cnt++)
            {
                ProdusAbstract serviciu = (Serviciu)ReadElementFromConsole((uint)cnt);

                // Compararea produselor deja existente
                if (!elemente.Contains(serviciu))
                {
                    elemente.Add(new Serviciu(
                            (uint)elemente.Count + 1,
                            serviciu.Nume,
                            serviciu.CodIntern,
                            serviciu.Pret,
                            serviciu.Categorie
                        ));
                }
            }
        }

        //Citeste un singur serviciu de la tastatura si il adauga in tabloul de servicii
        public override ProdusAbstract ReadElementFromConsole(uint id)
        {
            // instantierea unui serviciu
            Console.WriteLine("\nIntrodu un serviciu:");

            Console.Write("Numele >> ");
            string? nume = Console.ReadLine();

            Console.Write("Codul intern >> ");
            string? codIntern = Console.ReadLine();

            Console.Write("Categorie >> ");
            string? categorie = Console.ReadLine();

            Console.Write("Pret >> ");
            uint? pret = uint.Parse(Console.ReadLine() ?? string.Empty);

            return new Serviciu(id, nume, codIntern, pret, categorie);
        }

    }
}
