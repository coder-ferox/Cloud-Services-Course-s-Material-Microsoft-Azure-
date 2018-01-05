namespace BlobClientAzure
{
    partial class testcloudblob
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreaContainer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeContainer = new System.Windows.Forms.TextBox();
            this.txtNomeBlob = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpContBlob = new System.Windows.Forms.GroupBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grp = new System.Windows.Forms.GroupBox();
            this.btnDelFileBlob = new System.Windows.Forms.Button();
            this.btnDownloadFileBlob = new System.Windows.Forms.Button();
            this.btnUplFileBlob = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtListaBlob = new System.Windows.Forms.TextBox();
            this.btnListaBlob = new System.Windows.Forms.Button();
            this.grpContBlob.SuspendLayout();
            this.grp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreaContainer
            // 
            this.btnCreaContainer.Location = new System.Drawing.Point(292, 21);
            this.btnCreaContainer.Name = "btnCreaContainer";
            this.btnCreaContainer.Size = new System.Drawing.Size(75, 23);
            this.btnCreaContainer.TabIndex = 2;
            this.btnCreaContainer.Text = "+ Container";
            this.btnCreaContainer.UseVisualStyleBackColor = true;
            this.btnCreaContainer.Click += new System.EventHandler(this.btnCreaContainer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome Blob";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtNomeContainer
            // 
            this.txtNomeContainer.Location = new System.Drawing.Point(105, 23);
            this.txtNomeContainer.Name = "txtNomeContainer";
            this.txtNomeContainer.Size = new System.Drawing.Size(181, 20);
            this.txtNomeContainer.TabIndex = 1;
            // 
            // txtNomeBlob
            // 
            this.txtNomeBlob.Location = new System.Drawing.Point(105, 54);
            this.txtNomeBlob.Name = "txtNomeBlob";
            this.txtNomeBlob.Size = new System.Drawing.Size(181, 20);
            this.txtNomeBlob.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Container";
            // 
            // grpContBlob
            // 
            this.grpContBlob.Controls.Add(this.label1);
            this.grpContBlob.Controls.Add(this.txtNomeContainer);
            this.grpContBlob.Controls.Add(this.btnCreaContainer);
            this.grpContBlob.Location = new System.Drawing.Point(12, 12);
            this.grpContBlob.Name = "grpContBlob";
            this.grpContBlob.Size = new System.Drawing.Size(380, 58);
            this.grpContBlob.TabIndex = 5;
            this.grpContBlob.TabStop = false;
            this.grpContBlob.Text = "Container / Blob Info";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(117, 104);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(181, 20);
            this.txtFileName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome File";
            // 
            // grp
            // 
            this.grp.Controls.Add(this.btnDelFileBlob);
            this.grp.Controls.Add(this.btnDownloadFileBlob);
            this.grp.Controls.Add(this.btnUplFileBlob);
            this.grp.Controls.Add(this.txtNomeBlob);
            this.grp.Controls.Add(this.label2);
            this.grp.Location = new System.Drawing.Point(12, 76);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(380, 114);
            this.grp.TabIndex = 7;
            this.grp.TabStop = false;
            this.grp.Text = "File in Blob";
            // 
            // btnDelFileBlob
            // 
            this.btnDelFileBlob.Location = new System.Drawing.Point(292, 52);
            this.btnDelFileBlob.Name = "btnDelFileBlob";
            this.btnDelFileBlob.Size = new System.Drawing.Size(75, 23);
            this.btnDelFileBlob.TabIndex = 7;
            this.btnDelFileBlob.Text = "- File in Blob";
            this.btnDelFileBlob.UseVisualStyleBackColor = true;
            this.btnDelFileBlob.Click += new System.EventHandler(this.btnDelFileBlob_Click);
            // 
            // btnDownloadFileBlob
            // 
            this.btnDownloadFileBlob.Location = new System.Drawing.Point(105, 80);
            this.btnDownloadFileBlob.Name = "btnDownloadFileBlob";
            this.btnDownloadFileBlob.Size = new System.Drawing.Size(181, 23);
            this.btnDownloadFileBlob.TabIndex = 6;
            this.btnDownloadFileBlob.Text = "Download File da Blob";
            this.btnDownloadFileBlob.UseVisualStyleBackColor = true;
            this.btnDownloadFileBlob.Click += new System.EventHandler(this.btnDownloadFileBlob_Click);
            // 
            // btnUplFileBlob
            // 
            this.btnUplFileBlob.Location = new System.Drawing.Point(292, 26);
            this.btnUplFileBlob.Name = "btnUplFileBlob";
            this.btnUplFileBlob.Size = new System.Drawing.Size(75, 22);
            this.btnUplFileBlob.TabIndex = 5;
            this.btnUplFileBlob.Text = "+ File in Blob";
            this.btnUplFileBlob.UseVisualStyleBackColor = true;
            this.btnUplFileBlob.Click += new System.EventHandler(this.btnUplFileBlob_Click);
            // 
            // txtLog
            // 
            this.txtLog.Enabled = false;
            this.txtLog.Location = new System.Drawing.Point(12, 398);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(380, 74);
            this.txtLog.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnListaBlob);
            this.groupBox1.Controls.Add(this.txtListaBlob);
            this.groupBox1.Location = new System.Drawing.Point(13, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 195);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista BLOB";
            // 
            // txtListaBlob
            // 
            this.txtListaBlob.Enabled = false;
            this.txtListaBlob.Location = new System.Drawing.Point(6, 19);
            this.txtListaBlob.Multiline = true;
            this.txtListaBlob.Name = "txtListaBlob";
            this.txtListaBlob.Size = new System.Drawing.Size(279, 170);
            this.txtListaBlob.TabIndex = 0;
            // 
            // btnListaBlob
            // 
            this.btnListaBlob.Location = new System.Drawing.Point(291, 19);
            this.btnListaBlob.Name = "btnListaBlob";
            this.btnListaBlob.Size = new System.Drawing.Size(75, 22);
            this.btnListaBlob.TabIndex = 8;
            this.btnListaBlob.Text = "Lista";
            this.btnListaBlob.UseVisualStyleBackColor = true;
            this.btnListaBlob.Click += new System.EventHandler(this.btnListaBlob_Click);
            // 
            // testcloudblob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 484);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpContBlob);
            this.Controls.Add(this.grp);
            this.Name = "testcloudblob";
            this.Text = "Test Blob Cloud Azure";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpContBlob.ResumeLayout(false);
            this.grpContBlob.PerformLayout();
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreaContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeContainer;
        private System.Windows.Forms.TextBox txtNomeBlob;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpContBlob;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Button btnUplFileBlob;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnDelFileBlob;
        private System.Windows.Forms.Button btnDownloadFileBlob;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtListaBlob;
        private System.Windows.Forms.Button btnListaBlob;
    }
}

