using System;
using NUnit.Framework;
using System.Threading;
using ipfs.echo.Core;
using ipfs.Core.Tests;
using ipfs.Core.Tests.Integration;
using ipfs.Core;

namespace ipfs.echo.Core.Tests
{
	[TestFixture(Category="Integration")]
	public class ipfsEchoIntegrationTestFixture : BaseIntegrationTestFixture
	{
		// TODO: Overhaul this test and re-enable
		//[Test]
		public void Test_Publish()
		{
			new DockerTestLauncher ().Launch (this);
		}

		public override void Execute()
		{

			var echo = new ipfsEcho ();
			echo.IsVerbose = true;
			echo.Init ();
				
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

