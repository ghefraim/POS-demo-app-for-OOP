using Entitati;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace App1
{
    public class PachetManager : ProdusAbstractManager
    {
        public override void GetListFromConsole()
        {
            Console.Write("Numar pachete >> ");
            uint pacheteCount = uint.Parse(Console.ReadLine() ?? string.Empty);

            int countInitial = (int)elemente.Count;
            for (int cnt = countInitial; cnt < countInitial + pacheteCount; cnt++)
            {
                Pachet pachet = (Pachet)ReadElementFromConsole((uint)cnt);

                // Compararea produselor deja existente
                if (!elemente.Contains(pachet))
                {
                    elemente.Add(new Pachet(
                           (uint)elemente.Count + 1,
                           pachet.Nume,
                           pachet.CodIntern,
                           pachet.Categorie,
                           pachet.ElementePachet
                       ));
                }
            }
        }

        public override ProdusAbstract ReadElementFromConsole(uint id)
        {
            // instantierea unui Pachet
            Console.WriteLine("\nIntrodu un pachet:");

            Console.Write("Numele >> ");
            string? nume = Console.ReadLine();

            Console.Write("Codul intern >> ");
            string? codIntern = Console.ReadLine();

            Console.Write("Categorie >> ");
            string? categorie = Console.ReadLine();


            Console.Write("Numar produse >> ");
            uint produseCount = uint.Parse(Console.ReadLine() ?? string.Empty);
            
            List<IPackageable>? elementePachet = new List<IPackageable>();

            int countInitial = 0;
            for (int cnt = countInitial; cnt < countInitial + produseCount; cnt++)
            {
                ProdusManager produsManager = new ProdusManager();
                Produs prod = (Produs)produsManager.ReadElementFromConsole((uint)cnt);

                // Compararea produselor deja existente
                if (!elementePachet.Contains(prod))
                {
                    elementePachet.Add(new Produs(
                           (uint)elemente.Count + 1,
                           prod.Nume,
                           prod.CodIntern,
                           prod.Pret,
                           prod.Categorie,
                           prod.Producator
                       ));
                }
            }

            Console.Write("Numar servicii >> ");
            uint serviciiCount = uint.Parse(Console.ReadLine() ?? string.Empty);

            countInitial = (int)produseCount;
            for (int cnt = countInitial; cnt < countInitial + serviciiCount; cnt++)
            {
                ServiciuManager serviciiManager = new ServiciuManager();
                Serviciu serviciu = (Serviciu)serviciiManager.ReadElementFromConsole((uint)cnt);

                // Compararea produselor deja existente
                if (!elementePachet.Contains(serviciu))
                {
                    elementePachet.Add(new Serviciu(
                           (uint)elemente.Count + 1,
                           serviciu.Nume,
                           serviciu.CodIntern,
                           serviciu.Pret,
                           serviciu.Categorie
                       ));
                }
            }

            return new Pachet(id, nume, codIntern, categorie, elementePachet);
        }

        public override List<ProdusAbstract> GetListFromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Faculta\\poo\\POS\\app1\\XMLPachete.xml");
            XmlNodeList listaNoduri = doc.SelectNodes("/pachete/Pachet");

            foreach (XmlNode nod in listaNoduri)
            {
                Pachet pachet = (Pachet)ReadElementFromXML(nod);

                if (!elemente.Contains(pachet))
                {
                    elemente.Add(pachet);
                }
            }

            return elemente;
        }

        public override ProdusAbstract ReadElementFromXML(XmlNode nod)
        {
            string nume = nod["Nume"].InnerText;
            string codIntern = nod["CodIntern"].InnerText;
            string categorie = nod["Categorie"].InnerText;

            Pachet pachetInstance = new Pachet();

            XmlNodeList elementePachetXml = nod["ElementePachet"].ChildNodes;
            List<IPackageable> elementePachet = new List<IPackageable>();

            foreach (XmlNode elementPachetXml in  elementePachetXml)
            {
                string typeName = "App1." + elementPachetXml.Name + "Manager";
                Type type = Type.GetType(typeName);
                object instance = Activator.CreateInstance(type);

                MethodInfo method = type.GetMethod("ReadElementFromXML", new Type[] { typeof(XmlNode) });
                object[] args = new object[] { elementPachetXml };
                ProdusAbstract result = (ProdusAbstract)method.Invoke(instance, args);

                if (pachetInstance.canAddToPackage(elementePachet, result))
                {
                    elementePachet.Add(result);
                }

            }

            return new Pachet(
                (uint)elemente.Count + 1,
                nume,
                codIntern,
                categorie,
                elementePachet
             );
        }
    }
}
