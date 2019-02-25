using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TempetarureWidget.DTO;

namespace TempetarureWidget
{
   public class Manager : IManager
    {
        public event Action<string> SetTemperatureLabel;
        public event Action<string> setUpdataDataLabel;

        private int _refreshTime = 2000;

        public Fields Field { get; set; }
        public string Channel{ get; set; }
        public string ApiKey { get; set; }
        public int RefreshTime
        {
            get
            {
                return _refreshTime;
            }
            set
            {
                if(value < 1000 || value > 216000000) //second
                {
                    throw new ArgumentException("RefreshTime out of range");
                }
                _refreshTime = value;
            }
        }

        private static  GetData _getData;

        public Manager()
        {
            _getData = new GetData();
        }

        private async Task<Data> getDataAsync()
        {
            return await _getData.GetDataAsync($"https://api.thingspeak.com/channels/{Channel}/feeds.json?api_key={ApiKey}&results=1");
        }

        public async void GetTemperatureAsync()
        {

            Data data = await getDataAsync();

            SetTemperatureLabel.Invoke(temperatureFromFieldAsync(data));
            setUpdataDataLabel.Invoke(data.feeds[0].created_at);

        }

        public async Task<Dictionary<Fields, string>> AvailableFieldsAsync()
        {
            Dictionary<Fields, string> fields = new Dictionary<Fields, string>();

            Data data = await getDataAsync();

            if (!string.IsNullOrEmpty(data.channel.field1))
                fields.Add(Fields.field1, data.channel.field1);
            if (!string.IsNullOrEmpty(data.channel.field2))
                fields.Add(Fields.field2, data.channel.field2);
            if (!string.IsNullOrEmpty(data.channel.field3))
                fields.Add(Fields.field3, data.channel.field3);
            if (!string.IsNullOrEmpty(data.channel.field4))
                fields.Add(Fields.field4, data.channel.field4);
            if (!string.IsNullOrEmpty(data.channel.field5))
                fields.Add(Fields.field5, data.channel.field5);
            if (!string.IsNullOrEmpty(data.channel.field6))
                fields.Add(Fields.field6, data.channel.field6);
            if (!string.IsNullOrEmpty(data.channel.field7))
                fields.Add(Fields.field7, data.channel.field7);
            if (!string.IsNullOrEmpty(data.channel.field8))
                fields.Add(Fields.field8, data.channel.field8);

            return fields;
        }

        private string temperatureFromFieldAsync( Data data)
        {

            switch(Field)
            {
                case Fields.field1:
                    {
                        return data.feeds[0].field1;
                    }
                case Fields.field2:
                    {
                        return data.feeds[0].field2;
                    }
                case Fields.field3:
                    {
                        return data.feeds[0].field3;
                    }
                case Fields.field4:
                    {
                        return data.feeds[0].field4;
                    }
                case Fields.field5:
                    {
                        return data.feeds[0].field5;
                    }
                case Fields.field6:
                    {
                        return data.feeds[0].field6;
                    }
                case Fields.field7:
                    {
                        return data.feeds[0].field7;
                    }
                case Fields.field8:
                    {
                        return data.feeds[0].field8;
                    }
                default:
                    {
                        throw new ArgumentNullException("Field must be initialized");
                    }
            }
        }

        public void Start()
        {
            Thread thread = new Thread(new ThreadStart( () =>
            {
                while (true)
                {
                    if(!string.IsNullOrWhiteSpace(ApiKey) || !string.IsNullOrWhiteSpace(Channel))
                        GetTemperatureAsync();
                    Thread.Sleep(_refreshTime);
                }
            }));

            thread.Start();

        }
    }
}
