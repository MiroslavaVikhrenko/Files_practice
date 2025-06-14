namespace _20250614_Task4
{
    /*
     Выполнить сохранение текста в файл, потом его чтения и вывод информации в консоль.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\mvikh\OneDrive\Desktop\CH notes\test.txt";

            if (File.Exists(path))
            {
                File.WriteAllText(path, "Hello world");

                string fileContent = File.ReadAllText(path);

                Console.WriteLine($"Text from the file:\n {fileContent}");
            }

            Console.ReadKey();
        }
    }
}
