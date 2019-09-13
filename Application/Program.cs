using System;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.Speech.Synthesis;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using Hotkeys;
using Select2Speech.Controllers;
using Select2Speech.Data;
using Select2Speech.Options;
using Select2Speech.Properties;
using Select2Speech.SystemTray;
using Select2Speech.Views;

namespace Select2Speech
{
    static class Program
	{
        /// <summary>
        /// Main entry, returns if already running.
        /// </summary>
	    [STAThread]
	    static void Main()
	    {
         //   string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
	        //using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
	        //{
	        //    if (!mutex.WaitOne(0, false))
	        //    {
	        //        return;
	        //    }
	        //}
	        Application.EnableVisualStyles();
	        Application.SetCompatibleTextRenderingDefault(false);
	        Application.Run(new Select2SpeechApplicationContext());
	    }

	    /// <summary>
	    /// The application context that is run from Main. Creates default settings and sets up the MVC relations.
	    /// </summary>
        public class Select2SpeechApplicationContext : ApplicationContext {

	        public Select2SpeechApplicationContext()
	        {	    
	            TTSEngine TTSEngine = new TTSEngine();
	            SettingsController settingsController = new SettingsController(TTSEngine);

                AddVoiceBindingController addVoiceBindingController = new AddVoiceBindingController(settingsController, TTSEngine);
                settingsController.SetAddVoiceBindingController(addVoiceBindingController);

                SystemTrayView systemTrayView = new SystemTrayView();
                SystemTrayController systemTrayController = new SystemTrayController(systemTrayView, settingsController, TTSEngine);
                systemTrayView.SetController(systemTrayController);
            }

            /// <summary>
            /// Checks for various edges cases and loads the current settings.
            /// </summary>
            /// <seealso cref="EvalShouldUseDefaultSettings"/>
            /// <seealso cref="EvalActiveVoiceUninstalled"/>
            /// <seealso cref="LoadSettings"/>
            /// <param name="speechEngine">
            /// The speech engine.
            /// </param>
            /// <param name="settingsRepo">
            /// The settings repo.
            /// </param>
	        //private void InitializeApplication(VoiceSelectionModel voiceSelectionModel, OptionsFormModel optionsModel, SettingsRepo settingsRepo)
	        //{
         //       EvalUseDefualtSettings(voiceSelectionModel, optionsModel, settingsRepo);
         //       EvalActiveVoiceUninstalled(voiceSelectionModel);
         //       LoadSettings(voiceSelectionModel, optionsModel, settingsRepo);
	        //}            

         //   /// <summary>
         //   /// Creates default settings if the settings file does not exist.
         //   /// </summary>
         //   /// <param name="speechEngine">
         //   /// The speech engine.
         //   /// </param>
         //   /// <param name="settingsRepo">
         //   /// The settings repo.
         //   /// </param>
	        //private void EvalUseDefualtSettings(VoiceSelectionModel voiceSelectionModel, OptionsFormModel optionsModel, SettingsRepo settingsRepo)
	        //{
	        //    if (!settingsRepo.SettingsExists())
	        //    {
	        //        settingsRepo.Create(new SettingsFile());
	        //        Hotkey defaultHotkey = new Hotkey(ModifierKey.CTRL, Keys.Space);
	        //        string[] installedVoices = voiceSelectionModel.GetInstalledVoices();
	        //        if (installedVoices.Length >= 0) {
	        //            voiceSelectionModel.SetVoice(installedVoices[0]);
	        //        }
	        //        optionsModel.SetHotkey(defaultHotkey);
         //       }
         //   }

         //   /// <summary>
         //   /// Resets the active voice in the settings file if it is not installed anymore.
         //   /// </summary>
         //   /// <param name="speechEngine">
         //   /// The speech engine.
         //   /// </param>
         //   /// <param name="settingsRepo">
         //   /// The settings repo.
         //   /// </param>
	        //private void EvalActiveVoiceUninstalled(VoiceSelectionModel voiceSelectionModel)
         //   {                
         //       string selectedVoice = voiceSelectionModel.GetSelectedtVoice();
         //       string[] installedVoices = voiceSelectionModel.GetInstalledVoices();
         //       if (installedVoices.Length > 0 && !installedVoices.Contains(selectedVoice))
         //       {
         //           voiceSelectionModel.SetVoice(installedVoices[0]);
         //       }
         //   }

	        //private void LoadSettings(VoiceSelectionModel voiceSelectionModel, OptionsFormModel optionsModel,
	        //    SettingsRepo settingsRepo)
	        //{
	        //    SettingsFile settingsFile = settingsRepo.Read();
         //       voiceSelectionModel.SetVoice(settingsFile.Voice);
         //       optionsModel.SetHotkey(settingsFile.Hotkey);
	        //}

        }
    }
}