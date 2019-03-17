using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempetarureWidget.SettingsApp
{
    public class Settings
    {
        internal readonly int _id;
        public string api_key;
        public string channel;
        public int refreshTime;
        public bool dateVisable;
        public bool nameVisable;
        public bool channelNameVisable;
        public bool fieldNameVisable;
        public bool runWithWindows;
        public Fields field;
        public Color backColor;
        public Color textColor;
        public float opacity;
        public float temperatureSize;
        public float dateSize;
        public Deegree deegree;
        public string unit;
        public Point location;
        public string timezone;
        public bool publicChannel;

        internal bool IsEmpty
        {
            get
            {
                if (string.IsNullOrWhiteSpace(api_key) || string.IsNullOrWhiteSpace(channel))
                    return true;
                else
                    return false;
            }
        }

        internal bool IsEmptyChannel
        {
            get
            {
                if (string.IsNullOrWhiteSpace(channel))
                    return true;
                else
                    return false;
            }
        }

        public Settings()
        {
            int uid = SettingsManager.GetUniqeId();

            _id = uid;
        }

        public void Save()
        {
            SettingsManager.Save(_id, this);
             
        }
    }
}
