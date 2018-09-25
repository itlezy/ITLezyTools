using System;

namespace Itlezy.Common.JSON
{
	public class JsonItem
	{
		public String JsonString { get; set; }
		
		public String JsonAbbrev
		{
			get
			{
				if (!String.IsNullOrEmpty(JsonString))
				{
					return
						JsonString.Substring(0, Math.Min(50, JsonString.Length));
				}
				else
				{
					return String.Empty;
				}
			}
		}
		
		public override string ToString()
		{
			return JsonAbbrev;
		}

	}
}
