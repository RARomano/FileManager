using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharePoint.FileManager.Models
{
	public class Container : TreeNode
	{
		public string Url { get; set; }

		public Container()
		{
		}

		public Container(string title)
			: base(title)
		{
			Name = title;
		}
	}
}
