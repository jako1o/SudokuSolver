using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverConsole
{
    internal class SudokuGrid
    {

        //Attribute
        protected uint[][] grid;
        //Konstruktoren

        //Methoden

        protected uint[][] CreateGrid(uint[][] gr)
        {
            //Überprüfen, ob eingegebenes Array valid ist.


            //Array Dimensionen
            bool LenghtValid;

            if (gr.GetLength(0) == 9 && gr.GetLength(1) == 9)
            {
                LenghtValid = true;
            }
            else
            {
                LenghtValid = false;
            }

            //Zahlen zwischen 1 und 9
            bool NumbersValid;

        }

    }
}
