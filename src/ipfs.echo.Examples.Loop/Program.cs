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

			while (true){
				var temperature = sensor.GetTemperature (location);

				var line = String.Format("Date: {0}; Temperature: {1}c;", DateTime.Now.ToString(), temperature);

				Console.WriteLine (line);

				var hash = echo.Echo(line, "TemperatureData");

				Console.WriteLine (hash);

				Thread.Sleep (30000);
			}
		}
	}
}
