using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverConsole
{
    internal class SudokuSolver
    {
        //Attribute
        private SudokuGrid SudokuGrid; //Verwende die Klasse SudokuGrid
        private bool isSolved; //Speichert Ergebnis

        //Konstrukor

        public SudokuSolver(SudokuGrid grid)
        {
            SudokuGrid = grid; // Speichert die Instanz des SudokuGrid
            isSolved = false;
        }

        //Methoden

        public bool Solve()
        {

            var grid = SudokuGrid.GetGrid();//Aktuelles Grid aufrufen

            //Erstes leeres Feld finden
            var emptyPos = FindEmptyPosition();

            //Kein leeres Feld, ture zurückgeben -> Sudoku gelöst
            if (emptyPos == null)
            {
                isSolved = true;
                return true;
            }

            uint row = emptyPos.Value.Item1; //erste Variable vom Tuple
            uint col = emptyPos.Value.Item2; //zweite...

            for (uint num = 1; num <= 9; num++) //Probiere Zahlen von 1 bis 9
            {
                if (IsValid(row, col, num))
                {
                    grid[row, col] = num;

                    //Rekursiver Aufruf, Methode ruft sich selbst auf und läuft nochmal durch, ist komplett verschickt :)
                    if (Solve()) return true;

                    grid[row, col] = 0; //Backtracking, Zahl wird auf 0 zurückgesetzt, wenn vorher nicht im rekursiven Aufruf true kam, also keine Lösung gefunden wurde

                }
            }

            isSolved = false;
            return false; //keine Lösung gefunden

        }

        private (uint, uint)? FindEmptyPosition()  //Leeres Feld finden, gibt entweder Koordinaten als Tuple oder null zurück
        {
            var grid = SudokuGrid.GetGrid();

            for (uint i = 0; i < 9; i++)
            {
                for (uint j = 0; j < 9; j++)
                {
                    if (grid[i, j] == 0) return (i, j);

                }
            }
            return null; //Gibt null zurück,wenn keine leere Stelle gefunden wurde

        }

        private bool IsValid(uint row, uint col, uint num)     //Überprüfe, ob das Setzen einer Zahl (num) an (row, col) gültig ist
        {
            var grid = SudokuGrid.GetGrid();

            // Überprüfe die Zeile
            for (int i = 0; i < 9; i++)
            {
                if (grid[row, i] == num) return false;
            }

            // Überprüfe die Spalte
            for (int i = 0; i < 9; i++)
            {
                if (grid[i, col] == num) return false;
            }

            // Bestimme den Startpunkt des 3x3-Blocks (wird ganzzahlig geteilt)
            uint startRow = row / 3 * 3;
            uint startCol = col / 3 * 3;

            // Durchlaufe alle Zellen im 3x3-Block
            for (uint i = startRow; i < startRow + 3; i++)
            {
                for (uint j = startCol; j < startCol + 3; j++)
                {
                    if (grid[i, j] == num) return false;
                }
            }



            return true; //Gib true aus, wenn kein Fehler gefunden wurde
        }

        

    }
}
