using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using iHealthlabs.OpenAPI.Sample.Library.Entity;

namespace iHealthlabs.OpenAPI.Sample.Library
{
    public class ConnectToiHealthlabs
    {
        #region You must modify this part
        public string client_id = "cc3f7432dc33409******";
        public string client_secret = "31c425e51a0c41******";
        public string redirect_uri = "http://localhost:9201/TestPage.aspx";
        public string sc = "be5c4e0be6e54d3******";
        public string sv_bp = "70723428bf134ff2a******";
        public string sv_weight = "4e5141c702354dc49******";
        public string sv_bg = "c25ce4f8ddaf4f4baed0******";
        public string sv_bo = "92bae4fa0f1848538c7******";
        public string sv_ar = "7f0e5424d8d645289c4******";
        public string sv_sr = "c2c05b7ac78e4efcaec******";
        public string sv_user = "0bd11250d5e443d5******";

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

        private string url_authorization = "https://api.ihealthlabs.com:8443/OpenApiV2/OAuthv2/userauthorization";
        private string url_bp_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/bp.json/";
        private string url_weight_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/weight.json/";
        private string url_bg_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/glucose.json/";
        private string url_bo_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/spo2.json/";
        private string url_ar_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/activity.json/";
        private string url_sr_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}/sleep.json/";
        private string url_user_data = "https://api.ihealthlabs.com:8443/openapiv2/user/{0}.json/";

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
                this.Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                return false;
            }
            else
            {
                AccessTokenEntity accessToken = this.JsonDeserializ<AccessTokenEntity>(ResultString);
                httpContext.Session["token"] = accessToken;
                return true;
            }
        }

        public bool RefreshAccessToken(string code, string client_para, HttpContext httpContext)
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
                this.Error = JsonDeserializ<ApiErrorEntity>(ResultString);
                return false;
            }
            else
            {
                AccessTokenEntity accessToken = this.JsonDeserializ<AccessTokenEntity>(ResultString);
                httpContext.Session["token"] = accessToken;
                return true;
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
                    + "&sv=" + sv_bp
                    + "&locale=" + aBPUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + startTime.Value.ToString();

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
                    + "&sv=" + sv_weight
                    + "&locale=" + aWeightUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + startTime.Value.ToString();

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
                    + "&sv=" + sv_bg
                    + "&locale=" + aBGUnit;
                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + startTime.Value.ToString();

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
                    return this.JsonDeserializ<DownloadBGDataResultEntity>(ResultString);
                }
            }
            else
            {
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
                    + "&sv=" + sv_bo
                    + "&locale=" + aBOUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + startTime.Value.ToString();

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
                    + "&sv=" + sv_ar
                    + "&locale=" + aARUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + startTime.Value.ToString();

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
                    + "&sv=" + sv_sr
                    + "&locale=" + aSRUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + startTime.Value.ToString();

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
                    + "&sv=" + sv_user
                    + "&locale=" + aUserUnit;

                if (pageIndex.HasValue)
                    url += "&page_index=" + pageIndex.Value;

                if (startTime.HasValue)
                    url += "&start_time=" + startTime.Value.ToString();

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
                    return this.JsonDeserializ<DownloadUserInfoDataEntity>(ResultString);
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
