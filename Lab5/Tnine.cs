using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace Lab5
{
    [Serializable]
    public class Tnine
    {
        private Dictionary<string,List<string>> Dict { get; set; } = new Dictionary<string, List<string>>();
        private List<string> AddMiss(List<string> miss)
        {
            string word;
            Console.WriteLine("add misswords, enter exitplease to stop: ");
            while (true)
            {
                word = Console.ReadLine();
                if(word == "exitplease")
                {
                    break;
                }
                miss.Add(word);
            }
            return miss;
        }
        private void AddWord()
        {
            Console.Write("Enter word: ");
            var word = Console.ReadLine();
            if (Dict.ContainsKey(word))
            {
                throw new Exception("Wtf bro, we already have this one...");
            }

            var miss = new List<string>();
            Dict.Add(word, miss);
            Dict[word] = AddMiss(Dict[word]);
            Console.WriteLine("Added.");
        }

        private string T9Word(string word)
        {
            foreach(var newWord in Dict)
            {
                foreach(var miss in newWord.Value)
                {
                    if(word == miss)
                    {
                        word = newWord.Key;
                        return word;
                    }
                }
            }
            return word;
        }
        private string T9Line(string Line)
        {
            var words = Line.Split();
            var result = "";
            foreach(var word in words)
            {
                result += $"{T9Word(word)} ";
            }
            result = $"{result}\n";
            return result;
        }
        private void T9Text(string name)
        {
            var result = "";
            using (var file = new StreamReader(name))
            {
                var orig = "";
                while (!file.EndOfStream)
                {
                    orig = file.ReadLine();
                    result += T9Line(orig);
                }
            }
            using(var file = new StreamWriter(name))
            {
                file.WriteLine(result);
                file.Flush();
            }
            Console.WriteLine("Ended");
            Console.ReadKey();
        }
        private string T9NumLine(string Line)
        {
            string result = "";
            string Number = "";
            var RegexFind = new Regex(@"([(]\d{3}[)]\s{1}\d{3})-(\d{2})-(\d{2})");
            var ReplaceDash = new Regex(@"-");
            var ReplaceBracket1 = new Regex(@"[(]");
            var ReplaceBracket2 = new Regex(@"[)]");

            var Matches = RegexFind.Matches(Line);
            if (Matches.Count > 0)
            {
                foreach (Match Match in Matches)
                {
                    Number = Match.Value;
                    Number = ReplaceDash.Replace(Number, " ");
                    Number = ReplaceBracket1.Replace(Number, "");
                    Number = ReplaceBracket2.Replace(Number, "");
                    Number = $"+380 {Number.Substring(1)}";

                    Line = Line.Replace(Match.Value, Number);
                }
            }
            result = $"{Line}\n";
            return result;
        }

        private void T9Number(string name)
        {
            var result = "";
            using (var file = new StreamReader(name))
            {
                var orig = "";
                while (!file.EndOfStream)
                {
                    orig = file.ReadLine();
                    result += T9NumLine(orig);
                }
            }
            using (var file = new StreamWriter(name))
            {
                file.WriteLine(result);
                file.Flush();
            }
            Console.WriteLine("Ended");
            Console.ReadKey();
        }

        private void Serialize(FileStream File)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(File, this);
            File.Close();
        }

        private void Deserialize(FileStream File)
        {
            var formatter = new BinaryFormatter();
            var deserialized = (Tnine)formatter.Deserialize(File);
            Dict = deserialized.Dict;
            File.Close();
        }

        public void Start()
        {
            string dir, name, path;
            while (true)
            {
                Console.Write("No Directory???: ");
                dir = Console.ReadLine();
                Console.Write("No Name????: ");
                name = Console.ReadLine();

                path = dir + "/" + name;

                if (File.Exists(path))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("No File ?????? Bruh :/\nTry again");
                }
            }

            var file = new FileStream($"{dir}/dict.bin", FileMode.OpenOrCreate, FileAccess.Read);
            if(file.Length != 0)
            {
                Deserialize(file);
            }
            file.Close();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Add word in dict - 1");
                Console.WriteLine("T9 text - 2");
                Console.WriteLine("T9 number - 3");
                Console.WriteLine("Exit - 0");

                switch (Console.ReadLine())
                {
                    case "0":
                        return;
                    case "1":
                        Console.Clear();
                        try
                        {
                            AddWord();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                            break;
                        }
                        file = new FileStream($"{dir}/dict.bin", FileMode.Open, FileAccess.Write);
                        Serialize(file);
                        file.Close();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        T9Text(path);
                        break;
                    case "3":
                        T9Number(path);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
