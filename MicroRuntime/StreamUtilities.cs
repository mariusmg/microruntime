using System.IO;
using System.Text;
using System.Runtime.CompilerServices;

namespace voidsoft.MicroRuntime
{
    /// <summary>
    /// Utilities to operate on streams
    /// </summary>
    public class StreamUtilities
    {

        /// <summary>
        /// Converts to stream.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="ec">The ec.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Stream ConvertToStream(string text, Encoding ec)
        {
            byte[] bts = ec.GetBytes(text);
            MemoryStream ms = new MemoryStream(bts);
            return ms;
        }
    }
}