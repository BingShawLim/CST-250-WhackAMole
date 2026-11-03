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
            SuspendLayout();
            //
            // lblTimeElapsed
            //
            lblTimeElapsed.AutoSize = true;
            lblTimeElapsed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTimeElapsed.Location = new Point(12, 9);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(72, 28);
            lblTimeElapsed.TabIndex = 0;
            lblTimeElapsed.Text = "00:00:00";
            //
            // btnStart
            //
            btnStart.Location = new Point(12, 409);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 32);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStartClickEH;
            //
            // btnStop
            //
            btnStop.Location = new Point(112, 409);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 32);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += BtnStopClickEH;
            //
            // btnReset
            //
            btnReset.Location = new Point(212, 409);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 32);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnResetClickEH;
            //
            // tmrStopwatch
            //
            tmrStopwatch.Enabled = true;
            tmrStopwatch.Interval = 1000;
            tmrStopwatch.Tick += TmrStopwatchTickEH;
            //
            // btnTarget
            //
            btnTarget.Location = new Point(331, 190);
            btnTarget.Name = "btnTarget";
            btnTarget.Size = new Size(120, 60);
            btnTarget.TabIndex = 4;
            btnTarget.Text = "Target";
            btnTarget.UseVisualStyleBackColor = true;
            //
            // FrmStopwatch
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(btnTarget);
            Controls.Add(btnReset);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lblTimeElapsed);
            Name = "FrmStopwatch";
            Text = "Stopwatch";
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
    }
}
