using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNotepad;
internal class Note
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public Note() { }
    public Note(string name, string content)
    {
        Name = name;
        Content = content;
    }
}
