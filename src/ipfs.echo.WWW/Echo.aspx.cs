using System;
using System.Web;
using System.Web.UI;
using ipfsecho.Core;

namespace ipfs.echo.WWW
{
	
	public partial class Echo : System.Web.UI.Page
	{
		public string TextData = "";
		public string DeviceKey = "";
		public bool Overwrite;

		public bool DidPublish;

		public string LocalUrl = "";
		public string IpfsUrl = "";

		string UrlFormat = "{0}/{1}/{2}";

		string LocalUrlStart = "http://localhost:8080";
		string IpfsUrlStart = "https://ipfs.io";

		private void Page_Load(object sender, EventArgs e)
		{
			TextData = Request.QueryString ["t"];

			DeviceKey = Request.QueryString ["d"];

			Overwrite = Convert.ToBoolean(Request.QueryString ["o"]);

			if (!String.IsNullOrEmpty (TextData)) {
				DidPublish = true;

				var echo = new ipfsEcho ();
				echo.IsVerbose = true;

				if (String.IsNullOrEmpty (DeviceKey)) {
					var hash = echo.Echo (TextData);

					CreateIpfsUrls (hash);

				} else {
					var peerId = echo.Echo (TextData, DeviceKey, Overwrite);

					CreateIpnsUrls (peerId, DeviceKey);
				}
			}
		}

		private void CreateIpfsUrls(string hash)
		{
			var protocol = "ipfs";

			LocalUrl = String.Format (UrlFormat, LocalUrlStart, protocol, hash);
			IpfsUrl = String.Format (UrlFormat, IpfsUrlStart, protocol, hash);
		}

		private void CreateIpnsUrls(string peerId, string deviceKey)
		{
			var relativePath = peerId + "/" + deviceKey + "/data.txt";

			var protocol = "ipns";

			LocalUrl = String.Format (UrlFormat, LocalUrlStart, protocol, relativePath);
			IpfsUrl = String.Format (UrlFormat, IpfsUrlStart, protocol, relativePath);
		}
	}
}

