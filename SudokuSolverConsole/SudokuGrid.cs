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
        protected uint[,] grid; //Array mit dem gearbeitet wird
        protected uint[,] originalGrid; //Variable, um ursprünglichen Zustand zu speichern
        protected bool[,] isGiven; //Struktur, die speichert ob Zahl vorher schon gegeben war, um diese dann später rot auszugeben
       
        //Konstruktor
        public SudokuGrid()
        {
            grid = new uint[9, 9]; //leeres Grid initialisieren          
            isGiven = new bool[9, 9];
            originalGrid = new uint[9, 9];
        }


        //Methoden

        public bool CreateGrid(uint[,] gr)  //Neues Grid erzeugen Methode
        {
            //Überprüfen, ob eingegebenes Array die richtige Größe hat
            if (gr.GetLength(0) != 9 || gr.GetLength(1) != 9)
            {
                Console.WriteLine("Das eingegebene Raster hat nicht die erforderliche Größe (9x9).");
                grid = new uint[9, 9]; // Rückgabe eines leeren 9x9-Arrays
                return false;
            }

            //Zahlen auf Gültigkeit prüfen (0-9 erlaubt)
            for (int i = 0; i < gr.GetLength(0); i++)
            {
                for (int j = 0; j < gr.GetLength(1); j++)
                {
                    if (gr[i, j] > 9)
                    {
                        Console.WriteLine("Das eingegebene Raster enthält ungültige Zahlen.");
                        grid = new uint[9, 9]; //Rückgabe eines leeren 9x9-Arrays
                        return false;
                    }
                }
            }

            //Überprüfen, ob Eingabe leer ist.
            bool empty = true;
            foreach (var item in gr)
            {
                if (item != 0)
                {
                    empty = false;
                }               
            }
            if (empty) return false;



            Console.WriteLine("Ein neues Raster wurde erfolgreich erstellt.");
            grid = gr; //Neues Raster in Klassenvariable schreiben

            originalGrid = CopyGrid(grid); //nach dem erzeugen wird hier der Ursprungszustand gespeichert

            for (int i = 0; i < 9; i++) //Markiert gegebene Zahlen in der isGiven Struktur mit true
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] != 0)
                    {
                        isGiven[i, j] = true;  // Markiere als gegeben
                    }
                }
            }
            
            return true; //Gibt true zurück wenn erstellen erfolgreich
        }

        public void PrintGrid()  //Methode zur Augabe
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
                       
                        if (isGiven[i, j]) //Zahl rot
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // Farbe auf Rot setzen
                            Console.Write(grid[i, j] + " "); // Zahl ausgeben mit Leerzeichen
                            Console.ResetColor(); // Farbe zurücksetzen
                        }
                        else //Zahl schwarz
                        {
                            Console.Write(grid[i, j] + " ");
                        }

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

        public uint[,] GetGrid() //Getter um von Solve drauf zuzugreifen
        {
            return grid;
        }

        public uint[,] GetOriginalGrid() //Getter um auf Originalzustand zuzugreifen
        {
            return originalGrid;
        }

        private uint[,] CopyGrid(uint[,] source) //Methode um Grid zu kopieren, da sonst immer die Referenz übergeben wird
        {            
            uint[,] copy = new uint[source.GetLength(0), source.GetLength(1)];

            for (uint i = 0; i < source.GetLength(0); i++)
            {
                for (uint j = 0; j < source.GetLength(1); j++)
                {
                    copy[i, j] = source[i, j];
                }
            }

            return copy;
        }
    }
}
