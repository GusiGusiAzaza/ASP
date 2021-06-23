using System;
using System.Web;

namespace asp1.httpHandlers
{
    public class IISHandler1 : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest req = context.Request;
            HttpResponse res = context.Response;

            switch (req.HttpMethod)
            {
                case "GET":
                {
                    res.AddHeader("Content-Type", "text/plain");
                    res.Write($"GET-HTTP-HKV:ParmA = {req.QueryString["ParmA"]}, ParmB = {req.QueryString["ParmB"]}");
                    break;
                }
                case "POST":
                {
                    res.AddHeader("Content-Type", "text/plain");
                    res.Write($"POST-HTTP-HKV:ParmA = {req.Params["ParmA"]}, ParmB = {req.Params["ParmB"]}");
                    break;
                }
                case "PUT":
                {
                    res.AddHeader("Content-Type", "text/plain");
                    res.Write($"PUT-HTTP-HKV:ParmA = {req.Params["ParmA"]}, ParmB = {req.Params["ParmB"]}");
                    break;
                }
                default:
                {
                    res.StatusCode = 405;
                    res.Write("405 - Method Not Allowed");
                    break;
                }
            }
        }

        #endregion
    }
}
