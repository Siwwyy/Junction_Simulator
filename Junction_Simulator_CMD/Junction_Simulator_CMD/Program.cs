using System;

namespace Junction_Simulator_CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a = 10;

            //int ab = new int();
            Draw_Junction Obj = new Draw_Junction(100,20);
            Obj.Draw();
        }
    }
}
