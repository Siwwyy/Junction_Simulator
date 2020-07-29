using System;
using System.Collections.Generic;
using System.Text;

namespace Highway_gates_simulator
{
    class Gate
    {
        private int[] space;

        private readonly object Space_locker = new object();


        public Gate()
        {
            this.space = new int[3];
        }

        public Gate(int space_size)
        {
            this.space = new int[space_size];
            for (int i = 0; i < space.Length; ++i)
            {
                space[i] = -1;
            }
        }

        public int Occupy_Gate(int car_index)
        {
            lock (Space_locker)
            {
                for (int i = 0; i < space.Length; ++i)
                {
                    if (space[i] == -1)
                    {
                        space[i] = car_index;
                        return i;
                    }
                }
            }
            return -1;
        }

        public void Release_Gate(int car_index)
        {
            lock (Space_locker)
            {
                for (int i = 0; i < space.Length; ++i)
                {
                    if (space[i] == car_index)
                    {
                        space[i] = -1;
                    }
                }
            }
        }

        public int[] Space { get => space; set => space = value; }
    }
}
