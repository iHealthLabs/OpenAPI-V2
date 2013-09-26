using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library.Entity
{
    [DataContract]
    public class DownloadUserInfoDataEntity
    {
        [DataMember]
        public string userid { get; set; }
        [DataMember]
        public string nickname { get; set; }
        [DataMember]
        public string gender { get; set; }
        [DataMember]
        public double height { get; set; }
        [DataMember]
        public double weight { get; set; }
        [DataMember]
        public long dateofbirth { get; set; }
        [DataMember]
        public string logo { get; set; }
        [DataMember]
        public int UserHeightUnit { get; set; }
        [DataMember]
        public int UserWeightUnit { get; set; }
    }
}

