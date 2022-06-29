using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4
{
    public static class Editor
    {
        private static Searcher CreateSearcher()
        {

            Searcher searcher;

            while (true)
            {

                Console.WriteLine("Enter directory:");
                var directory = Console.ReadLine();

                try
                {

                    searcher = new Searcher(directory);
                    break;
                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Try again.");
                    Console.WriteLine("\n");
                }
            }

            return searcher;
        }
        private static void FindFile(Searcher searcher)
        {

            Console.Clear();
            Console.WriteLine("Show all files in current directory     0");
            Console.WriteLine("Find file by tags                       1");
            Console.WriteLine("Add tags to files                       2");
            Console.WriteLine("EXIT                                    3");
            Console.WriteLine("\n");

            while (true)
            {

                Console.WriteLine("Choose option");

                switch (Console.ReadLine())
                {

                    case "0":
                        searcher.GetFile();
                        break;
                    case "1":

                        var fileS = new FileStream($"{searcher.Dir + "/search.bin"}", FileMode.OpenOrCreate, FileAccess.Read);
                        if (fileS.Length != 0)
                        {

                            searcher.Deserialize(fileS);
                            fileS.Close();
                        }
                        else
                        {

                            Console.WriteLine("No files found.");
                            fileS.Close();
                            break;
                        }

                        Console.WriteLine("Enter tags:");
                        string[] tags = new string[2];
                        tags[0] = Console.ReadLine();
                        tags[1] = Console.ReadLine();

                        try
                        {

                            searcher.Search(tags);
                            break;
                        }
                        catch (Exception exception)
                        {

                            Console.WriteLine(exception.Message);
                            break;
                        }
                    case "2":

                        var fileD = new FileStream($"{searcher.Dir + "/search.bin"}", FileMode.OpenOrCreate, FileAccess.Read);
                        if (fileD.Length != 0)
                        {

                            searcher.Deserialize(fileD);
                        }
                        fileD.Close();

                        Console.WriteLine("Enter file name:");
                        var name = Console.ReadLine();
                        try
                        {

                            searcher.AddFile(name);
                        }
                        catch (Exception exception)
                        {

                            Console.WriteLine(exception.Message);
                            break;
                        }

                        fileD = new FileStream($"{searcher.Dir + "/search.bin"}", FileMode.OpenOrCreate, FileAccess.Write);
                        searcher.Serialize(fileD);
                        fileD.Close();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Unknown option.");
                        break;
                }

                Console.WriteLine("\n");
            }
        }

        private static void EditorInterface(Searcher searcher)
        {

            Console.WriteLine("Enter file name:");
            var name = Console.ReadLine();
            name = searcher.Dir + "/" + name;

            if (!File.Exists(name))
            {

                var file = File.Create(name);
                file.Close();
            }

            Console.Clear();

            var textFile = new TextFile(name);
            var textR = new StreamReader(textFile.Name);
            textFile.Content = textR.ReadToEnd();
            Console.WriteLine(textFile.Content);
            textR.Close();

            using (var textW = new StreamWriter(textFile.Name, true))
            {

                var key = new ConsoleKeyInfo();
                var text = "";
                var caretaker = new Caretaker(textFile);

                while (true)
                {

                    caretaker.Backup();

                    text += Console.ReadLine();
                    textFile.Content += $"\n{text}";

                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Delete)
                    {

                        caretaker.Undo();
                        Console.Clear();
                        Console.WriteLine(textFile.Content);
                        text = "";
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {

                        textW.WriteLine(text);
                        textW.Flush();
                        Console.WriteLine("Editing finished.");
                        return;
                    }
                    else
                    {

                        textW.WriteLine(text);
                        textW.Flush();
                        text = key.Key.ToString().ToLower();
                    }
                }
            }
        }

        public static void Start()
        {
            Console.WriteLine("Text editor");
            Console.WriteLine();
            var searcher = CreateSearcher();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Search files     0");
                Console.WriteLine("Text editor      1");
                Console.WriteLine("EXIT             2");
                Console.WriteLine("\n");
                Console.WriteLine("Choose option");

                switch (Console.ReadLine())
                {

                    case "0":
                        Console.Clear();
                        FindFile(searcher);
                        break;
                    case "1":
                        Console.Clear();
                        EditorInterface(searcher);
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Unknown option.");
                        break;
                }
            }
        }
    }
}
