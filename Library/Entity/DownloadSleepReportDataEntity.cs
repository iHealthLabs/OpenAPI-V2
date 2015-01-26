using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library.Entity
{
    [DataContract]
    public class DownloadSleepReportDataEntity
    {
        /// <summary>
        /// Sleep efficiency
        /// </summary>
        [DataMember]
        public double SleepEfficiency { get; set; }
        /// <summary>
        /// Sleep duration
        /// </summary>
        [DataMember]
        public double FallSleep { get; set; }
        /// <summary>
        /// start time
        /// </summary>
        [DataMember]
        public long StartTime { get; set; }
        /// <summary>
        /// end time
        /// </summary>
        [DataMember]
        public long EndTime { get; set; }
        /// <summary>
        /// note
        /// </summary>
        [DataMember]
        public string Note { get; set; }
        /// <summary>
        /// Longitude
        /// </summary>
        [DataMember]
        public double Lon { get; set; }
        /// <summary>
        /// Latitude
        /// </summary>
        [DataMember]
        public double Lat { get; set; }
        /// <summary>
        /// Data only Serial number
        /// </summary>
        [DataMember]
        public string DataID { get; set; }
        /// <summary>
        /// Sleep duration
        /// </summary>
        [DataMember]
        public double HoursSlept { get; set; }
        /// <summary>
        /// The length of time awake
        /// </summary>
        [DataMember]
        public double Awake { get; set; }
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
        /// <summary>
        /// Time zone of measurement location
        /// </summary>
        [DataMember]
        public string TimeZone { get; set; }

    }
}
