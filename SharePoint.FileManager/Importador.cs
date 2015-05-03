using Microsoft.SharePoint.Client;
using SharePoint.FileManager.Business;
using SharePoint.FileManager.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SharePoint.FileManager
{
	public partial class Importador : System.Windows.Forms.Form
	{
		public Importador()
		{
			InitializeComponent();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if (Uri.IsWellFormedUriString(txtURL.Text, UriKind.RelativeOrAbsolute))
			{
				var connection = new Connection(txtURL.Text, txtUserName.Text, txtPassword.Text, rbSPOnline.Checked);
				txtLog.Clear();
				btnImportar.Enabled = true;
			}
			else
			{
				throw new Exception(SharePoint.FileManager.Properties.Resources.Messages_Invalid_URL);
			}
		}

		internal void ImportFiles(ClientContext context, IEnumerable<string> filesToImport, string[] xmlFiles)
		{
			foreach (string file in filesToImport)
			{
				foreach (var xmlFile in xmlFiles)
				{
					XmlDocument doc = new XmlDocument();
					doc.Load(xmlFile);

					var nav = doc.CreateNavigator();
					var rs = nav.Select("/Files/File[@Name='" + Path.GetFileName(file) + "']");

					if (rs.Count > 0)
					{
						while (rs.MoveNext())
						{
							var current = rs.Current;
							var destination = current.Value;

							Items.UploadFile(context, file, destination);

							txtLog.AppendText(file + Environment.NewLine);
						}

						break;

					}
				}
			}
		}

		private void btnImportar_Click(object sender, EventArgs e)
		{
			var connection = new Connection().Current;
			if (connection == null)
			{
				throw new Exception(SharePoint.FileManager.Properties.Resources.Messages_Not_Connected);
			}
			else
			{
				using (var fileDialog = new FolderBrowserDialog())
				{
					var result = fileDialog.ShowDialog();
					if (result == System.Windows.Forms.DialogResult.OK)
					{
						var filesToImport = System.IO.Directory.GetFiles(fileDialog.SelectedPath, "*.*",
						  System.IO.SearchOption.AllDirectories).Where(a => !a.Contains("clixml"));

						var xmlFiles = System.IO.Directory.GetFiles(fileDialog.SelectedPath, "*.clixml");

						ImportFiles(connection, filesToImport, xmlFiles);

					}
				}

			}
		}
	}
}
