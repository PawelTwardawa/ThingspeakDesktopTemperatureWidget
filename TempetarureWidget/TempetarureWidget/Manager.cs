using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TempetarureWidget.DTO;
using TempetarureWidget.DTOs;
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget
{
   public class Manager : IDisposable, IManager
    {
        public event Action<string> SetTemperatureLabel;
        //public event Action<string, string, string> SetUpdateDataLabel;
        public event Action<DateTime> SetUpdateDataLabel;
        public event Action<string, string> SetNameLabel;
        public event Action<bool> ShowNoConnIcon;
        public event Action<List<Data<dynamic>>> SetData;

        private int _refreshTime = 2000;
        private Data _data;
        private static GetData _getData;
        private Thread _mainThread;
        private bool _internetConnection = true;
        private int _dataCount = 1;

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

        public Manager(string apiKey, string channel) : this()
        {
            ApiKey = apiKey;
            Channel = channel;
        }


        public async void ChangeSetting(Settings settings)
        {
            _mainThread?.Abort();
            RefreshTime = settings.RefreshTime;
            Field = settings.Field;
            Channel = settings.Channel;
            ApiKey = settings.Api_Key;
            Timezone = settings.Timezone;

            if(settings.ChartSettings != null)
                _dataCount = settings.ChartSettings.NumberOfData;
            _data = (await GetDataAsync(Field)).Item1;
            

            ChannelName = GetChannelName();
            FieldName = GetFieldName(Field);

            SetNameLabel?.Invoke(ChannelName, FieldName);
            if (_mainThread?.IsAlive == false)
                Start();

        }

        private string GetChannelName()
        {
            if(_data != null)
            {
                return _data.Channel.name;
            }
            return null;
        }
        
        private string GetFieldName()
        {
            return GetFieldName(Field);
        }

        private string GetFieldName(Fields field)
        {
            if(_data != null)
            {
                switch(field)
                {
                    case Fields.field1:
                        {
                            return _data.Channel.field1;
                        }
                    case Fields.field2:
                        {
                            return _data.Channel.field2;
                        }
                    case Fields.field3:
                        {
                            return _data.Channel.field3;
                        }
                    case Fields.field4:
                        {
                            return _data.Channel.field4;
                        }
                    case Fields.field5:
                        {
                            return _data.Channel.field5;
                        }
                    case Fields.field6:
                        {
                            return _data.Channel.field6;
                        }
                    case Fields.field7:
                        {
                            return _data.Channel.field7;
                        }
                    case Fields.field8:
                        {
                            return _data.Channel.field8;
                        }
                }
            }
            return null;
        }

        private async Task<(Data, System.Net.HttpStatusCode)> GetDataAsync()
        {
            return await _getData.GetDataAsync<Data>($"https://{host}/channels/{Channel}/feeds.json?api_key={ApiKey}&results=1&timezone={Timezone}");
        }

        private async Task<(Data, System.Net.HttpStatusCode)> GetDataAsync(Fields field)
        {
            return await _getData.GetDataAsync<Data>($"https://{host}/channels/{Channel}/fields/{(int)field}.json?api_key={ApiKey}&results=1&timezone={Timezone}");
        }

        private async Task<(Data, System.Net.HttpStatusCode)> GetDataAsync(Fields field, int count)
        {
            return await _getData.GetDataAsync<Data>($"https://{host}/channels/{Channel}/fields/{(int)field}.json?api_key={ApiKey}&results={count}&timezone={Timezone}");
        }

        private async void GetTemperatureAsync()
        {
            System.Net.HttpStatusCode status;
            (_data, status)= await GetDataAsync(Field, _dataCount);
            //(_data, status) = await getDataAsync(Field);

            if (status.Equals(System.Net.HttpStatusCode.OK))
            {
                ShowNoConnIcon?.Invoke(false);
                
                ChannelName = GetChannelName();
                FieldName = GetFieldName(Field);
                SetNameLabel?.Invoke(ChannelName, FieldName);

                List<Data<dynamic>> dataList = new List<Data<dynamic>>();

                for (int i = 0; i < _data.Feeds.Count; i++)
                {
                    string value = TemperatureFromFieldAsync(_data, i);

                    if (value != null)
                    {
                        string[] dateTime = _data.Feeds[i].created_at.Split('T');
                        string[] time = Regex.Split(dateTime[1], @"(?=[+-])");
                        DateTime date = Convert.ToDateTime(dateTime[0] + " " + time[0]);

                        dataList.Add(new Data<dynamic>(){ date = date, value = value});
                    }
                }
                SetTemperatureLabel?.Invoke(dataList[dataList.Count -1].value);
                SetUpdateDataLabel?.Invoke(dataList[dataList.Count - 1].date);
                SetData?.Invoke(dataList);
            }
            else if(status.Equals(System.Net.HttpStatusCode.ServiceUnavailable))
            {
                ShowNoConnIcon?.Invoke(true);
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

             (_data, status) = await GetDataAsync();

            if (status.Equals(System.Net.HttpStatusCode.OK))
            {
                if (!string.IsNullOrEmpty(_data.Channel.field1))
                    fields.Add(Fields.field1, _data.Channel.field1);
                if (!string.IsNullOrEmpty(_data.Channel.field2))
                    fields.Add(Fields.field2, _data.Channel.field2);
                if (!string.IsNullOrEmpty(_data.Channel.field3))
                    fields.Add(Fields.field3, _data.Channel.field3);
                if (!string.IsNullOrEmpty(_data.Channel.field4))
                    fields.Add(Fields.field4, _data.Channel.field4);
                if (!string.IsNullOrEmpty(_data.Channel.field5))
                    fields.Add(Fields.field5, _data.Channel.field5);
                if (!string.IsNullOrEmpty(_data.Channel.field6))
                    fields.Add(Fields.field6, _data.Channel.field6);
                if (!string.IsNullOrEmpty(_data.Channel.field7))
                    fields.Add(Fields.field7, _data.Channel.field7);
                if (!string.IsNullOrEmpty(_data.Channel.field8))
                    fields.Add(Fields.field8, _data.Channel.field8);
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

        private string TemperatureFromFieldAsync(Data data)
        {
            return TemperatureFromFieldAsync(data, data.Feeds.Count - 1);
        }

        private string TemperatureFromFieldAsync( Data data, int fieldNumber)
        {

            switch (Field)
            {
                case Fields.field1:
                    {

                        if (data.Feeds[fieldNumber].field1 != null)
                            return data.Feeds[fieldNumber].field1.Replace("\r\n", string.Empty);
                        else
                            return data.Feeds[fieldNumber].field1;
                    }
                case Fields.field2:
                    {
                        if (data.Feeds[fieldNumber].field2 != null)
                            return data.Feeds[fieldNumber].field2.Replace("\r\n", string.Empty);
                        else
                            return data.Feeds[fieldNumber].field2;
                    }
                case Fields.field3:
                    {
                        if (data.Feeds[fieldNumber].field3 != null)
                            return data.Feeds[fieldNumber].field3.Replace("\r\n", string.Empty);
                        else
                            return data.Feeds[fieldNumber].field3;
                    }
                case Fields.field4:
                    {
                        if (data.Feeds[fieldNumber].field4 != null)
                            return data.Feeds[fieldNumber].field4.Replace("\r\n", string.Empty);
                        else
                            return data.Feeds[fieldNumber].field4;
                    }
                case Fields.field5:
                    {
                        if (data.Feeds[fieldNumber].field5 != null)
                            return data.Feeds[fieldNumber].field5.Replace("\r\n", string.Empty);
                        else
                            return data.Feeds[fieldNumber].field5;
                    }
                case Fields.field6:
                    {
                        if (data.Feeds[fieldNumber].field6 != null)
                            return data.Feeds[fieldNumber].field6.Replace("\r\n", string.Empty);
                        else
                            return data.Feeds[fieldNumber].field6;
                    }
                case Fields.field7:
                    {
                        if (data.Feeds[fieldNumber].field7 != null)
                            return data.Feeds[fieldNumber].field7.Replace("\r\n", string.Empty);
                        else
                            return data.Feeds[fieldNumber].field7;
                    }
                case Fields.field8:
                    {
                        if (data.Feeds[fieldNumber].field8 != null)
                            return data.Feeds[fieldNumber].field8.Replace("\r\n", string.Empty);
                        else
                            return data.Feeds[fieldNumber].field8;
                    }
                default:
                    {
                        throw new ArgumentNullException(@"Field not initialized");
                    }
            }
        }

        public void Start()
        {
            _mainThread = new Thread(() =>
            {
                while (true)
                {
                    if(!string.IsNullOrWhiteSpace(ApiKey) || !string.IsNullOrWhiteSpace(Channel))
                        GetTemperatureAsync();
                    Thread.Sleep(RefreshTime);
                }
            });

            _mainThread.Start();

        }

        public void Stop()
        {
            _mainThread?.Abort();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
