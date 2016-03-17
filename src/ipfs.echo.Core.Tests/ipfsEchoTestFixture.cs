using System;
using NUnit.Framework;

namespace ipfs.echo.Core.Tests
{
	[TestFixture(Category="Unit")]
	public class ipfsEchoTestFixture
	{
		public ipfsEchoTestFixture ()
		{
		}

		[Test]
		public void Test_Echo()
		{
			var echo = new ipfsEcho ();
			Console.WriteLine(echo.Echo ("Hello world!"));
		}

	}
}

