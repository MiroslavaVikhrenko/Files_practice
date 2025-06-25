namespace _20250625_Task19
{
    /*
     Дан файл firma.txt, который содержит номера телефонов сотрудников учреждения: указываются фамилия сотрудника, 
    его инициалы и номер телефона. Найти по телефону сотрудника его фамилию и инициалы.

Файл имеет следующий вид:

Иванов И. И. +380970601478
Петров П. П. +380505968742

Сидоров С. С. 0964549817
Владимиров В.В. (без телефона)
Кузнецов К. К. +380956329815
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "firma.txt";

            Console.WriteLine("Enter phone number you are looking for:");
            string phoneNumber = Console.ReadLine();

            try 
            {
                string result = FindEmployeeByPhone(filePath, phoneNumber);
                if (result != "Not found" && result != null)
                {
                    Console.WriteLine($"Employee found: {result}");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static string FindEmployeeByPhone(string filePath, string phoneNumber)
        {
           try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (line.Contains(phoneNumber))
                    {
                        int phoneIndex = line.IndexOf(phoneNumber);
                        return line.Substring(0, phoneIndex).Trim(); 
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "Not found";
        }
    }
}
