using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.IO;

namespace ExampleXML
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = File.OpenText("Entries.txt");

            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0","utf-8",null);
            xmlDoc.AppendChild(xmlDecl);
            XmlElement entriesElement = xmlDoc.CreateElement("entries");

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] fields = line.Split('|');

                XmlElement entryElement = xmlDoc.CreateElement("entry");
                entryElement.SetAttribute("type", fields[0]);

                XmlElement amountElement = xmlDoc.CreateElement("amount");
                amountElement.InnerText = fields[1];
                XmlElement dataElement = xmlDoc.CreateElement("data");
                dataElement.InnerText = fields[2];
                XmlElement descriptionElement = xmlDoc.CreateElement("description");
                XmlCDataSection cdataDescription = xmlDoc.CreateCDataSection(fields[3]);
                descriptionElement.AppendChild(cdataDescription);
                XmlElement categoryElement = xmlDoc.CreateElement("category");
                categoryElement.InnerText = fields[4];

                entryElement.AppendChild(amountElement);
                entryElement.AppendChild(dataElement);
                entryElement.AppendChild(descriptionElement);
                entryElement.AppendChild(categoryElement);

                entriesElement.AppendChild(entryElement);
            }

            xmlDoc.AppendChild(entriesElement);
            xmlDoc.Save("entries.xml");

            sr.Close();
        }
    }
}
