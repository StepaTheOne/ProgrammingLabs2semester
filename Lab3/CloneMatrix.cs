using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class CloneMatrix:SquareMatrix,ICloneable
    {
        public object Clone()
        {
            var clone = new SquareMatrix(Size);
            clone.Matrix = this.Matrix;

            return clone;
        }
    }
}
