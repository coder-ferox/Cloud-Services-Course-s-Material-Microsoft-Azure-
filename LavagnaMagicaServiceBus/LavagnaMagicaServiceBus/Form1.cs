using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace LavagnaMagicaServiceBus
{
    public partial class Form1 : Form
    {
        string connectionString = "Endpoint=sb://avsbtest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=removed because privacy purposes";
        string queueName = "05";
        QueueClient ReceiveClient;
        

        public Form1()
        {
            InitializeComponent();
        }

        int oldX, oldY;

        List<LineEntity> Lines = new List<LineEntity>();
            

        private void picBlkBrd_MouseMove(object sender, MouseEventArgs e)
        {
            lblX.Text = "X: " + e.X.ToString();
            lblY.Text = "Y: " + e.Y.ToString();

            if (e.Button == MouseButtons.Left)
            {
                DrawLine(e.X, e.Y, oldX, oldY,txtColor.Text);
                


                if (chkSend.Checked)
                {
                    LineEntity le = new LineEntity();
                    le.x1 = e.X;
                    le.y1 = e.Y;
                    le.x2 = oldX;
                    le.y2 = oldY;
                    le.color = txtColor.Text;
                    Lines.Add(le);
                    if (Lines.Count == 50)
                    {
                        SendLines(Lines);
                        Lines.Clear();
                    }
                            //SendLine(e.X, e.Y, oldX, oldY, txtColor.Text);
                }
                oldX = e.X;
                oldY = e.Y;
            }
        }

        private void SendLines(List<LineEntity> lines)
        {
            QueueClient client =
                QueueClient.CreateFromConnectionString(connectionString, queueName);
            StringBuilder sb = new StringBuilder();
            foreach (LineEntity le in lines)
            {
                sb.Append(le.x1.ToString() + ",");
                sb.Append(le.y1.ToString() + ",");
                sb.Append(le.x2.ToString() + ",");
                sb.Append(le.y2.ToString() + ",");
                sb.Append(le.color + ";");

            }
            BrokeredMessage message = new BrokeredMessage(sb.ToString());
            client.Send(message);
        }

        private void picBlkBrd_MouseDown(object sender, MouseEventArgs e)
        {
            

            if (e.Button == MouseButtons.Left)
            {
                
                oldX = e.X;
                oldY = e.Y; 
            }
        }

        private void chkSend_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSend.Checked)
                chkReceive.Checked = false;
        }

        private void chkReceive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReceive.Checked) {
                chkSend.Checked = false;

                ReceiveClient = QueueClient.CreateFromConnectionString(connectionString, queueName);
                ReceiveClient.OnMessage(message =>
                {
                    /*
                    string msg = message.GetBody<String>();
                    int x1 = int.Parse(msg.Split(',')[0]);
                    int y1 = int.Parse(msg.Split(',')[1]);
                    int x2 = int.Parse(msg.Split(',')[2]);
                    int y2 = int.Parse(msg.Split(',')[3]);
                    string color = msg.Split(',')[4];
                    DrawLine(x1, y1, x2, y2,color);
                    */
                    string msg = message.GetBody<String>();
                    string[] segs = msg.Split(';');

                    foreach (string seg in segs)
                    {
                        if (seg.Length > 0)
                        {
                            int x1 = int.Parse(seg.Split(',')[0]);
                            int y1 = int.Parse(seg.Split(',')[1]);
                            int x2 = int.Parse(seg.Split(',')[2]);
                            int y2 = int.Parse(seg.Split(',')[3]);
                            string color = seg.Split(',')[4];
                            DrawLine(x1, y1, x2, y2, color);
                        }
                    }

                    //MessageBox.Show(String.Format("Message body: {0},{1},{2},{3}",x1,y1,x2,y2));
                });          
            }
            else
            {
                ReceiveClient.Close();
                ReceiveClient = null;
            }
        }

        private void DrawLine(int x1,int y1, int x2, int y2, string color)
        {
            Color c = System.Drawing.ColorTranslator.FromHtml(color);
            Graphics g = picBlkBrd.CreateGraphics();
            g.DrawLine(new Pen(c), x1, y1, x2, y2);
            g.Dispose();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics g;
            g = picBlkBrd.CreateGraphics();
            g.Clear(Color.White);
            g.Dispose();
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            txtColor.Text = "#FF0000";
            
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            txtColor.Text = "#00FF00";

        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            txtColor.Text = "#0000FF";
        }

        private void btnViolet_Click(object sender, EventArgs e)
        {
            txtColor.Text = "#800080";
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            txtColor.Text = "#FFFF00";
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            txtColor.Text = "#000000";
        }

        private void SendLine (int x1,int y1,int x2,int y2, string color)
        {
            QueueClient client =
                QueueClient.CreateFromConnectionString(connectionString, queueName);
            BrokeredMessage message = new BrokeredMessage(
                x1.ToString() + "," + y1.ToString() + "," +
                x2.ToString() + "," + y2.ToString() + "," + color);
            client.Send(message);
         }

    }
}
