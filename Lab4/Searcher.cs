using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Lab4
{
    [Serializable]
    public class Searcher
    {
        public string Dir { get; private set; }
        private List<TextFile> Files { get; set; } = new List<TextFile>();

        public Searcher(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new Exception("Not exist");
            }
            Dir = directory;
        }

        public void GetFile()
        {
            string[] names = Directory.GetFiles(Dir);
            foreach (string name in names)
            {
                Console.WriteLine(name); //ffg
            }
        }

        public void AddFile(string name)
        {
            name = Dir + "/" + name;

            if (!File.Exists(name))
            {
                throw new Exception("Not exist");
            }

            foreach(var file in Files)
            {
                if(file.Name == name)
                {
                    throw new Exception("Added");
                }
            }

            string[] tags = new string[2];
            Console.WriteLine($"Add tags for {name.Remove(0,Dir.Length + 1)}:");
            tags[0] = Console.ReadLine();
            tags[1] = Console.ReadLine();

            Files.Add(new TextFile(name, tags));

            Console.WriteLine("File added");
        }

        public void Search(string[] tags)
        {
            Console.WriteLine("found: ");
            var found = false;
            foreach(var file in Files)
            {
                if(file.Tags[0] == tags[0] || file.Tags[1] == tags[0] || file.Tags[0] == tags[1] || file.Tags[1] == tags[1])
                {
                    Console.WriteLine($"{file.Name.Remove(0, Dir.Length + 1)}");
                    found = true;
                }
            }

            if (!found)
            {
                throw new Exception("No files???");
            }
        }

        public void Serialize(FileStream file)
        {

            var formatter = new BinaryFormatter();
            formatter.Serialize(file, this);
            file.Close();
        }

        public void Deserialize(FileStream file)
        {

            var formatter = new BinaryFormatter();
            var deserialized = (Searcher)formatter.Deserialize(file);
            Files = deserialized.Files;
            file.Close();
        }
    }
}
