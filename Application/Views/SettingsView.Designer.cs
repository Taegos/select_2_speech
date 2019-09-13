namespace Select2Speech.Options {
    partial class SettingsView {
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
            this.components = new System.ComponentModel.Container();
            this.modifierKeyDropdown = new System.Windows.Forms.ComboBox();
            this.hotkeyRegistryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sayLanguageWhenVoiceChangesCheckbox = new System.Windows.Forms.CheckBox();
            this.addBindingButton = new System.Windows.Forms.Button();
            this.removeBindingButton = new System.Windows.Forms.Button();
            this.voiceBindingsGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.hotkeyRegistryBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voiceBindingsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // modifierKeyDropdown
            // 
            this.modifierKeyDropdown.Cursor = System.Windows.Forms.Cursors.Default;
            this.modifierKeyDropdown.DataSource = this.hotkeyRegistryBindingSource;
            this.modifierKeyDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modifierKeyDropdown.FormattingEnabled = true;
            this.modifierKeyDropdown.Location = new System.Drawing.Point(6, 19);
            this.modifierKeyDropdown.Name = "modifierKeyDropdown";
            this.modifierKeyDropdown.Size = new System.Drawing.Size(105, 21);
            this.modifierKeyDropdown.TabIndex = 0;
            // 
            // hotkeyRegistryBindingSource
            // 
            this.hotkeyRegistryBindingSource.DataSource = typeof(Hotkeys.HotkeyRegistry);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.keyBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.modifierKeyDropdown);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Speak Hotkey:";
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(141, 19);
            this.keyBox.Name = "keyBox";
            this.keyBox.ReadOnly = true;
            this.keyBox.Size = new System.Drawing.Size(104, 20);
            this.keyBox.TabIndex = 3;
            this.keyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(117, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "+";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(418, 319);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(103, 41);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.apply_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sayLanguageWhenVoiceChangesCheckbox);
            this.groupBox2.Controls.Add(this.addBindingButton);
            this.groupBox2.Controls.Add(this.removeBindingButton);
            this.groupBox2.Controls.Add(this.voiceBindingsGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 245);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Voice Bindings:";
            // 
            // sayLanguageWhenVoiceChangesCheckbox
            // 
            this.sayLanguageWhenVoiceChangesCheckbox.AutoSize = true;
            this.sayLanguageWhenVoiceChangesCheckbox.Location = new System.Drawing.Point(6, 216);
            this.sayLanguageWhenVoiceChangesCheckbox.Name = "sayLanguageWhenVoiceChangesCheckbox";
            this.sayLanguageWhenVoiceChangesCheckbox.Size = new System.Drawing.Size(193, 17);
            this.sayLanguageWhenVoiceChangesCheckbox.TabIndex = 8;
            this.sayLanguageWhenVoiceChangesCheckbox.Text = "Say language when voice changes";
            this.sayLanguageWhenVoiceChangesCheckbox.UseVisualStyleBackColor = true;
            // 
            // addBindingButton
            // 
            this.addBindingButton.Location = new System.Drawing.Point(406, 211);
            this.addBindingButton.Name = "addBindingButton";
            this.addBindingButton.Size = new System.Drawing.Size(103, 25);
            this.addBindingButton.TabIndex = 7;
            this.addBindingButton.Text = "Add Binding";
            this.addBindingButton.UseVisualStyleBackColor = true;
            this.addBindingButton.Click += new System.EventHandler(this.addBindingButton_Click);
            // 
            // removeBindingButton
            // 
            this.removeBindingButton.Location = new System.Drawing.Point(297, 211);
            this.removeBindingButton.Name = "removeBindingButton";
            this.removeBindingButton.Size = new System.Drawing.Size(103, 25);
            this.removeBindingButton.TabIndex = 6;
            this.removeBindingButton.Text = "Remove Binding";
            this.removeBindingButton.UseVisualStyleBackColor = true;
            this.removeBindingButton.Click += new System.EventHandler(this.removeBindingButton_Click);
            // 
            // voiceBindingsGridView
            // 
            this.voiceBindingsGridView.AllowUserToAddRows = false;
            this.voiceBindingsGridView.AllowUserToDeleteRows = false;
            this.voiceBindingsGridView.AllowUserToResizeColumns = false;
            this.voiceBindingsGridView.AllowUserToResizeRows = false;
            this.voiceBindingsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.voiceBindingsGridView.Location = new System.Drawing.Point(6, 19);
            this.voiceBindingsGridView.MultiSelect = false;
            this.voiceBindingsGridView.Name = "voiceBindingsGridView";
            this.voiceBindingsGridView.ReadOnly = true;
            this.voiceBindingsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.voiceBindingsGridView.Size = new System.Drawing.Size(503, 186);
            this.voiceBindingsGridView.TabIndex = 0;
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 372);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsView";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.hotkeyRegistryBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voiceBindingsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox modifierKeyDropdown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView voiceBindingsGridView;
        private System.Windows.Forms.Button addBindingButton;
        private System.Windows.Forms.Button removeBindingButton;
        private System.Windows.Forms.BindingSource hotkeyRegistryBindingSource;
        private System.Windows.Forms.CheckBox sayLanguageWhenVoiceChangesCheckbox;
    }
}