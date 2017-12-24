using System.Diagnostics;

namespace Chords
{
    internal sealed class Logger
    {
        public void Log(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
