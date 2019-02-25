using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempetarureWidget.SettingsApp
{
    public class AppSettings : SettingsManager<AppSettings>
    {
        public string api_key;
        public string channel;
        public string refreshTime;
        public bool dataVisable;
        public Fields field;
    }
}
