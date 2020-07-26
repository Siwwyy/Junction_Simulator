using System;
using System.Collections.Generic;
using System.Text;

namespace Junction_Simulator_CMD_ver2
{
    class Car
    {
        private int car_id;
        private String car_name;
        private int pos_x, pos_y;

        public Car()
        {
            this.car_id = 0;
            this.car_name = "Renault";
        }

        public Car(int car_id, String car_name)
        {
            this.car_id = car_id;
            this.car_name = car_name;
        }

        public Car(int car_id, String car_name, int pos_x, int pos_y)
        {
            this.car_id = car_id;
            this.car_name = car_name;
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }


        public void Draw_Car()
        {
            Console.SetCursorPosition(this.pos_x, this.pos_y);
            Console.Write("=>");
            Console.SetCursorPosition(0, 0);
        }

        public void Erase_Car()
        {
            Console.SetCursorPosition(this.pos_x, this.pos_y);
            Console.Write(" ");
            Console.SetCursorPosition(0, 0);
        }

        public string Car_name { get => car_name; set => car_name = value; }
        public int Car_id { get => car_id; set => car_id = value; }
        public int Pos_x { get => pos_x; set => pos_x = value; }
        public int Pos_y { get => pos_y; set => pos_y = value; }
    }
}
