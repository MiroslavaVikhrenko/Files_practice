using System.Text;

namespace _20250621_Task17
{
    /*
     Пользователь вводит путь к файлу. Приложение отображает статистическую информацию о файле:  

1) Количество предложений  
2) Количество больших букв  
3) Количество маленьких букв  
4) Количество гласных букв  
5) Количество согласных букв  
6) Количество цифр
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            // C:\Users\mvikh\OneDrive\Desktop\test20250621.txt
            Console.WriteLine("Please enter the path to the text file:");

            string filePath = Console.ReadLine();

            int sentenceCount = 0;       
            int upperCaseCount = 0;      
            int lowerCaseCount = 0;      
            int vowelCount = 0;          
            int consonantCount = 0;      
            int digitCount = 0;          

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Create a byte buffer of size 1 to read one byte at a time
                    byte[] buffer = new byte[1]; // The FileStream.Read() method requires a byte array
                    int bytesRead;

                    // Read one byte from the stream into buffer repeatedly
                    // fs.Read returns number of bytes read; 0 means end of stream
                    while ((bytesRead = fs.Read(buffer, 0, 1)) > 0)
                    {
                        // Convert the byte to char 
                        char c = Encoding.ASCII.GetString(buffer)[0];

                        // Check for sentence delimiters 
                        if (c == '.' || c == '!' || c == '?')
                        {
                            sentenceCount++; // Increase sentence count by one
                        }

                        // Check if character is uppercase letter
                        if (c >= 'A' && c <= 'Z')
                        {
                            upperCaseCount++;  

                            // Also check if uppercase vowel
                            if ("AEIOU".IndexOf(c) >= 0)
                            {
                                vowelCount++;  
                            }
                            else if (char.IsLetter(c))
                            {
                                consonantCount++; // Increment consonant counter (letter but not vowel)
                            }
                        }
                        // Check if character is lowercase letter (a-z)
                        else if (c >= 'a' && c <= 'z')
                        {
                            lowerCaseCount++;  

                            // Also check if lowercase vowel
                            if ("aeiou".IndexOf(c) >= 0)
                            {
                                vowelCount++;  
                            }
                            else if (char.IsLetter(c))
                            {
                                consonantCount++;  // Increment consonant counter
                            }
                        }
                        // Check if character is digit 
                        else if (c >= '0' && c <= '9')
                        {
                            digitCount++;  
                        }
                    }
                }
                Console.WriteLine("File statistics:");
                Console.WriteLine($"Number of sentences: {sentenceCount}");
                Console.WriteLine($"Number of uppercase letters: {upperCaseCount}");
                Console.WriteLine($"Number of lowercase letters: {lowerCaseCount}");
                Console.WriteLine($"Number of vowels: {vowelCount}");
                Console.WriteLine($"Number of consonants: {consonantCount}");
                Console.WriteLine($"Number of digits: {digitCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
