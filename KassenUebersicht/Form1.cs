using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WatsonWebsocket;
using Produkt.Class;
using KassenUebersicht.Class;
using Produkt;

namespace KassenUebersicht
{
    public partial class Form1 : Form
    {
        private WebSocketServer _server;
        private FlowLayoutPanel _panel;
        private Dictionary<string, DataGridView> _clientGridViews = new Dictionary<string, DataGridView>();

        public Form1()
        {
            InitializeComponent();

            // Erstelle das Panel, um DataGridViews für jeden Client zu speichern
            _panel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true };
            Controls.Add(_panel);

            // WebSocket-Server starten
            _server = new WebSocketServer(this);
        }

        public void AddClient(string clientId)
        {
            Invoke((MethodInvoker)(() =>
            {
                if (!_clientGridViews.ContainsKey(clientId))
                {
                    
                    Label lbl = new Label
                    {
                        Text = $"Client {clientId} verbunden",
                        AutoSize = true
                    };

                    DataGridView dgv = new DataGridView
                    {
                        Name = "Client_" + clientId,
                        Width = 400,
                        Height = 200,
                        ColumnCount = 3
                    };

                    _panel.Controls.Add(lbl);
                    _panel.Controls.Add(dgv);
                    _clientGridViews[clientId] = dgv;
                }
            }));
        }

        public void UpdateDataGridView(object data, string type, string clientId)
        {
            Invoke((MethodInvoker)(() =>
            {
                if (_clientGridViews.TryGetValue(clientId, out var dgv))
                {
                    if (type == "Produkt")
                    {
                        var produkt = data as Produktnew;
                        dgv.Rows.Add(produkt.Produktname, produkt.Menge, produkt.Einheit, produkt.VKStueckpreis);
                    }
                }
            }));
        }
    }
}


