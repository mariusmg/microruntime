using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Web;
using log4net;
using log4net.Config;

namespace voidsoft.MicroRuntime
{
	public static class Log
	{
		private static readonly ILog ii = LogManager.GetLogger(typeof (Log));
		private static object lockedTrace = new object();

		private static bool logWebContext;

		public static bool LogWebContext
		{
			get
			{
				return logWebContext;
			}
			set
			{
				logWebContext = value;
			}
		}

		/// <summary>
		///     Logging initialization
		/// </summary>
		public static void Initialize()
		{
			XmlConfigurator.Configure();
		}

		/// <summary>
		///     Writes the trace output.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void WriteTraceOutput(string message)
		{
			lock (lockedTrace)
			{
				ii.Error(CaptureExecutionContext() + Environment.NewLine + message);
			}
		}

		/// <summary>
		///     Writes the trace output.
		/// </summary>
		/// <param name="ex">The ex.</param>
		public static void WriteTraceOutput(Exception ex)
		{
			if (ex is ThreadAbortException)
			{
				return;
			}

			lock (lockedTrace)
			{
				ii.ErrorFormat("**********************" + Environment.NewLine);
				ii.Error(CaptureExecutionContext() + GetRecursiveMessage(ex), ex);
			}
		}

		/// <summary>
		///     Writes the trace output.
		/// </summary>
		/// <param name="messages">The messages.</param>
		public static void WriteTraceOutput(IEnumerable<string> messages)
		{
			lock (lockedTrace)
			{
				foreach (string s in messages)
				{
					ii.Error(s + Environment.NewLine);
				}
			}
		}

		

		/// <summary>
		///     Gets the recursive message.
		/// </summary>
		/// <param name="ex">The ex.</param>
		/// <returns></returns>
		private static string GetRecursiveMessage(Exception ex)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(ex.Message + "\n");

			Exception currentException = ex;

			while ((currentException = GetInnerException(currentException)) != null)
			{
				builder.Append(currentException.Message + "\n");
			}

			return builder.ToString();
		}

		/// <summary>
		///     Gets the inner exception.
		/// </summary>
		/// <param name="ex">Exception</param>
		/// <returns></returns>
		private static Exception GetInnerException(Exception ex)
		{
			return ex.InnerException;
		}

		

		[MethodImpl(MethodImplOptions.Synchronized)]
		private static string CaptureExecutionContext()
		{
			StringBuilder builder = null;

			try
			{
				if (LogWebContext == false)
				{
					return string.Empty;
				}

				builder = new StringBuilder();

				if (HttpContext.Current == null)
				{
					return string.Empty;
				}

				var request = HttpContext.Current.Request;

				if (request == null)
				{
					return string.Empty;
				}

				builder.Append("Machine " + HttpContext.Current.Server.MachineName + Environment.NewLine);
				builder.Append("Url: " + request.HttpMethod + " " + request.RawUrl + Environment.NewLine);
				builder.Append("User Agent: " + request.UserAgent + Environment.NewLine);

				if (request.UrlReferrer != null)
				{
					builder.Append("Referrer: " + request.UrlReferrer + Environment.NewLine);
				}

				if (request.Cookies.Count > 0)
				{
					builder.Append("Cookies: ");

					foreach (HttpCookie c in request.Cookies)
					{
						try
						{
							builder.Append(c.Name + "=" + c.Value);
						}
						catch
						{
							continue;
						}
					}

					builder.Append(Environment.NewLine);
				}

				return builder.ToString();
			}
			catch
			{
				if (builder != null)
				{
					return builder.ToString();
				}

				return string.Empty;
			}
		}
	}
}