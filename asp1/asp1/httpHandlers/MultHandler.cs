using System;
using System.Web;
using Newtonsoft.Json;

namespace asp1.httpHandlers
{
    public class MultHandler : IHttpHandler
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
                    res.AddHeader("Content-Type", "text/html");
                    res.WriteFile(@"./static/mult.html");
                    break;
                }
                case "POST":
                {
                    res.AddHeader("Content-Type", "text/plain");
                    context.Response.AddHeader("Access-Control-Allow-Origin", "*");

                    if (int.TryParse(req.Params["x_value"], out var x) && int.TryParse(req.Params["y_value"], out var y))
                        res.Write($"X * Y = {x * y}");
                    else 
                        res.Write("Not a number");
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
