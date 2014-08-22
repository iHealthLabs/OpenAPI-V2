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
        public string client_id = "e4dce2f7027044e0a6ce82e******";
        public string client_secret = "bb6a0326db55468f8f474a******";
        public string redirect_uri = "http://localhost:9201/TestPage.aspx";
        public string sc = "082a65ac25db4262b795f******";
        public string sv_OpenApiBP = "add22354420244ba9e0f3a5******";
        public string sv_OpenApiWeight = "bd82a25dcf18446b90f32******";
        public string sv_OpenApiBG = "978af9615739478ea29794e******";
        public string sv_OpenApiSpO2 = "3ea83f3ca05342b5b862c******";
        public string sv_OpenApiActivity = "34f4434741414722b15fb******";
        public string sv_OpenApiSleep = "d7a1dfc8939742bca0a41e******";
        public string sv_OpenApiUserInfo = "ba698f077b3843e8b2a3******";
        public string sv_OpenApiFood = "43f68d3478aa436abd96a440a6d7fd64";
        public string sv_OpenApiSport = "43f68d3478aa436abd96a440a6d7fd64";

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
        private string APIName_FOOD = "OpenApiFood";
        private string APIName_SPORT = "OpenApiSport";
        public string url_authorization = "https://api.ihealthlabs.com:8443/OpenApiV2/OAuthv2/userauthorization/";
        private string url_bp_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/bp.json/";
        private string url_bp_data_xml = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/bp.xml/";
        private string url_weight_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/weight.json/";
        private string url_weight_data_xml = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/weight.xml/";
        private string url_bg_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/glucose.json/";
        private string url_bg_data_xml = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/glucose.xml/";
        private string url_bo_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/spo2.json/";
        private string url_bo_data_xml = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/spo2.xml/";
        private string url_ar_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/activity.json/";
        private string url_ar_data_xml = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/activity.json/";
        private string url_sr_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/sleep.json/";
        private string url_sr_data_xml = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/sleep.json/";
        private string url_user_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}.json/";
        private string url_food_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/food.json/";
        private string url_sport_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/sport.json/";

        private string url_bp_data_client = "https://api.ihealthlabs.com:8443/openapiv2/application/bp.json/";
        private string url_weight_data_client = "https://api.ihealthlabs.com:8443/openapiv2/application/weight.json/";
        private string url_bg_data_client = "https://api.ihealthlabs.com:8443/openapiv2/application/glucose.json/";
        private string url_bo_data_client = "https://api.ihealthlabs.com:8443/openapiv2/application/spo2.json/";
        private string url_ar_data_client = "https://api.ihealthlabs.com:8443/openapiv2/application/activity.json/";
        private string url_sr_data_client = "https://api.ihealthlabs.com:8443/openapiv2/application/sleep.json/";
        private string url_user_data_client = "https://api.ihealthlabs.com:8443/openapiv2/application/userinfo.json/";
        private string url_food_data_client = "https://api.ihealthlabs.com:8443/openapiv2/application/food.json/";
        private string url_sport_data_client = "https://api.ihealthlabs.com:8443/openapiv2/application/sport.json/";


        public ConnectToiHealthlabs()
        {
        }

        public void GetCode()
        {
            string url = url_authorization
                + "?client_id=" + client_id
                + "&response_type=" + response_type_code
                + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
                + "&APIName=" + APIName_BP + " " + APIName_Weight + " " + APIName_BG + " " + APIName_BO + " " + APIName_SR + " " + APIName_User + " " + APIName_AR + " " + APIName_FOOD + " " + APIName_SPORT;
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
            + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri);

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

        public bool RefreshAccessToken(string code, string client_para, HttpContext httpContext, out AccessTokenEntity aAccessTokenEntity)
        {
            if (((AccessTokenEntity)httpContext.Session["token"]) != null)
            {
                string url = url_authorization
                    + "?client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&client_para=" + client_para
                    + "&refresh_token=" + ((AccessTokenEntity)httpContext.Session["token"]).RefreshToken
                    + "&response_type=" + response_type_refresh_token
                    + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri);

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
                    + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
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
                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {
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
        /// Download FoodReport Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadFoodDataResultEntity DownloadFOODData(HttpContext httpContext, int? pageIndex, DateTime? MDateTime, string aFOODUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = string.Format(url_food_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiFood
                    + "&locale=" + aFOODUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (MDateTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(MDateTime.Value).ToString();


                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {

                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {

                    return this.JsonDeserializ<DownloadFoodDataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download ClientFoodReport Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadFoodDataResultEntity DownloadClientFOODData(HttpContext httpContext, int? pageIndex, DateTime? MDateTime, string aFOODUnit)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = url_food_data_client
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiFood
                    + "&locale=" + aFOODUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (MDateTime.HasValue)
                    url += "&start_time=" + UnixTime.ToUnixTime(MDateTime.Value).ToString();

                //if (endTime.HasValue)
                //    url += "&end_time=" + UnixTime.ToUnixTime(endTime.Value).ToString();

                string ResultString = this.HttpGet(url);
                if (ResultString.StartsWith("{\"Error\":"))
                {

                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {

                    return this.JsonDeserializ<DownloadFoodDataResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download SportReport Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadSportDataReportEntity DownloadSPORTData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = string.Format(url_sport_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiSport;
                //+ "&locale=" + aFOODUnit;

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

                    return this.JsonDeserializ<DownloadSportDataReportEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Download ClientSportReport Data
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="pageIndex">can be set null</param>
        /// <param name="startTime">can be set null</param>
        /// <param name="endTime">can be set null</param>
        /// <returns>if some errors happened, it will be return null.</returns>
        public DownloadSportDataReportEntity DownloadClientSportData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime)
        {
            if (httpContext.Session["token"] != null)
            {
                string url = url_sport_data_client
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&redirect_uri=" + HttpUtility.UrlEncode(redirect_uri)
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiSport;
                //+ "&locale=" + aFOODUnit;

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

                    return this.JsonDeserializ<DownloadSportDataReportEntity>(ResultString);
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

                    Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                    return null;
                }
                else
                {

                    return this.JsonDeserializ<DownloadUserInfoResultEntity>(ResultString);
                }
            }
            else
            {
                return null;
            }
        }

        #region Tool functions
        public T JsonDeserializ<T>(string Json)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(Json)))
            {
                DataContractJsonSerializer serializer1 = new DataContractJsonSerializer(typeof(T));
                T p1 = (T)serializer1.ReadObject(ms);
                return (T)p1;
            }
        }
        public string HttpGet(string url)
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
        #region 2014-4-16
        private string HttpPost(string url, string str)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/x-www-form-urlencoded";

            string tempJson = str;
            byte[] buffer = Encoding.UTF8.GetBytes(tempJson);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            string ResultString = "";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                ResultString = reader.ReadToEnd();
            }
            return ResultString;
        }
        #endregion
        public string UploadloadBPData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string post, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_bp_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                   + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                   + "&client_id=" + client_id
                   + "&client_secret=" + client_secret
                   + "&sc=" + sc
                   + "&sv=" + sv_OpenApiBP
                   + "&request_type=" + post
                   + "&querynumber=" + querynumber;
                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);

                    return ResultString;
                }
                else
                {
                    string url = string.Format(url_bp_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiBP
                    + "&request_type=" + post
                    + "&querynumber=" + querynumber;
                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);

                    return ResultString;

                }




            }
            else
            {
                return null;
            }
        }
        public string UploadloadBGData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string post, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_bg_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiBG
                    + "&request_type=" + post
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;
                }
                else
                {
                    string url = string.Format(url_bg_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiBG
                    + "&request_type=" + post
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;
                }


            }
            else
            {
                return null;
            }
        }
        public string UploadloadWEIGHTData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string post, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_weight_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                   + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                   + "&client_id=" + client_id
                   + "&client_secret=" + client_secret
                   + "&sc=" + sc
                   + "&sv=" + sv_OpenApiWeight
                   + "&request_type=" + post
                   + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);

                    return ResultString;
                }
                else
                {
                    string url = string.Format(url_weight_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                 + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                 + "&client_id=" + client_id
                 + "&client_secret=" + client_secret
                 + "&sc=" + sc
                 + "&sv=" + sv_OpenApiWeight
                 + "&request_type=" + post
                 + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);

                    return ResultString;
                }


            }
            else
            {
                return null;
            }
        }
        public string UploadloadBOData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string post, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_bo_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiSpO2
                    + "&request_type=" + post
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);

                    return ResultString;
                }
                else
                {
                    string url = string.Format(url_bo_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiSpO2
                    + "&request_type=" + post
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);

                    return ResultString;
                }

            }
            else
            {
                return null;
            }
        }
        public string UploadloadAMData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string post, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_ar_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiActivity
                    + "&request_type=" + post
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);

                    return ResultString;
                }
                else
                {
                    string url = string.Format(url_ar_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiActivity
                    + "&request_type=" + post
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);

                    return ResultString;
                }

            }
            else
            {
                return null;
            }
        }
        public string UploadloadSLEEPData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string post, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_sr_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiSleep
                    + "&request_type=" + post
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);

                    return ResultString;
                }
                else
                {
                    string url = string.Format(url_sr_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiSleep
                    + "&request_type=" + post
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);

                    return ResultString;
                }

            }
            else
            {
                return null;
            }
        }

        public string UpdataloadBPData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string put, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_bp_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiBP
                    + "&request_type=" + put
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;
                }
                else
                {
                    string url = string.Format(url_bp_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiBP
                    + "&request_type=" + put
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;
                }


            }
            else
            {
                return null;
            }
        }
        public string UpdataloadBGData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string put, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_bg_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiBG
                    + "&request_type=" + put
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;
                }
                else
                {
                    string url = string.Format(url_bg_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiBG
                    + "&request_type=" + put
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;
                }


            }
            else
            {
                return null;
            }
        }
        public string UpdataloadWEIGHTData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string put, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_weight_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiWeight
                    + "&request_type=" + put
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;

                }
                else
                {
                    string url = string.Format(url_weight_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiWeight
                    + "&request_type=" + put
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;

                }

            }
            else
            {
                return null;
            }
        }
        public string UpdataloadBOData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string put, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_bo_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                  + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                  + "&client_id=" + client_id
                  + "&client_secret=" + client_secret
                  + "&sc=" + sc
                  + "&sv=" + sv_OpenApiSpO2
                  + "&request_type=" + put
                  + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;

                }
                else
                {
                    string url = string.Format(url_bo_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                  + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                  + "&client_id=" + client_id
                  + "&client_secret=" + client_secret
                  + "&sc=" + sc
                  + "&sv=" + sv_OpenApiSpO2
                  + "&request_type=" + put
                  + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;

                }

            }
            else
            {
                return null;
            }
        }
        public string UpdataloadAMData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string put, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_ar_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiActivity
                    + "&request_type=" + put
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;

                }
                else
                {
                    string url = string.Format(url_ar_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                    + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                    + "&client_id=" + client_id
                    + "&client_secret=" + client_secret
                    + "&sc=" + sc
                    + "&sv=" + sv_OpenApiActivity
                    + "&request_type=" + put
                    + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;

                }

            }
            else
            {
                return null;
            }
        }
        public string UpdataloadSLEEPData(HttpContext httpContext, int? pageIndex, DateTime? startTime, DateTime? endTime, string aStr, string put, string querynumber, string aType)
        {
            if (httpContext.Session["token"] != null)
            {
                if (aType == "xml")
                {
                    string url = string.Format(url_sr_data_xml, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                   + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                   + "&client_id=" + client_id
                   + "&client_secret=" + client_secret
                   + "&sc=" + sc
                   + "&sv=" + sv_OpenApiSleep
                   + "&request_type=" + put
                   + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;

                }
                else
                {
                    string url = string.Format(url_sr_data, ((AccessTokenEntity)httpContext.Session["token"]).UserID)
                   + "?access_token=" + ((AccessTokenEntity)httpContext.Session["token"]).AccessToken
                   + "&client_id=" + client_id
                   + "&client_secret=" + client_secret
                   + "&sc=" + sc
                   + "&sv=" + sv_OpenApiSleep
                   + "&request_type=" + put
                   + "&querynumber=" + querynumber;

                    if (pageIndex.HasValue)
                        url += "&page_index=" + pageIndex.Value;

                    if (startTime.HasValue)
                        url += "&start_time=" + UnixTime.ToUnixTime(startTime.Value).ToString();

                    if (endTime.HasValue)
                        url += "&end_time=" + endTime.Value.ToString();

                    string ResultString = this.HttpPost(url, aStr);
                    return ResultString;

                }
            }
            else
            {
                return null;
            }
        }


    }
}
