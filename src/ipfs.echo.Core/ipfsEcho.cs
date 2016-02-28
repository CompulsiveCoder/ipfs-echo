using System;
using System.IO;
using ipfs.Core;
using ipfs.Managed;

namespace ipfsecho.Core
{
	public class ipfsEcho
	{
		public bool IsVerbose = false;

		public ipfsEcho ()
		{
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
				Console.WriteLine ("Sub folder name: \"" + subFolderName + "\"");
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
			var managedClient = new ipfsManagedClient ();
			managedClient.IsVerbose = IsVerbose;

			var hash = "";

			if (replaceContent)
				hash = managedClient.Set (ipnsSubFolder, fileName, text);
			else
				hash = managedClient.Append (ipnsSubFolder, fileName, text, true);

			var peerId = managedClient.Publish (hash);

			var url = "{0}/ipns/" + peerId + "/" + ipnsSubFolder + "/data.txt";

			Console.WriteLine (String.Format (url, "http://localhost:8080"));
			Console.WriteLine (String.Format (url, "https://ipfs.io"));

			return peerId;
		}
	}
}

