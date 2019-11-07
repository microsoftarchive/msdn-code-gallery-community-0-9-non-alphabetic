<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs"
  Inherits="SimpleWeSocketbApplication.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <span id="webSocketStatusSpan"></span>
      <br />
      <span id="webSocketReceiveDataSpan"></span>
      <br />
      <span>Введите строку для отправки</span>
      <br />
      <input id="nameTextBox" type="text" value="" />
      <input type="button" value="Отправить данные" onclick="SendData();" />
      <input type="button" value="Закрыть веб-сокет" onclick="CloseWebSocket();" />
    </div>
  </form>
  <script type="text/javascript">

    var webSocketStatusSpan = document.getElementById("webSocketStatusSpan");
    var webSocketReceiveDataSpan = document.getElementById("webSocketReceiveDataSpan");
    var nameTextBox = document.getElementById("nameTextBox");

    var webSocket;
    //Адрес нашего обработчика HTTP-данных, который будет отвечать на запросы.
    var handlerUrl = "ws://localhost/SimpleWebSocketApplication/WebSocketHandler.ashx";

    //Метод отправляющий данные.
    function SendData() {
      //Метод инициализирующий веб-сокет.
      InitWebSocket();
      //Смотрим, если веб-сокет открыт и готов к использованию
      //отправляем данные.
      if (webSocket.OPEN && webSocket.readyState == 1)
        webSocket.send(nameTextBox.value);
      //Если веб-сокет закрывается или закрыт, выводим сообщение.
      if (webSocket.readyState == 2 || webSocket.readyState == 3)
        webSocketStatusSpan.innerText = "Веб-сокет закрыт, отправить данные невозможно."
    }
    function CloseWebSocket() {
      //Функция для программного закрытия веб-сокета.
      //После закрытия, получать или отправлять данные не получится.
      webSocket.close();
    }
    function InitWebSocket() {
      //Если объект веб-сокета не инициализирован, инициализируем его.
      if (webSocket == undefined) {
        webSocket = new WebSocket(handlerUrl);

        //Устанавливаем обработчик открытия соединения.
        webSocket.onopen = function () {
          webSocketStatusSpan.innerText = "Веб-сокет окрыт."
          webSocket.send(nameTextBox.value);
        };

        //Устанавливаем обработчик получения данных.
        webSocket.onmessage = function (e) {
          webSocketReceiveDataSpan.innerText = e.data;
        };

        //Устанавливаем обработчик закрытия соединения.
        webSocket.onclose = function () {
          webSocketStatusSpan.innerText = "Веб-сокет закрыт."
        };

        //Устанавливаем обработчик ошибки.
        webSocket.onerror = function (e) {
          webSocketStatusSpan.innerText = e.message;
        }
      }
    }

  </script>
</body>
</html>
