using System;
using ipfsecho.Core;

namespace ipfsecho.ConsoleUI
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var arguments = new Arguments (args);

			if (arguments.KeylessArguments.Length == 0)
				throw new ArgumentException ("Some text must be provided as an argument.");

			var text = arguments.KeylessArguments [0];

			var hashOnly = arguments.Contains ("h")
				|| arguments.Contains("hash");

			var showPath = arguments.Contains ("p")
				|| arguments.Contains("path");

			var longOutput = arguments.Contains ("l")
				|| arguments.Contains("long");

			var showLink = arguments.Contains ("link");

			var ipnsPublish = arguments.Contains ("ipns");

			if (longOutput)
			{
				if (showLink == false)
					showLink = true;
				if (showPath == false)
					showPath = true;
			}

			var echo = new ipfsEcho ();

			var hash = echo.Echo (text, ipnsPublish);

			if (hashOnly) {
				Console.WriteLine (hash);
			} else {
				Console.WriteLine ("Hash: " + hash);
			}

			var protocol = (ipnsPublish ? "ipns" : "ipfs");

			if (showLink) {
				var link = "URL: https://ipfs.io/" + protocol + "/" + hash;
				Console.WriteLine (link);
			}

			if (showPath) {
				var path = "Path: /" + protocol + "/" + hash;
				Console.WriteLine (path);
			}
		}
	}
}
