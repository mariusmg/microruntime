using System.IO;
using System.Text;

namespace voidsoft.MicroRuntime
{
	public class StreamUtilities
	{
		public Stream ConvertToStream(string text, Encoding ec)
		{
			byte[] bts = ec.GetBytes(text);
			MemoryStream ms = new MemoryStream(bts);
			return ms;
		}
	}
}