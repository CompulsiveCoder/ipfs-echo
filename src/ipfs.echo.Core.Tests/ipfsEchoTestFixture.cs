using System;
using NUnit.Framework;
using System.Threading;
using ipfs.Core.Tests;

namespace ipfsecho.Core.Tests
{
	[TestFixture]
	public class ipfsEchoTestFixture : BaseTestFixture
	{
		[Test]
		public void Test_Echo()
		{
			var echo = new ipfsEcho ();
			Console.WriteLine(echo.Echo ("Hello world!"));
		}

		// TODO: Turn this into an integration test
		//[Test]
		public void Test_Echo_Publish()
		{
			var echo = new ipfsEcho ();
			echo.IsVerbose = true;
				
			var firstString = "one";

			var subFolderName = Guid.NewGuid().ToString();

			var peerId = echo.Echo (firstString, subFolderName);

			Console.WriteLine(peerId);

			var fileChecker = new ipfsFileChecker ();

			var relativeFilePath = subFolderName + "/data.txt";

			fileChecker.CheckTestFile ("ipns", peerId, relativeFilePath, firstString);

			var secondString = "two";

			peerId = echo.Echo (secondString, subFolderName);

			var combinedString = firstString + Environment.NewLine + secondString;

			fileChecker.CheckTestFile ("ipns", peerId, relativeFilePath, combinedString);
		}
	}
}

