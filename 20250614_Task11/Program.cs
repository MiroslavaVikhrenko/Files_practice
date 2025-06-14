namespace _20250614_Task11
{
    /*
     Разработать приложение для записи заметок в файл. Для этого можно создать класс «Note», 
    который представляет собой одну заметку. 
Каждая заметка имеет заголовок и текст, а также дату создания. Затем можно создать класс «NoteManager», 
    который управляет списком заметок и позволяет добавлять, удалять и редактировать заметки, а также сохранять 
    и загружать их из файла.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\mvikh\OneDrive\Desktop\notes.txt";

            NoteManager manager = new NoteManager();
            manager.LoadFromFile(path);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Add Note");
                Console.WriteLine("2 - View Notes");
                Console.WriteLine("3 - Edit Note");
                Console.WriteLine("4 - Delete Note");
                Console.WriteLine("5 - Save Notes");
                Console.WriteLine("6 - Exit");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter content: ");
                        string content = Console.ReadLine();

                        Note newNote = new Note { Title = title, Content = content };
                        manager.AddNote(newNote);
                        Console.WriteLine("Note added.\n");
                        break;

                    case "2":
                        manager.ViewNotes();
                        break;

                    case "3":
                        Console.Write("Enter title of the note to edit: ");
                        string editTitle = Console.ReadLine();
                        manager.EditNote(editTitle);
                        break;

                    case "4":
                        Console.Write("Enter title of the note to delete: ");
                        string deleteTitle = Console.ReadLine();
                        manager.DeleteNote(deleteTitle);
                        break;

                    case "5":
                        manager.SaveToFile(path);
                        break;

                    case "6":
                        manager.SaveToFile(path);
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option.\n");
                        break;
                }

                Console.WriteLine("Press Enter to return to menu...");
                Console.ReadLine();
            }
        }
    }
}
