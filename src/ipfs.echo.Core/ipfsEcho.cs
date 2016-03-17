using System;
using System.IO;
using ipfs.Core;
using ipfs.Managed;

namespace ipfs.echo.Core
{
	public class ipfsEcho
	{
		public bool IsVerbose = false;

		public ipfsManagedClient Client;

		public ipfsEcho ()
		{
			Client = new ipfsManagedClient ();
			Client.IsVerbose = true;
		}

		public void Init()
		{
			Client.Init ();
		}

		public string Echo(string text)
		{
			return Echo (text, String.Empty, String.Empty, false);
		}

		public string Echo(string text, string subFolderName)
		{
			return Echo (text, subFolderName, "data.txt", false);
		}

		public string Echo(string text, string subFolderName, string fileName)
		{
			return Echo (text, subFolderName, fileName, false);
		}

		public string Echo(string text, string subFolderName, string fileName, bool replaceContent)
		{
			if (IsVerbose) {
				Console.WriteLine ("ipfs-echo: \"" + text + "\"");
				Console.WriteLine ("");
				Console.WriteLine ("Folder name: \"" + subFolderName + "\"");
				Console.WriteLine ("File name: \"" + fileName + "\"");
				Console.WriteLine ("");
			}

			var doPublish = !String.IsNullOrEmpty(subFolderName);

			var hash = "";

			if (!doPublish) {
				hash = EchoBasic (text);
			} else {
				hash = EchoPublish (text, subFolderName, fileName, replaceContent);
			}

			return hash;
		}

		public string EchoBasic(string text)
		{
			var originalDirectory = Environment.CurrentDirectory;

			var tmpDir = Path.GetFullPath (".tmp");

			if (!Directory.Exists (tmpDir))
				Directory.CreateDirectory (tmpDir);

			var uniqueTmpDir = Path.Combine (tmpDir, Guid.NewGuid ().ToString ());

			Directory.CreateDirectory (uniqueTmpDir);

			Directory.SetCurrentDirectory (uniqueTmpDir);

			var tmpFileName = "file.txt";

			var tmpFile = Path.Combine (uniqueTmpDir, tmpFileName);

			File.WriteAllText (tmpFile, text);

			var client = new ipfsClient ();

			var hash = client.AddFile (tmpFileName);

			Directory.SetCurrentDirectory (originalDirectory);

			Directory.Delete (uniqueTmpDir, true);

			return hash;
		}

		public string EchoPublish(string text, string ipnsSubFolder, string fileName, bool replaceContent)
		{

			var hash = "";

			if (replaceContent)
				hash = Client.Set (ipnsSubFolder, fileName, text);
			else
				hash = Client.Append (ipnsSubFolder, fileName, text, true);

			var peerId = Client.Publish (hash);

			var url = "{0}/ipns/" + peerId + "/" + ipnsSubFolder + "/" + fileName;

			Console.WriteLine (String.Format (url, "http://localhost:8080"));
			Console.WriteLine (String.Format (url, "https://ipfs.io"));

			return peerId;
		}
	}
}

