
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SudokuSolverForms.Enums;

namespace SudokuSolverForms.Logic
{
    public  class SudokuGrid
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


        public ErrorCode CreateGrid(uint[,] gr)  //Neues Grid erzeugen Methode
        {
            //Überprüfen, ob eingegebenes Array die richtige Größe hat
            if (gr.GetLength(0) != 9 || gr.GetLength(1) != 9)
            {
                // Console.WriteLine("Das eingegebene Raster hat nicht die erforderliche Größe (9x9).");
                grid = new uint[9, 9]; // Rückgabe eines leeren 9x9-Arrays
                return ErrorCode.Size;
            }

            //Zahlen auf Gültigkeit prüfen (0-9 erlaubt)
            for (int i = 0; i < gr.GetLength(0); i++)
            {
                for (int j = 0; j < gr.GetLength(1); j++)
                {
                    if (gr[i, j] > 9)
                    {
                        // Console.WriteLine("Das eingegebene Raster enthält ungültige Zahlen.");
                        grid = new uint[9, 9]; //Rückgabe eines leeren 9x9-Arrays
                        return ErrorCode.NumbersInvalid;
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
            if (empty) return ErrorCode.Empty;

            if (!IsValidSudoku(gr)) return ErrorCode.InputInvalid;



            //Console.WriteLine("Ein neues Raster wurde erfolgreich erstellt.");
            grid = gr; //Neues Raster in Klassenvariable schreiben



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

            return ErrorCode.InputValid; //Gibt true zurück wenn erstellen erfolgreich
        }


        public uint[,] GetGrid() //Getter um von Solve drauf zuzugreifen
        {
            return grid;
        }

        public uint[,] GetOriginalGrid() //Getter um auf Originalzustand zuzugreifen
        {
            return originalGrid;
        }

        public bool[,] GetGivenStatus()
        {
            return isGiven;
        }
        private bool IsValidSudoku(uint[,] grid) //Methode überprüft mittels hash set ob eingabe gegen die Regeln verstößt
        {
            HashSet<uint> seen = new HashSet<uint>();

            // Überprüfe Zeilen
            for (int row = 0; row < 9; row++)
            {
                seen.Clear(); // Setze das HashSet zurück für jede Zeile
                for (int col = 0; col < 9; col++)
                {
                    uint num = grid[row, col];
                    if (num != 0) // Nur auf nicht leere Felder prüfen
                    {
                        if (!seen.Add(num)) // Wenn die Zahl nicht hinzugefügt werden kann, ist es ein Duplikat
                        {
                            MessageBox.Show($"Fehler in Zeile {row + 1}, Spalte {col + 1}. Duplikatwert: {num}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }

            // Überprüfe Spalten
            for (int col = 0; col < 9; col++)
            {
                seen.Clear();
                for (int row = 0; row < 9; row++)
                {
                    uint num = grid[row, col];
                    if (num != 0)
                    {
                        if (!seen.Add(num))
                        {
                            MessageBox.Show($"Fehler in Zeile {row + 1}, Spalte {col + 1}. Duplikatwert: {num}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }

            // Überprüfe 3x3 Blöcke
            for (int blockRow = 0; blockRow < 3; blockRow++)
            {
                for (int blockCol = 0; blockCol < 3; blockCol++)
                {
                    seen.Clear();
                    for (int row = blockRow * 3; row < (blockRow + 1) * 3; row++)
                    {
                        for (int col = blockCol * 3; col < (blockCol + 1) * 3; col++)
                        {
                            uint num = grid[row, col];
                            if (num != 0)
                            {
                                if (!seen.Add(num))
                                {
                                    MessageBox.Show($"Fehler im Block {blockRow + 1},{blockCol + 1} bei Zeile {row + 1}, Spalte {col + 1}. Duplikatwert: {num}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true; // Keine Duplikate gefunden

        }

        public SudokuGrid GetGridObject()
        {
            return this;
        }
    }
}