using System;
using System.Collections.Generic;
using System.Text;

namespace Highway_gates_simulator
{
    class Car
    {
        int pos_x, pos_y;
        int car_id;
        String car_name;
        public Car()
        {

        }

        public Car(int pos_x, int pos_y)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }

        public Car(int pos_x, int pos_y, int car_id, string car_name) : this(pos_x, pos_y)
        {
            this.car_id = car_id;
            this.car_name = car_name;
        }

        public void Move_Car_Forward()
        {
            this.pos_x++;
        }

        public void Move_Car_Upwards()
        {
            this.pos_y++;
        }

        public void Move_Car_Downwards()
        {
            this.pos_y--;
        }

        public int Pos_x { get => pos_x; set => pos_x = value; }
        public int Pos_y { get => pos_y; set => pos_y = value; }
    }
}
