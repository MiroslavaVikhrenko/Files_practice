namespace _20250614_Task5
{
    /*
     Напишите программу, запрашивающую у пользователя путь и имя текстового файла. 
    Программа проверит, что указанный файл существует и выведет сообщение об ошибке и закроется, 
    если это не так. Далее файл откроется и его содержимое будет скопировано в другой файл 
    (пользователю будет предложено указать путь и дать ему имя), но каждый символ будет переведен в верхний регистр.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the full path with the file name and extension included");
            string path = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR The file you mentioned does not exist");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            string fileContent = File.ReadAllText(path);

            string upperCaseText = fileContent.ToUpper();


            Console.WriteLine("Please specify where to copy?");
            string targetFolder = Console.ReadLine();
            Console.WriteLine("Enter a new file's name:");
            string targetName = Console.ReadLine();

            string targetPath = targetFolder + "/" + targetName + ".txt";

            File.WriteAllText(targetPath, upperCaseText);

            Console.ReadKey();
        }
    }
}
