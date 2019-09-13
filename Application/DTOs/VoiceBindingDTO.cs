using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select2Speech.DTOs {
    public class VoiceBindingDTO {
        public string ModifierKey { get; set; }
        public string Key { get; set; }
        public string Voice { get; set; }

        public VoiceBindingDTO(string modifierKey, string key, string voice)
        {
            ModifierKey = modifierKey;
            Key = key;
            Voice = voice;
        }
    }
}
