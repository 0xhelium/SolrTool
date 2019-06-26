using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolrTool
{
    public class ScrollLog
    {
        private string _logPath;
        private static ScrollLog _scrollLog=null;
        private int _lastPos = 0;
        private static object _root = new object();
        private ScrollLog(string path) {
            _logPath = path;
        }

        public static ScrollLog Create(string path)
        {
            if (_scrollLog == null)
            {
                _scrollLog = new ScrollLog(path);
            }

            return _scrollLog;
        }

        public async Task<string> TailLog()
        {
            return await Task.Run(() =>
            {
                lock (_root)
                {
                    var lines = File.ReadLines(_logPath);
                    var increLines = lines.Skip(_lastPos);
                    _lastPos += increLines.Count();
                    var text = string.Join(Environment.NewLine, increLines);
                    return text;
                }
            });
        }
    }
}
