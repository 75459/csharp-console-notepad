using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNotepad;

internal class Notepad
{
    public int LatestNoteId { get; set; }

    public Dictionary<int, Note> NoteList { get; set; } = new Dictionary<int, Note>();

    public int AddNote(string name, string desc)
    {
        LatestNoteId++;
        NoteList.Add(LatestNoteId, new Note(name, desc));
        return LatestNoteId;
    }

    public void RemoveNote(int id)
    {
        NoteList.Remove(id);
    }

    public void EditNoteContent(int id, string NewContent)
    {
        Note NoteObj = NoteList[id];
        NoteObj.Content = NewContent;
    }

    public void EditNoteName(int id, string NewName)
    {
        Note NoteObj = NoteList[id];
        NoteObj.Name = NewName;
    }

    public void PrintNotepad()
    {
        Console.WriteLine("==========================================================================================");
        Console.WriteLine("\tNOTES:");
        Console.WriteLine();
        foreach (var i in NoteList)
        {
            Console.WriteLine($"{i.Key} - {i.Value.Name}");
        }
    }

    public bool DoesIdExist(int id)
    {
        return NoteList.ContainsKey(id);
    }

    public int GetNoteCount()
    {
        return NoteList.Count;
    }

    public void OpenNote(int id)
    {
        Note NoteObj = NoteList[id];
        Console.Clear();
        Console.WriteLine($"\tNotatka: {NoteObj.Name} [{id}]      (wcisnij dowolny przycisk, aby wyjsc.) ");
        Console.WriteLine();
        Console.WriteLine(NoteObj.Content);
    }
}

