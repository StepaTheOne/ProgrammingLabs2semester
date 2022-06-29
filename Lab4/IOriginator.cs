using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public interface IOriginator
    {
        public Memento Save();

        public void Back(Memento mem);
    }
}
