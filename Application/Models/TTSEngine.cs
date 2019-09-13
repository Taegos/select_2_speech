using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using Hotkeys;
using Microsoft.Speech.Synthesis;
using Select2Speech.Data;

namespace Select2Speech {

    /// <summary>
    /// Class that contains the core TTS functionality.
    /// </summary>

    public class TTSEngine
    {
        private SpeechSynthesizer speechSynthesizer;
        private HotkeyRegistry hotkeyRegistry;
        private InputSimulator inputSimulator;
        private SettingsRepo settingsRepo;
        private string currentText;

        /// <summary>
        /// Sets up member variables.
        /// </summary>
        public TTSEngine()
        {
            speechSynthesizer = new SpeechSynthesizer();
            hotkeyRegistry = new HotkeyRegistry();
            inputSimulator = new InputSimulator();
            settingsRepo = new SettingsRepo();
            speechSynthesizer.SetOutputToDefaultAudioDevice();
            if (!settingsRepo.SettingsExists()) {
                string[] installedVoices = GetInstalledVoices();
                if (installedVoices.Length == 0) {
                    throw new DependentPlatformMissingException("No installed voices found.");
                }
                settingsRepo.Create(new SettingsFile(new Hotkey(ModifierKey.CTRL, Keys.Space), installedVoices[0], true, new List<VoiceBindingEntity>()));
            }
            ReloadSettings();
        }

        public void UpdateSettings(SettingsFile settingsFile) {
            ValidateSettings(settingsFile);
            settingsRepo.Update(settingsFile);
            ReloadSettings();
        }

        public SettingsFile GetSettings()
        {
            return settingsRepo.Read();
        }

        private void ReloadSettings() {            
            hotkeyRegistry.UnregisterAll();
            SettingsFile settingsFile = settingsRepo.Read();
            hotkeyRegistry.Register(settingsFile.Hotkey, ActivateHighlightedTTS);
            foreach (VoiceBindingEntity voiceBindingEntity in settingsFile.VoiceBindings) {
                hotkeyRegistry.Register(voiceBindingEntity.Hotkey, () => { ChangeVoice(voiceBindingEntity.Voice) ;});
            }
            SetVoice(settingsFile.Voice);
        }

        private void ChangeVoice(string voice)
        {          
            SettingsFile settingsFile = GetSettings();
            settingsFile.Voice = voice;
            UpdateSettings(settingsFile);
            if (settingsFile.ShouldSayChangedLanguage)
            {
                Speak(speechSynthesizer.Voice.Culture.NativeName);
            }
        }

        private void SetVoice(string voice)
        {
            string[] installedVoices = GetInstalledVoices();
            if (!installedVoices.Contains(voice)) {
                throw new ArgumentException("That voice is not installed on the system.");
            }
            speechSynthesizer.SelectVoice(voice);
        }

        /// <summary>
        /// Gets the installed voices on the system.
        /// </summary>
        /// <returns>
        /// An array containing the installed voices.
        /// </returns>
        public string[] GetInstalledVoices()
        {
            ReadOnlyCollection<InstalledVoice> installedVoices;
            try
            {
                installedVoices = speechSynthesizer.GetInstalledVoices();
            }
            catch (NullReferenceException)
            {
                return new string[] { };
            }
            catch (NotSupportedException)
            {
                return new string[] { };
            }
            string[] voices = new string[installedVoices.Count];
            for (int i = 0; i < installedVoices.Count; i++) {
                voices[i] = installedVoices[i].VoiceInfo.Name;
            }
            return voices;
        }

        /// <summary>
        /// Starts reading the highlighted text, if the speaker is reading it stops.
        /// </summary>
        private void ActivateHighlightedTTS() {
            inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C).Sleep(50);
            string highlightedText = Clipboard.GetText(TextDataFormat.Text);
            if (currentText != highlightedText || speechSynthesizer.State == SynthesizerState.Ready)
            {
                Speak(highlightedText);
            }
            else
            {
                speechSynthesizer.SpeakAsyncCancelAll();
            }
            currentText = highlightedText;
        }

        private void Speak(string text)
        {
            if (speechSynthesizer.State == SynthesizerState.Speaking)
            {
                speechSynthesizer.SpeakAsyncCancelAll();
            }
            speechSynthesizer.SpeakAsync(text);
        }

        private void ValidateSettings(SettingsFile settingsFile) {

        }
    }
}
