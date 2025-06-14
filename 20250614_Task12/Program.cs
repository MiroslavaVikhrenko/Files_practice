namespace _20250614_Task12
{
    /*
     Создайте приложение для перемещения папок. Пользователь вводит путь к оригинальной папке и 
    путь к тому месту куда нужно переместить папку. Приложение должно сообщить об успешности или неуспешности операции.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Folder Mover Application ===\n\n\n");
            Console.ResetColor();

            Console.Write("Enter the full path of the folder you want to move: ");
            string sourcePath = Console.ReadLine();

            // C:\Users\mvikh\OneDrive\Desktop\Source_Folder
            // C:\Users\mvikh\OneDrive\Desktop\Destination_Folder

            Console.Write("Enter the destination path where you want to move the folder: ");
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

                Directory.Move(sourcePath, destinationPath);
                Console.WriteLine($"\nSuccess: Folder moved to '{destinationPath}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
