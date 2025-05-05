using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Produkt;
using Client.Class;

namespace Client
{
    public partial class Form1 : Form
    {
        string serverUri = "ws://127.0.0.1:8080";
        WatsonWebSocketClient client;
        public Form1()
        {
            InitializeComponent();
            client = new WatsonWebSocketClient();
            client.ConnectAsync(serverUri);

        }

        private void SendenArtikel_Click(object sender, EventArgs e)
        {
            client.SendMessageAsync(TestArtikel.Text);
        }

        private void SendenGegeben_Click(object sender, EventArgs e)
        {
            client.SendMessageAsync(Gegeben.Text);
        }

        private void Rueckgeld_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void SendenRueckgeld_Click(object sender, EventArgs e)
        {
 client.SendMessageAsync(Rueckgeld.Text);
        }
    }
}
