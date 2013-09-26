using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library.Entity
{
    [DataContract]
    public class DownloadActiveReportDataResultEntity
    {
        public DownloadActiveReportDataResultEntity() { }
        /// <summary>
        /// The page data
        /// </summary>
        [DataMember]
        public List<DownloadActiveReportDataEntity> ARDataList { get; set; }
        /// <summary>
        /// Current Total
        /// </summary>
        [DataMember]
        public int CurrentRecordCount { get; set; }
        /// <summary>
        /// Next page URL
        /// </summary>
        [DataMember]
        public string NextPageUrl { get; set; }
        /// <summary>
        /// Page number
        /// </summary>
        [DataMember]
        public int PageLength { get; set; }
        /// <summary>
        /// Current page
        /// </summary>
        [DataMember]
        public int PageNumber { get; set; }
        /// <summary>
        /// Page up URL
        /// </summary>
        [DataMember]
        public string PrevPageUrl { get; set; }
        /// <summary>
        /// Total
        /// </summary>
        [DataMember]
        public int RecordCount { get; set; }
        /// <summary>
        /// 2013 5 15 Distance unit  Kilometer Mile
        /// </summary>
        [DataMember]
        public int DistanceUnit { get; set; }
    }
}
