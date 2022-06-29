using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Caretaker
    {
        private List<Memento> _mementos = new List<Memento>();
        private TextFile _originator = null;

        public Caretaker(TextFile originator)
        {
            this._originator = originator;
        }

        public void Backup()
        {
            this._mementos.Add(this._originator.Save());
        }

        public void Undo()
        {
            if (_mementos.Count == 0)
                return;

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);
            try
            {
                this._originator.Back(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
        }
    }
}
