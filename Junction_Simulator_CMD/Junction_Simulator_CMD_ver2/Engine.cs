using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Junction_Simulator_CMD_ver2
{
    class Engine
    {
        private Road Draw_Road_Obj;
        //private Car Car_Obj;
        private List<Car> Car_Array;
        private Pedestrians Pedestrians_Obj;

        private volatile bool break_execution = true;

        //THREADS
        Thread Key_Thread;
        Thread Draw_Car_Thread;
        Thread Erase_Car_Thread;
        Thread Draw_Pedestrians_Thread;
        Thread Draw_Road_Thread;
        //Thread Add_Car_Thread;
        ////////////////////////
        //Lockers
        object Drawing_Locker = new object();
        object Car_Array_Locker = new object();
        ////////////////////////

        public Engine()
        {

        }

        public Engine(int width, int height)
        {
            Draw_Road_Obj = new Road(width, height);
            //Car_Obj = new Car(0, "Renault", 0, ((int)(height / 2) + 1));
            Pedestrians_Obj = new Pedestrians(0, "Mark", ((int)(width / 2) + 1), ((int)(height / 2) - 10));
            Draw_Road_Thread = new Thread(Draw_Road);
            Draw_Road_Thread.Start();


            Car_Array = new List<Car>();
            Car_Array.Add(new Car(0, "Renault", 0, ((int)(height / 2) + 1)));

        }

        public void Run()
        {
            //Key_Thread = new Thread(Detect_Specified_Key);
            Key_Thread = new Thread(Detect_Keys);
            Draw_Car_Thread = new Thread(Draw_Car);
            Erase_Car_Thread = new Thread(Erase_Car);
            Draw_Pedestrians_Thread = new Thread(Draw_Pedestrians);
            //Add_Car_Thread = new Thread(Add_Car);


            Key_Thread.Start();
            Draw_Car_Thread.Start();
            Erase_Car_Thread.Start();
            Draw_Pedestrians_Thread.Start();
            //Add_Car_Thread.Start();
            //Key_Thread.Start(ConsoleKey.Escape);
        }

        private void Detect_Specified_Key(object key)
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

        private void Detect_Keys()
        {
            while (break_execution)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break_execution = false;
                    lock (Drawing_Locker)
                    {
                        System.Console.Clear();
                    }
                }
                else if (Console.ReadKey().Key == ConsoleKey.A)
                {
                    //Pedestrians road will receive green light and then cars stop

                }
                else if (Console.ReadKey().Key == ConsoleKey.D)
                {
                    lock (Car_Array_Locker)
                    {
                        Car_Array.Add(new Car(0, "Renault", 0, ((int)(Draw_Road_Obj.Height / 2) + 1)));
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void Draw_Car()
        {
            //while (break_execution)
            //{
            //    lock (Car_Array_Locker)
            //    {
            //        for (int i = 0; i < Car_Array.Count; ++i)
            //        {
            //            lock (Drawing_Locker)
            //            {
            //                Car_Array[i].Draw_Car();
            //            }
            //            Thread.Sleep(200);
            //            lock (Drawing_Locker)
            //            {
            //                Car_Array[i].Erase_Car();
            //            }
            //            Car_Array[i].Pos_x++;
            //        }
            //    }
            //}

            while (break_execution)
            {
                lock (Car_Array_Locker)
                {
                    for (int i = 0; i < Car_Array.Count; ++i)
                    {
                        lock (Drawing_Locker)
                        {
                            Car_Array[i].Draw_Car();
                        }
                    }
                }
                Thread.Sleep(200);
            }
        }

        private void Erase_Car()
        {
            while (break_execution)
            {
                lock (Car_Array_Locker)
                {
                    for (int i = 0; i < Car_Array.Count; ++i)
                    {
                        lock (Drawing_Locker)
                        {
                            Car_Array[i].Erase_Car();
                        }
                        Car_Array[i].Pos_x++;
                    }
                }
                Thread.Sleep(300);
            }
        }

        private void Draw_Pedestrians()
        {
            while (break_execution)
            {
                lock (Drawing_Locker)
                {
                    Pedestrians_Obj.Draw_Pedestrians();
                }
                Thread.Sleep(400);
                lock (Drawing_Locker)
                {
                    Pedestrians_Obj.Erase_Pedestrians();
                }
                Pedestrians_Obj.Pos_y++;
            }
        }

        private void Draw_Road()
        {
            while (break_execution)
            {
                lock (Drawing_Locker)
                {
                    Draw_Road_Obj.Draw_Road_Pedestrians_Crossing();
                }
                Thread.Sleep(750);
            }
        }

        private void Add_Car()
        {

        }
    }
}
