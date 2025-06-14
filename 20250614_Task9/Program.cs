namespace _20250614_Task9
{
    /*
     У вас есть набор текстовых файлов, содержащих данные о покупках в вашем интернет-магазине. 
    Каждый файл содержит информацию о покупках за определенный день. Ваша задача - создать программу на C#, 
    которая будет сканировать папку, содержащую эти файлы, и выводить на экран общее количество проданных товаров за все дни, 
    данные которых находятся в этой папке.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"C:\Users\mvikh\OneDrive\Desktop\orders";

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("The folder does not exist.");
                return;
            }

            var files = Directory.GetFiles(folderPath, "*.txt");

            int totalItemsSold = 0;

            foreach (var file in files)
            {
                Console.WriteLine($"Processing file: {Path.GetFileName(file)}");

                var lines = File.ReadAllLines(file);

                foreach (var line in lines)
                {
                    // Each line format: ProductName, Quantity
                    var parts = line.Split(',');
                    Console.WriteLine($" >> {parts[0]} : {parts[1]}");

                    if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int quantity))
                    {
                        totalItemsSold += quantity;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nTotal items sold across all files: {totalItemsSold}");
            Console.ResetColor();

            Console.ReadKey();
        }
    }
}
