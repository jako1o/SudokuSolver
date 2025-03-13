using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver;

public class GameController
{
    private SudokuGrid grid;
    private MainForm form;

    public GameController(SudokuGrid grid, MainForm form)
    {
        this.grid = grid;
        this.form = form;
    }

    public void LoadFromUI()
    {
        grid.SetBoard(form.GetGridInput());
    }

    public void SolveSudoku(object sender, EventArgs e)
    {
        if (grid.Solve())
        {
            form.DisplaySolution(grid.GetBoard());
            MessageBox.Show("Sudoku gelöst!");
        }
        else
        {
            MessageBox.Show("Keine Lösung gefunden!");
        }
    }
}