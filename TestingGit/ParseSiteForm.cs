using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AngleSharp;
using TestingGit.Core;
using TestingGit.Core.Habra;

namespace TestingGit
{

	public partial class ParseSiteForm : Form
	{
		ParserWorker<string[]> parser;
		public ParseSiteForm()
		{
			InitializeComponent();
			parser = new ParserWorker<string[]>(
				new HabraParser()
				
				);
			parser.OnCompleted += Parser_OnCompleted;
			parser.OnNewData += Parser_OnNewData;
		}

		private void Parser_OnNewData(object arg1, string[] arg2)
		{
			listTitles.Items.AddRange(arg2);
		}

		private void Parser_OnCompleted(object obj)
		{
			MessageBox.Show("All done!");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			parser.ParserSettings = new HabraSettings((int)numericStart.Value, (int)numericEnd.Value);
			parser.Start();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			parser.Abort();
		}
	}
}
