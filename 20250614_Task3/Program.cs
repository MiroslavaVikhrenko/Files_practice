namespace _20250614_Task3
{
    /*
     Пользователь вводит путь и ключевое слово. Отобразить все файлы в текущей папке, содержащие данное ключевое слово.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\mvikh\OneDrive\Desktop\CH notes";
            string keyword = "Assets";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (FileInfo file in files)
            {
                if (file.Name.Contains(keyword))
                {
                    Console.WriteLine($" >> {file.Name}");
                }
            }

            Console.ReadLine();
        }
    }
}
