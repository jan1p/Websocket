using System;
using System.Text;
using System.Collections.Generic;
using WatsonWebsocket;
using Produkt.Class;

namespace KassenUebersicht.Class
{
    internal class WebSocketServer
    {
        public WatsonWsServer Server { get; private set; }
        private Form1 _form;

        public WebSocketServer(Form1 form)
        {
            _form = form;
            Server = new WatsonWsServer("127.0.0.1", 8080);
            Server.ClientConnected += ClientConnected;
            Server.MessageReceived += Server_MessageReceived;
            Server.Start();
        }

        private void ClientConnected(object sender, ConnectionEventArgs e)
        {
            WebSocketServerForm send = (WebSocketServerForm)sender;
            string clientId = sender.ToString();
            Console.WriteLine($"Client connected: {clientId}");
            _form.AddClient(clientId);
        }

        private void Server_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            string result = Encoding.ASCII.GetString(e.Data.Array, e.Data.Offset, e.Data.Count);
            string[] temp = result.Split('#');

            if (temp.Length < 3) return;

            string clientId = temp[0];

            _form.UpdateDataGridView(temp[1], "Produkt", clientId);
        }
    }
}
