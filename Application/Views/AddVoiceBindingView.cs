using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Select2Speech.Controllers;
using Select2Speech.DTOs;
using Select2Speech.Options;

namespace Select2Speech.Views {
    public partial class AddVoiceBindingView : Form
    {
        private AddVoiceBindingController controller;

        public AddVoiceBindingView(AddVoiceBindingController controller, string[] installedVoices, string[] modifierKeyOptions) {
            InitializeComponent();
            this.controller = controller;
            Load(installedVoices, modifierKeyOptions);
        }


        private void Load(string[] installedVoices, string[] modifierKeyOptions)
        {
            modifierKeyDropdown.DataSource = modifierKeyOptions;
            voiceDropDown.DataSource = installedVoices;
        }

        private void applyButton_Click(object sender, EventArgs e) {
            VoiceBindingDTO voiceBindingDTO = new VoiceBindingDTO(modifierKeyDropdown.Text, keyBox.Text, voiceDropDown.Text);
            controller.AddVoiceBinding(voiceBindingDTO);
        }

        private void keyBox_KeyDown(object sender, KeyEventArgs e) {
            Keys key = e.KeyCode;
            keyBox.Text = key.ToString();
        }
    }
}
