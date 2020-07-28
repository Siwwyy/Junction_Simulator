using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Highway_gates_simulator
{
    public class Draw_Highway
    {
        private int width, height;
        private int amount_of_lines;

        private readonly object Draw_Locker = new object();
        public Draw_Highway(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.amount_of_lines = (int)(height / 2);
        }

        public void Draw()
        {
            for (int i = 0; i < this.height; ++i)
            {
                if (i == 0 || i == this.height - 1)
                {
                    Draw_Road_Line(0, i, '=');
                }
                else if (i % 2 == 0)
                {
                    Draw_Road_Line(0, i, '-');
                }
            }
        }

        public void Draw_Object(int initial_x, int initial_y, char sign)
        {
            lock (Draw_Locker)
            {
                Console.SetCursorPosition(initial_x, initial_y);
                Console.Write(sign);
                Console.SetCursorPosition(0, 0);
            }
            //Console.SetCursorPosition(initial_x, initial_y);
            //Console.Write(sign);
            //Console.SetCursorPosition(0, 0);
        }

        private void Draw_Road_Line(int initial_x, int initial_y)
        {
            lock (Draw_Locker)
            {
                Console.SetCursorPosition(initial_x, initial_y);
                for (int i = 0; i < this.width; ++i)
                {
                    Console.Write('-');
                }
                Console.SetCursorPosition(0, 0);
            }
            //Console.SetCursorPosition(initial_x, initial_y);
            //for (int i = 0; i < this.width; ++i)
            //{
            //    Console.Write('-');
            //}
            //Console.SetCursorPosition(0, 0);
        }
        private void Draw_Road_Line(int initial_x, int initial_y, char sign)
        {
            lock (Draw_Locker)
            {
                Console.SetCursorPosition(initial_x, initial_y);
                for (int i = 0; i < this.width; ++i)
                {
                    Console.Write(sign);
                }
                Console.SetCursorPosition(0, 0);
            }
            //Console.SetCursorPosition(initial_x, initial_y);
            //for (int i = 0; i < this.width; ++i)
            //{
            //    Console.Write(sign);
            //}
            //Console.SetCursorPosition(0, 0);
        }

        public void Console_Clear()
        {
            lock (Draw_Locker)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
            }
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
    }
}
