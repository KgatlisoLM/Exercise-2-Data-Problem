using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Data_Problem
{
   public class Program
    {
       public static void Main()
       {

            string[] csvLines =   File.ReadAllLines("../../../Data/Data.csv");
            StreamWriter pathNames = new StreamWriter("../../../Data/Names.txt");
            StreamWriter pathAddress = new StreamWriter("../../../Data/Addresses.txt");
   
            var FirstNames = new List<string>();
            var LastNames = new List<string>();
           
            
            var Address = new List<string>();

            for (int i = 1; i < csvLines.Length; i++)
            {
               string[] rowData = csvLines[i].Split(',');

                FirstNames.Add(rowData[0]);
                LastNames.Add(rowData[1]);
                Address.Add(rowData[2]);
            }

            FirstNames.AddRange(LastNames);

            var arr = FirstNames.ToList();

            arr.Sort();

            var array = from x in arr
                        group x by x into g
                        let count = g.Count()
                        orderby count descending
                        select new { Value = g.Key, Count = count };

            foreach (var item in array)
            {
                Console.WriteLine("{0},{1}", item.Value, item.Count);
                pathNames.WriteLine("{0},{1}", item.Value, item.Count);  
            }
            pathNames.Close();




            Console.WriteLine("\n");

            var address = Address.OrderBy( x => new string(x.Where(char.IsLetter).ToArray())).ThenBy(x => {
                int number;
                if (int.TryParse(new string(x.Where(char.IsDigit).ToArray()), out number))

                    return number;
                return -1;
            
            }).ToList();

            for (int i = 0; i < address.Count; i++)
            {
                var arry = address[i];
                Console.WriteLine(string.Join(",", arry));

                pathAddress.WriteLine(string.Join(",", arry));
            }
            pathAddress.Close();

            Console.ReadKey();   
        }


    }
 
}
