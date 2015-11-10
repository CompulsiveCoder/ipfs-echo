using System;
using NUnit.Framework;

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
	}
}

