using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TempetarureWidget.SettingsApp
{
    public class SettingsManager
    {
        private static readonly string FILENAME = Path.Combine(Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments), Application.ProductName, "settings.json");
        private static AppSettings appSettings;
        private static int _uid = 0;

        public static int GetUniqeId()
        {
            return _uid++;
        }

        public static void RemoveSettings(Settings settings)
        {
            appSettings.settings.Remove(settings);

            Save();
        }

        public static void Save(int id, Settings settings)
        {
            for(int i = 0; i <appSettings.settings.Count; i++)
            {
                if(appSettings.settings[i].id == id)
                {
                    appSettings.settings[i] = settings;
                    Save();
                    return;
                }
            }
            appSettings.settings.Add(settings);
            Save();
        }

        public static void Save()
        {
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Application.ProductName));
            File.WriteAllText(FILENAME, JsonConvert.SerializeObject(appSettings));
        }

        public ref AppSettings Load()
        {
            if (File.Exists(FILENAME))
            {
                appSettings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(FILENAME));
                return ref appSettings;
                
            }
            appSettings = new AppSettings();
            return ref appSettings;
        }
    }
}
