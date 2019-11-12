using System;
using System.Web;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using System.Net.WebSockets;
using System.Web.WebSockets;

namespace SimpleWeSocketbApplication
{
  public class WebSocketHandler : IHttpHandler
  {
    public void ProcessRequest(HttpContext context)
    {
      //Проверяем, является ли запрос, запросом по протоколу WebSocket.
      if (context.IsWebSocketRequest)
      {
        //Если да, назначаем асинхронный обработчик.
        context.AcceptWebSocketRequest(WebSocketRequestHandler);
      }
    }

    public bool IsReusable { get { return false; } }

    //Асинхронный обработчик запроса.
    public async Task WebSocketRequestHandler(AspNetWebSocketContext webSocketContext)
    {
      //Получаем текущий объект веб-сокета.
      WebSocket webSocket = webSocketContext.WebSocket;

      /*Определяем некую константу, которая будет представлять
      максимльный размер входных данных. Её устанавливаем мы и значение
      можем задать любым. Мы знаем, что в данном случае размер пересылаемых
      данных очень мал.
      */
      const int maxMessageSize = 1024;

      //Буфер битов, в который будут записываться полученные данные.
      ArraySegment<Byte> receivedDataBuffer = new ArraySegment<Byte>(new Byte[maxMessageSize]);

      //Токен отмены, в данном примере не используется.
      var cancellationToken = new CancellationToken();

      //Проверяем состояние веб-сокета.
      while (webSocket.State == WebSocketState.Open)
      {
        //Читаем данные.
        WebSocketReceiveResult webSocketReceiveResult = 
          await webSocket.ReceiveAsync(receivedDataBuffer, cancellationToken);
        //Смотрим, если входной фрейм закрывающий, посылаем ответ на закрытие.
        if (webSocketReceiveResult.MessageType == WebSocketMessageType.Close)
        {
          await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, 
            String.Empty, cancellationToken);
        }
        else
        {
          //Читаем только те байты, которые пришли.
          byte[] payloadData = receivedDataBuffer.Array.Where(b => b != 0).ToArray();
          //Поскольку мы знаем, что это строка, то конвертируем.
          string receiveString = 
            System.Text.UTF8Encoding.UTF8.GetString(payloadData, 0, payloadData.Length);
          //Собираем новую строку и преобразовываем в массив байт.
          var newString = 
            String.Format("Hello, " + receiveString + " ! Time {0}", DateTime.Now.ToString());
          Byte[] bytes = System.Text.UTF8Encoding.UTF8.GetBytes(newString);
          //Отсылаем данные обратно браузеру.
          await webSocket.SendAsync(new ArraySegment<byte>(bytes),
            WebSocketMessageType.Text, true, cancellationToken);
        }
      }
    }
  }
}