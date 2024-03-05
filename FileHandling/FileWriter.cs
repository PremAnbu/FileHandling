using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    public class FileWriter
    {
        FileStream fileStream = null;
        StreamWriter writer = null;
        string path = "C:\\DotNet\\IOStreams\\text.txt";
        public void fileWriter()
        {     
            try
            {
                if (File.Exists(path))
                {
                    fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
                    writer = new StreamWriter(fileStream);
                    Console.WriteLine("Enter the text which you want to write to the file");
                    string str = Console.ReadLine();
                    writer.Write(str + " ");
                    writer.Flush();
                }
                else
                    throw new FileNotFoundException("File Not Fount .....");
            }
            catch(FileNotFoundException ex) {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(fileStream != null)
                {
                    writer.Close();
                    fileStream.Close();
                }
            }
        }
        public void updateFIle()
        {
            try
            {
                if (File.Exists(path))
                {
                   string existingFile=File.ReadAllText(path);
                    Console.WriteLine("Enter new Content..");
                    string newContent=Console.ReadLine();
                    existingFile = existingFile + newContent + " ";
                    File.WriteAllText(path, newContent);
                    Console.WriteLine("File Updated");
                }
                else
                    throw new FileNotFoundException("File Not Fount .....");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (fileStream != null)
                {
                    writer.Close();
                    fileStream.Close();
                }
            }

        } 
    }
}
