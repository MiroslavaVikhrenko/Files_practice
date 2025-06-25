namespace _20250625_Task21
{
    internal class Program
    {
        /*
         Выполнить параллельное извлечение и добавление файлов.
         */
        static async Task Main(string[] args)
        {
            string source = "source";
            string target = "target";

            string[] files = Directory.GetFiles(source);
            List<Task> tasks = new List<Task>();

            Console.WriteLine($"Starting to copy {files.Length} files in parallel ...");
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string targetFile = Path.Combine(target, fileName);
                tasks.Add(Task.Run(() =>
                {
                    try
                    {
                        File.Copy(file, targetFile, true);
                        Console.WriteLine($"Copied {fileName} to {targetFile}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error copying {fileName}: {ex.Message}");
                    }
                }));
            }

            await Task.WhenAll(tasks);
            Console.WriteLine("All files copied successfully.");
        }
    }
}
