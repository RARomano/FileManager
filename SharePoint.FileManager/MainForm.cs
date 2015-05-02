using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharePoint.FileManager
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
		  var form = new Form1();
		  form.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var form = new Importador();
			form.ShowDialog();
		}
	}
}
