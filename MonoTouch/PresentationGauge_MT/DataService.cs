using System;
using System.Xml;
using System.Xml.Linq;

namespace mt_test1
{
	public class DataService
	{
		public static int GetScore()
		{
			XDocument xDoc = XDocument.Load("http://axum.mobi/api/xml");
			
			return (int) xDoc.Root.Attribute("value");
		}
	}
}
