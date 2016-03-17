using System;
using NUnit.Framework;
using ipfs.Core;

namespace ipfs.echo.Core.Tests.Integration
{
	[TestFixture(Category="Integration")]
	public class ipfsEchoTestFixture
	{
		public ipfsEchoTestFixture ()
		{
		}

		[Test]
		public void Test_Echo()
		{
			var client = new ipfsClient ();
			client.Init ();

			var echo = new ipfsEcho ();
			Console.WriteLine(echo.Echo ("Hello world!"));
		}

	}
}

