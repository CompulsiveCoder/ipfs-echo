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

			var replace = arguments.Contains ("replace");

			var publishKey = arguments["publish"];

			var fileName = arguments["fileName"];

			if (String.IsNullOrEmpty (fileName))
				fileName = "data.txt";

			if (longOutput)
			{
				if (showLink == false)
					showLink = true;
				if (showPath == false)
					showPath = true;
			}

			var echo = new ipfsEcho ();

			var hash = echo.Echo (text, publishKey, fileName, replace);

			// TODO: Clean up the output code. Currently the ipfsEcho class outputs during publish, but this console outputs during standard echo.
			// The location of the output code should be more consistent
			if (String.IsNullOrEmpty (publishKey)) {
				if (hashOnly) {
					Console.WriteLine (hash);
				} else {
					Console.WriteLine ("Hash: " + hash);
				}

				var protocol = (!String.IsNullOrEmpty (publishKey) ? "ipns" : "ipfs");

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
}
