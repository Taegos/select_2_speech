using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Select2Speech.Data;
using Select2Speech.Options;
using Select2Speech.SystemTray;

namespace Select2Speech.Controllers {
    public class SystemTrayController
    {
        private SystemTrayView view;
        private SettingsController settingsController;
        private TTSEngine TTSEngine;

        public SystemTrayController(SystemTrayView view, SettingsController settingsController, TTSEngine TTSEngine)
        {
            this.view = view;
            this.settingsController = settingsController;
            this.TTSEngine = TTSEngine;    
            Open();
        }

        public void SetVoice(string voice)
        {
            SettingsFile settingsFile = TTSEngine.GetSettings();
            view.SetMenuItemChecked(settingsFile.Voice, false);
            settingsFile.Voice = voice;
            TTSEngine.UpdateSettings(settingsFile);
            settingsFile = TTSEngine.GetSettings();
            view.SetMenuItemChecked(settingsFile.Voice, true);        
        }

        public void Open()
        {
            string[] installedVoices = TTSEngine.GetInstalledVoices();
            SettingsFile settingsFile = TTSEngine.GetSettings();
            view.Load(installedVoices);
            view.SetMenuItemChecked(settingsFile.Voice, true);
        }

        public void OpenSettings()
        {
            settingsController.Open();
        }

        public void Exit()
        {
            view.Dispose();
            Application.Exit();
        }
    }
}
