using RobotView;

namespace TestDrive
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DriveView driveView;
        private ConsoleView consoleView;
        private CommonRunParameters crp;
        private RadarView radar;
        private RunLine rl;
        private RunTurn rt;
        private RunArc ra;

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
            this.driveView = new RobotView.DriveView();
            this.consoleView = new RobotView.ConsoleView();
            this.crp = new RobotView.CommonRunParameters();
            this.radar = new RobotView.RadarView();
            this.rl = new RobotView.RunLine();
            this.rt = new RobotView.RunTurn();
            this.ra = new RobotView.RunArc();
            this.btnBreak = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // driveView
            // 
            this.driveView.Drive = null;
            this.driveView.Location = new System.Drawing.Point(3, 3);
            this.driveView.Name = "driveView";
            this.driveView.Size = new System.Drawing.Size(292, 289);
            this.driveView.TabIndex = 0;
            // 
            // consoleView
            // 
            this.consoleView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.consoleView.Location = new System.Drawing.Point(3, 298);
            this.consoleView.Name = "consoleView";
            this.consoleView.RobotConsole = null;
            this.consoleView.Size = new System.Drawing.Size(216, 55);
            this.consoleView.TabIndex = 8;
            // 
            // crp
            // 
            this.crp.Acceleration = 0.3F;
            this.crp.Location = new System.Drawing.Point(320, 3);
            this.crp.Name = "crp";
            this.crp.Size = new System.Drawing.Size(402, 84);
            this.crp.Speed = 0.5F;
            this.crp.TabIndex = 0;
            // 
            // radar
            // 
            this.radar.Location = new System.Drawing.Point(230, 311);
            this.radar.Name = "radar";
            this.radar.Radar = null;
            this.radar.Size = new System.Drawing.Size(565, 42);
            this.radar.TabIndex = 9;
            // 
            // rl
            // 
            this.rl.Acceleration = 0F;
            this.rl.Drive = null;
            this.rl.Length = 1F;
            this.rl.Location = new System.Drawing.Point(320, 93);
            this.rl.Name = "rl";
            this.rl.Size = new System.Drawing.Size(456, 46);
            this.rl.Speed = 0F;
            this.rl.TabIndex = 1;
            // 
            // rt
            // 
            this.rt.Acceleration = 0F;
            this.rt.Drive = null;
            this.rt.Location = new System.Drawing.Point(317, 145);
            this.rt.Name = "rt";
            this.rt.Size = new System.Drawing.Size(478, 45);
            this.rt.Speed = 0F;
            this.rt.TabIndex = 2;
            // 
            // ra
            // 
            this.ra.Acceleration = 0F;
            this.ra.Drive = null;
            this.ra.Location = new System.Drawing.Point(320, 196);
            this.ra.Name = "ra";
            this.ra.Size = new System.Drawing.Size(484, 114);
            this.ra.Speed = 0F;
            this.ra.TabIndex = 3;
            // 
            // btnBreak
            // 
            this.btnBreak.Location = new System.Drawing.Point(197, 375);
            this.btnBreak.Name = "btnBreak";
            this.btnBreak.Size = new System.Drawing.Size(72, 20);
            this.btnBreak.TabIndex = 4;
            this.btnBreak.Text = "Halt";
            this.btnBreak.Click += new System.EventHandler(this.btnBreak_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(366, 375);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(72, 20);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1402, 772);
            this.Controls.Add(this.driveView);
            this.Controls.Add(this.consoleView);
            this.Controls.Add(this.radar);
            this.Controls.Add(this.btnBreak);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.crp);
            this.Controls.Add(this.rl);
            this.Controls.Add(this.rt);
            this.Controls.Add(this.ra);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBreak;
        private System.Windows.Forms.Button btnStop;
    }
}

