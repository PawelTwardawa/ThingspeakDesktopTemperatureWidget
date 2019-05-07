using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempetarureWidget.DTO;
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget
{
    public interface IManager
    {
        //bool InternetConnection { get; }

        event Action<string, string> SetNameLabel;
        event Action<string> SetTemperatureLabel;
        event Action<DateTime> SetUpdateDataLabel;
        event Action<bool> ShowNoConnIcon;
        event Action<List<Data<dynamic>>> SetData;

        Task<Dictionary<Fields, string>> AvailableFieldsAsync();
        void ChangeSetting(Settings settings);
        void Start();
        void Stop();
    }
}