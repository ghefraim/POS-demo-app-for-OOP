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
    public abstract class ProdusAbstractManager
    {
        protected static List<ProdusAbstract> elemente = new List<ProdusAbstract>();
        //protected static uint CountElemente { get; set; } = 0;

        public abstract ProdusAbstract ReadElementFromConsole(uint id);
        public abstract ProdusAbstract ReadElementFromXML(XmlNode nod);
        public abstract void GetListFromConsole();
        public abstract List<ProdusAbstract> GetListFromXML();

        public void WriteToConsole(List<ProdusAbstract> produseAbstracte = null)
        {
            IOrderedEnumerable<ProdusAbstract> sortedElementeByPrice =
                produseAbstracte == null ? elemente.OrderBy(e => e.Pret) : produseAbstracte.OrderBy(e => e.Pret);
            foreach (ProdusAbstract element in sortedElementeByPrice)
            {
                if (new CriteriuPret(element.Pret).isFulfilled("<", 5000))
                {
                    element.Descriere(); // folosesc override la toString
                }
            }
        }

        public void WriteToConsoleLINQ()
        {
            IEnumerable<ProdusAbstract> query =
                from elem in elemente
                where elem.Categorie == "Tehnologia Informatiei"
                orderby elem.Nume
                select elem;

            foreach(ProdusAbstract element in query)
            {
                element.Descriere();
            }
        }

        protected bool Contains(ProdusAbstract prod)
        {
            for (int comp = 0; comp < elemente.Count; comp++)
            {
                if (prod.Equals((Produs)elemente[comp]))
                {
                    return true;
                }
            }
            return false;
        }

        protected bool Contains(string nume)
        {
            for (int comp = 0; comp < elemente.Count; comp++)
            {
                if (nume.Equals(elemente[comp].Nume))
                {
                    return true;
                }
            }
            return false;
        }

        public List<ProdusAbstract> GetListOfElemente()
        {
            return elemente;
        }

        // Lab7 - Serializare si deserializare
        public void SaveToXML(string fileName)
        {
            Type[] prodAbstractTypes = new Type[2];
            prodAbstractTypes[0] = typeof(Serviciu);
            prodAbstractTypes[1] = typeof(Produs);

            XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), prodAbstractTypes);
            StreamWriter sw = new StreamWriter("C:\\Faculta\\poo\\POS\\app1\\" + fileName + ".xml");

            xs.Serialize(sw, elemente);
            sw.Close();
        }

        public List<ProdusAbstract>? LoadFromXML(string fileName)
        {
            Type[] prodAbstractTypes = new Type[2];
            prodAbstractTypes[0] = typeof(Serviciu);
            prodAbstractTypes[1] = typeof(Produs);

            XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), prodAbstractTypes);
            FileStream fs = new FileStream("C:\\Faculta\\poo\\POS\\app1\\" + fileName + ".xml", FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            
            //deserializare cu crearea de obiect => constructor fara param
            List<ProdusAbstract>? produseAbstracte = (List<ProdusAbstract>?)xs.Deserialize(reader);
            fs.Close();

            return produseAbstracte;
        }
    }
}
