﻿namespace SharePoint.FileManager
{
	partial class Form1
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnConnect = new System.Windows.Forms.Button();
			this.rbOnPremises = new System.Windows.Forms.RadioButton();
			this.rbSPOnline = new System.Windows.Forms.RadioButton();
			this.txtPassword = new System.Windows.Forms.MaskedTextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.trvData = new System.Windows.Forms.TreeView();
			this.btnExport = new System.Windows.Forms.Button();
			this.dtPicker = new System.Windows.Forms.DateTimePicker();
			this.rbAllItems = new System.Windows.Forms.RadioButton();
			this.rbModifiedDate = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtURL);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btnConnect);
			this.groupBox1.Controls.Add(this.rbOnPremises);
			this.groupBox1.Controls.Add(this.rbSPOnline);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.txtUserName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(646, 120);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Conexão";
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(85, 22);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(399, 20);
			this.txtURL.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "URL:";
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(500, 76);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(139, 27);
			this.btnConnect.TabIndex = 7;
			this.btnConnect.Text = "Conectar";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// rbOnPremises
			// 
			this.rbOnPremises.AutoSize = true;
			this.rbOnPremises.Location = new System.Drawing.Point(500, 50);
			this.rbOnPremises.Name = "rbOnPremises";
			this.rbOnPremises.Size = new System.Drawing.Size(139, 17);
			this.rbOnPremises.TabIndex = 6;
			this.rbOnPremises.Text = "SharePoint On-Premises";
			this.rbOnPremises.UseVisualStyleBackColor = true;
			// 
			// rbSPOnline
			// 
			this.rbSPOnline.AutoSize = true;
			this.rbSPOnline.Checked = true;
			this.rbSPOnline.Location = new System.Drawing.Point(500, 25);
			this.rbSPOnline.Name = "rbSPOnline";
			this.rbSPOnline.Size = new System.Drawing.Size(110, 17);
			this.rbSPOnline.TabIndex = 5;
			this.rbSPOnline.TabStop = true;
			this.rbSPOnline.Text = "SharePoint Online";
			this.rbSPOnline.UseVisualStyleBackColor = true;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(85, 83);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(399, 20);
			this.txtPassword.TabIndex = 4;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(85, 51);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(399, 20);
			this.txtUserName.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Senha";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Usuário";
			// 
			// trvData
			// 
			this.trvData.FullRowSelect = true;
			this.trvData.Location = new System.Drawing.Point(12, 169);
			this.trvData.Name = "trvData";
			this.trvData.Size = new System.Drawing.Size(646, 259);
			this.trvData.TabIndex = 1;
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(12, 440);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(646, 33);
			this.btnExport.TabIndex = 2;
			this.btnExport.Text = "Exportar";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// dtPicker
			// 
			this.dtPicker.Location = new System.Drawing.Point(298, 139);
			this.dtPicker.Name = "dtPicker";
			this.dtPicker.Size = new System.Drawing.Size(360, 20);
			this.dtPicker.TabIndex = 4;
			// 
			// rbAllItems
			// 
			this.rbAllItems.AutoSize = true;
			this.rbAllItems.Checked = true;
			this.rbAllItems.Location = new System.Drawing.Point(13, 141);
			this.rbAllItems.Name = "rbAllItems";
			this.rbAllItems.Size = new System.Drawing.Size(94, 17);
			this.rbAllItems.TabIndex = 5;
			this.rbAllItems.TabStop = true;
			this.rbAllItems.Text = "Todos os itens";
			this.rbAllItems.UseVisualStyleBackColor = true;
			// 
			// rbModifiedDate
			// 
			this.rbModifiedDate.AutoSize = true;
			this.rbModifiedDate.Location = new System.Drawing.Point(123, 141);
			this.rbModifiedDate.Name = "rbModifiedDate";
			this.rbModifiedDate.Size = new System.Drawing.Size(133, 17);
			this.rbModifiedDate.TabIndex = 6;
			this.rbModifiedDate.Text = "Itens modificados após";
			this.rbModifiedDate.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(663, 481);
			this.Controls.Add(this.rbModifiedDate);
			this.Controls.Add(this.rbAllItems);
			this.Controls.Add(this.dtPicker);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.trvData);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "File Manager";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbOnPremises;
		private System.Windows.Forms.RadioButton rbSPOnline;
		private System.Windows.Forms.MaskedTextBox txtPassword;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TreeView trvData;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.DateTimePicker dtPicker;
		private System.Windows.Forms.RadioButton rbAllItems;
		private System.Windows.Forms.RadioButton rbModifiedDate;
	}
}

