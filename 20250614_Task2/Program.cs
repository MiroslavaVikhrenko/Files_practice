namespace _20250614_Task2
{
    /*
     В указанной пользователем папке, найти самый объёмный файл (по размеру) и переместить ее в другую папку 
    (тоже указанную пользователем).
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\mvikh\OneDrive\Desktop\CH notes";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            FileInfo[] files = directoryInfo.GetFiles();

            FileInfo largestFile = files.OrderByDescending(f => f.Length).First();

            Console.WriteLine($"Largest file: {largestFile.Name}\nsize: {largestFile.Length} bytes");


            largestFile.MoveTo(@"C:\Users\mvikh\OneDrive\Desktop\CH notes\largestfile\" + largestFile.Name);


        }
    }
}
