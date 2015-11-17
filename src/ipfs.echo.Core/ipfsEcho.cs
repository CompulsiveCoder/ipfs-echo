using System;
using System.IO;
using ipfs.Core;

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
			return Echo (text, true);
		}

		public string Echo(string text, bool ipnsPublish)
		{
			if (IsVerbose) {
				Console.WriteLine ("ipfs-echo: \"" + text + "\"");
				Console.WriteLine ("");
			}

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

			var ifps = new ipfsClient ();


			var hash = ifps.AddFile (tmpFileName);

			if (ipnsPublish)
				hash = ifps.Publish (hash);

			Directory.SetCurrentDirectory (originalDirectory);

			Directory.Delete (uniqueTmpDir, true);

			return hash;
		}
	}
}

