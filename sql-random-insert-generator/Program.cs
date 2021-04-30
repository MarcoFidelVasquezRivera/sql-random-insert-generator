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

        public static List<String> firstNames, lastNames,position, addresses, departments, projectNames, departmentCodeNumbers;
        public static Dictionary<string, List<string>> departmentEmployees;
        public static Dictionary<string, List<string>> departmentProyects;


        static void Main(string[] args)
        {
            firstNames = new List<String>();
            lastNames = new List<String>();
            position = new List<String>();
            addresses = new List<String>();
            departments = new List<String>();
            projectNames = new List<String>();
            departmentEmployees = new Dictionary<string, List<string>>();
            departmentProyects = new Dictionary<string, List<string>>();

            string path = "C:/Users/David Steven/Documents/GIT/sql-random-insert-generator/data/datos.csv";
            string fileName = @"C:/Users/David Steven/Documents/GIT/sql-random-insert-generator/data/INSERTS.sql";
            LoadData(path);

            List<String> dataReturned = generateInserts();

            WriteData(dataReturned, fileName);

        }

        public static void LoadData(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));
            string line = reader.ReadLine();
            line = reader.ReadLine();


            while (line != null && line != "")
            {
                string[] info = line.Split(';');

                if (info[0]!=null && !info[0].Equals("")) { departments.Add(info[0]); }

                if (info[1]!=null && !info[1].Equals("")) { firstNames.Add(info[1]); }

                if (info[2]!=null && !info[2].Equals("")) { lastNames.Add(info[2]); }

                if (info[3]!=null && !info[3].Equals("")) { position.Add(info[3]); }

                if (info[4]!=null && !info[4].Equals("")) { addresses.Add(info[4]); }

                if (info[5]!=null && !info[5].Equals("")) { projectNames.Add(info[5]); }

                line = reader.ReadLine();
            }

        }

        public static List<String> GenerateDepartments()
        {
            List<String> departmentsGenerated = new List<String>();
            List<String> departmentNames = new List<String>();
            departmentCodeNumbers = new List<string>();

            Random r = new Random();
            

            while (departmentCodeNumbers.Count()<5)
            {
                string code = "DP"+r.Next(10, 99);

                if (!departmentCodeNumbers.Contains(code))
                {
                    departmentEmployees.Add(code, new List<String>());
                    departmentProyects.Add(code, new List<String>());
                    departmentCodeNumbers.Add(code);
                }
            }

            while (departmentNames.Count() < 5)
            {
                string name = departments[r.Next(0, departments.Count())];

                if (!departmentNames.Contains(name))
                {
                    departmentNames.Add(name);
                }
            }

            for (int i=0; i<5; i++)
            {  
                string insert = $"INSERT INTO Department VALUES ('{departmentCodeNumbers[i]}', '{departmentNames[i]}', null);";
                departmentsGenerated.Add(insert);
            }

            return departmentsGenerated;
        }

        public static List<String> GenerateEmployees()
        {
            List<String> employeesGenerated = new List<String>();
            RandomDateTime rdt = new RandomDateTime(new DateTime(1955, 1, 1), new DateTime(2001, 1, 1));
            Random r = new Random();

            for (int i=0; i<20; i++)
            {
                //"INSERT INTO Employee VALUES('EM00','Darwin','Bonner','24 Cherokee Way',TO_DATE('6/7/1974', 'mm/dd/yyyy'),'M','Department Manager','DP30');""
                string code = "EM" + (i + 10);
                string firstName = firstNames[r.Next(0,firstNames.Count())];
                string lastname = lastNames[r.Next(0, lastNames.Count())];
                string address = addresses[r.Next(0, addresses.Count())];
                string date = rdt.Next().ToString().Split(' ')[0].Replace('.', '/');
                char[] genders = { 'M', 'F' };
                char gender = genders[r.Next(0, 2)];

                string job = i<5 ? position[0] : position[r.Next(1,position.Count())];
                string department = i < 5 ? departmentCodeNumbers[i] : departmentCodeNumbers[r.Next(1, departmentCodeNumbers.Count())];

                departmentEmployees[department].Add(code);
                string insert = $"INSERT INTO Employee VALUES ('{code}', '{firstName}', '{lastname}', '{address}', TO_DATE('{date}', 'mm/dd/yyyy'), '{gender}', '{job}', '{department}');";
                employeesGenerated.Add(insert);
            }


            return employeesGenerated;
        }



        public static List<String> GenerateProjects()
        {
            List<String> projectsGenerated = new List<String>();

            Random r = new Random();

            for (int i = 0; i < 20; i++)
            {
                string pName = projectNames[r.Next(0, projectNames.Count())];
                if (!projectNames.Contains(pName))
                {
                    projectNames.Add(pName);
                }

            }



            for (int i = 0; i < 20; i++)
            {
                string pCode = "PJ" + (i + 10);
                string name = projectNames[i];
                string manDpmt = departmentCodeNumbers[r.Next(0, departmentCodeNumbers.Count())];

                departmentProyects[manDpmt].Add(pCode);
                string insert = $"INSERT INTO Projectt VALUES('{pCode}','{name}', '{manDpmt}');";
                projectsGenerated.Add(insert);
            }

            return projectsGenerated;
        }

        public static List<String> GenerateWorksOn()
        {
            List<String> generatedWorksOn = new List<String>();
            RandomDateTime rdt = new RandomDateTime(new DateTime(2019, 1, 1),new DateTime(2021, 1, 1));
            Random r = new Random();

            for (int i=0; i<20;i++)
            {
                string date = rdt.Next().ToString().Split(' ')[0].Replace('.', '/');
                double hours = r.NextDouble() * (10 - 4) + 4;

                string department = departmentCodeNumbers[r.Next(0, departmentCodeNumbers.Count())];
                string project = departmentProyects[department][r.Next(0, departmentProyects[department].Count())];
                string employee = departmentEmployees[department][r.Next(0, departmentEmployees[department].Count())];

                string insert = $"INSERT INTO WorksOn VALUES('{employee}','{project}', TO_DATE('{date}', 'mm/dd/yyyy'), {hours.ToString("#.#").Replace(',','.')});";
                generatedWorksOn.Add(insert);
            }
            return generatedWorksOn;
        }


        public static List<String> generateInserts()
        {
            List<string> inserts = new List<string>();

            inserts.AddRange(GenerateDepartments());
            inserts.AddRange(GenerateEmployees());
            inserts.AddRange(GenerateProjects());
            inserts.AddRange(GenerateWorksOn());

            return inserts;
        }

        public static void WriteData(List<string> data, string fileName)
        {
            try
            {
                StreamWriter writer = new StreamWriter(fileName);

                foreach (string d in data)
                {
                    writer.WriteLine(d);
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
