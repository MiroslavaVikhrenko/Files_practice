namespace _20250614_Task7
{
    /*
     У вас есть папка на вашем компьютере, в которой находится несколько сотен файлов разных типов. 
    Вам необходимо создать программу на C#, которая должна считать названия файлов и отсортировать в соответствии с их типом.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\mvikh\OneDrive\Desktop\CH notes";

            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();

            var groupedFiles = files.GroupBy(f => f.Extension).OrderBy(g => g.Key);

            foreach (var groupedFile in groupedFiles)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" > {groupedFile.Key} :");
                Console.ResetColor();
                foreach (var file in groupedFile)
                {
                    Console.WriteLine($"     >>> {file.Name}");
                }
            }

            Console.ReadKey();
        }
    }
}
