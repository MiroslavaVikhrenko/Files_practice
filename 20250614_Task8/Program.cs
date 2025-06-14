namespace _20250614_Task8
{
    /*
     Дан текстовый файл, где каждая строка начинается на новой линии и может начинаться как с заглавной, 
    так и прописной буквы. Сделать заглавной каждую букву нового предложения, используя методы расширения Linq 
    и собственный метод расширения для класса String.
     */

 
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\mvikh\OneDrive\Desktop\test.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("The file does not exist.");
                return;
            }

            var lines = File.ReadAllLines(path);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nOriginal text:\n");
            Console.ResetColor();
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            var modifiedLines = lines
                .Select(line => line.CapitalizeFirstLetter())
                .ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nModified text:\n");
            Console.ResetColor();
            PrintText(modifiedLines);

            Console.ReadKey();
        }

        public static void PrintText(List<string> text)
        {
            foreach (var line in text)
            {
                Console.WriteLine(line);
            }
        }
    }
}
