using System;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class MainForm : Form
    {
        private SudokuGrid grid;
        private GameController controller;
        private TableLayoutPanel tableLayoutPanel;
        private TextBox[,] textBoxes = new TextBox[9, 9];

        public MainForm()
        {
            InitializeComponent();
            grid = new SudokuGrid();
            controller = new GameController(grid, this);
            InitializeSudokuGrid();
        }

        private void InitializeSudokuGrid()
        {
            tableLayoutPanel = new TableLayoutPanel
            {
                RowCount = 9,
                ColumnCount = 9,
                Width = 315,
                Height = 315,
                Left = 10,
                Top = 10,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    TextBox box = new TextBox
                    {
                        Width = 30,
                        Height = 30,
                        MaxLength = 1,
                        TextAlign = HorizontalAlignment.Center,
                        Dock = DockStyle.Fill
                    };
                    box.KeyPress += ValidateInput;
                    textBoxes[row, col] = box;
                    tableLayoutPanel.Controls.Add(box, col, row);
                }
            }

            Controls.Add(tableLayoutPanel);

            Button solveButton = new Button
            {
                Text = "Lösen",
                Left = 10,
                Top = 330,
                Width = 100
            };
            solveButton.Click += (sender, e) => controller.LoadFromUI();
            solveButton.Click += controller.SolveSudoku;
            Controls.Add(solveButton);
        }

        private void ValidateInput(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '1' && e.KeyChar <= '9') && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        public int[,] GetGridInput()
        {
            int[,] board = new int[9, 9];
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    board[row, col] = int.TryParse(textBoxes[row, col].Text, out int value) ? value : 0;
                }
            }
            return board;
        }

        public void DisplaySolution(int[,] solvedBoard)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    textBoxes[row, col].Text = solvedBoard[row, col] != 0 ? solvedBoard[row, col].ToString() : "";
                }
            }
        }
    }
}
