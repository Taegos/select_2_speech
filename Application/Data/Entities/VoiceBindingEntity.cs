using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotkeys;

namespace Select2Speech.Data {
    public class VoiceBindingEntity {
        public Hotkey Hotkey { get; set; }
        public string Voice { get; set; }

        public VoiceBindingEntity(Hotkey hotkey, string voice)
        {
            Hotkey = hotkey;
            Voice = voice;
        }
    }
}
