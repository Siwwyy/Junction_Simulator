using System;
using System.Collections.Generic;
using System.Text;

namespace Highway_gates_simulator
{
    class Keyboard
    {
        private ConsoleKey current_key;

        private readonly object Key_Locker = new object();

        public Keyboard()
        {
            this.current_key = ConsoleKey.Enter;
        }


        public void Detect_Key()
        {
            lock (Key_Locker)
            {
                this.current_key = (ConsoleKey)Console.ReadKey().Key;
            }
            //this.current_key = (ConsoleKey)Console.ReadKey().Key;
        }

        public ConsoleKey GetCurrent_key()
        {
            lock (Key_Locker)
            {
                return current_key;
            }
            //return current_key;
        }
    }
}
