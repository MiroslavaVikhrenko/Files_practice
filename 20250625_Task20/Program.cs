using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

namespace _20250625_Task20
{
    /*
     Разработать программу оценки знаний студента. Создать обычный тест, в котором указывается Ф.И.О. 
    и группа. После идут вопросы и к ним 3 варианта ответа, по завершению выводится табличка с результатами 
    и результаты записываются в файл.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("********** Konwledge Test: World Capitals **********\n");
            Console.ResetColor();

            Console.WriteLine("Enter your Full Name:");
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter your Group:");
            string group = Console.ReadLine();

            List<Question> questions = new List<Question>
            {
                new Question("What is the capital of France?", new[] { "Berlin", "Madrid", "Paris" }, 2),
                new Question("What is the capital of Germany?", new[] { "Berlin", "Vienna", "Zurich" }, 0),
                new Question("What is the capital of Spain?", new[] { "Barcelona", "Madrid", "Lisbon" }, 1),
                new Question("What is the capital of Italy?", new[] { "Rome", "Milan", "Naples" }, 0),
                new Question("What is the capital of Japan?", new[] { "Tokyo", "Seoul", "Beijing" }, 0),
                new Question("What is the capital of Canada?", new[] { "Toronto", "Ottawa", "Vancouver" }, 1)
            };

            int score = StartQuiz(questions);
            PrintResults(fullName, group, score, questions.Count);
            SaveResultsToFile(fullName, group, score, questions.Count);


        }

        static void PrintResults(string fullName, string group, int score, int totalQuestions)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n********** Results **********");
            Console.ResetColor();
            Console.WriteLine($"Full Name: {fullName}");
            Console.WriteLine($"Group: {group}");
            Console.WriteLine($"Score: {score}/{totalQuestions}");
            Console.WriteLine($"Percentage: {Math.Round((double)score / totalQuestions * 100, 2)}%");
        }

        static void SaveResultsToFile(string fullName, string group, int score, int totalQuestions)
        {
            string filePath = "results.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Full Name: {fullName}");
                writer.WriteLine($"Group: {group}");
                writer.WriteLine($"Score: {score}/{totalQuestions}");
                writer.WriteLine($"Percentage: {Math.Round((double)score / totalQuestions * 100, 2)}%");
                writer.WriteLine("-------------------------------");
            }
            Console.WriteLine($"\nResults saved to {filePath}");
        }

        static int StartQuiz(List<Question> questions)
        {
            int score = 0;
            Console.WriteLine("\nPlease answer the following questions:\n");

            for (int i = 0; i < questions.Count; i++)
            {
                Question question = questions[i];
                Console.WriteLine($"{i + 1}. {question.Text}");
                for (int j = 0; j < question.Options.Length; j++)
                {
                    Console.WriteLine($"   {j + 1}. {question.Options[j]}");
                }
                Console.Write("Your answer (1-3): ");
                int answer;
                while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > question.Options.Length)
                {
                    Console.Write("Invalid input. Please enter a number between 1 and 3: ");
                }
                if (answer - 1 == question.CorrectOptionIndex)
                {
                    score++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect! The correct answer is: {question.Options[question.CorrectOptionIndex]}\n");
                }
                Console.ResetColor();
            }
            return score;
        }
    }
}
