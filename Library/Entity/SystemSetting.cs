using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHealthlabs.OpenAPI.Sample.Library.Entity
{
   // public class SystemSetting
   // {
   //     public string url_authorization { get; set; }
   //     public string url_bp_data { get; set; }
   //     public string url_bp_data_xml { get; set; }
   //     public string url_weight_data { get; set; }
   //     public string url_weight_data_xml { get; set; }
   //     public string url_bg_data { get; set; }
   //     public string url_bg_data_xml { get; set; }
   //     public string url_bo_data { get; set; }
   //     public string url_bo_data_xml { get; set; }
   //     public string url_ar_data { get; set; }
   //     public string url_ar_data_xml { get; set; }
   //     public string url_sr_data { get; set; }
   //     public string url_sr_data_xml { get; set; }
   //     public string url_user_data { get; set; }
   //     public string url_food_data { get; set; }
   //     public string url_sport_data { get; set; }

   //     public string url_bp_data_client { get; set; }
   //     public string url_weight_data_client { get; set; }
   //     public string url_bg_data_client { get; set; }
   //     public string url_bo_data_client { get; set; }
   //     public string url_ar_data_client { get; set; }
   //     public string url_sr_data_client { get; set; }
   //     public string url_user_data_client { get; set; }
   //     public string url_food_data_client { get; set; }
   //     public string url_sport_data_client { get; set; }

   //     public string client_id { get; set; }
   //     public string client_secret { get; set; }
   //     public string redirect_uri { get; set; }
   //     public string sc { get; set; }
   //     public string sv_OpenApiBP { get; set; }
   //     public string sv_OpenApiWeight { get; set; }
   //     public string sv_OpenApiBG { get; set; }
   //     public string sv_OpenApiSpO2 { get; set; }
   //     public string sv_OpenApiActivity { get; set; }
   //     public string sv_OpenApiSleep { get; set; }
   //     public string sv_OpenApiUserInfo { get; set; }
   //     public string sv_OpenApiFood { get; set; }
   //     public string sv_OpenApiSport { get; set; }

   //     public string url_authorization_1 { get; set; }
   //     public string url_bp_data_1 { get; set; }
   //     public string url_weight_data_1 { get; set; }

   // }

   // public class URLEntity
   // {
   //     public string URL { get; set; }
   //     public string Type { get; set; }
   // }

   // public class ServiceSetting
   // {
   //     public static List<URLEntity> GetUrlList(string aAppSettings)
   //     {
   //         string SettingString = aAppSettings;
   //         if (!string.IsNullOrEmpty(SettingString))
   //         {
   //             List<URLEntity> ResultList = new List<URLEntity>();

   //             List<string> UrlList = SettingString.Split('@').ToList();

   //             for (int i = 0; i < UrlList.Count; i++)
   //             {
   //                 string itemString = UrlList[i];
   //                 if (itemString.Length > 0)
   //                 {
   //                     string[] StringArray = itemString.Split('#');
   //                     if (StringArray.Length > 0)
   //                     {
   //                         URLEntity temp = new URLEntity();
   //                         temp.Type = StringArray[0];
   //                         temp.URL = StringArray[1];
   //                         ResultList.Add(temp);
   //                     }
   //                 }
   //             }
   //             return ResultList;
   //         }
   //         else
   //         {
   //             return null;
   //         }
   //     }


   //     public static SystemSetting GetByChoose(string aChoose)
   //     {
   //         if (aChoose == "54")
   //         {
   //             return Service63;
   //         }
   //         else if (aChoose == "22")
   //         {
   //             return Service22;
   //         }
   //         else if (aChoose == "tokyo")
   //         {
   //             return ServiceTokyo;
   //         }
   //         else if (aChoose == "usa")
   //         {
   //             return ServiceUSA;
   //         }
   //         else
   //         {
   //             return Service63;
   //         }
   //     }

   //     public static SystemSetting Service63 = new SystemSetting()
   //     {
   //         client_id = "4e691bb9e012401387db69f822dd2109"
   //         ,
   //         client_secret = "22e7c705abbc410082c35f57ef8ae538"
   //         ,
   //         redirect_uri = "http://192.168.8.34:8009/TestPage.aspx"
   //         ,
   //         sc = "d63493704c2c4104830f3202380e66cc"
   //         ,
   //         sv_OpenApiBP = "54f006ef99c043e381d2e939444c72c3"
   //         ,
   //         sv_OpenApiWeight = "97354b25d2124e65bfd1b7ca6fda3006"
   //         ,
   //         sv_OpenApiBG = "1294ef5fd0444fad8c7a568bcece2e47"
   //         ,
   //         sv_OpenApiSpO2 = "ef0af5f2e208481f97a1ab9a48d61e66"
   //         ,
   //         sv_OpenApiActivity = "a3f780f1e3274371a93b66d31e107c12"
   //         ,
   //         sv_OpenApiSleep = "67462ade904841d1b20314a97ca6e949"
   //         ,
   //         sv_OpenApiUserInfo = "6db5425413694db7b8b5bcde9849a51c"
   //         ,
   //         url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
   //         ,
   //         url_bp_data = "/openapiv2/user/{0}/bp.json/"
   //         ,
   //         url_weight_data = "/openapiv2/user/{0}/weight.json/"
   //         ,
   //         url_bg_data = "/openapiv2/user/{0}/glucose.json/"
   //         ,
   //         url_bo_data = "/openapiv2/user/{0}/spo2.json/"
   //         ,
   //         url_ar_data = "/openapiv2/user/{0}/activity.json/"
   //         ,
   //         url_sr_data = "/openapiv2/user/{0}/sleep.json/"
   //         ,
   //         url_user_data = "/openapiv2/user/{0}.json/"
   //         ,
   //         url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
   //         ,
   //         url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
   //         ,
   //         url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
   //         ,
   //         url_bp_data_client = "/openapiv2/application/bp.json/"
   //         ,
   //         url_weight_data_client = "/openapiv2/application/weight.json/"
   //         ,
   //         url_bg_data_client = "/openapiv2/application/glucose.json/"
   //         ,
   //         url_bo_data_client = "/openapiv2/application/spo2.json/"
   //         ,
   //         url_ar_data_client = "/openapiv2/application/activity.json/"
   //         ,
   //         url_sr_data_client = "/openapiv2/application/sleep.json/"
   //         ,
   //         url_user_data_client = "/openapiv2/application/userinfo.json/"
   //     };

   //     public static SystemSetting Service22 = new SystemSetting()
   //     {
   //         client_id = "0fcaa97eceed4bdbacbddf7793b5f3ac"
   //         ,
   //         client_secret = "f761d325640d456294619c70b4f21ed5"
   //         ,
   //         redirect_uri = "http://192.168.1.22:8029/testopenapi/TestPage.aspx"
   //         ,
   //         sc = "58cee4eae6f943bd93a0c5bae3b46970"
   //         ,
   //         sv_OpenApiBP = "081464b08b9340bbb8e71ad5c85de216"
   //         ,
   //         sv_OpenApiWeight = "21c00505a41448f289860456278432e8"
   //         ,
   //         sv_OpenApiBG = "8c8d498fb1194b679f1e14d75cbf79eb"
   //         ,
   //         sv_OpenApiSpO2 = "a68eb8917d1b4ed5bd704f6d9318d0d8"
   //         ,
   //         sv_OpenApiActivity = "b8f8f3546da64dc69da14c44a15ea86f"
   //         ,
   //         sv_OpenApiSleep = "88649d90f6354fcf8576e878ca076ff5"
   //         ,
   //         sv_OpenApiUserInfo = "d9cd3c7e2bf94ed9b6ab641d006ec1f6"
   //         ,
   //         sv_OpenApiFood = "f62932d1daea47c6b423fa359f34240d"
   //         ,
   //         sv_OpenApiSport = "13867e862214484689855a2576b45be1"
   //         ,
   //         url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
   //         ,
   //         url_bp_data = "/openapiv2/user/{0}/bp.json/"
   //         ,
   //         url_bp_data_xml = "/openapiv2/user/{0}/bp.xml/"
   //         ,
   //         url_weight_data = "/openapiv2/user/{0}/weight.json/"
   //         ,
   //         url_weight_data_xml = "/openapiv2/user/{0}/weight.xml/"
   //         ,
   //         url_bg_data = "/openapiv2/user/{0}/glucose.json/"
   //         ,
   //         url_bg_data_xml = "/openapiv2/user/{0}/glucose.xml/"
   //         ,
   //         url_bo_data = "/openapiv2/user/{0}/spo2.json/"
   //         ,
   //         url_bo_data_xml = "/openapiv2/user/{0}/spo2.xml/"
   //         ,
   //         url_ar_data = "/openapiv2/user/{0}/activity.json/"
   //         ,
   //         url_ar_data_xml = "/openapiv2/user/{0}/activity.xml/"
   //         ,
   //         url_sr_data = "/openapiv2/user/{0}/sleep.json/"
   //         ,
   //         url_sr_data_xml = "/openapiv2/user/{0}/sleep.xml/"
   //         ,
   //         url_user_data = "/openapiv2/user/{0}.json/"
   //         ,
   //         url_food_data = "/openapiv2/user/{0}/food.json/"
   //         ,
   //         url_sport_data = "/openapiv2/user/{0}/sport.json/"
   //         ,

   //         url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
   //         ,
   //         url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
   //         ,
   //         url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
   //         ,
   //         url_bp_data_client = "/openapiv2/application/bp.json/"
   //         ,
   //         url_weight_data_client = "/openapiv2/application/weight.json/"
   //         ,
   //         url_bg_data_client = "/openapiv2/application/glucose.json/"
   //         ,
   //         url_bo_data_client = "/openapiv2/application/spo2.json/"
   //         ,
   //         url_ar_data_client = "/openapiv2/application/activity.json/"
   //         ,
   //         url_sr_data_client = "/openapiv2/application/sleep.json/"
   //         ,
   //         url_user_data_client = "/openapiv2/application/userinfo.json/"
   //         ,
   //         url_food_data_client = "/openapiv2/application/food.json/"
   //         ,
   //         url_sport_data_client = "/openapiv2/application/sport.json/"
   //     };

   //     public static SystemSetting ServiceTokyo = new SystemSetting()
   //{
   //    client_id = "d260aaa30e5d48a4a1e772bb43cf05ff"
   //    ,
   //    client_secret = "8b7496e88c94489885ddef6bda43a79b"
   //    ,
   //    redirect_uri = "http://192.168.8.34:8009/TestPage.aspx"
   //    ,
   //    sc = "0ec7d50f393847b486b945f52f8d7d5f"
   //    ,
   //    sv_OpenApiBP = "a49339ba4dea4e78b8fa54e30209ee2a"
   //    ,
   //    sv_OpenApiWeight = "57c5c07edbe44a37acb9fda3acc1f3ab"
   //    ,
   //    sv_OpenApiBG = "9b2bf5029e664b3cb2f681f283f1fdd4"
   //    ,
   //    sv_OpenApiSpO2 = "e2ecd32ab6c84c77a00a4694b579f2e2"
   //    ,
   //    sv_OpenApiActivity = "652da8dce7c4460ca9bf27e502a61a36"
   //    ,
   //    sv_OpenApiSleep = "e24fbfc307fe4bca8a8b01200c7b41d0"
   //    ,
   //    sv_OpenApiUserInfo = "f02a76072aa64680b107c79c8013d8cb"
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


   //     public static SystemSetting ServiceUSA = new SystemSetting()
   //    {
   //        client_id = "2a8387e3f4e94407a3a767a72dfd52ea"
   //            ,
   //        client_secret = "fd5e845c47944a818bc511fb7edb0a77"
   //            ,
   //        redirect_uri = "http://203.195.180.233:8009/TestPage.aspx"
   //        ,
   //        sc = "c47c2bc6b71a4938a3bb87819918aadc"
   //        ,
   //        sv_OpenApiBP = "1ce66ec1758b48acbc29b638cc68fc0c"
   //        ,
   //        sv_OpenApiWeight = "041887bc341241feb6cb82a8567f05a6"
   //        ,
   //        sv_OpenApiBG = "79709628e0dc48ae9a01673ca6a3235f"
   //        ,
   //        sv_OpenApiSpO2 = "ceee88c31119453b90ada7a9dde1ae8e"
   //        ,
   //        sv_OpenApiActivity = "9fa46008ea974c018ab649445b4538fe"
   //        ,
   //        sv_OpenApiSleep = "43f68d3478aa436abd96a440a6d7fd64"
   //        ,
   //        sv_OpenApiUserInfo = "21ab802f66a445baa2bcebbc5b5e8f05"
   //        ,
   //        url_authorization = "/OpenApiV2/OAuthv2/userauthorization"
   //        ,
   //        url_bp_data = "/openapiv2/user/{0}/bp.json/"
   //        ,
   //        url_weight_data = "/openapiv2/user/{0}/weight.json/"
   //        ,
   //        url_bg_data = "/openapiv2/user/{0}/glucose.json/"
   //        ,
   //        url_bo_data = "/openapiv2/user/{0}/spo2.json/"
   //        ,
   //        url_ar_data = "/openapiv2/user/{0}/activity.json/"
   //        ,
   //        url_sr_data = "/openapiv2/user/{0}/sleep.json/"
   //        ,
   //        url_user_data = "/openapiv2/user/{0}.json/"
   //        ,
   //        url_authorization_1 = "/api/OAuthv2/userauthorization.ashx"
   //        ,
   //        url_bp_data_1 = "/api/OpenApi/downloadbpdata.ashx"
   //        ,
   //        url_weight_data_1 = "/api/OpenApi/downloadweightdata.ashx"
   //        ,
   //        url_bp_data_client = "/openapiv2/application/bp.json/"
   //        ,
   //        url_weight_data_client = "/openapiv2/application/weight.json/"
   //        ,
   //        url_bg_data_client = "/openapiv2/application/glucose.json/"
   //        ,
   //        url_bo_data_client = "/openapiv2/application/spo2.json/"
   //        ,
   //        url_ar_data_client = "/openapiv2/application/activity.json/"
   //        ,
   //        url_sr_data_client = "/openapiv2/application/sleep.json/"
   //        ,
   //        url_user_data_client = "/openapiv2/application/userinfo.json/"
   //    };
   // }
}
