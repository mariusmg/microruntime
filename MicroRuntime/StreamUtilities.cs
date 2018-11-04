using System.IO;
using System.Text;
using System.Web;

#if NETSTANDARD2_0
using Microsoft.AspNetCore.Http;
#endif
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

#if NETSTANDARD2_0
		public byte[] GetBytesFromFormFile(IFormFile file)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				file.CopyTo(ms);
				ms.Position = 0;
				return ms.ToArray();
			}
		}
#else
		public byte[] GetBytesFromHttpFileBase(HttpPostedFileBase file)
		{
			Stream stream = file.InputStream;
			return ToBytes(stream);
		}
#endif
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