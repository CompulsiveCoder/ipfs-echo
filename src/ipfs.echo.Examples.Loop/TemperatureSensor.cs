using System;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ipfs.echo.Examples.Loop
{
	public class TemperatureSensor
	{
		public TemperatureSensor ()
		{
		}

		public float GetTemperature(string location)
		{

			StringBuilder theWebAddress = new StringBuilder();
			theWebAddress.Append("http://query.yahooapis.com/v1/public/yql?");
			theWebAddress.Append("q=" + System.Web.HttpUtility.UrlEncode("select * from weather.forecast where woeid in (select woeid from geo.places(1) where text='" + location + "') and u='c'"));
			theWebAddress.Append("&format=json");
			theWebAddress.Append("&diagnostics=false");

			string results = "";    

			using (WebClient wc = new WebClient())    
			{    
				results = wc.DownloadString (theWebAddress.ToString());
			}    

			dynamic jo = JObject.Parse(results);    
			var items = jo.query.results.channel.item.condition;   
			var temp = items.temp;  

			return temp;
		}
	}
}

