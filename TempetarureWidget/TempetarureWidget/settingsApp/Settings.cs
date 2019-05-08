using System.Drawing;

namespace TempetarureWidget.SettingsApp
{
    public class Settings
    {
        internal readonly int id;
        public string Api_Key { get; set; }
        public string Channel { get; set; }
        public int RefreshTime { get; set; }
        public bool DateVisable { get; set; }
        public bool NameVisable { get; set; }
        public bool ChannelNameVisable { get; set; }
        public bool FieldNameVisable { get; set; }
        //public bool runWithWindows;
        public Fields Field { get; set; }
        public Color BackColor { get; set; }
        public Color TextColor { get; set; }
        public float Opacity { get; set; }
        public float TemperatureSize { get; set; }
        public float DateSize { get; set; }
        public Deegree Deegree { get; set; }
        public string Unit { get; set; }
        public Point Location { get; set; }
        public string Timezone { get; set; }
        public bool PublicChannel { get; set; }
        public ChartSettings ChartSettings { get; set; }

        internal bool IsEmpty
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Api_Key) || string.IsNullOrWhiteSpace(Channel))
                    return true;
                else
                    return false;
            }
        }

        internal bool IsEmptyChannel
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Channel))
                    return true;
                else
                    return false;
            }
        }

        public Settings()
        {
            int uid = SettingsManager.GetUniqeId();

            id = uid;
        }

        public void Save()
        {
            SettingsManager.Save(id, this);
             
        }
    }
}
