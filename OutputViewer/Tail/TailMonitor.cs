using System;
using System.IO;
using System.Text;
using System.Threading;
using log4net;

namespace Itlezy.App.OutputViewer.Tail
{
	public class TailMonitor : IDisposable
	{
		private static readonly ILog logger = LogManager.GetLogger(typeof(TailMonitor));

        public const int MAX_TAIL_SIZE = 4 * 1048576;
		
		// it actually handles multiple lines
		public delegate void NewLineEventHandler(String line);
		public event NewLineEventHandler NewLine;

		Thread fileMonitor;
		
		private String fileName;
		public String FileName { get { return fileName; } }
		private StreamReader reader;
		long lastMaxOffset = -1;
		
		public TailMonitor(String fileName)
		{
			this.fileName = fileName;
		}
		
		public void Start()
		{
			fileMonitor = new Thread(new ThreadStart(StartInternal));
			fileMonitor.IsBackground = true;
			fileMonitor.Start();
		}
		
		private void OpenReader()
		{
			reader = new StreamReader(new FileStream(
                fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), Encoding.UTF8); //TODO configurable
		}
		
		private void CloseReader()
		{
			if (reader != null)
			{
				try
				{
					reader.Close();
					reader = null;
				}
				catch (Exception ex)
				{
					logger.Warn("", ex);
				}
			}
		}
		
		private void StartInternal()
		{
			while (true)
			{
				try
				{
					if (File.Exists(fileName))
					{
						DoRead();
					}
					else
					{
						lastMaxOffset = 0;
						
						NewLine("File does not exist [" + fileName + "]");
					}
				}
				catch (Exception ex)
				{
					logger.Error("", ex);
					
					NewLine("Unable to read file [" + fileName + "] " + ex.Message);
				}
				finally
				{
					CloseReader();
				}
				
				Thread.Sleep(3000);
			}
		}
		
		private void DoRead()
		{
			OpenReader();
			
			// if the file size has not changed, idle
			if (reader.BaseStream.Length > lastMaxOffset)
			{
				if (reader.BaseStream.Length > MAX_TAIL_SIZE)
				{
					// read the last 4Mb at most
                    lastMaxOffset = Math.Max(lastMaxOffset, reader.BaseStream.Length - MAX_TAIL_SIZE);
				}
				
				if (lastMaxOffset > 0)
				{
					// seek to the last max offset
					reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);
				}
				
				StringBuilder sb = new StringBuilder();
				// read out of the file until the EOF
				String line = String.Empty;
				while ((line = reader.ReadLine()) != null)
				{
					sb.AppendLine(line);
				}
				
				if (sb.Length > 0)
				{
					// raise the new line event
					NewLine(sb.ToString());
				}
				
				// update the last max offset
				lastMaxOffset = reader.BaseStream.Position;
			}
			else if (reader.BaseStream.Length < lastMaxOffset)
			{
				// reset offset
				lastMaxOffset = 0;
			}
		}
		
		public void Dispose()
		{
			CloseReader();
			
			if (fileMonitor != null)
			{
				try
				{
					fileMonitor.Abort();
				}
				catch (ThreadAbortException tex)
				{
					logger.Warn("", tex);
				}
			}
		}
	}
}