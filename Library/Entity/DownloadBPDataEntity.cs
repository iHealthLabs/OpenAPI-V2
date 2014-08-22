using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library
{
    [DataContract]
    public class DownloadBPDataEntity
    {
        /// <summary>
        /// BP level
        /// </summary>
        [DataMember]
        public int BPL { get; set; }
        /// <summary>
        /// HP
        /// </summary>
        [DataMember]
        public double HP { get; set; }
        /// <summary>
        /// HR
        /// </summary>
        [DataMember]
        public int HR { get; set; }
        /// <summary>
        /// IsArr
        /// </summary>
        [DataMember]
        public int IsArr { get; set; }
        /// <summary>
        /// LP
        /// </summary>
        [DataMember]
        public double LP { get; set; }
        /// <summary>
        /// Lat
        /// </summary>
        [DataMember]
        public double Lat { get; set; }
        /// <summary>
        /// Lon
        /// </summary>
        [DataMember]
        public double Lon { get; set; }
        /// <summary>
        /// Data ID
        /// </summary>
        [DataMember]
        public string DataID { get; set; }
        /// <summary>
        /// Measure date
        /// </summary>
        [DataMember]
        public long MDate { get; set; }
        /// <summary>
        /// Note
        /// </summary>
        [DataMember]
        public string Note { get; set; }
        /// <summary>
        /// Last change time
        /// </summary>
        [DataMember]
        public long LastChangeTime { get; set; }
        /// <summary>
        /// Data Source the value is "Manual" or "FromDevice"
        /// </summary>
        [DataMember]
        public string DataSource { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        [DataMember]
        public string userid { get; set; }
    }
}
