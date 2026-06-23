using System.Diagnostics;
using System.Threading;
using Chip8Emulator;
using static SDL2.SDL;

SDL_Init(SDL_INIT_VIDEO);

IntPtr window = SDL_CreateWindow(
    "CHIP-8 Emulator",
    SDL_WINDOWPOS_CENTERED,
    SDL_WINDOWPOS_CENTERED,
    640,
    320,
    SDL_WindowFlags.SDL_WINDOW_SHOWN
);

IntPtr renderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

Memory memory = new Memory("C:\\Users\\Luis\\Chip8Emulator\\IBM Logo.ch8");
Display display = new Display();
Keyboard keyboard = new Keyboard();
CPU cpu = new CPU(memory, display, keyboard);

bool running = true;
Stopwatch stopwatch = new Stopwatch();

while (running) {
    stopwatch.Restart();

    while (SDL_PollEvent(out SDL_Event e) != 0) {
        if (e.type == SDL_EventType.SDL_QUIT) {
            running = false;
        }
        if (e.type == SDL_EventType.SDL_KEYDOWN)
        {
            if (e.key.repeat == 0)
            {
                keyboard.keyHeld(e.key.keysym.scancode);
            }
        }
        if(e.type == SDL_EventType.SDL_KEYUP)
        {
            keyboard.keyReleased(e.key.keysym.scancode);
        }
    }

    for (int i = 0; i < 11; i++) {
        cpu.Cycle();
    }

    if (cpu.delayTimer > 0) cpu.delayTimer--;
    if (cpu.soundTimer > 0) cpu.soundTimer--;

    SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255);
    SDL_RenderClear(renderer);

    for (int y = 0; y < 32; y++) {
        for (int x = 0; x < 64; x++) {
            if (display.display[y, x]) {
                SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);
            } else {
                SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255);
            }

            SDL_Rect rect = new SDL_Rect {
                x = x * 10,
                y = y * 10,
                w = 10,
                h = 10
            };

            SDL_RenderFillRect(renderer, ref rect);
        }
    }

    SDL_RenderPresent(renderer);

    stopwatch.Stop();
    long ts = stopwatch.ElapsedMilliseconds;
    if (16L - ts > 0)
        Thread.Sleep((int)(16L - ts));
}

SDL_DestroyRenderer(renderer);
SDL_DestroyWindow(window);
SDL_Quit();