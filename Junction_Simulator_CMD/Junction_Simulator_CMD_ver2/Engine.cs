using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Junction_Simulator_CMD_ver2
{
    class Engine
    {
        private Road Draw_Road_Obj;
        private Car Car_Obj;
        private Pederastian Pederastian_Obj;

        private volatile bool break_execution = true;

        //THREADS
        Thread Key_Thread;
        Thread Draw_Car_Thread;
        Thread Draw_Pederastian_Thread;
        Thread Draw_Road_Thread;
        ////////////////////////
        //Lockers
        object Drawing_Locker = new object();
        ////////////////////////
        /// </summary>

        public Engine()
        {

        }

        public Engine(int width, int height)
        {
            Draw_Road_Obj = new Road(width, height);
            Car_Obj = new Car(0, "Renault", 0, ((int)(height / 2) + 1));
            Pederastian_Obj = new Pederastian(0, "Mark", ((int)(width / 2) + 1), ((int)(height / 2) - 10));
            Draw_Road_Thread = new Thread(Draw_Road);
            Draw_Road_Thread.Start();
        }

        public void Run()
        {
            Key_Thread = new Thread(Detect_Key);
            Draw_Car_Thread = new Thread(Draw_Car);
            Draw_Pederastian_Thread = new Thread(Draw_Pederastian);

            Draw_Car_Thread.Start();
            Draw_Pederastian_Thread.Start();

            Key_Thread.Start(ConsoleKey.Escape);
        }

        private void Detect_Key(object key)
        {
            while (break_execution)
            {
                if (Console.ReadKey().Key == (ConsoleKey)key)
                {
                    break_execution = false;
                    lock (Drawing_Locker)
                    {
                        System.Console.Clear();
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void Draw_Car()
        {
            while (break_execution)
            {
                lock (Drawing_Locker)
                {
                    Car_Obj.Draw_Car();
                }
                Thread.Sleep(200);
                lock (Drawing_Locker)
                {
                    Car_Obj.Erase_Car();
                }
                Car_Obj.Pos_x++;
            }
        }

        private void Draw_Pederastian()
        {
            while (break_execution)
            {
                lock (Drawing_Locker)
                {
                    Pederastian_Obj.Draw_Pederastian();
                }
                Thread.Sleep(400);
                lock (Drawing_Locker)
                {
                    Pederastian_Obj.Erase_Pederastian();
                }
                Pederastian_Obj.Pos_y++;
            }
        }

        private void Draw_Road()
        {
            while (break_execution)
            {
                lock (Drawing_Locker)
                {
                    Draw_Road_Obj.Draw_Road_Pederastian_Crossing();
                }
                Thread.Sleep(750);
            }
        }
    }
}
