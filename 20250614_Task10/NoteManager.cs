using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _20250614_Task10
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
                Console.WriteLine("\n-----------------\n");
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
                note.ModifiedAt = DateTime.Now;
                Console.WriteLine("Note updated.\n");
            }
            else
            {
                Console.WriteLine("Note not found.\n");
            }
        }

        public void SaveToFile(string filePath)
        {
            var json = JsonSerializer.Serialize(notes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine("Notes saved.\n");
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                notes = JsonSerializer.Deserialize<List<Note>>(json) ?? new List<Note>();
                Console.WriteLine("Notes loaded.\n");
            }
            else
            {
                Console.WriteLine("No saved notes found.\n");
            }
        }
    }
}
