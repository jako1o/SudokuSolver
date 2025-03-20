using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SudokuSolverConsole
{
    internal class SudokuGrid
    {

        //Attribute
        protected uint[,] grid;
        //Konstruktoren

        //Methoden

        protected uint[,] CreateGrid(uint[,] gr)
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


            //Zahlen gültig
            int rows = gr.GetLength(0);
            int cols = gr.GetLength(1);
            bool NumbersValid;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (gr[i, j] < 0 || gr[i, j] > 9)
                    {
                        NumbersValid = false; ; // Ungültige Zahl gefunden
                    }
                    else
                    {
                        NumbersValid = true; //Array gültig
                    }
                }
            }                       
        }
                   
            
      
    }
}
