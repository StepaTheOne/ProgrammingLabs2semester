using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    [Serializable]
    public class TextFile:IOriginator
    {
        public string Name { get; set; }
        public string[] Tags { get; set; } = new string[2];
        public string Content { get; set; }

        public TextFile(string name)
        {
            Name = name;
        }

        public TextFile(string name, string[] tags)
        {
            Name=name;
            Tags = tags;
        }

        public void SerializeBin(FileStream text)
        {
            var form = new BinaryFormatter();
            form.Serialize(text, this);
            text.Close();
        }
        public void DeserializeBin(FileStream text)
        {
            var form = new BinaryFormatter();
            var orig = (TextFile)form.Deserialize(text);
            Name = orig.Name;
            Tags = orig.Tags;
            text.Close();
        }

        public void XmlSerialize(FileStream text)
        {
            var form = new XmlSerializer(this.GetType());
            form.Serialize(text, this);
            text.Close();
        }
        public void XmlDeserialize(FileStream text)
        {
            var form =new XmlSerializer(this.GetType());
            var orig = (TextFile)form.Deserialize(text);
            Name =orig.Name;
            Tags=orig.Tags;
            text.Close();
        }

        public Memento Save()
        {
            return new Memento(this.Content);
        }

        public void Back(Memento mem)
        {
            if (!(mem is Memento))
            {
                throw new Exception("Wtf is that... " + mem.ToString());
            }

            this.Content = mem.GetBack();
        }
    }
}
