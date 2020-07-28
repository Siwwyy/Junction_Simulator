using System;
using System.Collections.Generic;
using System.Text;

namespace Highway_gates_simulator
{
    class Gate
    {
        private bool[] space;

        public Gate()
        {
            this.space = new bool[3];
        }

        public Gate(int space_size)
        {
            this.space = new bool[space_size];
        }

        public bool[] Space { get => space; set => space = value; }
    }
}
