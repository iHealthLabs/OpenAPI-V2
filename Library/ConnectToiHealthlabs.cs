using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using iHealthlabs.OpenAPI.Sample.Library.Entity;
using System.Diagnostics.CodeAnalysis;

namespace iHealthlabs.OpenAPI.Sample.Library
{
    /// <summary>
    /// Change Unix to UTC
    /// </summary>
    public static class UnixTime
    {

        /// <summary>
        /// UTC 1970-1-1 00:00:00
        /// </summary>
        private static readonly DateTime UTCUnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Converts a DateTime to unix time. Unix time is the number of seconds 
        /// between 1970-1-1 0:0:0.0 (unix epoch) and the time (UTC).
        /// </summary>
        /// <param name="time">utc</param>
        /// <returns>The number of seconds between Unix epoch and the input time</returns>
        public static long ToUnixTime(DateTime time)
        {
            return (long)(time - UTCUnixEpoch).TotalSeconds;
        }


        /// <summary>
        /// Converts a long representation of a unix time into a DateTime. Unix time is 
        /// the number of seconds between 1970-1-1 0:0:0.0 (unix epoch) and the time (UTC).
        /// </summary>
        /// <param name="unixTime">The number of seconds since Unix epoch (must be >= 0)</param>
        /// <returns>A UTC DateTime object representing the unix time</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "unix", Justification = "UNIX is a domain term")]
        public static DateTime FromUnixTime(long unixTime)
        {
            if (unixTime < 0)
                throw new ArgumentOutOfRangeException("unixTime");

            return UTCUnixEpoch.AddSeconds(unixTime);
        }
    }


    public class ConnectToiHealthlabs
    {
        #region You must modify this part
        public string client_id = "1a2095353a8e4f988de89e5822109be9";
        public string client_secret = "faa4f2d64c2a43e1a41254a4897b371d";
        public string redirect_uri = "http://localhost:9201/TestPage.aspx";
        public string sc = "b19d66b0659a49939ba4e72bad6e644f";
        public string sv_OpenApiBP = "430d6bd34e4a4efb82b5d99ed1c00d52";
        public string sv_OpenApiWeight = "a3077c47346d4ba4a5d3bab4c4eb55ce";
        public string sv_OpenApiBG = "0f7f9de98e5b4c5880e80acf43089bc4";
        public string sv_OpenApiSpO2 = "c3be49f3e2434597b6d16d580caac6e9";
        public string sv_OpenApiActivity = "93e291a0c8b544239fafe6b4ea343e43";
        public string sv_OpenApiSleep = "f3a2abd2a1fc4f5b9d217f7a65674881";
        public string sv_OpenApiUserInfo = "4324b5e3b4cd4295817d70f88a606094";

        #endregion

        public ApiErrorEntity Error;

        private string response_type_code = "code";
        private string response_type_refresh_token = "refresh_token";
        private string grant_type_authorization_code = "authorization_code";
        private string APIName_BP = "OpenApiBP";
        private string APIName_Weight = "OpenApiWeight";
        private string APIName_BG = "OpenApiBG";
        private string APIName_BO = "OpenApiSpO2";
        private string APIName_AR = "OpenApiActivity";
        private string APIName_SR = "OpenApiSleep";
        private string APIName_User = "OpenApiUserInfo";
        private string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        private string url_authorization = "http://test.ihealthlabs.com:8000/OpenApiV2/OAuthv2/userauthorization/";
        private string url_bp_data = "http://test.ihealthlabs.com:8000/openapiv2/user/{0}/bp.json/";
        private string url_weight_data = "http://test.ihealthlabs.com:8000/openapiv2/user/{0}/weight.json/";
        private string url_bg_data = "http://test.ihealthlabs.com:8000/openapiv2/user/{0}/glucose.json/";
        private string url_bo_data = "http://test.ihealthlabs.com:8000/openapiv2/user/{0}/spo2.json/";
        private string url_ar_data = "http://test.ihealthlabs.com:8000/openapiv2/user/{0}/activity.json/";
        private string url_sr_data = "http://test.ihealthlabs.com:8000/openapiv2/user/{0}/sleep.json/";
        private string url_user_data = "http://test.ihealthlabs.com:8000/openapiv2/user/{0}.json/";

