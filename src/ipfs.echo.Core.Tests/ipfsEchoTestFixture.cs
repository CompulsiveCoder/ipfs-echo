using System;
using NUnit.Framework;
using System.Threading;

namespace ipfsecho.Core.Tests
{
	[TestFixture]
	public class ipfsEchoTestFixture
	{
		[Test]
		public void Test_Echo()
		{
			var echo = new ipfsEcho ();
			Console.WriteLine(echo.Echo ("Hello world!"));
		}

		[Test]
		public void Test_Echo_IpnsPublish()
		{
			var echo = new ipfsEcho ();
			echo.IsVerbose = true;

			var beforeString = Guid.NewGuid().ToString();

			var hash = echo.Echo (beforeString, true);

			Console.WriteLine(hash);

			// Sleep for a minute to let changes propagate (hopefully this can be removed once the system gets faster)
			//Thread.Sleep (60000);

			CheckTestFile ("ipns", hash, beforeString);

			var afterString = Guid.NewGuid().ToString();

			hash = echo.Echo (afterString, true);

			Console.WriteLine(hash);

			// Sleep for a while to let changes propagate (hopefully this can be removed once the system gets faster)
			Thread.Sleep (10000);

			CheckTestFile ("ipns", hash, afterString);
		}

		public void CheckTestFile(string protocol, string hash, string contents)
		{
			var starter = new ProcessStarter ();

			//var url = "http://ipfs.io/" + protocol + "/" + hash;

			var url = "http://localhost:8080/" + protocol + "/" + hash;

			starter.Start ("curl -s " + url);

			Assert.IsTrue(starter.Output.Trim().EndsWith (contents));
		}
	}
}

