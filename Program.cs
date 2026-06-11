using System.Diagnostics;
using System.Threading;
using Chip8Emulator;

bool running = true;
Stopwatch stopwatch = new Stopwatch();
Memory memory = new Memory("");
Display display = new Display();
CPU cpu = new CPU(memory, display);

while (running) {
    stopwatch.Start();
    stopwatch.Stop();


    long ts = stopwatch.ElapsedMilliseconds;
    Thread.Sleep((int)(16L - ts));
}
