using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library
{
    [DataContract]
    public class DownloadBPDataResultEntity
    {
        /// <summary>
        /// The page data
        /// </summary>
        [DataMember]
        public List<DownloadBPDataEntity> BPDataList { get; set; }
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
        /// Blood pressure unit 0 mmHg  1 kPa
        /// </summary>
        [DataMember]
        public int BPUnit { get; set; }
    }
}
