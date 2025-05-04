using FindowsWormsApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FindowsWormsApp.Enums;

namespace FindowsWormsApp.Helpers
{
    public static class GridHelper
    {
        public static uint[,] GetInputGrid(DataGridView dgv)  //Methode um Array aus Datagridview einzulesen
        {
            uint[,] inputGrid = new uint[9, 9]; // 2D-Array für Sudoku-Daten

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    // Validiert die Zelle und speichert ihre Werte im Array
                    if (dgv.Rows[row].Cells[col].Value != null &&
                       uint.TryParse(dgv.Rows[row].Cells[col].Value.ToString(), out uint number))
                    {
                        inputGrid[row, col] = number;
                    }
                    else
                    {
                        inputGrid[row, col] = 0; // Ungültige oder leere Werte auf 0 setzen
                    }
                }
            }
            return inputGrid;
        }

        public static SudokuGrid? SolveGrid(uint[,] grid)   //Methode um Solver zu instanzieren und Eingaben zu übergeben
        {
            SudokuGrid ToSolveGrid = new SudokuGrid();
            ErrorCode result = ToSolveGrid.CreateGrid(grid);

            if (result == ErrorCode.InputValid) //Solve Prozess läuft nur wenn Eingabe gültig
            {
                SudokuSolver Solver = new SudokuSolver(ToSolveGrid);

                if (Solver.Solve())
                {
                    return ToSolveGrid.GetGridObject();
                    
                }
                {
                    MessageBox.Show("Keine Lösung gefunden");
                    return null;
                }

            }
            else if (result == ErrorCode.Size)
            {
                MessageBox.Show("Die Eingabe entspricht nicht der geforderten Größe(9x9)");
                return null;
            }
            else if (result == ErrorCode.Empty)
            {
                MessageBox.Show("Die Eingegebene Raster enthält keine Werte");
                return null;
            }
            else if (result == ErrorCode.NumbersInvalid)
            {
                MessageBox.Show("Die Eingabe enthält unzulässige Zahlen (nur 1-9)");
                return null;
            }
            else if (result == ErrorCode.InputInvalid)
            {  
                return null; 
            }
            else
            {
                MessageBox.Show("Unbekannter Fehler");
                return null;
            }
        }

        public static void LoadArrayToGrid(DataGridView dgv, uint[,] array)  //Methode um datagrid zu beschreiben
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    dgv.Rows[row].Cells[col].Value = array[row, col] == 0 ? "" : array[row, col].ToString();
                }
            }
        }

        public static void ResetGrid(DataGridView dgv) //Reset für Eingabemaske
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = "";
                }
            }

            // Durchlaufe alle Zellen im DataGridView und setze die Hintergrundfarbe auf Weiß
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    dgv.Rows[row].Cells[col].Style.BackColor = Color.White;
                    dgv.Rows[row].Cells[col].Style.ForeColor = Color.Black;
                }
            }

        }

        public static uint[,] CopyGrid(uint[,] source) //Methode um Grid zu kopieren, da sonst immer die Referenz übergeben wird
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

        public static void LoadExampleSudoku(DataGridView dgv)
        {
            ResetGrid(dgv);
            //Zufälliges wählen aus Liste
            Random rand = new Random();
            int randomIndex = rand.Next(SudokuTestData.Examples.Count);

            uint[,] selectedSudoku = SudokuTestData.Examples[randomIndex];

            LoadArrayToGrid(dgv, selectedSudoku); //ZUfällis Sudoku ins Grid laden

        }
    }
}
