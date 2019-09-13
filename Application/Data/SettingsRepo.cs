using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotkeys;
using Newtonsoft.Json;

namespace Select2Speech.Data {
    public class SettingsRepo
    {
        private const string SETTINGS_PATH = "select2speech_settings.json";
        private IsolatedStorageFile isoStorage;

        /// <summary>
        /// Sets member variables.
        /// </summary>
        public SettingsRepo()
        {
            isoStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
        }

        /// <summary>
        /// Does the settings file exists?
        /// </summary>
        /// <returns>
        /// A bool indicating if the settings file exists.
        /// </returns>
        public bool SettingsExists()
        {
            return isoStorage.FileExists(SETTINGS_PATH);
        }

        /// <summary>
        /// Serializes a settings file in to isolated storage.
        /// </summary>
        /// <param name="settings">
        /// The settings file.
        /// </param>
        public void Create(SettingsFile settingsFile)
        {
            using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(SETTINGS_PATH, FileMode.CreateNew, isoStorage)) {
                using (StreamWriter writer = new StreamWriter(isoStream)) {
                    string json = JsonConvert.SerializeObject(settingsFile);
                    writer.Write(json);
                }
            }
        }

        /// <summary>
        /// Deserialzes the settings file and returns it.
        /// </summary>
        /// <returns>
        /// The settings file.
        /// </returns>
        public SettingsFile Read()
        {
            using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(SETTINGS_PATH, FileMode.Open, isoStorage)) {                
                using (StreamReader reader = new StreamReader(isoStream)) {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<SettingsFile>(json);
                }
            }
        }

        /// <summary>
        /// Writes changes to an already existing settings file.
        /// </summary>
        /// <param name="settings">
        /// The settings file.
        /// </param>
        public void Update(SettingsFile settingsFile)
        {
            using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(SETTINGS_PATH, FileMode.Truncate, isoStorage)) {
                using (StreamWriter writer = new StreamWriter(isoStream)) {
                    string json = JsonConvert.SerializeObject(settingsFile);
                    writer.Write(json);
                }
            }
        }
    }
}
