using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TempetarureWidget.DTO;
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget
{
   public class Manager : IDisposable, IManager
    {
        public event Action<string> SetTemperatureLabel;
        public event Action<string, string, string> SetUpdataDataLabel;
        public event Action<string, string> SetNameLabel;
        public event Action<bool> ShowNoConnIcon;

        private int _refreshTime = 2000;
        private Data _data;
        private static GetData _getData;
        private Thread mainThread;
        private bool _internetConnection = true;

        private string host = "api.thingspeak.com";

        public string Timezone { get; private set; }
        public string FieldName { get; private set; }
        public string ChannelName { get; private set; }
        public Fields Field { get; private set; }
        public string Channel{ get; private set; }
        public string ApiKey { get; private set; }
        public int RefreshTime
        {
            get
            {
                return _refreshTime;
            }
            private set
            {
                if(value < 1000 || value > 216000000) //second
                {
                    throw new ArgumentException("RefreshTime out of range");
                }
                _refreshTime = value;
            }
        }

        private int _tmpRefreshTime;

        public Manager()
        {
            _getData = new GetData();
        }


        public Manager(Settings settings) : this()
        {
            ChangeSetting(settings);
        }

        public Manager(string api_key, string channel) : this()
        {
            ApiKey = api_key;
            Channel = channel;
        }


        public async void ChangeSetting(Settings settings)
        {
            mainThread?.Abort();
            RefreshTime = settings.refreshTime;
            Field = settings.field;
            Channel = settings.channel;
            ApiKey = settings.api_key;
            Timezone = settings.timezone;

             _data = (await getDataAsync(Field)).Item1;


            ChannelName = channelName();
            FieldName = fieldName(Field);

            SetNameLabel?.Invoke(ChannelName, FieldName);
            if (mainThread?.IsAlive == false)
                Start();

        }

        private string channelName()
        {
            if(_data != null)
            {
                return _data.channel.name;
            }
            return null;
        }
        
        private string fieldName()
        {
            return fieldName(Field);
        }

        private string fieldName(Fields field)
        {
            if(_data != null)
            {
                switch(field)
                {
                    case Fields.field1:
                        {
                            return _data.channel.field1;
                        }
                    case Fields.field2:
                        {
                            return _data.channel.field2;
                        }
                    case Fields.field3:
                        {
                            return _data.channel.field3;
                        }
                    case Fields.field4:
                        {
                            return _data.channel.field4;
                        }
                    case Fields.field5:
                        {
                            return _data.channel.field5;
                        }
                    case Fields.field6:
                        {
                            return _data.channel.field6;
                        }
                    case Fields.field7:
                        {
                            return _data.channel.field7;
                        }
                    case Fields.field8:
                        {
                            return _data.channel.field8;
                        }
                }
            }
            return null;
        }

        private async Task<(Data, System.Net.HttpStatusCode)> getDataAsync()
        {
            return await _getData.GetDataAsync($"https://{host}/channels/{Channel}/feeds.json?api_key={ApiKey}&results=1&timezone={Timezone}");
        }

        private async Task<(Data, System.Net.HttpStatusCode)> getDataAsync(Fields field)
        {
            return await _getData.GetDataAsync($"https://{host}/channels/{Channel}/fields/{(int)field}.json?api_key={ApiKey}&results=1&timezone={Timezone}");
        }

        private async void GetTemperatureAsync()
        {
            System.Net.HttpStatusCode status;

            (_data, status) = await getDataAsync(Field);

            if (status.Equals(System.Net.HttpStatusCode.OK))
            {
                ShowNoConnIcon(false);
                
                ChannelName = channelName();
                FieldName = fieldName(Field);
                SetNameLabel?.Invoke(ChannelName, FieldName);

                string value = temperatureFromFieldAsync(_data);

                if (value != null)
                {
                    SetTemperatureLabel?.Invoke(value);

                    string[] dateTime = _data.feeds[0].created_at.Split('T');
                    string[] time = Regex.Split(dateTime[1], @"(?=[+-])");
                    SetUpdataDataLabel?.Invoke(dateTime[0], time[0], time[1]);
                }
            }
            else if(status.Equals(System.Net.HttpStatusCode.ServiceUnavailable))
            {
                //SetTemperatureLabel?.Invoke("INTERNET CONNECTION ERROR");
                ShowNoConnIcon(true);
            }

            if (!status.Equals(System.Net.HttpStatusCode.OK) && _internetConnection)
            {
                _internetConnection = false;
                Stop();
                _tmpRefreshTime = RefreshTime;
                RefreshTime = 1000;
                Start();
            }
            else if (status.Equals(System.Net.HttpStatusCode.OK) && !_internetConnection)
            {
                _internetConnection = true;
                Stop();
                RefreshTime = _tmpRefreshTime;
                Start();
            }

            GC.Collect(2, GCCollectionMode.Forced);

        }

        public async Task<Dictionary<Fields, string>> AvailableFieldsAsync()
        {
            Dictionary<Fields, string> fields = new Dictionary<Fields, string>();
            System.Net.HttpStatusCode status;

             (_data, status) = await getDataAsync();

            if (status.Equals(System.Net.HttpStatusCode.OK))
            {
                if (!string.IsNullOrEmpty(_data.channel.field1))
                    fields.Add(Fields.field1, _data.channel.field1);
                if (!string.IsNullOrEmpty(_data.channel.field2))
                    fields.Add(Fields.field2, _data.channel.field2);
                if (!string.IsNullOrEmpty(_data.channel.field3))
                    fields.Add(Fields.field3, _data.channel.field3);
                if (!string.IsNullOrEmpty(_data.channel.field4))
                    fields.Add(Fields.field4, _data.channel.field4);
                if (!string.IsNullOrEmpty(_data.channel.field5))
                    fields.Add(Fields.field5, _data.channel.field5);
                if (!string.IsNullOrEmpty(_data.channel.field6))
                    fields.Add(Fields.field6, _data.channel.field6);
                if (!string.IsNullOrEmpty(_data.channel.field7))
                    fields.Add(Fields.field7, _data.channel.field7);
                if (!string.IsNullOrEmpty(_data.channel.field8))
                    fields.Add(Fields.field8, _data.channel.field8);
            }
            else if(status.Equals(System.Net.HttpStatusCode.BadRequest) || status.Equals(System.Net.HttpStatusCode.NotFound))
            {
                fields.Add(Fields.unknown, "not found");
            }
            else
            {
                fields.Add(Fields.unknown, "connection error");
            }

            return fields;
        }

        private string temperatureFromFieldAsync( Data data)
        {

            switch(Field)
            {
                case Fields.field1:
                    {

                        if (data.feeds[0].field1 != null)
                            return data.feeds[0].field1.Replace("\r\n", string.Empty);
                        else
                            return data.feeds[0].field1;
                    }
                case Fields.field2:
                    {
                        if (data.feeds[0].field2 != null)
                            return data.feeds[0].field2.Replace("\r\n", string.Empty);
                        else
                            return data.feeds[0].field2;
                    }
                case Fields.field3:
                    {
                        if (data.feeds[0].field3 != null)
                            return data.feeds[0].field3.Replace("\r\n", string.Empty);
                        else
                            return data.feeds[0].field3;
                    }
                case Fields.field4:
                    {
                        if (data.feeds[0].field4 != null)
                            return data.feeds[0].field4.Replace("\r\n", string.Empty);
                        else
                            return data.feeds[0].field4;
                    }
                case Fields.field5:
                    {
                        if (data.feeds[0].field5 != null)
                            return data.feeds[0].field5.Replace("\r\n", string.Empty);
                        else
                            return data.feeds[0].field5;
                    }
                case Fields.field6:
                    {
                        if (data.feeds[0].field6 != null)
                            return data.feeds[0].field6.Replace("\r\n", string.Empty);
                        else
                            return data.feeds[0].field6;
                    }
                case Fields.field7:
                    {
                        if (data.feeds[0].field7 != null)
                            return data.feeds[0].field7.Replace("\r\n", string.Empty);
                        else
                            return data.feeds[0].field7;
                    }
                case Fields.field8:
                    {
                        if (data.feeds[0].field8 != null)
                            return data.feeds[0].field8.Replace("\r\n", string.Empty);
                        else
                            return data.feeds[0].field8;
                    }
                default:
                    {
                        throw new ArgumentNullException("Field not initialized");
                    }
            }
        }

        public void Start()
        {
            mainThread = new Thread(new ThreadStart( () =>
            {
                while (true)
                {
                    if(!string.IsNullOrWhiteSpace(ApiKey) || !string.IsNullOrWhiteSpace(Channel))
                        GetTemperatureAsync();
                    Thread.Sleep(RefreshTime);
                }
            }));

            mainThread.Start();

        }

        public void Stop()
        {
            mainThread?.Abort();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
