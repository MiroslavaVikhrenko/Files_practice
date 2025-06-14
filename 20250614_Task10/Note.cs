using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250614_Task10
{
    public class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"Title: {Title}\nDate: {CreatedAt}\nContent:\n{Content}\n Last update: {ModifiedAt}";
        }
    }
}
