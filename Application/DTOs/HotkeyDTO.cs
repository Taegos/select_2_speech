using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select2Speech.DTOs {
    public class HotkeyDTO {
        public string ModifierKey { get; set; }
        public string Key { get; set; }

        public HotkeyDTO(string modifierKey, string key)
        {
            ModifierKey = modifierKey;
            Key = key;
        }
    }
}
