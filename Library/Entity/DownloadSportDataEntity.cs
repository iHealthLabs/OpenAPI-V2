using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library.Entity
{
    public class DownloadSportDataEntity
    {
        /// <summary>
        /// Sport Name
        /// </summary>
        [DataMember]
        public string SportName { get; set; }
        /// <summary>
        /// Sport Start Time
        /// </summary>
        [DataMember]
        public long SportStartTime { get; set; }
        /// <summary>
        /// Sport End Time
        /// </summary>
        [DataMember]
        public long SportEndTime { get; set; }
        /// <summary>
        ///Time Zone
        /// </summary>
        [DataMember]
        public double TimeZone { get; set; }
        /// <summary>
        /// Lon
        /// </summary>
        [DataMember]
        public double Lon { get; set; }
        /// <summary>
        /// Lat
        /// </summary>
        [DataMember]
        public double Lat { get; set; }
        /// <summary>
        /// DataID
        /// </summary>
        [DataMember]
        public string DataID { get; set; }
        /// consumption of Calories 
        /// </summary>
        [DataMember]
        public double Calories { get; set; }
        /// <summary>
        /// Last Change Time
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
