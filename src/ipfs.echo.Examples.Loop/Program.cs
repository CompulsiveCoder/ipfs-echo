using System;
using ipfsecho.Core;
using System.Threading;
using ipfs.echo.Core;

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

				echo.Echo(line, "TemperatureData");

				Thread.Sleep (30000);

				Console.WriteLine ("");
			}
		}
	}
}
