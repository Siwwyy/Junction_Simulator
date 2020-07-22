using System;
using System.Collections.Generic;
using System.Text;

namespace Junction_Simulator_CMD
{
    class Draw_Junction
    {
        private int width;
        private int height;

        public Draw_Junction()
        {
            this.width = 500;
            this.height = 500;
        }

        public Draw_Junction(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            for (uint i = 0; i < this.height; ++i)
            {
                //HORIZONTAL DRAWING
                if ((i == (uint)(this.height / 2) - 2 || i == (uint)(this.height / 2) + 2))
                {
                    for (uint j = 0; j < this.width; ++j)
                    {
                        Console.Write("=");
                    }
                    Console.Write("\n");
                }
                else if (i == (uint)(this.height / 2))
                {
                    for (uint j = 0; j < this.width; ++j)
                    {
                        Console.Write("-");
                    }
                    Console.Write("\n");

                }
                //else
                //{
                //    //Console.Write("-\n");
                //    Console.Write("\n");
                //}
                //VERTICAL DRAWING
                else
                {
                    for (uint j = 0; j < this.width; ++j)
                    {
                        if (j == (uint)(this.width / 2) - 4 || j == (uint)(this.width / 2) + 4)
                        {
                            Console.Write("|");
                        }
                        else if (j == (uint)(this.width / 2))
                        {
                            Console.Write("'");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.Write("\n");
                }
                //else
                //{
                //    Console.Write("\n");
                //}
                //else if (i == (uint)(this.height / 2))
                //{
                //    for (uint j = 0; j < this.width; ++j)
                //    {
                //        Console.Write("-");
                //    }
                //    Console.Write("\n");

                //}

            }
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
    }
}
