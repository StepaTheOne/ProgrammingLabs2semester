using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public interface IMemento
    {
        string GetBack();
    }
    public class Memento:IMemento
    {
        private string _content;
        public Memento(string content)
        {
            _content = content;
        }
        public string GetBack()
        {
            return this._content;
        }
    }
}
