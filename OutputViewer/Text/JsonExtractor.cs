using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EPocalipse.Json.JsonView;
using Itlezy.Common.JSON;

namespace Itlezy.App.OutputViewer.Text
{
	public class JsonExtractor
	{
		public String Extract(String text, bool lastItemOnly)
		{
			StringBuilder sb = new StringBuilder();
			
			//TODO refactor to a single method
			using (StringReader sr = new StringReader(text))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					int openBracket = line.IndexOf('{');
					int closeBracket = line.LastIndexOf('}');

					if (openBracket >= 0 && closeBracket > openBracket)
					{
						if (lastItemOnly)
						{
							// TODO implement properly
							sb.Clear();
						}
						
						sb.AppendLine(
							line.Substring(
								openBracket,
								closeBracket - openBracket + 1));
					}
				}
			}
			return sb.ToString();
		}
		
		public IList<JsonItem> Extract(String text)
		{
			IList<JsonItem> jsonItems = new List<JsonItem>();
			
			using (StringReader sr = new StringReader(text))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					int openBracket = line.IndexOf('{');
					int closeBracket = line.LastIndexOf('}');

					if (openBracket >= 0 && closeBracket > openBracket)
					{
						jsonItems.Add(
							new JsonItem()
							{
								JsonString =
									line.Substring(
										openBracket,
										closeBracket - openBracket + 1)
							});
					}
				}
			}
			return jsonItems;
		}
	}
}
