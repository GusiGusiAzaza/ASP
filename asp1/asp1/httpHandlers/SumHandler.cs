using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace asp1.httpHandlers
{
    public class SumHandler : IHttpHandler
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

            if (req.HttpMethod == "POST")
            {
                res.AddHeader("Content-Type", "text/plain");
                if (int.TryParse(req.Params["x_value"], out var x) && int.TryParse(req.Params["y_value"], out var y))
                    res.Write($"X + Y = {x + y}");
                else
                    res.Write("Not a number");
            }
            else
            {
                res.StatusCode = 405;
                res.Write("405 - Method Not Allowed");
            }
        }

        #endregion
    }
}
