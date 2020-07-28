using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Highway_gates_simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Draw_Highway _Highway = new Draw_Highway(100, 9);
            //_Highway.Draw();
            Final_Class Final_Class_Obj = new Final_Class(100, 9);
            Final_Class_Obj.Run();
            //Console.Clear();
            //Console.ReadKey();
        }
    }
}
