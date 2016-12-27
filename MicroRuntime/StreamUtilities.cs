using System.IO;
using System.Text;
using System.Web;

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

		public byte[] GetBytesFromHttpFileBase(HttpPostedFileBase file)
		{
			Stream stream = file.InputStream;
			return ToBytes(stream);
		}

		public byte[] ToBytes(Stream stream)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				stream.CopyTo(ms);
				return ms.ToArray();
			}
		}
	}
}