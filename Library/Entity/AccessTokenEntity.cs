using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iHealthlabs.OpenAPI.Sample.Library
{
    [DataContract]
    public class AccessTokenEntity
    {
        /// <summary>
        /// Access Token Key
        /// </summary>
        [DataMember]
        public string AccessToken { get; set; }
        /// <summary>
        /// Expires Time(unix time,the seconds from 1970-1-1)
        /// </summary>
        [DataMember]
        public int Expires { get; set; }
        /// <summary>
        /// refresh Token Key
        /// </summary>
        [DataMember]
        public string RefreshToken { get; set; }
        /// <summary>
        /// Available interface
        /// </summary>
        [DataMember]
        public string APIName { get; set; }

        /// <summary>
        /// Customer paramter
        /// </summary>
        [DataMember]
        public string client_para { get; set; }

        /// <summary>
        /// Customer paramter
        /// </summary>
        [DataMember]
        public string UserID { get; set; }
    }
}
