using System;
using System.Xml;
using System.Xml.Linq;
using System.Net;

namespace PresentationGauge_WP
{
	public class DataService
	{
		public static void GetScore(Action<int> callback)
		{
            WebClient webClient = new WebClient();

            webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
            webClient.DownloadStringAsync(new Uri("http://axum.mobi/api/xml"), callback);
            
		}

        static void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Action<int> callback = (Action<int>) e.UserState;

            XDocument xDoc = XDocument.Parse(e.Result);

            callback( (int)xDoc.Root.Attribute("value"));
            
        }
	}
}
