using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library.Entity
{
    public class DownloadSportDataReportEntity
    {
        [DataMember]
        public List<DownloadSportDataEntity> SPORTDataList { get; set; }
        [DataMember]
        public int CurrentRecordCount { get; set; }
        [DataMember]
        public string NextPageUrl { get; set; }
        [DataMember]
        public int PageLength { get; set; }
        [DataMember]
        public int PageNumber { get; set; }
        [DataMember]
        public string PrevPageUrl { get; set; }
        [DataMember]
        public int RecordCount { get; set; }

    }
}
