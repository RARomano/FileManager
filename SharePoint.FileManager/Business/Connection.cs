using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePoint.FileManager.Business
{
	internal class Connection: IDisposable
	{
	  public static ClientContext _context;
	  public ClientContext Current { get { return _context; } }

	  public Connection()
	  {
	  }

	  public Connection(string url, string userName, string passWord, bool isSharePointOnline)
	  {
	    _context = new ClientContext(url);
	    if (isSharePointOnline)
	      _context.Credentials = new SharePointOnlineCredentials(userName, passWord.ToSecureString());
	    else
	      _context.Credentials = new System.Net.NetworkCredential(userName, passWord);
	  }


	  public void Dispose()
	  {
	    if (_context != null)
	    {
	      _context.Dispose();
	    }
	  }
	}
}
