namespace _20250614_Task6
{
    /* Возьмите любой текстовый файл и выведите на экран длину каждого рядка из этого файла. */
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\mvikh\OneDrive\Desktop\CH notes\01. ASSETS\015 Archive.docx";

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($" >> Line {i+1}: {lines[i].Length} chararcters");
            }

            Console.ReadKey();
        }
    }
}
