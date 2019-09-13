using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Hotkeys;
using Select2Speech.Controllers;
using Select2Speech.Data;
using Select2Speech.DTOs;
using Select2Speech.SystemTray;
using Select2Speech.Views;


namespace Select2Speech.Options
{
    /// <summary>
    /// The options controller, recieves user input from the options form, updates the options form and the options model.
    /// </summary>
    public class SettingsController 
    {
        private TTSEngine TTSEngine;
        private SettingsView view;
        private AddVoiceBindingController addVoiceBindingController;

        /// <summary>
        /// Sets member variables.
        /// </summary>
        /// <param name="view">
        /// The options view.
        /// </param>
        /// <param name="model">
        /// The options model.
        /// </param>
        public SettingsController(TTSEngine TTSEngine)
        {
            this.TTSEngine = TTSEngine;
        }

        public void SetAddVoiceBindingController(AddVoiceBindingController addVoiceBindingController) {
            this.addVoiceBindingController = addVoiceBindingController;
        }

        /// <summary>
        /// Populates the options form with the current settings and opens it.
        /// </summary>
        public void Open()
        {
            SettingsDTO settingsDTO = GetSettingsDTO();
            string[] modKeyOptions = Enum.GetNames(typeof(ModifierKey));
            view = new SettingsView(this, settingsDTO, modKeyOptions);                    
            view.Show();
        }

        public void Populate()
        {
            if (view == null || view.IsDisposed)
            {
                throw new NullReferenceException("Cant populate a disposed view");
            }
            SettingsDTO settingsDTO = GetSettingsDTO();
            view.Populate(settingsDTO);
        }

        private SettingsDTO GetSettingsDTO()
        {
            SettingsFile settingsFile = TTSEngine.GetSettings();
            string modifierKey = settingsFile.Hotkey.ModifierKey.ToString();
            string key = settingsFile.Hotkey.Key.ToString();
            HotkeyDTO hotkey = new HotkeyDTO(modifierKey, key);
            List<VoiceBindingDTO> voiceBindingDTOs = new List<VoiceBindingDTO>();
            foreach (VoiceBindingEntity voiceBindingEntity in settingsFile.VoiceBindings) {
                string modifierKeyBinding = voiceBindingEntity.Hotkey.ModifierKey.ToString();
                string keyBinding = voiceBindingEntity.Hotkey.Key.ToString();
                HotkeyDTO bindingHotkey = new HotkeyDTO(modifierKeyBinding, keyBinding);
                string bindingVoice = voiceBindingEntity.Voice;
                VoiceBindingDTO voiceBindingDTO = new VoiceBindingDTO(bindingHotkey.ModifierKey, bindingHotkey.Key, bindingVoice);
                voiceBindingDTOs.Add(voiceBindingDTO);
            }
            bool shouldSayLanguageWhenChange = settingsFile.ShouldSayChangedLanguage;
            return new SettingsDTO(hotkey, shouldSayLanguageWhenChange, voiceBindingDTOs);
        }

        /// <summary>
        /// Apply the settings selected in the options form and hide it.
        /// </summary>
        /// <param name="modifierKeyText">
        /// The modifier part of the hotkey.
        /// </param>
        /// <param name="keyText">
        /// The key part of the hotkey.
        /// </param>
        public void Apply(SettingsDTO settingsDTO)
        {
            Enum.TryParse(settingsDTO.Hotkey.ModifierKey, out ModifierKey modifierKey);
            Enum.TryParse(settingsDTO.Hotkey.Key, out Keys key);
            Hotkey hotkey = new Hotkey(modifierKey, key);
            List<VoiceBindingEntity> voiceBindingEntities = new List<VoiceBindingEntity>();
            foreach (VoiceBindingDTO voiceBindingDTO in settingsDTO.VoiceBindings)
            {
                Enum.TryParse(voiceBindingDTO.ModifierKey, out ModifierKey bindingModifierKey);
                Enum.TryParse(voiceBindingDTO.Key, out Keys biningKey);
                string bindingVoice = voiceBindingDTO.Voice;
                Hotkey bindingHotkey = new Hotkey(bindingModifierKey, biningKey);
                VoiceBindingEntity voiceBindingEntity = new VoiceBindingEntity(bindingHotkey, bindingVoice);
                voiceBindingEntities.Add(voiceBindingEntity);
            }

            SettingsFile settingsFile = TTSEngine.GetSettings();
            settingsFile.Hotkey = hotkey;
            settingsFile.ShouldSayChangedLanguage = settingsDTO.ShouldSayChangedLanguage;
            settingsFile.VoiceBindings = voiceBindingEntities;
            TTSEngine.UpdateSettings(settingsFile);
            view.Dispose();
        }

        public void OpenAddVoiceBindingView()
        {
            addVoiceBindingController.Open();
        }
    }
}