﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using SharePoint.FileManager.Models;
using System.IO;
using System.Xml;

namespace SharePoint.FileManager.Controller
{
	public static class Items
	{
		public static Container LoadData(ClientContext clientContext)
		{
			Container treeNode = null;
			var web = clientContext.Web;

			IEnumerable<List> libraries = clientContext.LoadQuery(web.Lists.Include(
				  a => a.BaseTemplate,
				  a => a.Title,
				  a => a.RootFolder.ServerRelativeUrl
				).Where(a => a.BaseTemplate == 101 || a.BaseTemplate == 116));

			clientContext.Load(web);
			clientContext.ExecuteQuery();

			treeNode = new Models.Container(web.Title);
			treeNode.Url = web.ServerRelativeUrl;

			treeNode.Nodes.Add(new Container("Bibliotecas"));

			foreach (var list in libraries)
			{
				clientContext.Load(list);
				clientContext.ExecuteQuery();

				var children = new Models.Container(list.Title);
				children.Url = list.RootFolder.ServerRelativeUrl;

				IEnumerable<Folder> folders = clientContext.LoadQuery(list.RootFolder.Folders.Include(
						a => a.Name,
						a => a.ServerRelativeUrl,
						a => a.Folders
					).Where(a => a.Name != "Forms"));
				clientContext.ExecuteQuery();

				foreach (var folder in folders)
				{
					LoadSubFolders(clientContext, children, folder);
				}
				treeNode.FirstNode.Nodes.Add(children);

			}

			return treeNode;
		}

		public static void LoadSubFolders(ClientContext clientContext, Container parentFolder, Folder folder)
		{
			var node = new Container(folder.Name);
			node.Url = folder.ServerRelativeUrl;

			var folders = folder.Folders;
			clientContext.Load(folders);
			clientContext.ExecuteQuery();
			foreach (var subFolder in folders)
			{
				LoadSubFolders(clientContext, node, subFolder);
			}

			parentFolder.Nodes.Add(node);
		}

		public static void ExportFiles(XmlElement element, ClientContext context, Container rootNode, string baseFolder)
		{
			string folder = baseFolder;
			if (!string.IsNullOrEmpty(rootNode.Url))
			{
				folder = folder + "\\" + rootNode.Name;
				if (!System.IO.Directory.Exists(folder))
					System.IO.Directory.CreateDirectory(folder);

				var fld = context.Web.GetFolderByServerRelativeUrl(rootNode.Url);

				context.Load(fld, a => a.Files);
				context.ExecuteQuery();

				foreach (var file in fld.Files)
				{
					var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(context, file.ServerRelativeUrl);

					using (var stream = fileInfo.Stream)
					{
						XmlNode node = element.AppendChild(element.OwnerDocument.CreateElement("File"));

						XmlAttribute attr = element.OwnerDocument.CreateAttribute("Name");
						attr.InnerText = file.Name;
						node.Attributes.Append(attr);

						var childNode = element.OwnerDocument.CreateElement("WebUrl");
						childNode.InnerText = rootNode.Url;

						node.AppendChild(childNode);

						string filePath = folder + "\\" + file.Name;
						var fileStream = System.IO.File.Create(filePath);
						stream.CopyTo(fileStream);

						fileStream.Flush();
						fileStream.Close();
					}
				}
			}

			foreach (Container subNode in rootNode.Nodes)
			{
				ExportFiles(element, context, subNode, folder);
			}
		}
	}
}