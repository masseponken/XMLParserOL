using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml;

namespace XMLParserOL
{
    public static class Program
    {
        static void Main()
        {
            Stopwatch timer = new Stopwatch();
            XmlDocument doc = new XmlDocument();

            bool success = false;

            do
            {
                try
                {
                    Console.Write("Location of XML-file: ");
                    string location = Console.ReadLine();

                    timer.Reset();
                    timer.Start();

                    doc.Load(location);

                    success = true;
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (!success);

            XmlNodeList competitors = doc.GetElementsByTagName("Competitor");
            timer.Stop();

            Console.WriteLine("Found and read " + competitors.Count + " in: " + timer.ElapsedMilliseconds.ToString() + " ms.");

            Console.Write("Filter by club: ");
            string club = Console.ReadLine();

            List<XmlNode> filteredList = new List<XmlNode>();

            timer.Reset();
            timer.Start();

            int x = 0;
            Console.WriteLine("Found " + x + " competitors from " + club);

            foreach (XmlNode competitor in competitors)
            {
               foreach(XmlNode competitorChildnodes in competitor.ChildNodes)
                {
                    if(competitorChildnodes.Name == "Organisation")
                    {
                        foreach (XmlNode childnode in competitorChildnodes.ChildNodes)
                        {
                            if (childnode.Name == "Name")
                            {
                                if(childnode.FirstChild.Value.ToLower() == club.ToLower())
                                {
                                    filteredList.Add(competitor);
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    x++;
                                    Console.WriteLine("Found " + x + " competitors from " + club);
                                }
                            }
                        }
                    }
                }
            }

            XmlDocument outDoc = new XmlDocument();
            XmlNode header = outDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            outDoc.AppendChild(header);

            XmlNode competitorList = outDoc.ImportNode(doc.LastChild, false);

            foreach(XmlNode competitor in filteredList)
            {
                competitorList.AppendChild(outDoc.ImportNode(competitor, true));
            }

            outDoc.AppendChild(competitorList);

            Console.Write("Input path of output file: ");
            string output = Console.ReadLine();
            outDoc.Save(output);
        }
    }
}
