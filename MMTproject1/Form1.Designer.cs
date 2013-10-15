namespace MMTproject1 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.screen = new System.Windows.Forms.PictureBox();
            this.pauzeButton = new System.Windows.Forms.Button();
            this.antialiasingCheckBox = new System.Windows.Forms.CheckBox();
            this.s1SpeedLbl = new System.Windows.Forms.Label();
            this.s2SpeedLbl = new System.Windows.Forms.Label();
            this.s3SpeedLbl = new System.Windows.Forms.Label();
            this.s4SpeedLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.s1SpeedTxt = new System.Windows.Forms.TextBox();
            this.s2SpeedTxt = new System.Windows.Forms.TextBox();
            this.s3SpeedTxt = new System.Windows.Forms.TextBox();
            this.s4SpeedTxt = new System.Windows.Forms.TextBox();
            this.maxSpeedLbl = new System.Windows.Forms.Label();
            this.accelerationLbl = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.demoButton = new System.Windows.Forms.Button();
            this.maxSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.accellerationTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.restitutionTrackBar = new System.Windows.Forms.TrackBar();
            this.redScore = new System.Windows.Forms.TextBox();
            this.blueScore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSpeedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accellerationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restitutionTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // screen
            // 
            this.screen.Location = new System.Drawing.Point(10, 10);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(550, 400);
            this.screen.TabIndex = 0;
            this.screen.TabStop = false;
            // 
            // pauzeButton
            // 
            this.pauzeButton.Location = new System.Drawing.Point(577, 27);
            this.pauzeButton.Name = "pauzeButton";
            this.pauzeButton.Size = new System.Drawing.Size(80, 23);
            this.pauzeButton.TabIndex = 1;
            this.pauzeButton.Text = "Pauze";
            this.pauzeButton.UseVisualStyleBackColor = true;
            this.pauzeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // antialiasingCheckBox
            // 
            this.antialiasingCheckBox.AutoSize = true;
            this.antialiasingCheckBox.Checked = true;
            this.antialiasingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.antialiasingCheckBox.Location = new System.Drawing.Point(577, 73);
            this.antialiasingCheckBox.Name = "antialiasingCheckBox";
            this.antialiasingCheckBox.Size = new System.Drawing.Size(80, 17);
            this.antialiasingCheckBox.TabIndex = 2;
            this.antialiasingCheckBox.Text = "AntiAliasing";
            this.antialiasingCheckBox.UseVisualStyleBackColor = true;
            this.antialiasingCheckBox.CheckedChanged += new System.EventHandler(this.antialiasingCheckBox_CheckedChanged);
            // 
            // s1SpeedLbl
            // 
            this.s1SpeedLbl.AutoSize = true;
            this.s1SpeedLbl.Location = new System.Drawing.Point(578, 249);
            this.s1SpeedLbl.Name = "s1SpeedLbl";
            this.s1SpeedLbl.Size = new System.Drawing.Size(85, 13);
            this.s1SpeedLbl.TabIndex = 3;
            this.s1SpeedLbl.Text = "Snelheid speler1";
            // 
            // s2SpeedLbl
            // 
            this.s2SpeedLbl.AutoSize = true;
            this.s2SpeedLbl.Location = new System.Drawing.Point(578, 280);
            this.s2SpeedLbl.Name = "s2SpeedLbl";
            this.s2SpeedLbl.Size = new System.Drawing.Size(85, 13);
            this.s2SpeedLbl.TabIndex = 4;
            this.s2SpeedLbl.Text = "Snelheid speler2";
            // 
            // s3SpeedLbl
            // 
            this.s3SpeedLbl.AutoSize = true;
            this.s3SpeedLbl.Location = new System.Drawing.Point(578, 312);
            this.s3SpeedLbl.Name = "s3SpeedLbl";
            this.s3SpeedLbl.Size = new System.Drawing.Size(85, 13);
            this.s3SpeedLbl.TabIndex = 5;
            this.s3SpeedLbl.Text = "Snelheid speler3";
            // 
            // s4SpeedLbl
            // 
            this.s4SpeedLbl.AutoSize = true;
            this.s4SpeedLbl.Location = new System.Drawing.Point(578, 342);
            this.s4SpeedLbl.Name = "s4SpeedLbl";
            this.s4SpeedLbl.Size = new System.Drawing.Size(85, 13);
            this.s4SpeedLbl.TabIndex = 6;
            this.s4SpeedLbl.Text = "Snelheid speler4";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(581, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 4);
            this.label1.TabIndex = 7;
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(704, 27);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(75, 23);
            this.restartButton.TabIndex = 8;
            this.restartButton.Text = "Herstart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // s1SpeedTxt
            // 
            this.s1SpeedTxt.Location = new System.Drawing.Point(708, 246);
            this.s1SpeedTxt.Name = "s1SpeedTxt";
            this.s1SpeedTxt.ReadOnly = true;
            this.s1SpeedTxt.Size = new System.Drawing.Size(75, 20);
            this.s1SpeedTxt.TabIndex = 11;
            // 
            // s2SpeedTxt
            // 
            this.s2SpeedTxt.Location = new System.Drawing.Point(708, 277);
            this.s2SpeedTxt.Name = "s2SpeedTxt";
            this.s2SpeedTxt.ReadOnly = true;
            this.s2SpeedTxt.Size = new System.Drawing.Size(75, 20);
            this.s2SpeedTxt.TabIndex = 12;
            // 
            // s3SpeedTxt
            // 
            this.s3SpeedTxt.Location = new System.Drawing.Point(708, 309);
            this.s3SpeedTxt.Name = "s3SpeedTxt";
            this.s3SpeedTxt.ReadOnly = true;
            this.s3SpeedTxt.Size = new System.Drawing.Size(75, 20);
            this.s3SpeedTxt.TabIndex = 13;
            // 
            // s4SpeedTxt
            // 
            this.s4SpeedTxt.Location = new System.Drawing.Point(708, 339);
            this.s4SpeedTxt.Name = "s4SpeedTxt";
            this.s4SpeedTxt.ReadOnly = true;
            this.s4SpeedTxt.Size = new System.Drawing.Size(75, 20);
            this.s4SpeedTxt.TabIndex = 14;
            // 
            // maxSpeedLbl
            // 
            this.maxSpeedLbl.AutoSize = true;
            this.maxSpeedLbl.Location = new System.Drawing.Point(578, 102);
            this.maxSpeedLbl.Name = "maxSpeedLbl";
            this.maxSpeedLbl.Size = new System.Drawing.Size(120, 13);
            this.maxSpeedLbl.TabIndex = 15;
            this.maxSpeedLbl.Text = "Maximale snelheid (m/s)";
            // 
            // accelerationLbl
            // 
            this.accelerationLbl.AutoSize = true;
            this.accelerationLbl.Location = new System.Drawing.Point(578, 134);
            this.accelerationLbl.Name = "accelerationLbl";
            this.accelerationLbl.Size = new System.Drawing.Size(97, 13);
            this.accelerationLbl.TabIndex = 16;
            this.accelerationLbl.Text = "Versnelling (m/s^2)";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(704, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(36, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "AI";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(581, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 4);
            this.label2.TabIndex = 18;
            // 
            // demoButton
            // 
            this.demoButton.Location = new System.Drawing.Point(581, 387);
            this.demoButton.Name = "demoButton";
            this.demoButton.Size = new System.Drawing.Size(82, 23);
            this.demoButton.TabIndex = 19;
            this.demoButton.Text = "PhysicsDemo";
            this.demoButton.UseVisualStyleBackColor = true;
            this.demoButton.Click += new System.EventHandler(this.demoButton_Click);
            // 
            // maxSpeedTrackBar
            // 
            this.maxSpeedTrackBar.Location = new System.Drawing.Point(704, 96);
            this.maxSpeedTrackBar.Maximum = 40;
            this.maxSpeedTrackBar.Minimum = 5;
            this.maxSpeedTrackBar.Name = "maxSpeedTrackBar";
            this.maxSpeedTrackBar.Size = new System.Drawing.Size(104, 45);
            this.maxSpeedTrackBar.TabIndex = 20;
            this.maxSpeedTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.maxSpeedTrackBar.Value = 40;
            this.maxSpeedTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // accellerationTrackBar
            // 
            this.accellerationTrackBar.Location = new System.Drawing.Point(704, 134);
            this.accellerationTrackBar.Maximum = 50;
            this.accellerationTrackBar.Minimum = 1;
            this.accellerationTrackBar.Name = "accellerationTrackBar";
            this.accellerationTrackBar.Size = new System.Drawing.Size(104, 45);
            this.accellerationTrackBar.TabIndex = 21;
            this.accellerationTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.accellerationTrackBar.Value = 5;
            this.accellerationTrackBar.Scroll += new System.EventHandler(this.accellerationTrackBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Restitutie";
            // 
            // restitutionTrackBar
            // 
            this.restitutionTrackBar.Location = new System.Drawing.Point(708, 178);
            this.restitutionTrackBar.Maximum = 100;
            this.restitutionTrackBar.Minimum = 1;
            this.restitutionTrackBar.Name = "restitutionTrackBar";
            this.restitutionTrackBar.Size = new System.Drawing.Size(104, 45);
            this.restitutionTrackBar.TabIndex = 23;
            this.restitutionTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.restitutionTrackBar.Value = 5;
            this.restitutionTrackBar.Scroll += new System.EventHandler(this.restitutionTrackBar_Scroll);
            // 
            // redScore
            // 
            this.redScore.Location = new System.Drawing.Point(175, 445);
            this.redScore.Name = "redScore";
            this.redScore.ReadOnly = true;
            this.redScore.Size = new System.Drawing.Size(75, 20);
            this.redScore.TabIndex = 24;
            // 
            // blueScore
            // 
            this.blueScore.Location = new System.Drawing.Point(274, 445);
            this.blueScore.Name = "blueScore";
            this.blueScore.ReadOnly = true;
            this.blueScore.Size = new System.Drawing.Size(75, 20);
            this.blueScore.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Score";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Rood";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 429);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Blauw";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 477);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.blueScore);
            this.Controls.Add(this.redScore);
            this.Controls.Add(this.restitutionTrackBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accellerationTrackBar);
            this.Controls.Add(this.maxSpeedTrackBar);
            this.Controls.Add(this.demoButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.accelerationLbl);
            this.Controls.Add(this.maxSpeedLbl);
            this.Controls.Add(this.s4SpeedTxt);
            this.Controls.Add(this.s3SpeedTxt);
            this.Controls.Add(this.s2SpeedTxt);
            this.Controls.Add(this.s1SpeedTxt);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.s4SpeedLbl);
            this.Controls.Add(this.s3SpeedLbl);
            this.Controls.Add(this.s2SpeedLbl);
            this.Controls.Add(this.s1SpeedLbl);
            this.Controls.Add(this.antialiasingCheckBox);
            this.Controls.Add(this.pauzeButton);
            this.Controls.Add(this.screen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "MMT2Project1";
            ((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSpeedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accellerationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restitutionTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox screen;
        private System.Windows.Forms.Button pauzeButton;
        private System.Windows.Forms.CheckBox antialiasingCheckBox;
        private System.Windows.Forms.Label s1SpeedLbl;
        private System.Windows.Forms.Label s2SpeedLbl;
        private System.Windows.Forms.Label s3SpeedLbl;
        private System.Windows.Forms.Label s4SpeedLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.TextBox s1SpeedTxt;
        private System.Windows.Forms.TextBox s2SpeedTxt;
        private System.Windows.Forms.TextBox s3SpeedTxt;
        private System.Windows.Forms.TextBox s4SpeedTxt;
        private System.Windows.Forms.Label maxSpeedLbl;
        private System.Windows.Forms.Label accelerationLbl;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button demoButton;
        private System.Windows.Forms.TrackBar maxSpeedTrackBar;
        private System.Windows.Forms.TrackBar accellerationTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar restitutionTrackBar;
        private System.Windows.Forms.TextBox redScore;
        private System.Windows.Forms.TextBox blueScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

