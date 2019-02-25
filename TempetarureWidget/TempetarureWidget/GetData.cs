using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Json;
using System.Runtime.Serialization.Json;
using TempetarureWidget.DTO;
using System.IO;

namespace TempetarureWidget
{
    class GetData
    {

        public async Task<Data> GetDataAsync(string uri)
        {
            var clint = new HttpClient();
            Stream content = await clint.GetStreamAsync(uri);
            DataContractJsonSerializer serialize = new DataContractJsonSerializer(typeof(Data));
            return await Task.Run(() => serialize.ReadObject(content) as Data);
        }
    }
}
