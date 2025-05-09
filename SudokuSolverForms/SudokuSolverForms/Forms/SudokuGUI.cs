using System;
using System.Drawing;
using System.Windows.Forms;
using SudokuSolverForms.Logic;
using SudokuSolverForms.Helpers;


namespace SudokuSolverForms.Forms
{
    public class SudokuGUI : Form
    {
        private DataGridView? dataGridView = null;
        private Button? solveButton;
        private Button? resetButton;
        private Button? loadExampleButton;
       


        public SudokuGUI()
        {
            // Initialisierung der grafischen Komponenten
            InitializeComponents();
        }
        private void InitializeComponents()
        {
            Text = "Sudoku Solver"; // Fenstername
            FormBorderStyle = FormBorderStyle.FixedDialog; // Verhindert Gr��enanpassung
            Size = new Size(550, 600); // Festgelegte Fenstergr��e

            
            dataGridView = new DataGridView
            {
                ColumnCount = 9,
                RowHeadersVisible = false,
                ColumnHeadersVisible = false,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None,
                ScrollBars = ScrollBars.None,
                Size = new Size(453, 453),
                Location = new Point(40, 50),
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                RowTemplate = { Height = 50 }
            };

            // Spaltenbreite fix setzen
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.Width = 50;
            }

           


            // Anpassung des Zellenstils
            dataGridView.DefaultCellStyle.Font = new Font("Arial", 20, FontStyle.Bold); // Schrift fett und gr��er
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Zentriert
            dataGridView.DefaultCellStyle.BackColor = Color.White; // Hintergrundfarbe
            dataGridView.DefaultCellStyle.ForeColor = Color.DarkRed; // Schriftfarbe

           

            // 3x3-Gitterlinien
            dataGridView.CellPainting += DrawSudokuGrid;

            // Festlegung der Spalten- und Zeilenh�he
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.Width = 50; // Feste Spaltenbreite
            }

            for (uint i = 0; i < 9; i++)
            {
                dataGridView.Rows.Add(); // Hinzuf�gen der Zeilen
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Height = 50; // Feste Zeilenh�he
            }

            // Konfiguration des "L�sen"-Buttons
            solveButton = new Button
            {
                Text = "L�sen", // Beschriftung des Buttons
                Location = new Point(90, 520), // Position
                Size = new Size(103, 30) // Buttongr��e
            };
            solveButton.Click += SolveButton_Click; // Event-Handler f�r Klick

            // Konfiguration des "Reset"-Buttons
            resetButton = new Button
            {
                Text = "Reset", // Beschriftung des Buttons
                Location = new Point(340, 520), // Position
                Size = new Size(100, 30) // Buttongr��e
            };
            resetButton.Click += ResetButton_Click; // Event-Handler f�r Klick

            // Konfiguration des "Beispiel laden"-Buttons
            loadExampleButton = new Button
            {
                Text = "Beispiel laden", // Beschriftung des Buttons
                Location = new Point(205, 520), // Position des Buttons
                Size = new Size(120, 30) // Gr��e des Buttons
            };
            loadExampleButton.Click += LoadExampleButton_Click; // Event-Handler f�r Klick

            // Hinzuf�gen der Komponenten zum Formular
            Controls.Add(dataGridView);
            Controls.Add(solveButton);
            Controls.Add(resetButton);
            Controls.Add(loadExampleButton);

           


        }

        private void DrawSudokuGrid(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                using (Pen pen = new Pen(Color.Black, 2)) // Dicke der Gitterlinien
                {
                    // Vertikale Linien an jeder dritten Spalte
                    if (e.ColumnIndex % 3 == 2 && e.ColumnIndex != 8)
                    {
                        e.Graphics!.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    }

                    // Horizontale Linien an jeder dritten Zeile
                    if (e.RowIndex % 3 == 2 && e.RowIndex != 8)
                    {
                        e.Graphics!.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }
                }
            }

            e.Handled = true; // Verhindert Standardzeichnen
        }

        private void ResetButton_Click(object? sender, EventArgs e)
        {
            GridHelper.ResetGrid(dataGridView!);
        }

        private void SolveButton_Click(object? sender, EventArgs e)
        {
            uint[,] inputGrid = GridHelper.GetInputGrid(dataGridView!); // Daten aus dem DataGrid einlesen
            uint[,] backupGrid = GridHelper.CopyGrid(inputGrid); // Grid kopieren, um es im Fehlerfall wiederherzustellen

            // Rufe SolveGrid auf und erhalte das SudokuGrid-Objekt zur�ck
            SudokuGrid solvedGrid = GridHelper.SolveGrid(inputGrid)!;

            if (solvedGrid == null)
            {
                // Wenn das Sudoku nicht gel�st werden konnte, lade das Backup zur�ck
                GridHelper.LoadArrayToGrid(dataGridView!, backupGrid);
            }
            else
            {
                // Lade die L�sung ins Grid
                GridHelper.LoadArrayToGrid(dataGridView!, solvedGrid.GetGrid());

                // F�rbe die Zellen basierend auf den gegebenen Zahlen ein
                HighlightGivenNumbers(solvedGrid); // �bergib das gel�ste SudokuGrid an die Highlight-Methode
            }
        }

        private void LoadExampleButton_Click(object? sender, EventArgs e)
        {
            // Hier wird der Code ausgef�hrt, um das Beispiel zu laden
            GridHelper.LoadExampleSudoku(dataGridView!); // Beispiel laden
        }


        private void HighlightGivenNumbers(SudokuGrid sudokuGrid)
        {
            bool[,] isGiven = sudokuGrid.GetGivenStatus(); // Hole das isGiven-Array von SudokuGrid

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    // Hole den Wert der Zelle sicher
                    object cellValue = dataGridView!.Rows[row].Cells[col].Value;
                    uint value = 0;

                    // Versuche den Wert der Zelle in uint zu konvertieren
                    if (cellValue != null && uint.TryParse(cellValue.ToString(), out value))
                    {
                        // Wenn die Zahl gegeben ist, markiere sie anders
                        if (isGiven[row, col])
                        {
                            dataGridView.Rows[row].Cells[col].Style.BackColor = Color.Gainsboro;  // Hintergrundfarbe f�r gegebene Zellen
                            dataGridView.Rows[row].Cells[col].Style.ForeColor = Color.Black;     // Schriftfarbe f�r gegebene Zellen
                        }
                        else
                        {
                            dataGridView.Rows[row].Cells[col].Style.BackColor = Color.White; // Hintergrundfarbe f�r gel�ste Zellen
                            dataGridView.Rows[row].Cells[col].Style.ForeColor = Color.Black;     // Schriftfarbe f�r gel�ste Zellen
                        }
                    }
                    else
                    {
                        // Falls der Wert nicht konvertierbar ist, setze die Zellenfarbe auf Wei� (oder eine andere Standardfarbe)
                        dataGridView.Rows[row].Cells[col].Style.BackColor = Color.White;
                        dataGridView.Rows[row].Cells[col].Style.ForeColor = Color.Black;
                    }
                }
            }
        }





        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles(); // Aktiviert visuelle Stile
            Application.Run(new SudokuGUI()); // Startet das Hauptformular
        }
    }
}