using System;
using System.Web;
using System.Web.UI;

namespace ipfs.echo.WWW
{
	
	public partial class Default : System.Web.UI.Page
	{
		public void GoButton_Click (object sender, EventArgs args)
		{
			var url = String.Format ("Echo.aspx?text={0}&folder={1}&file={2}&overwrite={3}", HttpUtility.UrlEncode(TextData.Text), HttpUtility.UrlEncode(FolderName.Text), HttpUtility.UrlEncode(FileName.Text), Overwrite.Checked.ToString());

			Response.Redirect (url);
		}
	}
}

