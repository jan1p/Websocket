using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public class WebSocketServerForm : Form
{
    private readonly Dictionary<string, Panel> _clientPanels = new Dictionary<string, Panel>();
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private PictureBox Status;
    private TextBox Rückgeld;
    private TextBox Gegeben;
    private TextBox GesamtPreis;
    private DataGridView KassenUebersicht;
    private DataGridViewTextBoxColumn Produktname;
    private DataGridViewTextBoxColumn Menge;
    private DataGridViewTextBoxColumn Einheit;
    private DataGridViewTextBoxColumn Preis;
    private DataGridViewTextBoxColumn MWST;
    private FlowLayoutPanel _panel;

    public WebSocketServerForm()
    {
        _panel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true };
        Controls.Add(_panel);
    }

    public async Task HandleNewClientAsync(string clientId, string uri)
    {
        try
        {
            var webSocket = new ClientWebSocket();
            await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);

            Invoke((MethodInvoker)(() =>
            {
                // Erstellt ein Panel für den neuen Client
                Panel clientPanel = new Panel
                {
                    Name = "ClientPanel_" + clientId,
                    Width = 420,
                    Height = 250,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lbl = new Label
                {
                    Text = $"Client {clientId} verbunden",
                    AutoSize = true
                };

                DataGridView dgv = new DataGridView
                {
                    Name = "Client_" + clientId,
                    Width = 400,
                    Height = 150,
                    ColumnCount = 3
                };

                Button btnAction = new Button
                {
                    Text = "Aktion ausführen",
                    AutoSize = true
                };

                clientPanel.Controls.Add(lbl);
                clientPanel.Controls.Add(dgv);
                clientPanel.Controls.Add(btnAction);

                _panel.Controls.Add(clientPanel);
                _clientPanels[clientId] = clientPanel;
            }));

            await ReceiveDataAsync(clientId, webSocket);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Fehler beim Verbinden des Clients {clientId}: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task ReceiveDataAsync(string clientId, ClientWebSocket webSocket)
    {
        var buffer = new byte[1024];

        while (webSocket.State == WebSocketState.Open)
        {
            try
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                string receivedData = Encoding.UTF8.GetString(buffer, 0, result.Count);

                Invoke((MethodInvoker)(() =>
                {
                    if (_clientPanels.TryGetValue(clientId, out var clientPanel))
                    {
                        var dgv = clientPanel.Controls.OfType<DataGridView>().FirstOrDefault();
                        if (dgv != null)
                        {
                            dgv.Rows.Add(receivedData.Split(',')); // Beispielhafte Verarbeitung
                        }
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Empfangen der Daten für Client {clientId}: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    private void InitializeComponent()
    {
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.PictureBox();
            this.Rückgeld = new System.Windows.Forms.TextBox();
            this.Gegeben = new System.Windows.Forms.TextBox();
            this.GesamtPreis = new System.Windows.Forms.TextBox();
            this.KassenUebersicht = new System.Windows.Forms.DataGridView();
            this.Produktname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Einheit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MWST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KassenUebersicht)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 616);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 31);
            this.label4.TabIndex = 17;
            this.label4.Text = "Abgeschlossen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 569);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 31);
            this.label3.TabIndex = 16;
            this.label3.Text = "Rückgeld";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 529);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 31);
            this.label2.TabIndex = 15;
            this.label2.Text = "Gegeben";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 485);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 31);
            this.label1.TabIndex = 14;
            this.label1.Text = "GesamtPreis";
            // 
            // Status
            // 
            this.Status.BackColor = System.Drawing.Color.Red;
            this.Status.Location = new System.Drawing.Point(347, 624);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(23, 23);
            this.Status.TabIndex = 13;
            this.Status.TabStop = false;
            // 
            // Rückgeld
            // 
            this.Rückgeld.Location = new System.Drawing.Point(270, 580);
            this.Rückgeld.Name = "Rückgeld";
            this.Rückgeld.Size = new System.Drawing.Size(100, 20);
            this.Rückgeld.TabIndex = 12;
            // 
            // Gegeben
            // 
            this.Gegeben.Location = new System.Drawing.Point(270, 540);
            this.Gegeben.Name = "Gegeben";
            this.Gegeben.Size = new System.Drawing.Size(100, 20);
            this.Gegeben.TabIndex = 11;
            // 
            // GesamtPreis
            // 
            this.GesamtPreis.Location = new System.Drawing.Point(270, 496);
            this.GesamtPreis.Name = "GesamtPreis";
            this.GesamtPreis.Size = new System.Drawing.Size(100, 20);
            this.GesamtPreis.TabIndex = 10;
            // 
            // KassenUebersicht
            // 
            this.KassenUebersicht.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KassenUebersicht.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Produktname,
            this.Menge,
            this.Einheit,
            this.Preis,
            this.MWST});
            this.KassenUebersicht.Location = new System.Drawing.Point(16, 1);
            this.KassenUebersicht.Name = "KassenUebersicht";
            this.KassenUebersicht.Size = new System.Drawing.Size(354, 481);
            this.KassenUebersicht.TabIndex = 9;
            // 
            // Produktname
            // 
            this.Produktname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Produktname.HeaderText = "Produktname";
            this.Produktname.Name = "Produktname";
            this.Produktname.Width = 95;
            // 
            // Menge
            // 
            this.Menge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Menge.HeaderText = "Menge";
            this.Menge.Name = "Menge";
            this.Menge.Width = 65;
            // 
            // Einheit
            // 
            this.Einheit.HeaderText = "Einheit";
            this.Einheit.Name = "Einheit";
            this.Einheit.Width = 50;
            // 
            // Preis
            // 
            this.Preis.HeaderText = "Preis";
            this.Preis.Name = "Preis";
            this.Preis.Width = 50;
            // 
            // MWST
            // 
            this.MWST.HeaderText = "MWST";
            this.MWST.Name = "MWST";
            this.MWST.Width = 50;
            // 
            // WebSocketServerForm
            // 
            this.ClientSize = new System.Drawing.Size(380, 649);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Rückgeld);
            this.Controls.Add(this.Gegeben);
            this.Controls.Add(this.GesamtPreis);
            this.Controls.Add(this.KassenUebersicht);
            this.Name = "WebSocketServerForm";
            ((System.ComponentModel.ISupportInitialize)(this.Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KassenUebersicht)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
