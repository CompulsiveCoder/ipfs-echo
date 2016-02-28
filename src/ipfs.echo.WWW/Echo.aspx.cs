using System;
using System.Web;
using System.Web.UI;
using ipfsecho.Core;

namespace ipfs.echo.WWW
{
	
	public partial class Echo : System.Web.UI.Page
	{
		public string TextData = "";
		public string FolderName = "";
		public string FileName = "";
		public bool Overwrite;

		public bool DidPublish;

		public string LocalUrl = "";
		public string IpfsUrl = "";

		string UrlFormat = "{0}/{1}/{2}";

		string LocalUrlStart = "http://localhost:8080";
		string IpfsUrlStart = "https://ipfs.io";

		private void Page_Load(object sender, EventArgs e)
		{
			TextData = Request.QueryString ["text"];

			FolderName = Request.QueryString ["folder"];

			FileName = Request.QueryString ["file"];

			Overwrite = Convert.ToBoolean(Request.QueryString ["overwrite"]);

			if (!String.IsNullOrEmpty (TextData)) {
				DidPublish = true;

				var echo = new ipfsEcho ();
				echo.IsVerbose = true;

				if (String.IsNullOrEmpty (FolderName)) {
					var hash = echo.Echo (TextData);

					CreateIpfsUrls (hash);

				} else {
					var peerId = echo.Echo (TextData, FolderName, FileName, Overwrite);

					CreateIpnsUrls (peerId, FolderName, FileName);
				}
			}
		}

		private void CreateIpfsUrls(string hash)
		{
			var protocol = "ipfs";

			LocalUrl = String.Format (UrlFormat, LocalUrlStart, protocol, hash);
			IpfsUrl = String.Format (UrlFormat, IpfsUrlStart, protocol, hash);
		}

		private void CreateIpnsUrls(string peerId, string folderName, string fileName)
		{
			var relativePath = peerId + "/" + folderName + "/" + fileName;

			var protocol = "ipns";

			LocalUrl = String.Format (UrlFormat, LocalUrlStart, protocol, relativePath);
			IpfsUrl = String.Format (UrlFormat, IpfsUrlStart, protocol, relativePath);
		}
	}
}

