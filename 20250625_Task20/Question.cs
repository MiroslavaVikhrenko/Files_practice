using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250625_Task20
{
    public class Question
    {
        public string Text;
        public string[] Options;
        public int CorrectOptionIndex;

        public Question(string text, string[] options, int correctOption)
        {
            Text = text;
            Options = options;
            CorrectOptionIndex = correctOption;
        }
    }
}
