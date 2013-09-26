using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library.Entity
{
    [DataContract]
    public class DownloadBGDataEntity
    {
        /// <summary>
        /// Blood glucose value
        /// </summary>
        [DataMember]
        public double BG { get; set; }
        /// <summary>
        /// Dinner time
        /// </summary>
        [DataMember]
        public string DinnerSituation { get; set; }
        /// <summary>
        /// Medication time
        /// </summary>
        [DataMember]
        public string DrugSituation { get; set; }
        /// <summary>
        /// Measure time
        /// </summary>
        [DataMember]
        public long MDate { get; set; }
        /// <summary>
        /// note string 
        /// </summary>
        [DataMember]
        public string Note { get; set; }
        /// <summary>
        /// Latitude
        /// </summary>
        [DataMember]
        public double Lat { get; set; }
        /// <summary>
        /// Longitude
        /// </summary>
        [DataMember]
        public double Lon { get; set; }
        /// <summary>
        /// Data only Serial number
        /// </summary>
        [DataMember]
        public string DataID { get; set; }
    }
}
