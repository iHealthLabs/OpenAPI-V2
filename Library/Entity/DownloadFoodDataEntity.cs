using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library.Entity
{
    [DataContract]
    public class DownloadFoodDataEntity
    {
        /// <summary>
        /// Food Name
        /// </summary>
        [DataMember]
        public string FoodName { get; set; }
        /// <summary>
        /// Eating Time
        /// </summary>
        [DataMember]
        public long MDate { get; set; }
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
        /// DataId
        /// </summary>
        [DataMember]
        public string DataID { get; set; }
        /// <summary>
        /// Food total Calories
        /// </summary>
        [DataMember]
        public double Calories { get; set; }
        /// <summary>
        /// Food Amount
        /// </summary>
        [DataMember]
        public double Amount { get; set; }
        /// <summary>
        /// Time Zone
        /// </summary>
        [DataMember]
        public double TimeZone { get; set; }
        /// <summary>
        /// Food Kind
        /// </summary>
        [DataMember]
        public string FoodKind { get; set; }
        /// <summary>
        /// Last change time
        /// </summary>
        [DataMember]
        public long LastChangeTime { get; set; }
        ///// <summary>
        ///// UserId
        ///// </summary>
        [DataMember]
        public string userid { get; set; }
    }
}
