using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    public class FileHandlingMain
    {
        static void Main()
        {
            // FileWriter writer = new FileWriter();
            //writer.updateFIle();
            //writer.fileWriter();

            // FileReader reader = new FileReader();
            // reader.fileReader();
            string path = "C:\\DotNet\\IOStreams\\employees.csv";
           //File.WriteAllText(path, String.Empty);
            EmployeeMain e = new EmployeeMain();
            e.employeeMain();
        }
    }
}
