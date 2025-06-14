namespace _20250614_Task13
{
    /*
     Создайте приложение для копирования папок. Пользователь вводит путь к оригинальной папке и путь к 
    тому месту куда нужно скопировать папку. Приложение должно сообщить об успешности или неуспешности операции.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Folder Copy Application ===\n\n\n");
            Console.ResetColor();

            // C:\Users\mvikh\OneDrive\Desktop\Source_Folder
            // C:\Users\mvikh\OneDrive\Desktop\Destination_Folder

            Console.Write("Enter the full path of the folder you want to copy: ");
            string sourcePath = Console.ReadLine();

            Console.Write("Enter the destination path where you want to copy the folder: ");
            string destinationRoot = Console.ReadLine();

            try
            {
                if (!Directory.Exists(sourcePath))
                {
                    Console.WriteLine("Error: The source folder does not exist.");
                    return;
                }

                string folderName = new DirectoryInfo(sourcePath).Name;
                string destinationPath = Path.Combine(destinationRoot, folderName);

                if (Directory.Exists(destinationPath))
                {
                    Console.WriteLine("Error: A folder with the same name already exists at the destination.");
                    return;
                }

                CopyDirectory(sourcePath, destinationPath);

                Console.WriteLine($"\nSuccess: Folder copied to '{destinationPath}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        static void CopyDirectory(string sourceDir, string destDir)
        {
            // Ensure destination directory exists
            Directory.CreateDirectory(destDir);

            // Copy all files
            foreach (var filePath in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(filePath);
                string destFile = Path.Combine(destDir, fileName);
                File.Copy(filePath, destFile);
            }

            // Recursively copy subdirectories
            foreach (var subDir in Directory.GetDirectories(sourceDir))
            {
                string subDirName = Path.GetFileName(subDir);
                string destSubDir = Path.Combine(destDir, subDirName);
                CopyDirectory(subDir, destSubDir);
            }
        }
    }
}
