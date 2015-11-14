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

				var line = "Temperature: " + temperature + "c";

				Console.WriteLine (line);

				var hash = echo.Echo(line);

				Console.WriteLine (hash);

				Thread.Sleep (10000);
			}
		}
	}
}
