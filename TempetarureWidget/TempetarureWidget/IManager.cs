using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget
{
    public interface IManager
    {
        //bool InternetConnection { get; }

        event Action<string, string> SetNameLabel;
        event Action<string> SetTemperatureLabel;
        event Action<string, string, string> SetUpdataDataLabel;
        event Action<bool> ShowNoConnIcon;

        Task<Dictionary<Fields, string>> AvailableFieldsAsync();
        void ChangeSetting(Settings settings);
        void Start();
        void Stop();
    }
}