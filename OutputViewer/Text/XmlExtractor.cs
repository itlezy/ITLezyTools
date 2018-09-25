using System;
using System.IO;
using System.Text;

namespace Itlezy.App.OutputViewer.Text
{
	public class XmlExtractor
	{
		public String Extract(String text)
		{
			StringBuilder sb = new StringBuilder();
			using (StringReader sr = new StringReader(text))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					int openBracket = line.IndexOf('<');
					int closeBracket = line.LastIndexOf('>');

					if (openBracket >= 0 && closeBracket > openBracket && line.Contains("</"))
					{
						sb.AppendLine(
							line.Substring(
								openBracket,
								closeBracket - openBracket + 1));
					}
				}
			}
			
			return sb.ToString();
		}
	}
}
