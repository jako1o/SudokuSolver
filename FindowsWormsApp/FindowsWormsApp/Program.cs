using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataGridViewSoduko
{
    public class MainForm : Form
    {
        private DataGridView dataGridView;
        private Button solveButton;
        private Button resetButton;

        public MainForm()
        {
            // Initialisierung der grafischen Komponenten
            InitializeComponents();
        }
        private void InitializeComponents()
        {
            this.Text = "Sudoku Solver"; // Fenstername
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Verhindert Größenanpassung
            this.Size = new Size(550, 600); // Festgelegte Fenstergröße

            dataGridView = new DataGridView
            {
                ColumnCount = 9, // 9 Spalten für Sudoku
                RowHeadersVisible = false, // Keine Zeilenköpfe
                ColumnHeadersVisible = false, // Keine Spaltenköpfe
                AllowUserToAddRows = false, // Keine zusätzliche Zeile hinzufügen
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None, // Feste Spaltenbreite
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None, // Feste Zeilenhöhe
                ScrollBars = ScrollBars.None, // Scrollbars deaktivieren
                Size = new Size(453, 453), // Größe des Sudoku-Feldes
                Location = new Point(40, 50) // Position des Sudoku-Feldes
            };

            // Anpassung des Zellenstils
            dataGridView.DefaultCellStyle.Font = new Font("Arial", 20, FontStyle.Bold); // Schrift fett und größer
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Zentriert
            dataGridView.DefaultCellStyle.BackColor = Color.White; // Hintergrundfarbe
            dataGridView.DefaultCellStyle.ForeColor = Color.DarkRed; // Schriftfarbe

            // 3x3-Gitterlinien
            dataGridView.CellPainting += DrawSudokuGrid;

            // Festlegung der Spalten- und Zeilenhöhe
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.Width = 50; // Feste Spaltenbreite
            }

            for (int i = 0; i < 9; i++)
            {
                dataGridView.Rows.Add(); // Hinzufügen der Zeilen
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Height = 50; // Feste Zeilenhöhe
            }

            // Konfiguration des "Lösen"-Buttons
            solveButton = new Button
            {
                Text = "Lösen", // Beschriftung des Buttons
                Location = new Point(90, 520), // Position
                Size = new Size(100, 30) // Buttongröße
            };
            solveButton.Click += SolveButton_Click; // Event-Handler für Klick

            // Konfiguration des "Reset"-Buttons
            resetButton = new Button
            {
                Text = "Reset", // Beschriftung des Buttons
                Location = new Point(340, 520), // Position
                Size = new Size(100, 30) // Buttongröße
            };
            resetButton.Click += ResetButton_Click; // Event-Handler für Klick

            // Hinzufügen der Komponenten zum Formular
            this.Controls.Add(dataGridView);
            this.Controls.Add(solveButton);
            this.Controls.Add(resetButton);
        }

        private void DrawSudokuGrid(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                using (Pen pen = new Pen(Color.Black, 2)) // Dicke der Gitterlinien
                {
                    // Vertikale Linien an jeder dritten Spalte
                    if (e.ColumnIndex % 3 == 2 && e.ColumnIndex != 8)
                    {
                        e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    }

                    // Horizontale Linien an jeder dritten Zeile
                    if (e.RowIndex % 3 == 2 && e.RowIndex != 8)
                    {
                        e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }
                }
            }

            e.Handled = true; // Verhindert Standardzeichnen
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = ""; // Löscht den Inhalt der Zelle
                }
            }
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            int[,] sudokuGrid = new int[9, 9]; // 2D-Array für Sudoku-Daten

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    // Validiert die Zelle und speichert ihre Werte im Array
                    if (dataGridView.Rows[row].Cells[col].Value != null &&
                        int.TryParse(dataGridView.Rows[row].Cells[col].Value.ToString(), out int number))
                    {
                        sudokuGrid[row, col] = number;
                    }
                    else
                    {
                        sudokuGrid[row, col] = 0; // Ungültige oder leere Werte auf 0 setzen
                    }
                }
            }

            // Informationen an den Benutzer ausgeben
            MessageBox.Show("Sudoku-Daten wurden gespeichert!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles(); // Aktiviert visuelle Stile
            Application.Run(new MainForm()); // Startet das Hauptformular
        }
    }
}