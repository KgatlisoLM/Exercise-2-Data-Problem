using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Data_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../Data/Data.csv";


            //string[] lines = File.ReadAllLines(filePath);

            IEnumerable<string> lines = new List<string>();

            List<DataDsc> dataDsc = new List<DataDsc>();
            List<DataAsc> dataAsc = new List<DataAsc>();
            List<DataAdress> dataAdres = new List<DataAdress>();


            lines = File.ReadAllLines(filePath).ToList().Skip(1).Take(8).GroupBy(n =>n).OrderByDescending(x => x.Count()).ThenByDescending(g => g.Key).SelectMany(g=>g);
            foreach(string line in lines)
            {
                string[] items = line.Split(',');
                DataDsc d = new DataDsc(items[0], items[1]);
     
                dataDsc.Add(d);
            }

            List<string> outContents = new List<string>();

            foreach (DataDsc d in dataDsc)
            {
                
                Console.WriteLine(d);
                outContents.Add(d.ToString());
            }

            string outFile = "NamesDsc.txt";

            File.WriteAllLines(outFile, outContents);

            Console.WriteLine("\n");

            lines = File.ReadAllLines(filePath).ToList().Skip(1).Take(8).GroupBy(n => n).OrderBy(x => x.Count()).ThenBy(g =>g.Key).SelectMany(g => g);
            foreach (string line in lines)
            {
                string[] items = line.Split(',');
                DataAsc d = new DataAsc(items[0], items[1]);
                dataAsc.Add(d);
            }


            List<string> outNames = new List<string>();

            foreach (DataAsc d in dataAsc)
            {
                Console.WriteLine(d);
                outNames.Add(d.ToString());
            }

            string outList = "NamesAsc.txt";
            File.WriteAllLines(outList, outNames);

            Console.WriteLine("\n");

            lines = File.ReadAllLines(filePath).ToList().Skip(1).Take(8).GroupBy(n => n).OrderBy(x => x.Count()).ThenBy(g =>g.Key).SelectMany(g =>g);
            foreach (string line in lines)
            {
                string[] items = line.Split(',');
                DataAdress d = new DataAdress(items[2]);
                dataAdres.Add(d);
            }


   
            foreach (DataAdress d in dataAdres)
            {
                Console.WriteLine(d);
            }

            Console.ReadLine();   
            
        }





       

     
    }
}
