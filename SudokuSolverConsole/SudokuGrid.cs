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

        public SudokuGrid()
        {
            grid = new uint[9, 9];
        }


        //Methoden

        public void CreateGrid(uint[,] gr)                                //Neues Array erzeugen Methode
        {
            //Überprüfen, ob eingegebenes Array die richtige Größe hat
            if (gr.GetLength(0) != 9 || gr.GetLength(1) != 9)
            {
                Console.WriteLine("Das eingegebene Raster hat nicht die erforderliche Größe (9x9).");
                grid = new uint[9, 9]; // Rückgabe eines leeren 9x9-Arrays
            }

            //Zahlen auf Gültigkeit prüfen (0-9 erlaubt)
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (gr[i, j] > 9)
                    {
                        Console.WriteLine("Das eingegebene Raster enthält ungültige Zahlen.");
                        grid = new uint[9, 9]; //Rückgabe eines leeren 9x9-Arrays
                    }
                }
            }

            Console.WriteLine("Ein neues Raster wurde erfolgreich erstellt.");
            grid = gr; //Neues Raster in Klassenvariable schreiben
        }

        public void PrintGrid()
        {
            int size = grid.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("------+-------+------"); // Horizontale Trennlinie
                }

                for (int j = 0; j < size; j++)
                {
                    if (j % 3 == 0 && j != 0)
                    {
                        Console.Write("| "); // Vertikale Trennlinie
                    }

                    
                    if (grid[i, j] == 0)
                    {
                        Console.Write("  "); // Wenn das Feld 0 ist, gib nur ein Leerzeichen aus
                    }
                    else
                    {
                        Console.Write(grid[i, j] + " "); // Zahl ausgeben mit Leerzeichen
                    }
                }

                Console.WriteLine(); // Neue Zeile nach jeder Reihe
            }
        }

        public void PrintGridStraight()  //Gibt die Zahlen zum Test ob Inhalt da ist hintereinander aus
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(grid[i,j] + " , ");                    
                }
            }
            Console.WriteLine();
        }


    }
}
