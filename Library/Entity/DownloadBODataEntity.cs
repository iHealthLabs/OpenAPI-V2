using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library.Entity
{
    [DataContract]
    public class DownloadBODataEntity
    {
        /// <summary>
        /// Oxygen value
        /// </summary>
        [DataMember]
        public double BO { get; set; }
        /// <summary>
        /// Heart rate
        /// </summary>
        [DataMember]
        public double HR { get; set; }
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
    }
}
