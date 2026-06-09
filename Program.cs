using System.Diagnostics;
using System.Threading;

bool running = true;
Stack <ushort> s = new Stack<ushort>();
Stopwatch stopwatch = new Stopwatch();

while (running) {
    stopwatch.Start();

    stopwatch.Stop();


    long ts = stopwatch.ElapsedMilliseconds;
    Thread.Sleep((int)(16L - ts));
}
