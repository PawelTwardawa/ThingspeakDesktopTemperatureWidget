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
using System.Net;

namespace TempetarureWidget
{
    class GetData
    {
        public async Task<(Data, HttpStatusCode)> GetDataAsync(string uri)
        {
            GC.Collect(2, GCCollectionMode.Forced);

            var request = WebRequest.CreateHttp(uri);
            try
            {
                using (var response = await request.GetResponseAsync())
                using (var content = response.GetResponseStream())
                {
                    int status = (int)(response as HttpWebResponse).StatusCode;
                    DataContractJsonSerializer serialize = new DataContractJsonSerializer(typeof(Data));
                    return await Task.Run(() => (serialize.ReadObject(content) as Data, (response as HttpWebResponse).StatusCode));
                }
            }
            catch (WebException ex)
            {
                using (HttpWebResponse response = (HttpWebResponse) ex.Response)
                {
                    if (response != null)
                    {
                        //int status = (int)response.StatusCode;
                        return (null, response.StatusCode);
                    }
                    else
                    {
                        return (null, HttpStatusCode.ServiceUnavailable);
                    }

                }
            }  
        }
    }
}
