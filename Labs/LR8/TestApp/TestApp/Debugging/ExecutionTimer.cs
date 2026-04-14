using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TestApp.Debugging
{
    public class ExecutionTimer : IDisposable
    {
        private readonly Stopwatch _stopwatch;
        private readonly string _operationName;
        private bool _disposed = false;

        public ExecutionTimer(string operationName)
        {
            _operationName = operationName;
            _stopwatch = Stopwatch.StartNew();
            DebugLogger.Log($"Начало операции: {operationName}");
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _stopwatch.Stop();
                DebugLogger.Log($"Операция '{_operationName}' завершена за {_stopwatch.ElapsedMilliseconds} мс");
                _disposed = true;
            }
        }
    }
}
