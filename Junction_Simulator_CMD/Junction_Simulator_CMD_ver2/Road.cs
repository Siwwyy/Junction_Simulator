using System;
using System.Collections.Generic;
using System.Text;

namespace Junction_Simulator_CMD_ver2
{
    class Road
    {
        private int width;
        private int height;

        public Road()
        {
            this.width = 500;
            this.height = 500;
        }

        public Road(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        private void Draw_Road(int initial_x, int initial_y, string sign)
        {
            Console.SetCursorPosition(initial_x, initial_y);
            for (uint i = 0; i < this.width; ++i)
            {
                Console.Write(sign);
            }
            Console.SetCursorPosition(0, 0);
        }

        private void Draw_Pederastian_Crossing(int initial_x, int initial_y, string sign, int height)
        {
            for (uint i = 0; i < height; ++i)
            {
                Console.SetCursorPosition(initial_x, initial_y);
                Console.Write(sign);
                initial_y++;
            }
            Console.SetCursorPosition(0, 0);
        }

        public void Draw_Road_Pederastian_Crossing()
        {
            for (uint i = 0; i < this.height; ++i)
            {
                if ((i == (uint)(this.height / 2) - 2 || i == (uint)(this.height / 2) + 2))
                {
                    Draw_Road(0, (int)i, "=");
                }
                else if (i == (uint)(this.height / 2))
                {
                    Draw_Road(0, (int)i, "-");
                }
            }

            int pederastian_crossing_height = 6;

            Draw_Pederastian_Crossing((int)(this.width / 2), (int)(this.height / 2) - (int)(pederastian_crossing_height / 2), "___", pederastian_crossing_height);
        }

       
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
    }
}
