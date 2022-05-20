using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLabs
{
    class Task1_2
    {
        public string ChangeSecondChar()
        {
            string FirstNumber = Console.ReadLine();
            char CharToMove;
            CharToMove = FirstNumber[1];
            int StartIndexToRemove = 1;
            int HowManyCharsToRemove = 1;
            FirstNumber = FirstNumber.Remove(StartIndexToRemove, HowManyCharsToRemove);
            FirstNumber = FirstNumber.Insert(FirstNumber.Length, CharToMove.ToString());
            return FirstNumber;
        }
    }
}
