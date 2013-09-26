using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library
{
    [DataContract]
    public class DownloadWeightDataResultEntity
    {
        /// <summary>
        /// The page data
        /// </summary>
        [DataMember]
        public List<DownloadWeightDataEntity> WeightDataList { get; set; }
        /// <summary>
        /// Next page URL
        /// </summary>
        [DataMember]
        public string NextPageUrl { get; set; }
        /// <summary>
        /// Paging record number
        /// </summary>
        [DataMember]
        public int CurrentRecordCount { get; set; }
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
        /// Weight unit  0 kg   1 lbs
        /// </summary>
        [DataMember]
        public int WeightUnit { get; set; }
    }
}
