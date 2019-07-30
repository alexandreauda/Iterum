using System.Windows.Forms;

namespace GlobalMacroRecorder
{
    partial class EventSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventSettingForm));
            this.groupBoxGlobal = new System.Windows.Forms.GroupBox();
            this.ScrollPanel = new System.Windows.Forms.Panel();
            this.groupBoxFullCustomSpeed = new System.Windows.Forms.GroupBox();
            this.radioButtonFullCustomSpeed = new System.Windows.Forms.RadioButton();
            this.groupBoxCustomUniformSpeed = new System.Windows.Forms.GroupBox();
            this.labelCustomUniformSpeed = new System.Windows.Forms.Label();
            this.textBoxUniformSpeed = new System.Windows.Forms.TextBox();
            this.radioButtonCustomUniformSpeed = new System.Windows.Forms.RadioButton();
            this.groupBoxCustomMultiplierSpeed = new System.Windows.Forms.GroupBox();
            this.radioButtonCustomMultiplierSpeed = new System.Windows.Forms.RadioButton();
            this.groupBoxNormalSpeed = new System.Windows.Forms.GroupBox();
            this.radioButtonNormalSpeed = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBoxGlobal.SuspendLayout();
            this.ScrollPanel.SuspendLayout();
            this.groupBoxCustomUniformSpeed.SuspendLayout();
            this.groupBoxCustomMultiplierSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxGlobal
            // 
            this.groupBoxGlobal.Controls.Add(this.ScrollPanel);
            this.groupBoxGlobal.Location = new System.Drawing.Point(10, 12);
            this.groupBoxGlobal.Name = "groupBoxGlobal";
            this.groupBoxGlobal.Size = new System.Drawing.Size(356, 360);
            this.groupBoxGlobal.TabIndex = 3;
            this.groupBoxGlobal.TabStop = false;
            this.groupBoxGlobal.Text = "Choose the speed of Event ";
            // 
            // ScrollPanel
            // 
            this.ScrollPanel.AutoScroll = true;
            this.ScrollPanel.Controls.Add(this.groupBoxFullCustomSpeed);
            this.ScrollPanel.Controls.Add(this.radioButtonFullCustomSpeed);
            this.ScrollPanel.Controls.Add(this.groupBoxCustomUniformSpeed);
            this.ScrollPanel.Controls.Add(this.radioButtonCustomUniformSpeed);
            this.ScrollPanel.Controls.Add(this.groupBoxCustomMultiplierSpeed);
            this.ScrollPanel.Controls.Add(this.radioButtonCustomMultiplierSpeed);
            this.ScrollPanel.Controls.Add(this.groupBoxNormalSpeed);
            this.ScrollPanel.Controls.Add(this.radioButtonNormalSpeed);
            this.ScrollPanel.Location = new System.Drawing.Point(6, 12);
            this.ScrollPanel.Name = "ScrollPanel";
            this.ScrollPanel.Size = new System.Drawing.Size(344, 342);
            this.ScrollPanel.TabIndex = 0;
            // 
            // groupBoxFullCustomSpeed
            // 
            this.groupBoxFullCustomSpeed.Location = new System.Drawing.Point(23, 254);
            this.groupBoxFullCustomSpeed.Name = "groupBoxFullCustomSpeed";
            this.groupBoxFullCustomSpeed.Size = new System.Drawing.Size(318, 76);
            this.groupBoxFullCustomSpeed.TabIndex = 7;
            this.groupBoxFullCustomSpeed.TabStop = false;
            this.groupBoxFullCustomSpeed.Text = "Full Custom Speed";
            // 
            // radioButtonFullCustomSpeed
            // 
            this.radioButtonFullCustomSpeed.AutoSize = true;
            this.radioButtonFullCustomSpeed.Location = new System.Drawing.Point(3, 284);
            this.radioButtonFullCustomSpeed.Name = "radioButtonFullCustomSpeed";
            this.radioButtonFullCustomSpeed.Size = new System.Drawing.Size(14, 13);
            this.radioButtonFullCustomSpeed.TabIndex = 6;
            this.radioButtonFullCustomSpeed.TabStop = true;
            this.radioButtonFullCustomSpeed.UseVisualStyleBackColor = true;
            this.radioButtonFullCustomSpeed.CheckedChanged += new System.EventHandler(this.radioButtonFullCustomSpeed_CheckedChanged);
            // 
            // groupBoxCustomUniformSpeed
            // 
            this.groupBoxCustomUniformSpeed.Controls.Add(this.labelCustomUniformSpeed);
            this.groupBoxCustomUniformSpeed.Controls.Add(this.textBoxUniformSpeed);
            this.groupBoxCustomUniformSpeed.Location = new System.Drawing.Point(23, 172);
            this.groupBoxCustomUniformSpeed.Name = "groupBoxCustomUniformSpeed";
            this.groupBoxCustomUniformSpeed.Size = new System.Drawing.Size(318, 76);
            this.groupBoxCustomUniformSpeed.TabIndex = 5;
            this.groupBoxCustomUniformSpeed.TabStop = false;
            this.groupBoxCustomUniformSpeed.Text = "Custom Uniform Speed";
            // 
            // labelCustomUniformSpeed
            // 
            this.labelCustomUniformSpeed.AutoSize = true;
            this.labelCustomUniformSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomUniformSpeed.Location = new System.Drawing.Point(7, 30);
            this.labelCustomUniformSpeed.Name = "labelCustomUniformSpeed";
            this.labelCustomUniformSpeed.Size = new System.Drawing.Size(130, 16);
            this.labelCustomUniformSpeed.TabIndex = 1;
            this.labelCustomUniformSpeed.Text = "Uniform time speed: ";
            // 
            // textBoxUniformSpeed
            // 
            this.textBoxUniformSpeed.Location = new System.Drawing.Point(137, 29);
            this.textBoxUniformSpeed.Name = "textBoxUniformSpeed";
            this.textBoxUniformSpeed.Size = new System.Drawing.Size(100, 20);
            this.textBoxUniformSpeed.TabIndex = 0;
            this.textBoxUniformSpeed.Text = "0";
            this.textBoxUniformSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUniformSpeed_enterInput);
            // 
            // radioButtonCustomUniformSpeed
            // 
            this.radioButtonCustomUniformSpeed.AutoSize = true;
            this.radioButtonCustomUniformSpeed.Location = new System.Drawing.Point(3, 202);
            this.radioButtonCustomUniformSpeed.Name = "radioButtonCustomUniformSpeed";
            this.radioButtonCustomUniformSpeed.Size = new System.Drawing.Size(14, 13);
            this.radioButtonCustomUniformSpeed.TabIndex = 4;
            this.radioButtonCustomUniformSpeed.TabStop = true;
            this.radioButtonCustomUniformSpeed.UseVisualStyleBackColor = true;
            this.radioButtonCustomUniformSpeed.CheckedChanged += new System.EventHandler(this.radioButtonCustomUniformSpeed_CheckedChanged);
            // 
            // groupBoxCustomMultiplierSpeed
            // 
            this.groupBoxCustomMultiplierSpeed.Controls.Add(this.numericUpDown1);
            this.groupBoxCustomMultiplierSpeed.Controls.Add(this.label4);
            this.groupBoxCustomMultiplierSpeed.Controls.Add(this.label3);
            this.groupBoxCustomMultiplierSpeed.Controls.Add(this.label2);
            this.groupBoxCustomMultiplierSpeed.Controls.Add(this.label1);
            this.groupBoxCustomMultiplierSpeed.Controls.Add(this.trackBar1);
            this.groupBoxCustomMultiplierSpeed.Location = new System.Drawing.Point(23, 90);
            this.groupBoxCustomMultiplierSpeed.Name = "groupBoxCustomMultiplierSpeed";
            this.groupBoxCustomMultiplierSpeed.Size = new System.Drawing.Size(318, 76);
            this.groupBoxCustomMultiplierSpeed.TabIndex = 3;
            this.groupBoxCustomMultiplierSpeed.TabStop = false;
            this.groupBoxCustomMultiplierSpeed.Text = "Custom Multiplier Speed";
            // 
            // radioButtonCustomMultiplierSpeed
            // 
            this.radioButtonCustomMultiplierSpeed.AutoSize = true;
            this.radioButtonCustomMultiplierSpeed.Location = new System.Drawing.Point(3, 120);
            this.radioButtonCustomMultiplierSpeed.Name = "radioButtonCustomMultiplierSpeed";
            this.radioButtonCustomMultiplierSpeed.Size = new System.Drawing.Size(14, 13);
            this.radioButtonCustomMultiplierSpeed.TabIndex = 2;
            this.radioButtonCustomMultiplierSpeed.TabStop = true;
            this.radioButtonCustomMultiplierSpeed.UseVisualStyleBackColor = true;
            this.radioButtonCustomMultiplierSpeed.CheckedChanged += new System.EventHandler(this.radioButtonCustomMultiplierSpeed_CheckedChanged);
            // 
            // groupBoxNormalSpeed
            // 
            this.groupBoxNormalSpeed.Location = new System.Drawing.Point(23, 8);
            this.groupBoxNormalSpeed.Name = "groupBoxNormalSpeed";
            this.groupBoxNormalSpeed.Size = new System.Drawing.Size(318, 76);
            this.groupBoxNormalSpeed.TabIndex = 1;
            this.groupBoxNormalSpeed.TabStop = false;
            this.groupBoxNormalSpeed.Text = "Normal Speed";
            // 
            // radioButtonNormalSpeed
            // 
            this.radioButtonNormalSpeed.AutoSize = true;
            this.radioButtonNormalSpeed.Location = new System.Drawing.Point(3, 38);
            this.radioButtonNormalSpeed.Name = "radioButtonNormalSpeed";
            this.radioButtonNormalSpeed.Size = new System.Drawing.Size(14, 13);
            this.radioButtonNormalSpeed.TabIndex = 0;
            this.radioButtonNormalSpeed.TabStop = true;
            this.radioButtonNormalSpeed.UseVisualStyleBackColor = true;
            this.radioButtonNormalSpeed.CheckedChanged += new System.EventHandler(this.radioButtonNormalSpeed_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(185, 378);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(84, 33);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(276, 378);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(84, 33);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(5, 13);
            this.trackBar1.Maximum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 57);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Multiply time speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Divide time speed";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(185, 32);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // EventSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 418);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBoxGlobal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventSettingForm";
            this.Text = "Iterum";
            this.groupBoxGlobal.ResumeLayout(false);
            this.ScrollPanel.ResumeLayout(false);
            this.ScrollPanel.PerformLayout();
            this.groupBoxCustomUniformSpeed.ResumeLayout(false);
            this.groupBoxCustomUniformSpeed.PerformLayout();
            this.groupBoxCustomMultiplierSpeed.ResumeLayout(false);
            this.groupBoxCustomMultiplierSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxGlobal;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel ScrollPanel;
        private System.Windows.Forms.GroupBox groupBoxFullCustomSpeed;
        private System.Windows.Forms.RadioButton radioButtonFullCustomSpeed;
        private System.Windows.Forms.GroupBox groupBoxCustomUniformSpeed;
        private System.Windows.Forms.RadioButton radioButtonCustomUniformSpeed;
        private System.Windows.Forms.GroupBox groupBoxCustomMultiplierSpeed;
        private System.Windows.Forms.RadioButton radioButtonCustomMultiplierSpeed;
        private System.Windows.Forms.GroupBox groupBoxNormalSpeed;
        private System.Windows.Forms.RadioButton radioButtonNormalSpeed;
        private System.Windows.Forms.TextBox textBoxUniformSpeed;
        private System.Windows.Forms.Label labelCustomUniformSpeed;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TrackBar trackBar1;
    }
}

