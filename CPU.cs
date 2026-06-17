namespace Chip8Emulator
{
    public class CPU
    {
        public byte[] registers = new byte[16]; 
        public Stack <ushort> s = new Stack<ushort>();
        public ushort PC = 512;
        public ushort I = 0;
        public byte delayTimer = 0;
        public byte soundTimer = 0;
        Memory memory;
        Display display;
        Keyboard keyboard;

        public CPU(Memory memory, Display display, Keyboard keyboard)
        {
            this.memory = memory;
            this.display = display;
            this.keyboard = keyboard;
        }

        public void Cycle()
        {
            ushort instruction = Fetch();
            Execute(instruction);
        }

        private ushort Fetch()
        {
            byte byte1 = memory.buffer[PC];
            byte byte2 = memory.buffer[PC + 1];
            PC += 2;

            ushort instruction = (ushort)((byte1 << 8) | byte2);
            return instruction;
            
        }

        private void Execute(ushort instruction)
        {
            byte type = (byte)((instruction >> 12) & 0xF);
            byte X = (byte)((instruction >> 8) & 0xF);
            byte Y = (byte)((instruction >> 4) & 0xF);
            byte N = (byte)(instruction & 0xF);
            byte NN = (byte)(instruction & 0xFF);
            ushort NNN = (ushort)(instruction & 0xFFF);
            
            switch(type)
            {
                case 0x0:
                    switch (N)
                    {
                        case 0x0:
                            Array.Clear(display.display, 0, display.display.Length);
                            break;

                        case 0xE:
                            PC = s.Pop();
                            break;

                    }
                    break;

                case 0x1:
                    PC = NNN;
                    break;

                case 0x2:
                    s.Push(PC);
                    PC = NNN;
                    break;

                case 0x3:
                    if (registers[X] == NN)
                    {
                        PC += 2;
                    }
                    break;

                case 0x4:
                    if (registers[X] != NN)
                    {
                        PC += 2;
                    }
                    break;

                case 0x5:
                    if (registers[X] == registers[Y])
                    {
                        PC += 2;
                    }
                    break;

                case 0x6:
                    registers[X] = NN;
                    break;

                case 0x7:
                    registers[X] += NN;
                    break;

                case 0x8:
                    switch (N)
                    {
                        case 0x0:
                            registers[X] = registers[Y];
                            break;
                        case 0x1:
                            registers[X] = (byte) (registers[X] | registers[Y]);
                            break;
                        case 0x2:
                            registers[X] = (byte) (registers[X] & registers[Y]);
                            break;
                        case 0x3:
                            registers[X] = (byte) (registers[X] ^ registers[Y]);
                            break;
                        case 0x4:
                            registers[X] = (byte) (registers[X] + registers[Y]);
                            break;
                        case 0x5:
                            if (registers[X] >= registers[Y])
                            {
                                registers[15] = 1;
                            }

                            else
                            {
                                registers[15] = 0;
                            }
                            registers[X] = (byte) (registers[X] - registers[Y]);
                            break;
                        case 0x6:
                            registers[X] = registers[Y];
                            int shiftedOutRight = registers[X] & 1; // 1 or 0
                            registers[X] = (byte) (registers[X] >> 1);
                            registers[15] = (byte) shiftedOutRight;
                            break;
                        case 0x7:
                            if (registers[Y] >= registers[X])
                            {
                                registers[15] = 1;
                            }

                            else
                            {
                                registers[15] = 0;
                            }
                            registers[X] = (byte) (registers[Y] - registers[X]);
                            break;
                        case 0xE:
                            registers[X] = registers[Y];
                            int shiftedOutLeft = (registers[X] >> 7) & 1; // 1 or 0
                            registers[X] = (byte) (registers[X] << 1);
                            registers[15] = (byte) shiftedOutLeft;
                            break;
                    }
                    break;

                case 0x9:
                    if (registers[X] != registers[Y])
                    {
                        PC += 2;
                    }
                    break;

                case 0xA:
                    I = NNN;
                    break;

                case 0xB:
                    break;

                case 0xC:
                    break;

                case 0xD:
                    int yCoordinate = registers[Y] & 31;
                    registers[15] = 0;

                    for(int i = 0; i < N; i++) {
                        if (yCoordinate >= 32)
                        {
                            break;
                        }
                        byte sprite = memory.buffer[I + i];
                        int xCoordinate = registers[X] & 63;
                        
                        for (int j = 0; j < 8; j++){
                            if(xCoordinate >= 64)
                            {
                                break;
                            }
                            int shiftedOut = (sprite >> (7 - j)) & 1;

                            if (shiftedOut == 1 && display.display[yCoordinate, xCoordinate] == true)
                            {
                                display.display[yCoordinate, xCoordinate] = false;
                                registers[15] = 1;
                            }
                            else if (shiftedOut == 1 && display.display[yCoordinate, xCoordinate] == false)
                            {
                                display.display[yCoordinate, xCoordinate] = true;
                            }
                            xCoordinate += 1;
                        }
                        yCoordinate += 1;
                    }
                    break;

                case 0xE:
                    switch (N)
                    {
                        case 0x1:
                        break;

                        case 0xE:
                        break;
                    }
                    break;

                case 0xF:
                    break;


            }
        }
    }
}