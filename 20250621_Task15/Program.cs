using System.Text;

namespace _20250621_Task15
{
    internal class Program
    {
        /*
          У вас есть текстовый файл, в котором записаны числа, разделенные запятыми. 
        Вам необходимо считать числа из файла, подсчитать их сумму и вывести результат на экран. 
        Для решения этой задачи использовать только класс FileStream.
         */
        static void Main(string[] args)
        {
            string path = "numbers.txt";

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    int b;                  // to read one byte
                    string currentNumber = ""; 
                    int sum = 0;            

                    while ((b = fs.ReadByte()) != -1)  // read until end of file
                    {
                        char c = (char)b;     // convert byte to char

                        if (c == ',')
                        {
                            sum += int.Parse(currentNumber);  
                            currentNumber = "";                
                        }
                        else
                        {
                            currentNumber += c;  
                        }
                    }

                    // add the last number after loop
                    sum += int.Parse(currentNumber);

                    Console.WriteLine("Sum of numbers in file: " + sum);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}
