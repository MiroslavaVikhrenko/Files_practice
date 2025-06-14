using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250614_Task11
{
    public class NoteManager
    {
        private List<Note> notes = new List<Note>();

        public void AddNote(Note note)
        {
            notes.Add(note);
        }

        public void ViewNotes()
        {
            if (notes.Count == 0)
            {
                Console.WriteLine("No notes found.\n");
                return;
            }

            foreach (var note in notes)
            {
                Console.WriteLine(note);
                Console.WriteLine("---------------------------");
            }
        }

        public void DeleteNote(string title)
        {
            var note = notes.FirstOrDefault(n => n.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (note != null)
            {
                notes.Remove(note);
                Console.WriteLine("Note deleted.\n");
            }
            else
            {
                Console.WriteLine("Note not found.\n");
            }
        }

        public void EditNote(string title)
        {
            var note = notes.FirstOrDefault(n => n.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (note != null)
            {
                Console.WriteLine("Enter new content:");
                note.Content = Console.ReadLine();
                note.UpdatedAt = DateTime.Now;
                Console.WriteLine("Note updated.\n");
            }
            else
            {
                Console.WriteLine("Note not found.\n");
            }
        }

        public void SaveToFile(string filePath)
        {
            using StreamWriter writer = new StreamWriter(filePath);
            foreach (var note in notes)
            {
                writer.WriteLine("--- NOTE START ---");
                writer.WriteLine($"Title: {note.Title}");
                writer.WriteLine($"Date: {note.CreatedAt}");
                writer.WriteLine($"Last update: {note.UpdatedAt}");
                writer.WriteLine("Content:");
                writer.WriteLine(note.Content);
                writer.WriteLine("--- NOTE END ---");
                writer.WriteLine(); 
            }

            Console.WriteLine("Notes saved to file.\n");
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No saved notes found. Starting with an empty list.\n");
                return;
            }

            notes.Clear();
            string[] lines = File.ReadAllLines(filePath);

            Note currentNote = null;
            string content = "";

            foreach (var line in lines)
            {
                if (line == "--- NOTE START ---")
                {
                    currentNote = new Note();
                    content = "";
                }
                else if (line.StartsWith("Title: "))
                {
                    currentNote.Title = line.Substring(7);
                }
                else if (line.StartsWith("Date: "))
                {
                    DateTime.TryParse(line.Substring(6), out DateTime date);
                    currentNote.CreatedAt = date;
                }
                else if (line.StartsWith("Last update: "))
                {
                    DateTime.TryParse(line.Substring(6), out DateTime date);
                    currentNote.UpdatedAt = date;
                }
                else if (line == "Content:")
                {
                    // skip header
                }
                else if (line == "--- NOTE END ---")
                {
                    currentNote.Content = content.TrimEnd();
                    notes.Add(currentNote);
                    currentNote = null;
                }
                else
                {
                    content += line + "\n";
                }
            }

            Console.WriteLine("Notes loaded from file.\n");
        }
    }
}
