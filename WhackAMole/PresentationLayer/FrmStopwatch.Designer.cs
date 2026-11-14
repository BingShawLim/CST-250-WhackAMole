namespace WhackAMole.PresentationLayer
{
    partial class FrmStopwatch
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTimeElapsed = new Label();
            btnStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            tmrStopwatch = new System.Windows.Forms.Timer(components);
            btnTarget = new Button();
            btnDecoy = new Button();
            lblScore = new Label();
            lblLevel = new Label();
            lblLives = new Label();
            SuspendLayout();
            //
            // lblTimeElapsed
            //
            lblTimeElapsed.AutoSize = true;
            lblTimeElapsed.BackColor = Color.Transparent;
            lblTimeElapsed.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimeElapsed.ForeColor = Color.White;
            lblTimeElapsed.Location = new Point(12, 12);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(82, 28);
            lblTimeElapsed.TabIndex = 0;
            lblTimeElapsed.Text = "00:00:00";
            //
            // btnStart
            //
            btnStart.BackColor = Color.SaddleBrown;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(12, 405);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 36);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStartClickEH;
            //
            // btnStop
            //
            btnStop.BackColor = Color.SaddleBrown;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(120, 405);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(100, 36);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += BtnStopClickEH;
            //
            // btnReset
            //
            btnReset.BackColor = Color.SaddleBrown;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(228, 405);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 36);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += BtnResetClickEH;
            //
            // tmrStopwatch
            //
            tmrStopwatch.Interval = 1000;
            tmrStopwatch.Tick += TmrStopwatchTickEH;
            //
            // btnTarget
            //
            btnTarget.BackColor = Color.LightYellow;
            btnTarget.BackgroundImageLayout = ImageLayout.Zoom;
            btnTarget.Cursor = Cursors.Hand;
            btnTarget.FlatAppearance.BorderSize = 0;
            btnTarget.FlatStyle = FlatStyle.Flat;
            btnTarget.Location = new Point(351, 186);
            btnTarget.Name = "btnTarget";
            btnTarget.Size = new Size(80, 80);
            btnTarget.TabIndex = 4;
            btnTarget.TabStop = false;
            btnTarget.UseVisualStyleBackColor = false;
            btnTarget.Click += BtnTargetClickEH;
            //
            // btnDecoy
            //
            btnDecoy.BackColor = Color.MistyRose;
            btnDecoy.BackgroundImageLayout = ImageLayout.Zoom;
            btnDecoy.Cursor = Cursors.Hand;
            btnDecoy.FlatAppearance.BorderSize = 0;
            btnDecoy.FlatStyle = FlatStyle.Flat;
            btnDecoy.Location = new Point(520, 186);
            btnDecoy.Name = "btnDecoy";
            btnDecoy.Size = new Size(80, 80);
            btnDecoy.TabIndex = 5;
            btnDecoy.TabStop = false;
            btnDecoy.UseVisualStyleBackColor = false;
            btnDecoy.Visible = false;
            btnDecoy.Click += BtnDecoyClickEH;
            //
            // lblScore
            //
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(120, 12);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(83, 28);
            lblScore.TabIndex = 6;
            lblScore.Text = "Score: 0";
            //
            // lblLevel
            //
            lblLevel.AutoSize = true;
            lblLevel.BackColor = Color.Transparent;
            lblLevel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLevel.ForeColor = Color.White;
            lblLevel.Location = new Point(230, 12);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(76, 28);
            lblLevel.TabIndex = 7;
            lblLevel.Text = "Level: 1";
            //
            // lblLives
            //
            lblLives.AutoSize = true;
            lblLives.BackColor = Color.Transparent;
            lblLives.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLives.ForeColor = Color.MistyRose;
            lblLives.Location = new Point(330, 12);
            lblLives.Name = "lblLives";
            lblLives.Size = new Size(100, 28);
            lblLives.TabIndex = 8;
            lblLives.Text = "Lives: ♥♥♥";
            //
            // FrmStopwatch
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(96, 160, 64);
            ClientSize = new Size(782, 453);
            Controls.Add(btnTarget);
            Controls.Add(btnDecoy);
            Controls.Add(lblLives);
            Controls.Add(lblLevel);
            Controls.Add(lblScore);
            Controls.Add(btnReset);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lblTimeElapsed);
            Cursor = Cursors.Cross;
            DoubleBuffered = true;
            MinimumSize = new Size(560, 400);
            Name = "FrmStopwatch";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stopwatch - Whack-A-Mole";
            Click += FrmStopwatchClickEH;
            Resize += FrmStopwatchResizeEH;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTimeElapsed;
        private Button btnStart;
        private Button btnStop;
        private Button btnReset;
        private System.Windows.Forms.Timer tmrStopwatch;
        private Button btnTarget;
        private Button btnDecoy;
        private Label lblScore;
        private Label lblLevel;
        private Label lblLives;
    }
}
