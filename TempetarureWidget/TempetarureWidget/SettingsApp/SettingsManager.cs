using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TempetarureWidget.SettingsApp
{
    public class SettingsManager<T> where T : new()
    {
        private const string FILENAME = "settings.json";

        public void Save()
        {
            File.WriteAllText(FILENAME, JsonConvert.SerializeObject(this));
        }

        public static T Load()
        {
            if(File.Exists(FILENAME))
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(FILENAME));
            }

            return new T();
        }
    }
}
