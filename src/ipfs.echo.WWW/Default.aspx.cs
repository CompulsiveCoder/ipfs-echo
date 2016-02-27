using System;
using System.Web;
using System.Web.UI;

namespace ipfs.echo.WWW
{
	
	public partial class Default : System.Web.UI.Page
	{
		public void GoButton_Click (object sender, EventArgs args)
		{
			var url = String.Format ("Echo.aspx?t={0}&d={1}&o={2}", HttpUtility.UrlEncode(TextData.Text), HttpUtility.UrlEncode(DeviceKey.Text), Overwrite.Checked.ToString());

			Response.Redirect (url);
		}
	}
}

