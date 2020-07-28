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

        //private readonly object Draw_Key_Locker = new object();


        private volatile bool break_execution = true;

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
        }

        public void Run()
        {
            //_Highway.Draw();
            Draw_Highway_Thread = new Thread(Draw_Terrain);
            Logic_Thread = new Thread(Logic);
            Keyboard_Thread = new Thread(Keyboard_Event);

            Draw_Highway_Thread.Start();
            Keyboard_Thread.Start();
        }

        private void Draw_Terrain()
        {
            while(break_execution)
            {
                //lock (Draw_Key_Locker)
                //{
                //    _Highway.Draw();
                //}
                _Highway.Draw();
                Thread.Sleep(700);
            }
            _Highway.Console_Clear();
        }

        private void Logic()
        {
            while (break_execution)
            {
                
                Thread.Sleep(200);
            }
        }

        private void Keyboard_Event()
        {
            while (break_execution)
            {
                //    lock (Draw_Key_Locker)
                //    {
                //        _Keyboard.Detect_Key();
                //        if (_Keyboard.GetCurrent_key() == ConsoleKey.Escape)
                //        {
                //            break_execution = false;
                //        }
                //    }
                _Keyboard.Detect_Key();
                if (_Keyboard.GetCurrent_key() == ConsoleKey.Escape)
                {
                    break_execution = false;
                }
                Thread.Sleep(100);
            }
        }
    }
}
