using System.Text;

namespace _20250621_Task14
{
    /*
     Задачи с использованием класса FileStream:
    
    1. Выполнить запись в файл большого объема текста (300 символов) 2 раза.
    Используя каретку, считать первую половину текста, после передвинуть каретку и 
    считать вторую половину текста. Считать весь текст. Определить длину последнего слова 
    и заменить его на любое другое, работая с кареткой и записью в файл.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "example.txt";
            string largeText = "Long-distance running is more than just a test of physical endurance; it's a mental challenge that pushes runners beyond their comfort zones. The rhythm of steady breaths and pounding feet becomes a form of meditation. Each mile builds resilience, teaching patience and focus. Over time, the body adapts, and the mind grows stronger. What begins as struggle transforms into strength.";


            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                byte[] data = Encoding.UTF8.GetBytes(largeText);
                fs.Write(data, 0, data.Length);
                fs.Write(data, 0, data.Length);
            }

            byte[] fileContent;
            long halfLength;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                halfLength = fs.Length / 2;
                byte[] firstHalf = new byte[halfLength];
                fs.Read(firstHalf, 0, (int)halfLength);
                Console.WriteLine("First half:\n" + Encoding.UTF8.GetString(firstHalf));
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                fs.Position = halfLength;
                byte[] secondHalf = new byte[fs.Length - halfLength];
                fs.Read(secondHalf, 0, (int)(fs.Length - halfLength));
                Console.WriteLine("\nSecond half:\n" + Encoding.UTF8.GetString(secondHalf));
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                fileContent = new byte[fs.Length];
                fs.Read(fileContent, 0, fileContent.Length);
                Console.WriteLine("\nFull text:\n" + Encoding.UTF8.GetString(fileContent));
            }

            string fullText = Encoding.UTF8.GetString(fileContent);
            int lastSpaceIndex = fullText.LastIndexOf(' ');
            string lastWord = fullText.Substring(lastSpaceIndex + 1);
            Console.WriteLine($"\nLast word: '{lastWord}', Length: {lastWord.Length}");

            string replacement = "NEWWORD";
            if (replacement.Length > lastWord.Length)
            {
                Console.WriteLine("Replacement word is longer than the original. Aborting overwrite.");
                return;
            }

            string paddedReplacement = replacement.PadRight(lastWord.Length);
            byte[] replacementBytes = Encoding.UTF8.GetBytes(paddedReplacement);

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Write))
            {
                long position = Encoding.UTF8.GetByteCount(fullText.Substring(0, lastSpaceIndex + 1)); // where last word begins
                fs.Position = position;
                fs.Write(replacementBytes, 0, replacementBytes.Length);
            }

            Console.WriteLine("\nAfter replacement:");
            string updatedText = File.ReadAllText(filePath);
            Console.WriteLine(updatedText);
            Console.ReadLine();
        }
    }
}
