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
        //private const string FILENAME = "settings.json";

        private static AppSettings appSettings;
        private static int _uid = 0;

        public static void AddSettings(ref Settings settings)
        {
           
        }

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
            if (id >= appSettings.settings.Count)
                appSettings.settings.Add(settings);
            else
                appSettings.settings[id] = settings;
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
