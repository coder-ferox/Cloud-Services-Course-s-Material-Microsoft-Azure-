using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types


namespace BlobClientAzure
{
    public partial class testcloudblob : Form
    {

        string log = "";

        public testcloudblob()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCreaContainer_Click(object sender, EventArgs e)
        {
            

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference(txtNomeContainer.Text);

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();
            log += "Creato " + txtNomeContainer.Text + "\n";

            txtLog.Text = log;
            
            
        }

        private void btnUplFileBlob_Click(object sender, EventArgs e)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(txtNomeContainer.Text);

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(txtNomeBlob.Text);

            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = System.IO.File.OpenRead(txtFileName.Text))
            {
                blockBlob.UploadFromStream(fileStream);
                log += "Caricato file " + txtFileName.Text + " in Blob: " + txtNomeBlob.Text + " in Container: " + txtNomeContainer.Text + "\n";
                txtLog.Text = log;
           
            }



        }

        private void btnDownloadFileBlob_Click(object sender, EventArgs e)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(txtNomeContainer.Text);

            // Retrieve reference to a blob named "photo1.jpg".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(txtNomeBlob.Text);

            // Save blob contents to a file.
            using (var fileStream = System.IO.File.OpenWrite(txtFileName.Text))
            {
                blockBlob.DownloadToStream(fileStream);
                log += "Scaricato file " + txtFileName.Text + " da Blob: " + txtNomeBlob.Text + " in Container: " + txtNomeContainer.Text + "\n";
                txtLog.Text = log;
            }
        }

        private void btnDelFileBlob_Click(object sender, EventArgs e)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(txtNomeContainer.Text);

            // Retrieve reference to a blob named "myblob.txt".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(txtNomeBlob.Text);

            // Delete the blob.
            blockBlob.Delete();
            log += "Cancellato Blob " + txtNomeBlob.Text + " in Container: " + txtNomeContainer.Text + "\n";
            txtLog.Text = log;
        }
               

        private void btnListaBlob_Click(object sender, EventArgs e)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(txtNomeContainer.Text);

            StringBuilder sb = new StringBuilder();

            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;

                    sb.Append(String.Format("Block blob of length {0}: {1}\r\n", blob.Properties.Length, blob.Uri));

                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    CloudPageBlob pageBlob = (CloudPageBlob)item;

                    sb.Append(String.Format("Page blob of length {0}: {1}\r\n", pageBlob.Properties.Length, pageBlob.Uri));

                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory directory = (CloudBlobDirectory)item;

                    sb.Append(String.Format("Directory: {0}\r\n", directory.Uri));
                }
            }
            txtListaBlob.Text = sb.ToString();
        }
    }
}
