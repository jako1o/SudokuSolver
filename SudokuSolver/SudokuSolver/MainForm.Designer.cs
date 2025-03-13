namespace SudokuSolver
{
    partial class MainForm
    {
        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 9;
            tableLayoutPanel1.ColumnStyles.Clear();
            for (int i = 0; i < 9; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.11F));
            }

            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Clear();
            for (int i = 0; i < 9; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11F));
            }

            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 0); // Zelle 0,0 für DataGridView
            tableLayoutPanel1.Location = new Point(90, 58);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Size = new Size(540, 450); // Die Größe für das Layout anpassen
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(534, 444); // Die Größe des DataGridView anpassen
            dataGridView1.TabIndex = 0;

            // 9x9 Zellen für Sudoku-Raster hinzufügen
            for (int i = 0; i < 9; i++)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            }

            for (int i = 0; i < 9; i++)
            {
                dataGridView1.Rows.Add();
            }

            // Zellenhöhe und -breite anpassen
            for (int i = 0; i < 9; i++)
            {
                dataGridView1.Columns[i].Width = 60;
                dataGridView1.Rows[i].Height = 60;
            }

            // Event-Handler hinzufügen
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "SudokuSolver";
            Load += this.MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #region Designer-Variablen

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView1;

        #endregion
    }
}

