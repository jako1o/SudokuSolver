namespace SudokuSolverGUI
{
    public partial class Form1 : Form
    {
        private DataGridView dgvSudoku = new DataGridView();
        private Button btnSolve = new Button();
        private Button btnReset = new Button();

        public Form1()
        {
            InitializeComponent();
            CreateSudokuGrid();
            CreateButtons();
        }

        private void CreateSudokuGrid()
        {
            int cellSize = 50; // Einheitliche Zellengröße
            int gridSize = 9; // Sudoku 9x9

            dgvSudoku.ColumnCount = gridSize;
            dgvSudoku.RowCount = gridSize;
            dgvSudoku.Width = cellSize * gridSize + 3;
            dgvSudoku.Height = cellSize * gridSize + 3;
            dgvSudoku.Top = 10;
            dgvSudoku.Left = 10;

            dgvSudoku.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSudoku.DefaultCellStyle.Font = new Font("Arial", 18, FontStyle.Bold);
            dgvSudoku.RowHeadersVisible = false;
            dgvSudoku.ColumnHeadersVisible = false;
            dgvSudoku.AllowUserToAddRows = false;
            dgvSudoku.AllowUserToResizeColumns = false;
            dgvSudoku.AllowUserToResizeRows = false;
            dgvSudoku.MultiSelect = false;
            dgvSudoku.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // Feste Spaltenbreite und Zeilenhöhe setzen
            foreach (DataGridViewColumn col in dgvSudoku.Columns)
            {
                col.Width = cellSize;
            }
            foreach (DataGridViewRow row in dgvSudoku.Rows)
            {
                row.Height = cellSize;
            }

            // Hintergrundfarben für Blöcke
            //for (int i = 0; i < gridSize; i++)
            //{
            //    for (int j = 0; j < gridSize; j++)
            //    {
            //        if ((i / 3 + j / 3) % 2 == 0)
            //        {
            //            dgvSudoku.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
            //        }
            //    }
            //}

            this.Controls.Add(dgvSudoku);
        }

        private void CreateButtons()
        {
            btnSolve.Text = "Lösen";
            btnSolve.Width = 100;
            btnSolve.Height = 40;
            btnSolve.Top = dgvSudoku.Bottom + 10;
            btnSolve.Left = dgvSudoku.Left;
            btnSolve.Click += (s, e) => { MessageBox.Show("Lösung berechnen!"); };

            btnReset.Text = "Zurücksetzen";
            btnReset.Width = 100;
            btnReset.Height = 40;
            btnReset.Top = dgvSudoku.Bottom + 10;
            btnReset.Left = btnSolve.Right + 10;
            btnReset.Click += (s, e) => { MessageBox.Show("Sudoku zurücksetzen!"); };

            this.Controls.Add(btnSolve);
            this.Controls.Add(btnReset);
        }
    }

}
