using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHealthlabs.OpenAPI.Sample.Library.Entity
{
    public class SystemSetting
    {
        public string url_authorization { get; set; }
        public string url_bp_data { get; set; }
        public string url_weight_data { get; set; }
        public string url_bg_data { get; set; }
        public string url_bo_data { get; set; }
        public string url_ar_data { get; set; }
        public string url_sr_data { get; set; }
        public string url_user_data { get; set; }

        public string url_bp_data_client { get; set; }
        public string url_weight_data_client { get; set; }
        public string url_bg_data_client { get; set; }
        public string url_bo_data_client { get; set; }
        public string url_ar_data_client { get; set; }
        public string url_sr_data_client { get; set; }
        public string url_user_data_client { get; set; }

        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string redirect_uri { get; set; }
        public string sc { get; set; }
        public string sv_OpenApiBP { get; set; }
        public string sv_OpenApiWeight { get; set; }
        public string sv_OpenApiBG { get; set; }
        public string sv_OpenApiSpO2 { get; set; }
        public string sv_OpenApiActivity { get; set; }
        public string sv_OpenApiSleep { get; set; }
        public string sv_OpenApiUserInfo { get; set; }

        //public string sv_OpenApiBP_Client { get; set; }
        //public string sv_OpenApiWeight_Client { get; set; }
        //public string sv_OpenApiBG_Client { get; set; }
        //public string sv_OpenApiSpO2_Client { get; set; }
        //public string sv_OpenApiActivity_Client { get; set; }
        //public string sv_OpenApiSleep_Client { get; set; }
        //public string sv_OpenApiUserInfo_Client { get; set; }

        public string url_authorization_1 { get; set; }//= "/api/OAuthv2/userauthorization.ashx";
        public string url_bp_data_1 { get; set; }//= "/api/OpenApi/downloadbpdata.ashx";
        public string url_weight_data_1 { get; set; }// = "/api/OpenApi/downloadweightdata.ashx";

    }

    public class URLEntity
    {
        public string URL { get; set; }
        public string Type { get; set; }
    }

    public class ServiceSetting
    {
        public static List<URLEntity> GetUrlList(string aAppSettings)
        {
            string SettingString = aAppSettings;
            if (!string.IsNullOrEmpty(SettingString))
            {
                List<URLEntity> ResultList = new List<URLEntity>();

                List<string> UrlList = SettingString.Split('@').ToList();

                for (int i = 0; i < UrlList.Count; i++)
                {
                    string itemString = UrlList[i];
                    if (itemString.Length > 0)
                    {
                        string[] StringArray = itemString.Split('#');
                        if (StringArray.Length > 0)
                        {
                            URLEntity temp = new URLEntity();
                            temp.Type = StringArray[0];
                            temp.URL = StringArray[1];
                            ResultList.Add(temp);
                        }
                    }
                }
                return ResultList;
            }
            else
            {
                return null;
            }
        }


        public static SystemSetting GetByChoose(string aChoose)
        {
            if (aChoose == "57")
            {
                return Service57;
            }
            if (aChoose == "54")
            {
                return Service54;
            }
            else if (aChoose == "22")
            {
                return Service22;
            }
            else if (aChoose == "tokyo")
            {
                return ServiceTokyo;
            }
            else if (aChoose == "usa")
            {
                return ServiceUSA;
            }
            else if (aChoose == "54sandbox")
            {
                return Service54Sandbox;
            }
            else if (aChoose == "22sandbox")
            {
                return Service22Sandbox;
            }
            else if (aChoose == "tokyosandbox")
            {
                return ServiceTokyoSandbox;
            }
            else if (aChoose == "usasandbox")
            {
                return ServiceUSASandbox;
            }
            else
            {
                return Service54;
            }
        }
        ///

        public static SystemSetting Service57 = new SystemSetting()
        {
            client_id = "952f370e1f504e67a6bfc788e25a52cd"
            ,
            client_secret = "bb2293d6ad7d452aa05543b0624c72c7"
            ,
            redirect_uri = "http://192.168.8.57:8008/TestPage.aspx"
            ,
            sc = "71eaf43121c343b3bce66bdb85c9f772"
            ,
            sv_OpenApiBP = "4f41dc8e433d488ca47a2b2070dc59ee"
            ,
            sv_OpenApiWeight = "2fac3beba39f4c0b8da20c11628105a4"
            ,
            sv_OpenApiBG = "ee2749e3a1e54713a015afd0c418100a"
            ,
            sv_OpenApiSpO2 = "0fddb2a0b78342e98498bca9db0e8a00"
            ,
            sv_OpenApiActivity = "7ee34949666d446ebe9c1950d0c3c3de"
            ,
            sv_OpenApiSleep = "471dd178d1e346fdbfecf1cff25fd05e"
            ,
            sv_OpenApiUserInfo = "7605ea94bb634a80a8953c20ef8dc4f9"
                //,
                //sv_OpenApiBP_Client = "3d596a3bd87c425d8155b95c25cfbe9d"
                //,
                //sv_OpenApiWeight_Client = "e30a419ee29a415691ba39d27ca81f83"
                //,
                //sv_OpenApiBG_Client = "008514173059474c94abd910654145a8"
                //,
                //sv_OpenApiSpO2_Client = "a2ec06c31ff2460b8dcf36a3e1bd46a9"
                //,
                //sv_OpenApiActivity_Client = "4d712dc78f124f8a9cfa5d4c7b51a206"
                //,
                //sv_OpenApiSleep_Client = "75bae34140014786b4e78e8feb8ef1cf"
                //,
                //sv_OpenApiUserInfo_Client = "2780e9696f8c4b1e9dd7504e856d79e6"
            ,
            url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
            ,
            url_bp_data = "/openapiv2/user/{0}/bp.json/"
            ,
            url_weight_data = "/openapiv2/user/{0}/weight.json/"
            ,
            url_bg_data = "/openapiv2/user/{0}/glucose.json/"
            ,
            url_bo_data = "/openapiv2/user/{0}/spo2.json/"
            ,
            url_ar_data = "/openapiv2/user/{0}/activity.json/"
            ,
            url_sr_data = "/openapiv2/user/{0}/sleep.json/"
            ,
            url_user_data = "/openapiv2/user/{0}.json/"
            ,
            url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
            ,
            url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
            ,
            url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
            ,
            url_bp_data_client = "/openapiv2/application/bp.json/"
            ,
            url_weight_data_client = "/openapiv2/application/weight.json/"
            ,
            url_bg_data_client = "/openapiv2/application/glucose.json/"
            ,
            url_bo_data_client = "/openapiv2/application/spo2.json/"
            ,
            url_ar_data_client = "/openapiv2/application/activity.json/"
            ,
            url_sr_data_client = "/openapiv2/application/sleep.json/"
            ,
            url_user_data_client = "/openapiv2/application/userinfo.json/"
        };

        public static SystemSetting Service54 = new SystemSetting()
        {
            client_id = "4e691bb9e012401387db69f822dd2109"
            ,
            client_secret = "22e7c705abbc410082c35f57ef8ae538"
            ,
            redirect_uri = "http://192.168.8.34:8009/TestPage.aspx"
            ,
            sc = "d63493704c2c4104830f3202380e66cc"
            ,
            sv_OpenApiBP = "54f006ef99c043e381d2e939444c72c3"
            ,
            sv_OpenApiWeight = "97354b25d2124e65bfd1b7ca6fda3006"
            ,
            sv_OpenApiBG = "1294ef5fd0444fad8c7a568bcece2e47"
            ,
            sv_OpenApiSpO2 = "ef0af5f2e208481f97a1ab9a48d61e66"
            ,
            sv_OpenApiActivity = "a3f780f1e3274371a93b66d31e107c12"
            ,
            sv_OpenApiSleep = "67462ade904841d1b20314a97ca6e949"
            ,
            sv_OpenApiUserInfo = "6db5425413694db7b8b5bcde9849a51c"
                //,
                //sv_OpenApiBP_Client = "06d741494597415e8a900ca92d244fd7"
                //,
                //sv_OpenApiWeight_Client = "97354b25d2124e65bfd1b7ca6fda3006"
                //,
                //sv_OpenApiBG_Client = "1294ef5fd0444fad8c7a568bcece2e47"
                //,
                //sv_OpenApiSpO2_Client = "ef0af5f2e208481f97a1ab9a48d61e66"
                //,
                //sv_OpenApiActivity_Client = "d0ec4cb6645a4626851d1b33e3131b5c"
                //,
                //sv_OpenApiSleep_Client = "67462ade904841d1b20314a97ca6e949"
                //,
                //sv_OpenApiUserInfo_Client = "6db5425413694db7b8b5bcde9849a51c"
            ,
            url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
            ,
            url_bp_data = "/openapiv2/user/{0}/bp.json/"
            ,
            url_weight_data = "/openapiv2/user/{0}/weight.json/"
            ,
            url_bg_data = "/openapiv2/user/{0}/glucose.json/"
            ,
            url_bo_data = "/openapiv2/user/{0}/spo2.json/"
            ,
            url_ar_data = "/openapiv2/user/{0}/activity.json/"
            ,
            url_sr_data = "/openapiv2/user/{0}/sleep.json/"
            ,
            url_user_data = "/openapiv2/user/{0}.json/"
            ,
            url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
            ,
            url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
            ,
            url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
            ,
            url_bp_data_client = "/openapiv2/application/bp.json/"
            ,
            url_weight_data_client = "/openapiv2/application/weight.json/"
            ,
            url_bg_data_client = "/openapiv2/application/glucose.json/"
            ,
            url_bo_data_client = "/openapiv2/application/spo2.json/"
            ,
            url_ar_data_client = "/openapiv2/application/activity.json/"
            ,
            url_sr_data_client = "/openapiv2/application/sleep.json/"
            ,
            url_user_data_client = "/openapiv2/application/userinfo.json/"
        };
        public static SystemSetting Service22 = new SystemSetting()
        {
            client_id = "4e691bb9e012401387db69f822dd2109"
            ,
            client_secret = "22e7c705abbc410082c35f57ef8ae538"
            ,
            redirect_uri = "http://192.168.8.34:8009/TestPage.aspx"
            ,
            sc = "d63493704c2c4104830f3202380e66cc"
            ,
            sv_OpenApiBP = "54f006ef99c043e381d2e939444c72c3"
            ,
            sv_OpenApiWeight = "97354b25d2124e65bfd1b7ca6fda3006"
            ,
            sv_OpenApiBG = "1294ef5fd0444fad8c7a568bcece2e47"
            ,
            sv_OpenApiSpO2 = "ef0af5f2e208481f97a1ab9a48d61e66"
            ,
            sv_OpenApiActivity = "a3f780f1e3274371a93b66d31e107c12"
            ,
            sv_OpenApiSleep = "67462ade904841d1b20314a97ca6e949"
            ,
            sv_OpenApiUserInfo = "6db5425413694db7b8b5bcde9849a51c"
                //,
                //sv_OpenApiBP_Client = "06d741494597415e8a900ca92d244fd7"
                //,
                //sv_OpenApiWeight_Client = "97354b25d2124e65bfd1b7ca6fda3006"
                //,
                //sv_OpenApiBG_Client = "1294ef5fd0444fad8c7a568bcece2e47"
                //,
                //sv_OpenApiSpO2_Client = "ef0af5f2e208481f97a1ab9a48d61e66"
                //,
                //sv_OpenApiActivity_Client = "d0ec4cb6645a4626851d1b33e3131b5c"
                //,
                //sv_OpenApiSleep_Client = "67462ade904841d1b20314a97ca6e949"
                //,
                //sv_OpenApiUserInfo_Client = "6db5425413694db7b8b5bcde9849a51c"
            ,
            url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
            ,
            url_bp_data = "/openapiv2/user/{0}/bp.json/"
            ,
            url_weight_data = "/openapiv2/user/{0}/weight.json/"
            ,
            url_bg_data = "/openapiv2/user/{0}/glucose.json/"
            ,
            url_bo_data = "/openapiv2/user/{0}/spo2.json/"
            ,
            url_ar_data = "/openapiv2/user/{0}/activity.json/"
            ,
            url_sr_data = "/openapiv2/user/{0}/sleep.json/"
            ,
            url_user_data = "/openapiv2/user/{0}.json/"
            ,
            url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
            ,
            url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
            ,
            url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
            ,
            url_bp_data_client = "/openapiv2/application/bp.json/"
            ,
            url_weight_data_client = "/openapiv2/application/weight.json/"
            ,
            url_bg_data_client = "/openapiv2/application/glucose.json/"
            ,
            url_bo_data_client = "/openapiv2/application/spo2.json/"
            ,
            url_ar_data_client = "/openapiv2/application/activity.json/"
            ,
            url_sr_data_client = "/openapiv2/application/sleep.json/"
            ,
            url_user_data_client = "/openapiv2/application/userinfo.json/"
        };

        //public static SystemSetting Service22 = new SystemSetting()
        //{
        //    client_id = "952f370e1f504e67a6bfc788e25a52cd"
        //    ,
        //    client_secret = "bb2293d6ad7d452aa05543b0624c72c7"
        //    ,
        //    redirect_uri = "http://192.168.8.57:8008/TestPage.aspx"
        //    ,
        //    sc = "71eaf43121c343b3bce66bdb85c9f772"
        //    ,
        //    sv_OpenApiBP = "4f41dc8e433d488ca47a2b2070dc59ee"
        //    ,
        //    sv_OpenApiWeight = "2fac3beba39f4c0b8da20c11628105a4"
        //    ,
        //    sv_OpenApiBG = "ee2749e3a1e54713a015afd0c418100a"
        //    ,
        //    sv_OpenApiSpO2 = "0fddb2a0b78342e98498bca9db0e8a00"
        //    ,
        //    sv_OpenApiActivity = "7ee34949666d446ebe9c1950d0c3c3de"
        //    ,
        //    sv_OpenApiSleep = "471dd178d1e346fdbfecf1cff25fd05e"
        //    ,
        //    sv_OpenApiUserInfo = "7605ea94bb634a80a8953c20ef8dc4f9"
        //    ,
        //    sv_OpenApiBP_Client = "3d596a3bd87c425d8155b95c25cfbe9d"
        //    ,
        //    sv_OpenApiWeight_Client = "e30a419ee29a415691ba39d27ca81f83"
        //    ,
        //    sv_OpenApiBG_Client = "008514173059474c94abd910654145a8"
        //    ,
        //    sv_OpenApiSpO2_Client = "a2ec06c31ff2460b8dcf36a3e1bd46a9"
        //    ,
        //    sv_OpenApiActivity_Client = "4d712dc78f124f8a9cfa5d4c7b51a206"
        //    ,
        //    sv_OpenApiSleep_Client = "75bae34140014786b4e78e8feb8ef1cf"
        //    ,
        //    sv_OpenApiUserInfo_Client = "2780e9696f8c4b1e9dd7504e856d79e6"
        //    ,
        //    url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
        //    ,
        //    url_bp_data = "/openapiv2/user/{0}/bp.json/"
        //    ,
        //    url_weight_data = "/openapiv2/user/{0}/weight.json/"
        //    ,
        //    url_bg_data = "/openapiv2/user/{0}/glucose.json/"
        //    ,
        //    url_bo_data = "/openapiv2/user/{0}/spo2.json/"
        //    ,
        //    url_ar_data = "/openapiv2/user/{0}/activity.json/"
        //    ,
        //    url_sr_data = "/openapiv2/user/{0}/sleep.json/"
        //    ,
        //    url_user_data = "/openapiv2/user/{0}.json/"
        //    ,
        //    url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
        //    ,
        //    url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
        //    ,
        //    url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
        //    ,
        //    url_bp_data_client = "/openapiv2/application/bp.json/"
        //    ,
        //    url_weight_data_client = "/openapiv2/application/weight.json/"
        //    ,
        //    url_bg_data_client = "/openapiv2/application/glucose.json/"
        //    ,
        //    url_bo_data_client = "/openapiv2/application/spo2.json/"
        //    ,
        //    url_ar_data_client = "/openapiv2/application/activity.json/"
        //    ,
        //    url_sr_data_client = "/openapiv2/application/sleep.json/"
        //    ,
        //    url_user_data_client = "/openapiv2/application/userinfo.json/"
        //};

        public static SystemSetting ServiceTokyo = new SystemSetting()
        {
            client_id = "d260aaa30e5d48a4a1e772bb43cf05ff"
            ,
            client_secret = "8b7496e88c94489885ddef6bda43a79b"
            ,
            redirect_uri = "http://192.168.8.34:8009/TestPage.aspx"
            ,
            sc = "0ec7d50f393847b486b945f52f8d7d5f"
            ,
            sv_OpenApiBP = "a49339ba4dea4e78b8fa54e30209ee2a"
            ,
            sv_OpenApiWeight = "57c5c07edbe44a37acb9fda3acc1f3ab"
            ,
            sv_OpenApiBG = "9b2bf5029e664b3cb2f681f283f1fdd4"
            ,
            sv_OpenApiSpO2 = "e2ecd32ab6c84c77a00a4694b579f2e2"
            ,
            sv_OpenApiActivity = "652da8dce7c4460ca9bf27e502a61a36"
            ,
            sv_OpenApiSleep = "e24fbfc307fe4bca8a8b01200c7b41d0"
            ,
            sv_OpenApiUserInfo = "f02a76072aa64680b107c79c8013d8cb"
            ,
            url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
            ,
            url_bp_data = "/openapiv2/user/{0}/bp.json/"
            ,
            url_weight_data = "/openapiv2/user/{0}/weight.json/"
            ,
            url_bg_data = "/openapiv2/user/{0}/glucose.json/"
            ,
            url_bo_data = "/openapiv2/user/{0}/spo2.json/"
            ,
            url_ar_data = "/openapiv2/user/{0}/activity.json/"
            ,
            url_sr_data = "/openapiv2/user/{0}/sleep.json/"
            ,
            url_user_data = "/openapiv2/user/{0}.json/"
            ,
            url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
            ,
            url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
            ,
            url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
            ,
            url_bp_data_client = "/openapiv2/application/bp.json/"
            ,
            url_weight_data_client = "/openapiv2/application/weight.json/"
            ,
            url_bg_data_client = "/openapiv2/application/glucose.json/"
            ,
            url_bo_data_client = "/openapiv2/application/spo2.json/"
            ,
            url_ar_data_client = "/openapiv2/application/activity.json/"
            ,
            url_sr_data_client = "/openapiv2/application/sleep.json/"
            ,
            url_user_data_client = "/openapiv2/application/userinfo.json/"
        };


        //     public static SystemSetting ServiceUSA = new SystemSetting()
        //{
        //    client_id = "243f64e8ede04888933831136288ed59"
        //        ,
        //    client_secret = "bb906df910074529a3662dbbf27a6e6c"
        //        ,
        //    redirect_uri = "http://walgreens.medhelp.ws/TestPage.aspx"
        //    ,
        //    sc = "324f7c23618f4956a4e39e0faf92bacc"
        //    ,
        //    sv_OpenApiBP = "508ed83bd77d4c0f95e2f82a1148202b"
        //    ,
        //    sv_OpenApiWeight = "7ae4cf9b71d9474db2e3a5322b91711a"
        //    ,
        //    sv_OpenApiBG = "54f87a6002d44cb39e9f0ad4758d0693"
        //    ,
        //    sv_OpenApiSpO2 = "2bd4ccfb442d48d38d30d76eb70e7cdc"
        //    ,
        //    sv_OpenApiActivity = "23082ef650ce4c85aab95df829d8ba78"
        //    ,
        //    sv_OpenApiSleep = "a5e9917dd56347b3b3d0880ad77ca4da"
        //    ,
        //    sv_OpenApiUserInfo = "e279ab80f9604524848813ff3406bff5"
        //    ,
        //    url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
        //    ,
        //    url_bp_data = "/openapiv2/user/{0}/bp.json/"
        //    ,
        //    url_weight_data = "/openapiv2/user/{0}/weight.json/"
        //    ,
        //    url_bg_data = "/openapiv2/user/{0}/glucose.json/"
        //    ,
        //    url_bo_data = "/openapiv2/user/{0}/spo2.json/"
        //    ,
        //    url_ar_data = "/openapiv2/user/{0}/activity.json/"
        //    ,
        //    url_sr_data = "/openapiv2/user/{0}/sleep.json/"
        //    ,
        //    url_user_data = "/openapiv2/user/{0}.json/"
        //    ,
        //    url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
        //    ,
        //    url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
        //    ,
        //    url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
        //};

        public static SystemSetting ServiceUSA = new SystemSetting()
        {
            client_id = "2a8387e3f4e94407a3a767a72dfd52ea"
                ,
            client_secret = "fd5e845c47944a818bc511fb7edb0a77"
                ,
            redirect_uri = "http://192.168.8.34:8009/TestPage.aspx"
            ,
            sc = "c47c2bc6b71a4938a3bb87819918aadc"
            ,
            sv_OpenApiBP = "1ce66ec1758b48acbc29b638cc68fc0c"
            ,
            sv_OpenApiWeight = "041887bc341241feb6cb82a8567f05a6"
            ,
            sv_OpenApiBG = "79709628e0dc48ae9a01673ca6a3235f"
            ,
            sv_OpenApiSpO2 = "ceee88c31119453b90ada7a9dde1ae8e"
            ,
            sv_OpenApiActivity = "9fa46008ea974c018ab649445b4538fe"
            ,
            sv_OpenApiSleep = "43f68d3478aa436abd96a440a6d7fd64"
            ,
            sv_OpenApiUserInfo = "21ab802f66a445baa2bcebbc5b5e8f05"
            ,
            url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
            ,
            url_bp_data = "/openapiv2/user/{0}/bp.json/"
            ,
            url_weight_data = "/openapiv2/user/{0}/weight.json/"
            ,
            url_bg_data = "/openapiv2/user/{0}/glucose.json/"
            ,
            url_bo_data = "/openapiv2/user/{0}/spo2.json/"
            ,
            url_ar_data = "/openapiv2/user/{0}/activity.json/"
            ,
            url_sr_data = "/openapiv2/user/{0}/sleep.json/"
            ,
            url_user_data = "/openapiv2/user/{0}.json/"
            ,
            url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
            ,
            url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
            ,
            url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
        };


        public static SystemSetting Service54Sandbox = new SystemSetting()
        {
            client_id = "4e691bb9e012401387db69f822dd2109"
            ,
            client_secret = "22e7c705abbc410082c35f57ef8ae538"
            ,
            redirect_uri = "http://192.168.8.34:8009/TestPage.aspx"
            ,
            sc = "d63493704c2c4104830f3202380e66cc"
            ,
            sv_OpenApiBP = "54f006ef99c043e381d2e939444c72c3"
            ,
            sv_OpenApiWeight = "97354b25d2124e65bfd1b7ca6fda3006"
            ,
            sv_OpenApiBG = "1294ef5fd0444fad8c7a568bcece2e47"
            ,
            sv_OpenApiSpO2 = "ef0af5f2e208481f97a1ab9a48d61e66"
            ,
            sv_OpenApiActivity = "a3f780f1e3274371a93b66d31e107c12"
            ,
            sv_OpenApiSleep = "67462ade904841d1b20314a97ca6e949"
            ,
            sv_OpenApiUserInfo = "6db5425413694db7b8b5bcde9849a51c"
            ,
            url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
            ,
            url_bp_data = "/openapiv2/user/{0}/bp.json/"
            ,
            url_weight_data = "/openapiv2/user/{0}/weight.json/"
            ,
            url_bg_data = "/openapiv2/user/{0}/glucose.json/"
            ,
            url_bo_data = "/openapiv2/user/{0}/spo2.json/"
            ,
            url_ar_data = "/openapiv2/user/{0}/activity.json/"
            ,
            url_sr_data = "/openapiv2/user/{0}/sleep.json/"
            ,
            url_user_data = "/openapiv2/user/{0}.json/"
            ,
            url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
            ,
            url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
            ,
            url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
        };

        public static SystemSetting Service22Sandbox = new SystemSetting()
        {
            client_id = "4e691bb9e012401387db69f822dd2109"
            ,
            client_secret = "22e7c705abbc410082c35f57ef8ae538"
            ,
            redirect_uri = "http://192.168.8.34:8009/TestPage.aspx"
            ,
            sc = "d63493704c2c4104830f3202380e66cc"
            ,
            sv_OpenApiBP = "54f006ef99c043e381d2e939444c72c3"
            ,
            sv_OpenApiWeight = "97354b25d2124e65bfd1b7ca6fda3006"
            ,
            sv_OpenApiBG = "1294ef5fd0444fad8c7a568bcece2e47"
            ,
            sv_OpenApiSpO2 = "ef0af5f2e208481f97a1ab9a48d61e66"
            ,
            sv_OpenApiActivity = "a3f780f1e3274371a93b66d31e107c12"
            ,
            sv_OpenApiSleep = "67462ade904841d1b20314a97ca6e949"
            ,
            sv_OpenApiUserInfo = "6db5425413694db7b8b5bcde9849a51c"
            ,
            url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
            ,
            url_bp_data = "/openapiv2/user/{0}/bp.json/"
            ,
            url_weight_data = "/openapiv2/user/{0}/weight.json/"
            ,
            url_bg_data = "/openapiv2/user/{0}/glucose.json/"
            ,
            url_bo_data = "/openapiv2/user/{0}/spo2.json/"
            ,
            url_ar_data = "/openapiv2/user/{0}/activity.json/"
            ,
            url_sr_data = "/openapiv2/user/{0}/sleep.json/"
            ,
            url_user_data = "/openapiv2/user/{0}.json/"
            ,
            url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
            ,
            url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
            ,
            url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
        };

        public static SystemSetting ServiceTokyoSandbox = new SystemSetting()
        {
            client_id = "d260aaa30e5d48a4a1e772bb43cf05ff"
            ,
            client_secret = "8b7496e88c94489885ddef6bda43a79b"
            ,
            redirect_uri = "http://192.168.8.34:8009/TestPage.aspx"
            ,
            sc = "0ec7d50f393847b486b945f52f8d7d5f"
            ,
            sv_OpenApiBP = "a49339ba4dea4e78b8fa54e30209ee2a"
            ,
            sv_OpenApiWeight = "57c5c07edbe44a37acb9fda3acc1f3ab"
            ,
            sv_OpenApiBG = "9b2bf5029e664b3cb2f681f283f1fdd4"
            ,
            sv_OpenApiSpO2 = "e2ecd32ab6c84c77a00a4694b579f2e2"
            ,
            sv_OpenApiActivity = "652da8dce7c4460ca9bf27e502a61a36"
            ,
            sv_OpenApiSleep = "e24fbfc307fe4bca8a8b01200c7b41d0"
            ,
            sv_OpenApiUserInfo = "f02a76072aa64680b107c79c8013d8cb"
            ,
            url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
            ,
            url_bp_data = "/openapiv2/user/{0}/bp.json/"
            ,
            url_weight_data = "/openapiv2/user/{0}/weight.json/"
            ,
            url_bg_data = "/openapiv2/user/{0}/glucose.json/"
            ,
            url_bo_data = "/openapiv2/user/{0}/spo2.json/"
            ,
            url_ar_data = "/openapiv2/user/{0}/activity.json/"
            ,
            url_sr_data = "/openapiv2/user/{0}/sleep.json/"
            ,
            url_user_data = "/openapiv2/user/{0}.json/"
            ,
            url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
            ,
            url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
            ,
            url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
        };

        public static SystemSetting ServiceUSASandbox = new SystemSetting()
        {
            client_id = "18954694a2e44bc496e86ce364af046a"
            ,
            client_secret = "361ced3cf4554384916c6d992b4d0a5d"
            ,
            redirect_uri = "http://192.168.8.34:8009/TestPage.aspx"
            ,
            sc = "0ec7d50f393847b486b945f52f8d7d5f"
            ,
            sv_OpenApiBP = "1bb6837d12734504ad8db5f9556eeff1"
            ,
            sv_OpenApiWeight = "2137f31d8eb2492792a57d16eceaab51"
            ,
            sv_OpenApiBG = "ff35eed7ae2e4dab8fec16f3c1d5f22f"
            ,
            sv_OpenApiSpO2 = "5f3850bf430a47aea06f139e414c28eb"
            ,
            sv_OpenApiActivity = "7944c4ceccb14da29c854497838c9a00"
            ,
            sv_OpenApiSleep = "4a6e99ae57934d4085aba43986498aff"
            ,
            sv_OpenApiUserInfo = "ed2c1b602d064488b09297fb965c2053"
            ,
            url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
            ,
            url_bp_data = "/openapiv2/user/{0}/bp.json/"
            ,
            url_weight_data = "/openapiv2/user/{0}/weight.json/"
            ,
            url_bg_data = "/openapiv2/user/{0}/glucose.json/"
            ,
            url_bo_data = "/openapiv2/user/{0}/spo2.json/"
            ,
            url_ar_data = "/openapiv2/user/{0}/activity.json/"
            ,
            url_sr_data = "/openapiv2/user/{0}/sleep.json/"
            ,
            url_user_data = "/openapiv2/user/{0}.json/"
            ,
            url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
            ,
            url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
            ,
            url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
        };
    }
}
