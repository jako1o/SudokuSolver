using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
   
        public class SudokuGrid
        {
            private int[,] board = new int[9, 9];

            public void SetBoard(int[,] inputBoard)
            {
                board = inputBoard;
            }

            public int[,] GetBoard()
            {
                return board;
            }

            public bool Solve()
            {
                return Solve(0, 0);
            }

            private bool Solve(int row, int col)
            {
                if (row == 9) return true;
                if (col == 9) return Solve(row + 1, 0);
                if (board[row, col] != 0) return Solve(row, col + 1);

                for (int num = 1; num <= 9; num++)
                {
                    if (IsValid(row, col, num))
                    {
                        board[row, col] = num;
                        if (Solve(row, col + 1)) return true;
                        board[row, col] = 0;
                    }
                }
                return false;
            }

            private bool IsValid(int row, int col, int num)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (board[row, i] == num || board[i, col] == num) return false;
                }
                int boxRow = (row / 3) * 3;
                int boxCol = (col / 3) * 3;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[boxRow + i, boxCol + j] == num) return false;
                    }
                }
                return true;
            }
        }
    }
