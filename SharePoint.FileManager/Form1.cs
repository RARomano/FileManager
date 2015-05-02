using Microsoft.SharePoint.Client;
using SharePoint.FileManager.Business;
using SharePoint.FileManager.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SharePoint.FileManager
{
	public partial class Form1 : System.Windows.Forms.Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if (Uri.IsWellFormedUriString(txtURL.Text, UriKind.RelativeOrAbsolute))
			{
				var connection = new Connection(txtURL.Text, txtUserName.Text, txtPassword.Text, rbSPOnline.Checked);
				trvData.Nodes.Clear();
				trvData.Nodes.Add(Items.LoadData(connection.Current));
			}
			else
			{
				throw new Exception(SharePoint.FileManager.Properties.Resources.Messages_Invalid_URL);
			}
		}

		private void LoadData(Microsoft.SharePoint.Client.ClientContext clientContext)
		{
			var web = clientContext.Web;

			IEnumerable<List> libraries = clientContext.LoadQuery(web.Lists.Include(
				  a => a.BaseTemplate,
				  a => a.Title,
				  a => a.RootFolder.ServerRelativeUrl
				).Where(a => a.BaseTemplate == 101));

			clientContext.Load(web);
			clientContext.ExecuteQuery();

			var treeNode = new Models.Container(web.Title);
			treeNode.Url = web.Url;

			treeNode.Nodes.Add("Bibliotecas");

			foreach (var list in libraries)
			{
				clientContext.Load(list);
				clientContext.ExecuteQuery();

				var children = new Models.Container(list.Title);
				children.Url = list.RootFolder.ServerRelativeUrl;

				treeNode.FirstNode.Nodes.Add(children);

			}

			trvData.Nodes.Add(treeNode);
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			var connection = new Connection().Current;
			if (connection == null)
			{
				throw new Exception(SharePoint.FileManager.Properties.Resources.Messages_Not_Connected);
			}
			else
			{
				var selectedNode = trvData.SelectedNode;
				if (selectedNode != null)
				{
					using (var fileDialog = new FolderBrowserDialog())
					{
						fileDialog.SelectedPath = "C:\\TestExport";
						var result = fileDialog.ShowDialog();
						if (result == System.Windows.Forms.DialogResult.OK)
						{
							XmlDocument doc = new XmlDocument();
							var element = doc.AppendChild(doc.CreateElement("Files"));
							Items.ExportFiles((XmlElement)element, connection, (Models.Container)selectedNode, fileDialog.SelectedPath);
							doc.Save(fileDialog.SelectedPath + "\\exportlog_" + DateTime.Now.ToString("yyyyMMdd") + ".xml");
						}
					}
				}
			}


		}


	}
}
