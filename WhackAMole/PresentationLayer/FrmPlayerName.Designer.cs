namespace WhackAMole.PresentationLayer
{
    partial class FrmPlayerName
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
            lblFinalScore = new Label();
            lblPrompt = new Label();
            txtPlayerName = new TextBox();
            btnOk = new Button();
            SuspendLayout();
            //
            // lblFinalScore
            //
            lblFinalScore.AutoSize = true;
            lblFinalScore.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFinalScore.ForeColor = Color.SaddleBrown;
            lblFinalScore.Location = new Point(20, 16);
            lblFinalScore.Name = "lblFinalScore";
            lblFinalScore.Size = new Size(200, 28);
            lblFinalScore.TabIndex = 0;
            lblFinalScore.Text = "Game over!";
            //
            // lblPrompt
            //
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(20, 56);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(260, 20);
            lblPrompt.TabIndex = 1;
            lblPrompt.Text = "Enter your name for the Hall of Fame:";
            //
            // txtPlayerName
            //
            txtPlayerName.Font = new Font("Segoe UI", 11F);
            txtPlayerName.Location = new Point(20, 82);
            txtPlayerName.MaxLength = 20;
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(320, 32);
            txtPlayerName.TabIndex = 2;
            //
            // btnOk
            //
            btnOk.BackColor = Color.SaddleBrown;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(240, 128);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 36);
            btnOk.TabIndex = 3;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += BtnOkClickEH;
            //
            // FrmPlayerName
            //
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(362, 182);
            Controls.Add(btnOk);
            Controls.Add(txtPlayerName);
            Controls.Add(lblPrompt);
            Controls.Add(lblFinalScore);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPlayerName";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Player Name";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFinalScore;
        private Label lblPrompt;
        private TextBox txtPlayerName;
        private Button btnOk;
    }
}
