using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Select2Speech.Data;
using Select2Speech.DTOs;
using Select2Speech.Views;

namespace Select2Speech.Options
{
    /// <summary>
    /// The view for the options form.
    /// </summary>
    public partial class SettingsView : Form
    {
        private SettingsController controller;

        /// <summary>
        /// Initializes form.
        /// </summary>
        public SettingsView(SettingsController controller, SettingsDTO settingsDTO, string[] modifierKeyOptions) {
            InitializeComponent();
            keyBox.BackColor = Color.White;
            modifierKeyDropdown.DataSource = modifierKeyOptions;
            this.controller = controller;
            Populate(settingsDTO);
        }

        /// <summary>
        /// Populates the form with data.
        /// </summary>
        /// <param name="modifierKeyChoices">
        /// The available modifier keys.
        /// </param>
        /// <param name="currentModifierKey">
        /// The current modifier key.
        /// </param>
        /// <param name="currentKey">
        /// The current key.
        /// </param>
        public void Populate(SettingsDTO settingsDTO)
        {
            voiceBindingsGridView.Rows.Clear();
            voiceBindingsGridView.Columns.Clear();
            voiceBindingsGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn {
                    HeaderText = "Key 1",
                    FillWeight = 15,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "Key 2",
                    FillWeight = 15,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "Voice",
                    FillWeight = 70,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                }
            );
            modifierKeyDropdown.Text = settingsDTO.Hotkey.ModifierKey;
            keyBox.Text = settingsDTO.Hotkey.Key;
            sayLanguageWhenVoiceChangesCheckbox.Checked = settingsDTO.ShouldSayChangedLanguage;
            foreach (VoiceBindingDTO voiceBindingDTO in settingsDTO.VoiceBindings)
            {
                voiceBindingsGridView.Rows.Add(
                    voiceBindingDTO.ModifierKey,
                    voiceBindingDTO.Key,
                    voiceBindingDTO.Voice
                );
            }
        }

        /// <summary>
        /// Applies the options in the controller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void apply_Click(object sender, EventArgs e)
        {
            HotkeyDTO hotkey = new HotkeyDTO(modifierKeyDropdown.Text, keyBox.Text);
            List<VoiceBindingDTO> voiceBindingDTOs = new List<VoiceBindingDTO>();
            foreach (DataGridViewRow row in voiceBindingsGridView.Rows) {
                voiceBindingDTOs.Add(
                    new VoiceBindingDTO(
                        (string)row.Cells[0].Value,
                        (string)row.Cells[1].Value,
                        (string)row.Cells[2].Value
                    )
                );
            }
            controller.Apply(new SettingsDTO(hotkey, sayLanguageWhenVoiceChangesCheckbox.Checked, voiceBindingDTOs));
        }

        /// <summary>
        /// Sets the current selected key in the box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyBox_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            keyBox.Text = key.ToString();
        }

        private void addBindingButton_Click(object sender, EventArgs e)
        {
            controller.OpenAddVoiceBindingView();
        }

        private void removeBindingButton_Click(object sender, EventArgs e) {

            for (int i = 0; i < voiceBindingsGridView.RowCount; i++)
            {
                if (voiceBindingsGridView.Rows[i].Selected)
                {
                    voiceBindingsGridView.Rows.RemoveAt(i);
                }
            }           
        }
    }
}
