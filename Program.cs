using System;


namespace ConsoleNotepad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var notes = new Notepad();
            var storage = new StorageService("createdNotes.json");
            var notes = storage.Load<Notepad>();



            while (true)
                {
                    Console.WriteLine("==========================================================================================");
                    Console.WriteLine("Witaj \n\n1. stworz notatke\n2. usun notatke\n3. edytuj nazwe notatki\n4. edytuj tresc notatki\n5. Wyswietl notes");
                    string inputStr = Console.ReadLine();

                    if (!int.TryParse(inputStr, out int inputInt))
                    {
                        Console.WriteLine("Podaj liczbe!");
                        continue;
                    }


                    switch (inputInt)
                    {
                        case 1:
                            Console.WriteLine("Podaj Nazwę notatki.");
                            string name = Console.ReadLine();
                            string noteText = NoteMode();
                            int noteId = notes.AddNote(name, noteText);
                            storage.Save(notes);
                            Console.WriteLine($"Pomyslnie stworzono notatke ID --> {noteId}");
                            break;

                        case 2:
                            int noteId2 = AskAndCheckId("Podaj ID notatki", notes);
                            notes.RemoveNote(noteId2);
                            Console.WriteLine($"Pomyslnie usunięto notatke ID --> {noteId2}");
                            storage.Save(notes);
                            break;

                        case 3:
                            int id2 = AskAndCheckId("Podaj id notatki.", notes);
                            Console.WriteLine("Podaj nową nazwe notatki.");
                            string newName = Console.ReadLine();
                            notes.EditNoteName(id2, newName);
                            storage.Save(notes);
                            Console.WriteLine($"Pomyslnie zmieniono nazwe notatce [{id2}] na [{newName}]");
                            break;

                        case 4:
                            int id3 = AskAndCheckId("Podaj id notatki.", notes);
                            string newContent = NoteMode();
                            notes.EditNoteContent(id3, newContent);
                            storage.Save(notes);
                            Console.WriteLine($"Pomyslnie zmieniono tresc notatce [{id3}]");
                            break;

                        case 5:
                            if (notes.GetNoteCount() == 0)
                            {
                                Console.WriteLine("Brak notatek do otworzenia.");
                                break;
                            }
                            notes.PrintNotepad();
                            Console.WriteLine();
                            int noteChoice = AskAndCheckId("Podaj ID notatki do otworzenia.", notes);
                            notes.OpenNote(noteChoice);
                            Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("Podaj liczbe z zakresu 1-5!");
                            break;


                    }
                }
        }

        static int AskAndCheckId(string text, Notepad notepad)
        {
            while (true)
            {
                Console.WriteLine(text);
                string id = Console.ReadLine();
                if (int.TryParse(id, out int intId))
                {
                    if (notepad.DoesIdExist(intId))
                    {
                        return intId;
                    }

                    Console.WriteLine($"Notatka o ID {id} nie istnieje.");
                }
                else
                {
                    Console.WriteLine("Podaj liczbe!");
                }
            }
        }

        static string NoteMode()
        {
            Console.Clear();
            Console.WriteLine("\t\tAby zatwierdzic notatke wpisz w linijce samo end/");
            string noteCollected = $"";
            bool firstLine = true;

            while (true)
            {
                string newLine = Console.ReadLine();
                if (newLine == "end/")
                {
                    if (noteCollected == "")
                    {
                        return "PUSTA NOTATKA.";
                    }
                    else
                    {
                        return noteCollected;
                    }
                }
                if (firstLine)
                {
                    noteCollected += newLine;
                    firstLine = false;
                }
                else noteCollected += "\n" + newLine;
            }
        }
    }
}


