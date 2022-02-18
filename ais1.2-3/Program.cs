using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ais1._2_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*XDocument xDoc = new XDocument(
                new XElement("Dishes",
                    new XElement("Dish",
                        new XAttribute("id", "1"),
                        new XElement("name", "GOVNO"),
                        new XElement("compound", "123"),
                        new XElement("weight", "150"),
                        new XElement("price", "300")),
                    new XElement("Dish",
                        new XAttribute("id", "2"),
                        new XElement("name", "ZALUPA"),
                        new XElement("compound", "124"),
                        new XElement("weight", "200"),
                        new XElement("price", "150"))));

            xDoc.Save("dishes1.xml");*/
           
            /*IEnumerable<XElement> elements = xDoc.Descendants("Dish");
            foreach (XElement e in elements)
                Console.WriteLine("Элемент {0} : значение = {1}",e.Name,e.Value);*/
            
            XDocument xDoc = XDocument.Load("komusl.xml");

            /*var statusGroups = xDoc.Root.Elements("Order").GroupBy(t => t.Element("status").Value);
            foreach (IGrouping<string, XElement> a in statusGroups)
                Console.WriteLine("{0} - {1}", a.Key, a.Count());*/
            
            Get1(xDoc);
        }
        
        static void Get1(XDocument xDoc)
        {
            var rezult = from d in xDoc.Descendants("дом")
                from k in d.Elements("квартира")
                from a in d.Elements("адрес")
                where a.Element("улица").Value == "Волгоградская" && a.Element("номер").Value == "8"
                select k;
            foreach (var r in rezult)
            {
                Console.WriteLine(r.Attribute("номер").Value, r.Element("площадь").Value);
            }
        }
    }
}
