using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TempetarureWidget.SettingsApp
{
    //public class SettingsManager<T> where T : new()
    //{
    //    private const string FILENAME = "settings.json";

    //    public void Save()
    //    {
    //        File.WriteAllText(FILENAME, JsonConvert.SerializeObject(this));
    //    }

    //    public static T Load()
    //    {
    //        if (File.Exists(FILENAME))
    //        {
    //             return JsonConvert.DeserializeObject<T>(File.ReadAllText(FILENAME));
    //        }

    //        return new T();
    //    }
    //}

    public class SettingsManager
    {
        private const string FILENAME = "settings.json";
        private static AppSettings appSettings;
        private static int _uid = 0;

        public static void AddSettings(ref Settings settings)
        {
           
        }

        public static int GetUniqeId()
        {
            //for (int i = 0; i < appSettings.settings.Length; i++)
            //{
            //    if (appSettings.settings[i] == null)
            //    {
            //        return i;
            //    }
            //}



            return _uid++;
        }

        public static void RemoveSettings(Settings settings)
        {
            //for(int i = 0; i < appSettings.settings.Count; i++)
            //{
               // if (appSettings.settings[i].Equals(settings))
                   // appSettings.settings[i] = null;
                appSettings.settings.Remove(settings);
            //}

            Save();
        }

        public static void Save(int id, Settings settings)
        {
            //appSettings.settings.Insert(id, settings);
            //if (appSettings.settings.ElementAtOrDefault(id) != null)
            //{
            //    appSettings.settings[id] = settings;
            //}
            if (id >= appSettings.settings.Count)
                appSettings.settings.Add(settings);
            else
                appSettings.settings[id] = settings;
            Save();
        }

        public static void Save()
        {
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
