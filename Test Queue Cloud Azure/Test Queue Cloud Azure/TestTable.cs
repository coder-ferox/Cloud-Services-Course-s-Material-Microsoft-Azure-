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
using Microsoft.WindowsAzure.Storage.Table;


namespace Test_Queue_Cloud_Azure
{
    public partial class TestTable : Form
    {

        StringBuilder sb,list = new StringBuilder();

        public TestTable()
        {
            InitializeComponent();
        }

        private void btnMakeTable_Click(object sender, EventArgs e)
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference(txtTableName.Text);

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();

            sb.Append(String.Format("Creata la tabella {0}\r\n", txtTableName.Text));
            txtLog.Text = sb.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertCustomer_Click(object sender, EventArgs e)
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(txtTableName.Text);

            // Create a new customer entity.
            CustomerEntity customer1 = new CustomerEntity(txtLastName.Text, txtFirstName.Text);
            customer1.Email = txtEmail.Text;
            customer1.PhoneNumber = txtPhoneNum.Text;

            // Create the TableOperation object that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(customer1);

            // Execute the insert operation.
            table.Execute(insertOperation);

            sb.Append(String.Format("Inserita Entità {0} {1} {2} {3} in tabella {4}\r\n",txtLastName.Text,txtFirstName.Text,txtPhoneNum.Text,txtEmail.Text,txtTableName.Text));
            txtLog.Text = sb.ToString();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(txtTableName.Text);

            // Create the table query.
            TableQuery<CustomerEntity> rangeQuery = new TableQuery<CustomerEntity>().Where(
                
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, txtPartitionKey.Text));
                    

            // Loop through the results, displaying information about the entity.
            foreach (CustomerEntity entity in table.ExecuteQuery(rangeQuery))
            {
                list.Append(String.Format("{0} {1} {2} {3}\r\n",entity.PartitionKey, entity.RowKey, entity.PhoneNumber, entity.Email));
                txtQueryResult.Text = list.ToString();
            }
        }
    }
}
