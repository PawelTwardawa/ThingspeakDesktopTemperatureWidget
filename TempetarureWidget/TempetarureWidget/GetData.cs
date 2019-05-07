using System;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace TempetarureWidget
{
    class GetData
    {
        //public async Task<(Data, HttpStatusCode)> GetDataAsync(string uri)
        public async Task<(T, HttpStatusCode)> GetDataAsync<T>(string uri)
        {
            GC.Collect(2, GCCollectionMode.Forced);

            var request = WebRequest.CreateHttp(uri);
            try
            {
                using (var response = await request.GetResponseAsync())
                using (var content = response.GetResponseStream())
                using (var stream = new StreamReader(content ?? throw new NullReferenceException()))
                {
                    return await Task.Run(() => (JsonConvert.DeserializeObject<T>(stream.ReadToEnd()), ((HttpWebResponse) response).StatusCode));
                }
            }
            catch (WebException ex)
            {
                using (HttpWebResponse response = (HttpWebResponse) ex.Response)
                {
                    if (response != null)
                    {
                        return (default(T), response.StatusCode);
                    }
                    else
                    {
                        return (default(T), HttpStatusCode.ServiceUnavailable);
                    }

                }
            }  
        }
    }
}
