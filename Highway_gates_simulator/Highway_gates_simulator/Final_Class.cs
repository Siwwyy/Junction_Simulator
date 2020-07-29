using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Highway_gates_simulator
{
    public class Final_Class
    {
        private Draw_Highway _Highway;
        private Engine _Engine;
        private Keyboard _Keyboard;
        private Gate _Gate;

        //private readonly object Draw_Key_Locker = new object();


        private volatile bool break_execution = true;

        private readonly object Car_Array_Property_Locker = new object();


        //THREADS
        private Thread Draw_Highway_Thread;
        private Thread Draw_Car_Thread;
        private Thread Logic_Thread;
        private Thread Keyboard_Thread;
        //private Thread Move_Car_Thread;

        public Final_Class(int width, int height)
        {
            _Highway = new Draw_Highway(width, height);
            _Engine = new Engine();
            _Keyboard = new Keyboard();
            _Gate = new Gate(3);
        }

        public void Run()
        {
            //_Highway.Draw();
            Draw_Highway_Thread = new Thread(Draw_Terrain);
            Draw_Car_Thread = new Thread(Draw_Cars);
            Logic_Thread = new Thread(Logic);
            Keyboard_Thread = new Thread(Keyboard_Event);

            Draw_Highway_Thread.Start();
            Draw_Car_Thread.Start();
            Logic_Thread.Start();
            Keyboard_Thread.Start();
        }

        private void Draw_Terrain()
        {
            while (break_execution)
            {
                _Highway.Draw();
                _Highway.Draw_Gate(_Gate.Space.Length);
                Thread.Sleep(1000);
            }
            _Highway.Console_Clear();
        }

        private void Draw_Cars()
        {
            //while (break_execution)
            //{
            //    //lock (Car_Array_Property_Locker)
            //    //{
            //    //    for (int i = 0; i < _Engine.Car_Array.Count; ++i)
            //    //    {
            //    //        //_Highway.Draw_Object(_Engine.Car_Array[i].Pos_x, _Engine.Car_Array[i].Pos_y, '>');
            //    //        //Thread.Sleep(250);
            //    //        //_Highway.Erase_Object(_Engine.Car_Array[i].Pos_x, _Engine.Car_Array[i].Pos_y);
            //    //        //Thread.Sleep(200);
            //    //        //_Highway.Erase_Object(_Engine.Car_Array[i].Pos_x, _Engine.Car_Array[i].Pos_y);

            //    //        //_Highway.Draw_Object(5, 5, 'D');
            //    //    }
            //    //}
            //    for (int i = 0; i < _Engine.Car_Array.Count; ++i)
            //    {
            //        _Highway.Draw_Object(_Engine.Car_Array[i].Pos_x, _Engine.Car_Array[i].Pos_y, '>');
            //        //_Highway.Erase_Object(_Engine.Car_Array[i].Pos_x, _Engine.Car_Array[i].Pos_y);
            //        Thread.Sleep(200);
            //    }
            //    Thread.Sleep(300);
            //}
            while (break_execution)
            {
                lock (Car_Array_Property_Locker)
                {
                    for (int i = 0; i < _Engine.Car_Array.Count; ++i)
                    {
                        _Highway.Draw_Object(_Engine.Car_Array[i].Pos_x, _Engine.Car_Array[i].Pos_y, '>');
                    }
                    _Engine.Move_Cars_Forward();

                    Thread.Sleep(200);

                    for (int i = 0; i < _Engine.Car_Array.Count; ++i)
                    {
                        _Highway.Erase_Object(_Engine.Car_Array[i].Pos_x - 1, _Engine.Car_Array[i].Pos_y);
                    }
                }
                //Thread.Sleep(200);
            }
        }


        private void Logic()
        {
            Random rand = new Random();
            //int[] available_positions = { 1, 3, 5, 7 };
            while (break_execution)
            {
                lock (Car_Array_Property_Locker)
                {
                    //_Engine.Semaphore();
                    for (int i = 0; i < _Engine.Car_Array.Count; ++i)
                    {
                        if (_Engine.Car_Array[i].Pos_x > _Highway.Width - 5)
                        {
                            _Engine.Car_Array[i].Stop = true;
                            _Engine.Take_Gate(i);
                        }
                    }

                    if (rand.Next(1, 3) == 2)
                    {
                        _Engine.Add_Car(1);
                    }
                }

                Thread.Sleep(200);
            }
        }

        private void Keyboard_Event()
        {
            while (break_execution)
            {
                _Keyboard.Detect_Key();
                if (_Keyboard.GetCurrent_key() == ConsoleKey.Escape)
                {
                    break_execution = false;
                };
            }
        }
    }
}
