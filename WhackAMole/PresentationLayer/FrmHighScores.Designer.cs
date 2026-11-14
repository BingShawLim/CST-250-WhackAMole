namespace WhackAMole.PresentationLayer
{
    partial class FrmHighScores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            lblTitle = new Label();
            dgvHighScores = new DataGridView();
            colRank = new DataGridViewTextBoxColumn();
            colPlayer = new DataGridViewTextBoxColumn();
            colScore = new DataGridViewTextBoxColumn();
            colLevel = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHighScores).BeginInit();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.SaddleBrown;
            lblTitle.Location = new Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(330, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Hall of Fame: Top 10";
            //
            // dgvHighScores
            //
            dgvHighScores.AllowUserToAddRows = false;
            dgvHighScores.AllowUserToDeleteRows = false;
            dgvHighScores.AllowUserToResizeRows = false;
            dgvHighScores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHighScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHighScores.BackgroundColor = Color.Honeydew;
            headerStyle.BackColor = Color.SaddleBrown;
            headerStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            headerStyle.ForeColor = Color.White;
            dgvHighScores.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvHighScores.ColumnHeadersHeight = 34;
            dgvHighScores.Columns.AddRange(new DataGridViewColumn[] { colRank, colPlayer, colScore, colLevel, colDate, colTime });
            dgvHighScores.EnableHeadersVisualStyles = false;
            dgvHighScores.Location = new Point(16, 60);
            dgvHighScores.MultiSelect = false;
            dgvHighScores.Name = "dgvHighScores";
            dgvHighScores.ReadOnly = true;
            dgvHighScores.RowHeadersVisible = false;
            dgvHighScores.RowHeadersWidth = 51;
            dgvHighScores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHighScores.Size = new Size(600, 330);
            dgvHighScores.TabIndex = 1;
            //
            // colRank
            //
            colRank.FillWeight = 40F;
            colRank.HeaderText = "Rank";
            colRank.Name = "colRank";
            colRank.ReadOnly = true;
            //
            // colPlayer
            //
            colPlayer.FillWeight = 120F;
            colPlayer.HeaderText = "Player";
            colPlayer.Name = "colPlayer";
            colPlayer.ReadOnly = true;
            //
            // colScore
            //
            colScore.FillWeight = 55F;
            colScore.HeaderText = "Score";
            colScore.Name = "colScore";
            colScore.ReadOnly = true;
            //
            // colLevel
            //
            colLevel.FillWeight = 50F;
            colLevel.HeaderText = "Level";
            colLevel.Name = "colLevel";
            colLevel.ReadOnly = true;
            //
            // colDate
            //
            colDate.FillWeight = 130F;
            colDate.HeaderText = "Date";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            //
            // colTime
            //
            colTime.FillWeight = 50F;
            colTime.HeaderText = "Time";
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            //
            // btnClose
            //
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.SaddleBrown;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(516, 402);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 36);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnCloseClickEH;
            //
            // FrmHighScores
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            CancelButton = btnClose;
            ClientSize = new Size(632, 453);
            Controls.Add(btnClose);
            Controls.Add(dgvHighScores);
            Controls.Add(lblTitle);
            MinimumSize = new Size(520, 360);
            Name = "FrmHighScores";
            StartPosition = FormStartPosition.CenterParent;
            Text = "High Scores";
            ((System.ComponentModel.ISupportInitialize)dgvHighScores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvHighScores;
        private DataGridViewTextBoxColumn colRank;
        private DataGridViewTextBoxColumn colPlayer;
        private DataGridViewTextBoxColumn colScore;
        private DataGridViewTextBoxColumn colLevel;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colTime;
        private Button btnClose;
    }
}
