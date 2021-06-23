using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace asp1.httpHandlers
{
    public class WsHandler : IHttpHandler
    {
        private WebSocket _socket;

        private readonly ReaderWriterLockSlim _locker = new ReaderWriterLockSlim();

        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Content-Type", "text/plain;charset=utf-8");
                if (context.IsWebSocketRequest)
                    context.AcceptWebSocketRequest(WebSocketRequest);
        }

        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            int i = 0;
            _locker.EnterWriteLock();
            try
            {
                _socket = context.WebSocket;
            }
            finally
            {
                _locker.ExitWriteLock();
            }

            while (true)
            {
                var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes($"{i++}"));

                Thread.Sleep(5000);

                try
                {
                    if (_socket.State == WebSocketState.Open)
                    {
                        await _socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }

                catch (ObjectDisposedException)
                {
                    _locker.EnterWriteLock();
                    try
                    {
                        _socket.Abort();
                    }
                    finally
                    {
                        _locker.ExitWriteLock();
                    }
                }
            }
        }
    }
}
