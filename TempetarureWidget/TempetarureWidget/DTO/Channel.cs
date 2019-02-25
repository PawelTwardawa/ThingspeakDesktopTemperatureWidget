using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TempetarureWidget.DTO
{
    [DataContract]
    public class Channel
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string latitude { get; set; }
        [DataMember]
        public string longitude { get; set; }
        [DataMember]
        public string field1 { get; set; }
        [DataMember]
        public string field2 { get; set; }
        [DataMember]
        public string field3 { get; set; }
        [DataMember]
        public string field4 { get; set; }
        [DataMember]
        public string field5 { get; set; }
        [DataMember]
        public string field6 { get; set; }
        [DataMember]
        public string field7 { get; set; }
        [DataMember]
        public string field8 { get; set; }
        [DataMember]
        public string created_at { get; set; }
        [DataMember]
        public string updated_at { get; set; }
        [DataMember]
        public int last_entry_id { get; set; }
    }
}
