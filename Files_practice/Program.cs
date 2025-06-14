namespace Files_practice
{
    /*
     Используя класс DirectoryInfo, получить имена файлов и подкаталоги из папки, адрес к которой, введет пользователь.
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\mvikh\OneDrive\Desktop\CH notes";

            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                Console.WriteLine("Files:");
                FileInfo[] files = directoryInfo.GetFiles();

                foreach (FileInfo file in files)
                {
                    Console.WriteLine($" >> {file.Name}");
                }

                Console.WriteLine("Sub-folders:");
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();

                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    Console.WriteLine($" >> {subDirectory.Name}");
                }
            }

            Console.ReadLine();
        }
    }
}
