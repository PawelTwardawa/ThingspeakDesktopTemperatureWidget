using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TempetarureWidget.DTO
{
    public struct Data<T>
    {
        public T value;
        public DateTime date;
    }

    [DataContract]
    class Data
    {
        [DataMember]
        public Channel channel { get; set; }
        [DataMember]
        public List<Feed> feeds { get; set; }
    }
}
