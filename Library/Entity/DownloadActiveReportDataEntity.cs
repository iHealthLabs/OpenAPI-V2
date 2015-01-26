using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library.Entity
{
    [DataContract]
    public class DownloadActiveReportDataEntity
    {
        /// <summary>
        /// Steps
        /// </summary>
        [DataMember]
        public double Steps { get; set; }
        /// <summary>
        /// Distance
        /// </summary>
        [DataMember]
        public double DistanceTraveled { get; set; }
        /// <summary>
        /// Measure time
        /// </summary>
        [DataMember]
        public long MDate { get; set; }
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
        /// Of the total calories consumed
        /// </summary>
        [DataMember]
        public double Calories { get; set; }
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
        /// UserID
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
