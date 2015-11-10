using System;
using ipfsecho.Core;
using System.Threading;

namespace ipfs.echo.Examples.Loop
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var location = args [0];

			var echo = new ipfsEcho ();

			var sensor = new TemperatureSensor ();

			// TODO: Change to loop forever
			for (int i = 0; i < 10; i++) {
				var temperature = sensor.GetTemperature (location);

				Console.WriteLine ("Temperature: " + temperature + "c");

				var hash = echo.Echo("Hello world! -- " + temperature);

				Thread.Sleep (5000);
			}
		}
	}
}
