using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junction_Simulator
{
    public abstract class Game_Object
    {
        private int pos_x, pos_y;
        protected Game_Object()
        {
            this.Pos_x = 500; 
            this.Pos_y = 500; 
        }

        protected Game_Object(int initial_x, int initial_y)
        {
            this.Pos_x = initial_x;
            this.Pos_y = initial_y;
        }

        public int Pos_x
        {
            get { return this.pos_x; }
            set { pos_x = value; }
        }
        public int Pos_y
        {
            get { return this.pos_y; }
            set { pos_y = value; }
        }


    }
}
