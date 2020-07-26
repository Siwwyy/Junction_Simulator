using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Junction_Simulator_CMD
{
    class Engine
    {
        private Draw_Junction Draw_Junction_Obj;
        private Car Car_Obj;

        private volatile bool break_execution = true;

        //THREADS
        Thread Key_Thread;
        Thread Draw_Thread;
        Thread Adding_Cars_Thread;
        /// /////////////////////



        public Engine()
        {

        }

        public Engine(int width, int height)
        {
            Draw_Junction_Obj = new Draw_Junction(width, height);
            Car_Obj = new Car(0, "Renault", 0, ((int)(height / 2) + 1));
            //Car_Obj.Draw_Car();
            Draw_Junction_Obj.Draw();
        }

        public void Run()
        {
            Key_Thread = new Thread(Detect_Key);
            Draw_Thread = new Thread(Draw);
            Adding_Cars_Thread = new Thread(Draw);

            Draw_Thread.Start();
            Key_Thread.Start(ConsoleKey.Escape);


        }

        private void Draw()
        {
            while (break_execution)
            {
                //Car_Obj.Draw_Car();
                //Thread.Sleep(200);
                //Car_Obj.Erase_Car();
                //Car_Obj.Pos_x++;
            }
        }

        private void Detect_Key(object key)
        {
            while (break_execution)
            {
                if (Console.ReadKey().Key == (ConsoleKey)key)
                {
                    break_execution = false;
                }
                Thread.Sleep(100);
            }
        }

        private void Add_Car()
        {

        }
    }
}
