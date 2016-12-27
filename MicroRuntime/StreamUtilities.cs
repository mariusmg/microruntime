using System.IO;
using System.Text;

namespace Microruntime
{
	public class StreamUtilities
	{
		public Stream ToStream(string text, Encoding ec)
		{
			byte[] buffer = ec.GetBytes(text);
			MemoryStream ms = new MemoryStream(buffer);
			ms.Position = 0;
			return ms;
		}

		public Stream ToStream(byte[] buffer)
		{
			MemoryStream ms = new MemoryStream(buffer);
			ms.Position = 0;
			return ms;
		}



	}
}