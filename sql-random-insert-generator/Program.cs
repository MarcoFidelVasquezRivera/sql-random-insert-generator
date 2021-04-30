using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Random_Insert_Generator
{
    class Program
    {

        static List<String> firstNames, lastNames, addresses, departments, projectNames;

        static void Main(string[] args)
        {
            string path = "C:/Users/David Steven/Documents/GIT/sql-insert-generator/data/WorksOn.csv";
            string fileName = @"C:/Users/David Steven/Documents/GIT/sql-insert-generator/data/WorksOn.sql";
            LoadData(path);
            List<String> dataReturned = generateInserts();
            WriteData(dataReturned, fileName);

        }

        public static void LoadData(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));
            string line = reader.ReadLine();
            string[] headers = line.Split(';');

            line = reader.ReadLine();


            while (line != null && line != "")
            { 
            

            
            
            
            
            
            }






        }

        public static List<String> generateInserts()
        {
            List<string> inserts = new List<string>();

            for (int i = 0; i < 40; i++)
            {
                string toAdd = "";
                Random rand = new Random();

                int randIndex = rand.Next(firstNames.Count);
                toAdd += firstNames[randIndex];

                randIndex = rand.Next(lastNames.Count);



            }




            return inserts;
        }

        public static void WriteData(List<string> data, string fileName)
        {
            try
            {
                StreamWriter writer = new StreamWriter(fileName);

                foreach (string d in data)
                {
                    writer.Write(d);
                }
                writer.Close();

            }

            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

    }
}
