using System.Reflection.PortableExecutable;

namespace _20250622_Task18
{
    internal class Program
    {
        /* 
         Описать функцию fromto, переписывающую содержимое одного текстового файла в другой, но без пустых строк.
        */
        static void Main(string[] args)
        {
            string sourcePath = "source.txt";
            string targetPath = "target.txt";

            try
            {
                FromTo(sourcePath, targetPath);
                Console.WriteLine("File copied successfully without empty lines.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine();
        }

        static void FromTo(string sourcePath, string targetPath)
        {
            using (StreamReader sr = new StreamReader(sourcePath)) 

            using (StreamWriter sw = new StreamWriter(targetPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        sw.WriteLine(line);
                    }
                }
            }

        }
    }
}
