using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Test_Queue_Cloud_Azure
{
    public partial class TestQueue : Form
    {

        StringBuilder sb = new StringBuilder();

        // Retrieve storage account from connection string.



        CloudStorageAccount storageAccount = null;

        CloudQueueClient queueClient = null;

        CloudQueue queue = null;



        public TestQueue()
        {
            InitializeComponent();
        }

        private void TestQueue_Load(object sender, EventArgs e)
        {
            storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString")); //non mi ricordo più la key di azure quindi vado sul portale di azure, entro nel storage account che mi interessa e vedo il codice
            queueClient = storageAccount.CreateCloudQueueClient();
        }

        private void btnAddQueue_Click(object sender, EventArgs e)
        {
                     
            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference(txtQueueName.Text);

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            sb.Append(String.Format("Creata Queue {0}\r\n", txtQueueName.Text));
            txtLog.Text = sb.ToString();
        }

        private void btnEnqueue_Click(object sender, EventArgs e)
        {
            
            queue = queueClient.GetQueueReference(txtQueueName.Text);
            CloudQueueMessage message = new CloudQueueMessage(txtMsg.Text);
            queue.AddMessage(message);

            sb.Append(String.Format("Inserito il messaggio \"{0}\" nella coda \"{1}\"\r\n", txtMsg.Text, txtQueueName.Text));
            txtLog.Text = sb.ToString();
        }

        private void btnPeek_Click(object sender, EventArgs e)
        {
            // Retrieve a reference to a queue
            queue = queueClient.GetQueueReference(txtQueueName.Text);

            // Peek at the next message
            CloudQueueMessage peekedMessage = queue.PeekMessage();

            if (peekedMessage == null)
            {
                MessageBox.Show("La coda è vuota");
                return;
            }

            // Display message.
            sb.Append(String.Format("Ultimo PEEK:\r\n \"{0}\" dalla coda \"{1}\"\r\n", peekedMessage.AsString, txtQueueName.Text));
            txtLog.Text = sb.ToString();
            //MessageBox.Show(peekedMessage.AsString);
        }

        private void btnDequeue_Click(object sender, EventArgs e)
        {
            queue = queueClient.GetQueueReference(txtQueueName.Text);

            // Get the next message
            CloudQueueMessage retrievedMessage = queue.GetMessage();

            if (retrievedMessage == null)
            {
                MessageBox.Show("La coda è vuota");
                return;
            }

            //Process the message in less than 30 seconds, and then delete the message
            queue.DeleteMessage(retrievedMessage);

            sb.Append(String.Format("Scodato \"{0}\" dalla coda \"{1}\"\r\n", retrievedMessage.AsString, txtQueueName.Text));
            txtLog.Text = sb.ToString();
            //MessageBox.Show(retrievedMessage.AsString);

        }

        private void btnShowTableForm_Click(object sender, EventArgs e)
        {
            TestTable tt = new TestTable();
            tt.ShowDialog();
        }
    }
}
