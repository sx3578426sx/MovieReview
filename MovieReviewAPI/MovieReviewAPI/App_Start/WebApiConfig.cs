using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace MovieReviewAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務
            // 允許XML格式資料序列化
            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 設定回傳 format 可以是 json 或 xml
            config.Formatters.JsonFormatter.AddQueryStringMapping("$format", "json", "application/json");
            config.Formatters.XmlFormatter.AddQueryStringMapping("$format", "xml", "application/xml");
        }
    }
}
