using App1;

using Entitati;

/*
// PRODUSE - citim si afisam: 
ProdusManager produseManager = new ProdusManager();
//produsManager.GetListFromConsole(); // versiune veche
produsManager.GetListFromXML();
//Console.WriteLine("\nProdusele sunt: ");
//produsManager.WriteToConsole();

// SERVICII - citim si afisam:
ServicuManager serviciiManager = new ServiciuManager();
//servicuManager.GetListFromConsole();
servicuManager.GetListFromXML();
Console.WriteLine("\n\n### Produsele si Serviciile sunt: ###");
servicuManager.WriteToConsole();
Console.WriteLine("\nLINQ example:");
//servicuManager.WriteToConsoleLINQ();
*/

//Before lab7
//PachetManager pachetManager = new PachetManager();
//pachetManager.GetListFromXML();
//pachetManager.WriteToConsole();

//Lab7:
ProdusAbstractManager mgr = new ServiciuManager();
ServiciuManager serviciuManager = new ServiciuManager();
ProdusManager produsManager = new ProdusManager();
ProdusManager pachetManager = new ProdusManager();

serviciuManager.GetListFromConsole();
produsManager.GetListFromConsole();
pachetManager.GetListFromXML();

mgr.SaveToXML("XMLTestList");
List<ProdusAbstract> produseAbstracte = mgr.LoadFromXML("XMLTestList");

mgr.WriteToConsole(produseAbstracte);