        private string url_bp_data_client = "http://test.ihealthlabs.com:8000/openapiv2/application/bp.json/";
        private string url_weight_data_client = "http://test.ihealthlabs.com:8000/openapiv2/application/weight.json/";
        private string url_bg_data_client = "http://test.ihealthlabs.com:8000/openapiv2/application/glucose.json/";
        private string url_bo_data_client = "http://test.ihealthlabs.com:8000/openapiv2/application/spo2.json/";
        private string url_ar_data_client = "http://test.ihealthlabs.com:8000/openapiv2/application}/activity.json/";
        private string url_sr_data_client = "http://test.ihealthlabs.com:8000/openapiv2/application/sleep.json/";
        private string url_user_data_client = "http://test.ihealthlabs.com:8000/openapiv2/application/userinfo.json/";

        public void GetCode()
        {
            string url = url_authorization
                + "?client_id=" + client_id
                + "&response_type=" + response_type_code
                + "&redirect_uri=" + redirect_uri
                + "&APIName=" + APIName_BP + " " + APIName_Weight + " " + APIName_BG + " " + APIName_BO + " " + APIName_SR + " " + APIName_User + " " + APIName_AR;
            HttpContext.Current.Response.Redirect(url);
        }

        public bool GetAccessToken(string code, string client_para, HttpContext httpContext)
        {
            string url = url_authorization
            + "?client_id=" + client_id
            + "&client_secret=" + client_secret
            + "&client_para=" + client_para
            + "&code=" + code
            + "&grant_type=" + grant_type_authorization_code
            + "&redirect_uri=" + redirect_uri;

            string ResultString = this.HttpGet(url);

            if (ResultString.StartsWith("{\"Error\":"))
            {
                httpContext.Response.Write(url);
                httpContext.Response.Write("<br/>");
                this.Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                return false;
            }
            else
            {
                httpContext.Response.Write(url);
                httpContext.Response.Write("<br/>");
                httpContext.Response.Write(ResultString);
                AccessTokenEntity accessToken = this.JsonDeserializ<AccessTokenEntity>(ResultString);
                httpContext.Session["token"] = accessToken;
                return true;
            }
        }

