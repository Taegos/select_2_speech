using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotkeys;
using Select2Speech.Data;
using Select2Speech.DTOs;
using Select2Speech.Options;
using Select2Speech.Views;

namespace Select2Speech.Controllers {
    public class AddVoiceBindingController
    {
        private SettingsController settingsController;
        private TTSEngine TTSEngine;
        private AddVoiceBindingView view;

        public AddVoiceBindingController(SettingsController settingsController, TTSEngine TTSEngine)
        {
            this.TTSEngine = TTSEngine;
            this.settingsController = settingsController;
        }

        public void Open() {
            string[] installedVoices = TTSEngine.GetInstalledVoices();
            string[] modifierKeyOptions = Enum.GetNames(typeof(ModifierKey));
            view = new AddVoiceBindingView(this, installedVoices, modifierKeyOptions);
            view.Show();
        }

        public void AddVoiceBinding(VoiceBindingDTO voiceBindingDTO)
        {
            SettingsFile settingsFile = TTSEngine.GetSettings();
            Enum.TryParse(voiceBindingDTO.ModifierKey, out ModifierKey modifierKey);
            Enum.TryParse(voiceBindingDTO.Key, out Keys key);
            Hotkey hotkey = new Hotkey(modifierKey, key);
            VoiceBindingEntity voiceBindingEntity = new VoiceBindingEntity(hotkey, voiceBindingDTO.Voice);
            settingsFile.VoiceBindings.Add(voiceBindingEntity);
            TTSEngine.UpdateSettings(settingsFile);
            view.Dispose();
            settingsController.Populate();            
        }
    }
}
