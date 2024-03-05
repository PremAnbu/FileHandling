using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    public class EmployeePOCO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
    }

    public class FileWriters
    {
        public void WriteToCSV(EmployeePOCO employee)
        {
            string path = "C:\\DotNet\\IOStreams\\employees.csv";

            try
            {
                List<string> lines = File.ReadAllLines(path).ToList();
                StreamWriter s = new StreamWriter(path, append: true);
                s.AutoFlush = true;
                if (lines.Count == 0)
                    lines.Add("Name,Age,Department");
                lines.Add($"{employee.Name},{employee.Age},{employee.Department}");
                s.WriteLine(lines[lines.Count - 1]);
                Console.WriteLine("Employee data saved to CSV file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
            public void UpdateToCSV(EmployeePOCO employee,string name)
            {
                string path = "C:\\DotNet\\IOStreams\\employees.csv";
                List<string> lines = File.ReadAllLines(path).ToList();

            try
            {
                var v = "";
                if (lines.Count > 0)
                {
                    StreamWriter s = new StreamWriter(path, append: false);
                    s.AutoFlush = true;
                    foreach(string line in lines)
                    {
                       List<string> value = line.Split(",").ToList();
                       if (value[0].Equals(name))
                            v = line;   
                    }
                    lines[lines.IndexOf(v)] = $"{employee.Name},{employee.Age},{employee.Department}";
                    foreach (var item in lines)
                    {
                        s.WriteLine(item);   
                    }
                    s.Close();
                    Console.WriteLine("Employee data updated to CSV file.");
                }
                else
                    Console.WriteLine("FIle is empty..");
            }
            catch (Exception ex)
            {
                    Console.WriteLine($"Error: {ex.Message}");
            }
            
            }

        public void DeleteToCSV(string name)
        {
            string path = "C:\\DotNet\\IOStreams\\employees.csv";
            List<string> lines = File.ReadAllLines(path).ToList();

            try
            {
                var v = "";
                if (lines.Count > 0)
                {
                    var filteredLines = lines.Where(line => !line.StartsWith(name + ",")).ToList();

                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        foreach (string line in filteredLines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                    Console.WriteLine("Employee data deleted from CSV file.");
                }
                else
                    Console.WriteLine("File is empty.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
    public class EmployeeMain
    {
        public void employeeMain()
        {
            EmployeePOCO employeePOCO = new EmployeePOCO()
            {
                Name = "premkumar",
                Age = 35,
                Department = "Test"
            };
            FileWriters fileWriters = new FileWriters();
           // fileWriters.WriteToCSV(employeePOCO);
           // fileWriters.UpdateToCSV(employeePOCO, "prem");
           fileWriters.DeleteToCSV("premkumar");
        }
    }

}