        public bool RefreshAccessToken(string code, string client_para, HttpContext httpContext,out AccessTokenEntity aAccessTokenEntity)
        {
            if (((AccessTokenEntity)httpContext.Session["token"]) != null)
            {
                string url = url_authorization
                    + "?client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&client_para=" + client_para
                    + "&refresh_token=" + ((AccessTokenEntity)httpContext.Session["token"]).RefreshToken
                    + "&response_type=" + response_type_refresh_token
                    + "&redirect_uri=" + redirect_uri;

                string ResultString = HttpGet(url);

                if (ResultString.StartsWith("{\"Error\":"))
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    this.Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    aAccessTokenEntity = null;
                    return false;
                }
                else
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    httpContext.Response.Write(ResultString);
                    AccessTokenEntity accessToken = this.JsonDeserializ<AccessTokenEntity>(ResultString);
                    httpContext.Session["token"] = accessToken;
                    aAccessTokenEntity = accessToken;
                    return true;
                }
            }
            else
            {
                this.Error = new ApiErrorEntity("Do not has AccessToken.", "Do not has AccessToken.", 0000);
                aAccessTokenEntity = null;
                return false;
            }
        }

        /// <summary>
        /// Download bp data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadBPDataResultEntity DownloadBPData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aBPUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = string.Format(url_bp_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + redirect_uri
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiBP
                    + "&locale=" + aBPUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + endTime.Value.ToString();

                string ResultString = this.HttpGet(url);

                if (ResultString.StartsWith("{\"Error\":"))
                {
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    return this.JsonDeserializ<DownloadBPDataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Download application bp data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadBPDataResultEntity DownloadClientBPData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aBPUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = "";

                url = url_bp_data_client
              + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
              + "&client_id=" + client_id
              + "&client_secret=" + client_secret
              + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
              + "&sc=" + sc
              + "&sv=" + sv_OpenApiBP
              + "&locale=" + aBPUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);

                if (ResultString.StartsWith("{\"Error\":"))
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    httpContext.Response.Write(ResultString);
                    return this.JsonDeserializ<DownloadBPDataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// Download weight data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadWeightDataResultEntity DownloadWeightData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aWeightUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = string.Format(url_weight_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + redirect_uri
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiWeight
                    + "&locale=" + aWeightUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    return this.JsonDeserializ<DownloadWeightDataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download application weight data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadWeightDataResultEntity DownloadClientWeightData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aWeightUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = "";
                url = url_weight_data_client
              + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
              + "&client_id=" + client_id
              + "&client_secret=" + client_secret
              + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
              + "&sc=" + sc
              + "&sv=" + sv_OpenApiWeight
              + "&locale=" + aWeightUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);

                if (ResultString.StartsWith("{\"Error\":"))
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    httpContext.Response.Write(ResultString);
                    return this.JsonDeserializ<DownloadWeightDataResultEntity>(ResultString);
                }

            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download BG Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadBGDataResultEntity DownloadBGData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aBGUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = string.Format(url_bg_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + redirect_uri
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiBG
                    + "&locale=" + aBGUnit;
                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    return this.JsonDeserializ<DownloadBGDataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download application bg data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadBGDataResultEntity DownloadClientBGData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aBGUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string
                    url = url_bg_data_client
                  + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                  + "&client_id=" + client_id
                  + "&client_secret=" + client_secret
                  + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
                  + "&sc=" + sc
                  + "&sv=" + sv_OpenApiBG
                  + "&locale=" + aBGUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);

                if (ResultString.StartsWith("{\"Error\":"))
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    httpContext.Response.Write(ResultString);
                    return this.JsonDeserializ<DownloadBGDataResultEntity>(ResultString);
                }
            }
            else
            {
                Error = new ApiErrorEntity("", "Deny", -1);
                return null;
            }
        }
        /// <summary>
        /// Download BO Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadBODataResultEntity DownloadBOData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aBOUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = string.Format(url_bo_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + redirect_uri
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiSpO2
                    + "&locale=" + aBOUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    return this.JsonDeserializ<DownloadBODataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download ClientBO Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadBODataResultEntity DownloadClientBOData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aBOUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = url_bo_data_client
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiSpO2
                    + "&locale=" + aBOUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    httpContext.Response.Write(ResultString);
                    return this.JsonDeserializ<DownloadBODataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download ActiveReport Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadActiveReportDataResultEntity DownloadARData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aARUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = string.Format(url_ar_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + redirect_uri
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiActivity
                    + "&locale=" + aARUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    return this.JsonDeserializ<DownloadActiveReportDataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download ClientActiveReport Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadActiveReportDataResultEntity DownloadClientARData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aARUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = url_ar_data_client
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiActivity
                    + "&locale=" + aARUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    httpContext.Response.Write(ResultString);
                    return this.JsonDeserializ<DownloadActiveReportDataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download SleepReport Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadSleepReportDataResultEntity DownloadSRData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aSRUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = string.Format(url_sr_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + redirect_uri
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiSleep
                    + "&locale=" + aSRUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    return this.JsonDeserializ<DownloadSleepReportDataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download ClientSleepReport Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadSleepReportDataResultEntity DownloadClientSRData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aSRUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = url_sr_data_client
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiSleep
                    + "&locale=" + aSRUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    httpContext.Response.Write(ResultString);
                    return this.JsonDeserializ<DownloadSleepReportDataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download User Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadUserInfoDataEntity DownloadUserData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aUserUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = string.Format(url_user_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + redirect_uri
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiUserInfo
                    + "&locale=" + aUserUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    return this.JsonDeserializ<DownloadUserInfoDataEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download ClientUser Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadUserInfoResultEntity DownloadClientUserData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aUserUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = url_user_data_client
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiUserInfo
                    + "&locale=" + aUserUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                if (endTime.HasValue)
                    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
                    httpContext.Response.Write(url);
                    httpContext.Response.Write("<br/>");
                    httpContext.Response.Write(ResultString);
                    return this.JsonDeserializ<DownloadUserInfoResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }

        #region Tool functions
        private T JsonDeserializ<T>(string Json)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(Json)))
            {
                DataContractJsonSerializer serializer1 = new DataContractJsonSerializer(typeof(T));
                T p1 = (T)serializer1.ReadObject(ms);
                return (T)p1;
            }
        }
        private string HttpGet(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;

            string ResultString = "";
            HttpWebResponse httpresponse = request.GetResponse() as HttpWebResponse;
            using (StreamReader reader = new StreamReader(httpresponse.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                ResultString = reader.ReadToEnd();
            }
            return ResultString;
        }
        #endregion
    }
}
