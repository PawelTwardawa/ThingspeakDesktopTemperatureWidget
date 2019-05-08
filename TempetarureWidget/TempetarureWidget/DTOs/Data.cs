using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TempetarureWidget.DTO;

namespace TempetarureWidget.DTOs
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
        public Channel Channel { get; set; }
        [DataMember]
        public List<Feed> Feeds { get; set; }
    }
}
