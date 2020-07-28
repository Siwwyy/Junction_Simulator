using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junction_Simulator
{
    public class Paddle : Game_Object
    {

        public Paddle() : base()
        {

        }

        public Paddle(int initial_x, int initial_y) : base(initial_x,initial_y)
        {

        }

        public new int Pos_x { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public new int Pos_y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
