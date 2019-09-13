using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select2Speech.DTOs {
    public class SettingsDTO {
        public HotkeyDTO Hotkey { get; set; }
        public bool ShouldSayChangedLanguage { get; set; }
        public List<VoiceBindingDTO> VoiceBindings { get; set; }

        public SettingsDTO(
            HotkeyDTO hotkey,
            bool shouldSayChangedLanguage,
            List<VoiceBindingDTO> voiceBindingDTOs)
        {
            Hotkey = hotkey;
            ShouldSayChangedLanguage = shouldSayChangedLanguage;
            VoiceBindings = voiceBindingDTOs;
        }
    }
}
