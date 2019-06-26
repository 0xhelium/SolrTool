using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolrTool
{
    public class Logger:IDisposable
    {
        private Logger(LogType logType)
        {
            _logType = logType;

            if (_backGroundTask == null)
            {
                _tokenSource = new CancellationTokenSource();
                _backGroundTask = Task.Run(() =>
                {
                    ProcessQueue();
                }, _tokenSource.Token);
            }
        }

        private static Dictionary<LogType, Logger> _loggers = new Dictionary<LogType, Logger>();

        private readonly LogType _logType;

        private static object _root = new object();

        private static ConcurrentDictionary<LogType, ConcurrentQueue<string>> _queue = new ConcurrentDictionary<LogType, ConcurrentQueue<string>>();
        
        private string _logPath=null;

        private Task _backGroundTask=null;

        private CancellationTokenSource _tokenSource;

        private static ConcurrentQueue<string> _bufferedLogs = new ConcurrentQueue<string>();

        public string LogPath
        {
            get
            {
                if (_logPath != null)
                {
                    return _logPath;
                }

                var logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }

                var logFile = Path.Combine(logDir, DateTime.Now.ToString("yyyyMMdd") + ".log");
                _logPath = logFile;
                return logFile;
            }
        }
        public static Logger Create(LogType type)
        {
            if (!_loggers.TryGetValue(type, out var logger)) {
                var loggerIns = new Logger(type);
                _loggers.Add(type, loggerIns);
                _queue.TryAdd(type, new ConcurrentQueue<string>());                
                return loggerIns;
            }

            return logger;
        }
        public void Log(string text)
        {
            var logFile = LogPath;
            var content = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ff")}][{_logType.ToString()}] {text}";
            var q = _queue[_logType];
            q.Enqueue(content);
            _bufferedLogs.Enqueue(content);
        }

        private void ProcessQueue()
        {
            while (true)
            {
                foreach (var q in _queue)
                {
                    if (q.Value.TryDequeue(out var log))
                    {
                        try
                        {
                            using (var writer = File.AppendText(LogPath))
                            {
                                writer.WriteLine(log);
                                writer.Close();
                                writer.Dispose();
                            }
                        }
                        catch { }
                    }

                    Thread.Sleep(100);
                }
            }
        }

        public string GetBufferLog()
        {
            var sb = new StringBuilder();

            var c = 0;
            var r = true;
            while (c++ < 20 && r)
            {
                r = _bufferedLogs.TryDequeue(out var log);
                log = r ? log : "";
                log = log.Replace("\n", " ");
                if (log.Length > 500)
                {
                    return log.Substring(0, 400) + "......" + log.Substring(log.Length - 90, 90);
                }
                if (log != "")
                    sb.AppendLine(log);
            }

            return sb.ToString();
        }

        public void Dispose()
        {
            _tokenSource.Cancel();
        }
    }

    public enum LogType
    {
        INFO,
        ERROR,
    }
}
