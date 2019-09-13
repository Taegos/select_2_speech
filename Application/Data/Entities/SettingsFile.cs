using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotkeys;

namespace Select2Speech.Data {

    /// <summary>
    /// Deserialized specification of the settings file.
    /// </summary>
    public class SettingsFile {
        public Hotkey Hotkey { get; set; }
        public string Voice { get; set; }
        public bool ShouldSayChangedLanguage { get; set; }
        public List<VoiceBindingEntity> VoiceBindings { get; set; }

        public SettingsFile(Hotkey hotkey, string voice, bool shouldSayChangedLanguage, List<VoiceBindingEntity> voiceBindingEntities)
        {
            Hotkey = hotkey;
            Voice = voice;
            ShouldSayChangedLanguage = shouldSayChangedLanguage;
            VoiceBindings = voiceBindingEntities;
        }
        /// <summary>
        /// Sets member variables.
        /// </summary>
        /// <param name="hotkey">
        /// The hotkey.
        /// </param>
        /// <param name="voice">
        /// The voice.
        /// </param>
        //public SettingsFile(Hotkey hotkey, string voice)
        //{
        //    Hotkey = hotkey;
        //    Voice = voice;
        //}
    }
}
