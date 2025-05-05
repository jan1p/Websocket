using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Class
{


    public class WatsonWebSocketClient
    {
        private readonly ClientWebSocket _webSocket = new ClientWebSocket();

        public async Task ConnectAsync(string uri)
        {
            await _webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
            MessageBox.Show("Connected to Watson WebSocket");
        }

        public async Task SendMessageAsync(string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task ReceiveMessageAsync()
        {
            var buffer = new byte[1024];
            var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            string response = Encoding.UTF8.GetString(buffer, 0, result.Count);
            MessageBox.Show($"Received: {response}");
        }
    }

}

