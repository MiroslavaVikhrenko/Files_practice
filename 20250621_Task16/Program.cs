using System.Text;

namespace _20250621_Task16
{
    /*
     У вас есть текстовый файл, содержащий список сотрудников и их зарплаты, 
    разделенные запятыми. Вам необходимо отсортировать список сотрудников по 
    возрастанию зарплаты и записать его в новый файл. 
    Для решения этой задачи использовать только класс FileStream.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "employees.txt";
            string outputPath = "employees_sorted.txt";

            // list of tuples
            List<(string name, int salary)> employees = new List<(string, int)>();

            // Buffer to accumulate characters from file bytes
            StringBuilder lineBuilder = new StringBuilder();

            try
            {
                using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                {
                    int b; // variable to hold each byte read
                           // Read bytes one by one until the end of stream (-1)
                    while ((b = fs.ReadByte()) != -1)
                    {
                        // Convert byte to char 
                        char c = (char)b;

                        // Accumulate characters until line ends
                        if (c != '\n') // if not end of line, keep adding characters
                        {
                            lineBuilder.Append(c);
                        }
                        else
                        {
                            // End of line reached - process the accumulated line
                            string line = lineBuilder.ToString().Trim(); // get line text and trim spaces
                            lineBuilder.Clear(); // clear for next line

                            if (!string.IsNullOrEmpty(line))
                            {
                                // "EmployeeName,Salary"
                                string[] parts = line.Split(',');

                                // line must have exactly 2 parts
                                if (parts.Length == 2)
                                {
                                    string name = parts[0].Trim(); 
                                    int salary = int.Parse(parts[1].Trim()); 

                                    // Add employee info to the list
                                    employees.Add((name, salary));
                                }
                            }
                        }
                    }

                    // Handle last line if file does not end with new line
                    if (lineBuilder.Length > 0)
                    {
                        string line = lineBuilder.ToString().Trim();
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 2)
                            {
                                string name = parts[0].Trim();
                                int salary = int.Parse(parts[1].Trim());
                                employees.Add((name, salary));
                            }
                        }
                    }
                }

                employees.Sort((a, b) => a.salary.CompareTo(b.salary));

                using (FileStream fsOut = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    foreach (var emp in employees)
                    {
                        string outputLine = emp.name + "," + emp.salary.ToString() + "\n";

                        // Convert string to bytes 
                        byte[] bytesToWrite = Encoding.UTF8.GetBytes(outputLine);

                        // Write bytes to output file 
                        fsOut.Write(bytesToWrite, 0, bytesToWrite.Length);
                    }
                }

                Console.WriteLine("Employees sorted by salary and written to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
