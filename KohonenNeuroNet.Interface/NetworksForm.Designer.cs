namespace KohonenNeuroNet.Interface
{
	partial class NetworksForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgvNetworks = new System.Windows.Forms.DataGridView();
			this.btnAddNetwork = new System.Windows.Forms.Button();
			this.btnEditNetwork = new System.Windows.Forms.Button();
			this.btnDeleteNetwork = new System.Windows.Forms.Button();
			this.NetworkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NetworkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvNetworks)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvNetworks
			// 
			this.dgvNetworks.AllowUserToAddRows = false;
			this.dgvNetworks.AllowUserToDeleteRows = false;
			this.dgvNetworks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvNetworks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NetworkId,
            this.NetworkName});
			this.dgvNetworks.Location = new System.Drawing.Point(12, 12);
			this.dgvNetworks.Name = "dgvNetworks";
			this.dgvNetworks.ReadOnly = true;
			this.dgvNetworks.RowHeadersVisible = false;
			this.dgvNetworks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvNetworks.Size = new System.Drawing.Size(542, 239);
			this.dgvNetworks.TabIndex = 0;
			// 
			// btnAddNetwork
			// 
			this.btnAddNetwork.Location = new System.Drawing.Point(12, 257);
			this.btnAddNetwork.Name = "btnAddNetwork";
			this.btnAddNetwork.Size = new System.Drawing.Size(178, 30);
			this.btnAddNetwork.TabIndex = 1;
			this.btnAddNetwork.Text = "Добавить нейронную сеть";
			this.btnAddNetwork.UseVisualStyleBackColor = true;
			this.btnAddNetwork.Click += new System.EventHandler(this.Btn_AddNetwork_Click);
			// 
			// btnEditNetwork
			// 
			this.btnEditNetwork.Location = new System.Drawing.Point(196, 257);
			this.btnEditNetwork.Name = "btnEditNetwork";
			this.btnEditNetwork.Size = new System.Drawing.Size(178, 30);
			this.btnEditNetwork.TabIndex = 1;
			this.btnEditNetwork.Text = "Изменить нейронную сеть";
			this.btnEditNetwork.UseVisualStyleBackColor = true;
			this.btnEditNetwork.Click += new System.EventHandler(this.Btn_EditNetwork_Click);
			// 
			// btnDeleteNetwork
			// 
			this.btnDeleteNetwork.Location = new System.Drawing.Point(380, 257);
			this.btnDeleteNetwork.Name = "btnDeleteNetwork";
			this.btnDeleteNetwork.Size = new System.Drawing.Size(174, 30);
			this.btnDeleteNetwork.TabIndex = 2;
			this.btnDeleteNetwork.Text = "Удалить нейронную сеть";
			this.btnDeleteNetwork.UseVisualStyleBackColor = true;
			this.btnDeleteNetwork.Click += new System.EventHandler(this.Btn_DeleteNetwork_Click);
			// 
			// NetworkId
			// 
			this.NetworkId.Frozen = true;
			this.NetworkId.HeaderText = "Идентификатор";
			this.NetworkId.Name = "NetworkId";
			this.NetworkId.ReadOnly = true;
			this.NetworkId.Visible = false;
			// 
			// NetworkName
			// 
			this.NetworkName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.NetworkName.HeaderText = "Название нейронной сети";
			this.NetworkName.Name = "NetworkName";
			this.NetworkName.ReadOnly = true;
			// 
			// NetworksForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(566, 296);
			this.Controls.Add(this.btnDeleteNetwork);
			this.Controls.Add(this.btnEditNetwork);
			this.Controls.Add(this.btnAddNetwork);
			this.Controls.Add(this.dgvNetworks);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(582, 335);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(582, 335);
			this.Name = "NetworksForm";
			this.Text = "Нейронные сети";
			this.Load += new System.EventHandler(this.Form_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvNetworks)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvNetworks;
		private System.Windows.Forms.Button btnAddNetwork;
		private System.Windows.Forms.Button btnEditNetwork;
        private System.Windows.Forms.Button btnDeleteNetwork;
		private System.Windows.Forms.DataGridViewTextBoxColumn NetworkId;
		private System.Windows.Forms.DataGridViewTextBoxColumn NetworkName;
	}
}