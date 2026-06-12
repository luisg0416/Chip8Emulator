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

        public CPU(Memory memory, Display display)
        {
            this.memory = memory;
            this.display = display;
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

                    }
                    break;

                case 0x1:
                    PC = NNN;
                    break;

                case 0x2:
                    break;

                case 0x3:
                    break;

                case 0x4:
                    break;

                case 0x5:
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
                            break;
                    }
                    break;

                case 0x9:
                    break;

                case 0xA:
                    I = NNN;
                    break;

                case 0xB:
                    break;

                case 0xC:
                    break;

                case 0xD:

                    break;

                case 0xE:
                    break;

                case 0xF:
                    break;


            }
        }
    }
}