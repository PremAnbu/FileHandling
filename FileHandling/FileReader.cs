using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    public class FileReader
    {
        public void fileReader()
        {
            FileStream fileStream = null;
            StreamReader reader = null;
            string path = "C:\\DotNet\\IOStreams\\text.txt";
            try
            {
                if (File.Exists(path))
                {
                    fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    reader = new StreamReader(fileStream);
                    string s=reader.ReadLine();
                    while(s != null)
                    {
                        Console.WriteLine(s);
                        s = reader.ReadLine();
                    }
                }
                else
                    throw new FileNotFoundException("File Not Fount .....");

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (fileStream != null)
                {
                    reader.Close();
                    fileStream.Close();
                }
            }
        }
    }
}
