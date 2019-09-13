namespace Select2Speech.Views {
    partial class AddVoiceBindingView {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.modifierKeyDropdown = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.voiceDropDown = new System.Windows.Forms.ComboBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.keyBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.modifierKeyDropdown);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hotkey";
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(92, 20);
            this.keyBox.Name = "keyBox";
            this.keyBox.ReadOnly = true;
            this.keyBox.Size = new System.Drawing.Size(56, 20);
            this.keyBox.TabIndex = 3;
            this.keyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(68, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "+";
            // 
            // modifierKeyDropdown
            // 
            this.modifierKeyDropdown.Cursor = System.Windows.Forms.Cursors.Default;
            this.modifierKeyDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modifierKeyDropdown.FormattingEnabled = true;
            this.modifierKeyDropdown.Location = new System.Drawing.Point(6, 19);
            this.modifierKeyDropdown.Name = "modifierKeyDropdown";
            this.modifierKeyDropdown.Size = new System.Drawing.Size(56, 21);
            this.modifierKeyDropdown.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.voiceDropDown);
            this.groupBox3.Location = new System.Drawing.Point(171, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(345, 50);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Voice";
            // 
            // voiceDropDown
            // 
            this.voiceDropDown.Cursor = System.Windows.Forms.Cursors.Default;
            this.voiceDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.voiceDropDown.FormattingEnabled = true;
            this.voiceDropDown.Location = new System.Drawing.Point(6, 20);
            this.voiceDropDown.Name = "voiceDropDown";
            this.voiceDropDown.Size = new System.Drawing.Size(333, 21);
            this.voiceDropDown.TabIndex = 0;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(407, 68);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(103, 41);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Add";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // VoiceBindingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 124);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VoiceBindingView";
            this.Text = "Add Voice Binding";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox modifierKeyDropdown;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox voiceDropDown;
        private System.Windows.Forms.Button applyButton;
    }
}