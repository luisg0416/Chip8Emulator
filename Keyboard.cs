namespace Chip8Emulator;
using static SDL2.SDL;

public class Keyboard
{
    public bool[] keys = new bool[16];

    public void keyHeld(SDL_Scancode scancode)
    {
        switch (scancode)
        {
            case SDL_Scancode.SDL_SCANCODE_1:
                keys[0x1] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_2:
                keys[0x2] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_3:
                keys[0x3] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_4:
                keys[0xC] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_Q:
                keys[0x4] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_W:
                keys[0x5] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_E:
                keys[0x6] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_R:
                keys[0xD] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_A:
                keys[0x7] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_S:
                keys[0x8] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_D:
                keys[0x9] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_F:
                keys[0xE] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_Z:
                keys[0xA] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_X:
                keys[0x0] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_C:
                keys[0xB] = true;
                break;
            case SDL_Scancode.SDL_SCANCODE_V:
                keys[0xF] = true;
                break;
        }
    }

    public void keyReleased(SDL_Scancode scancode)
    {
        switch (scancode)
        {
            case SDL_Scancode.SDL_SCANCODE_1:
                keys[0x1] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_2:
                keys[0x2] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_3:
                keys[0x3] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_4:
                keys[0xC] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_Q:
                keys[0x4] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_W:
                keys[0x5] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_E:
                keys[0x6] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_R:
                keys[0xD] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_A:
                keys[0x7] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_S:
                keys[0x8] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_D:
                keys[0x9] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_F:
                keys[0xE] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_Z:
                keys[0xA] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_X:
                keys[0x0] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_C:
                keys[0xB] = false;
                break;
            case SDL_Scancode.SDL_SCANCODE_V:
                keys[0xF] = false;
                break;
        }
    }
}