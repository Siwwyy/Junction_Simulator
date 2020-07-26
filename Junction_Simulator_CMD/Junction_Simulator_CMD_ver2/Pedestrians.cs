using System;
using System.Collections.Generic;
using System.Text;

namespace Junction_Simulator_CMD_ver2
{
    class Pedestrians
    {
        private int pedestrians_id;
        private String pedestrians_name;
        private int pos_x, pos_y;

        public Pedestrians()
        {
            this.pedestrians_id = 0;
            this.pedestrians_name = "Mark";
        }

        public Pedestrians(int pedestrians_id, String pedestrians_name)
        {
            this.pedestrians_id = pedestrians_id;
            this.pedestrians_name = pedestrians_name;
        }

        public Pedestrians(int pedestrians_id, String pedestrians_name, int pos_x, int pos_y)
        {
            this.pedestrians_id = pedestrians_id;
            this.pedestrians_name = pedestrians_name;
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }

        public void Draw_Pedestrians()
        {
            Console.SetCursorPosition(this.pos_x, this.pos_y);
            Console.Write("X");
            Console.SetCursorPosition(0, 0);
        }

        public void Erase_Pedestrians()
        {
            Console.SetCursorPosition(this.pos_x, this.pos_y);
            Console.Write(" ");
            Console.SetCursorPosition(0, 0);
        }

        public string Pedestrians_name { get => pedestrians_name; set => pedestrians_name = value; }
        public int Pedestrians_id { get => pedestrians_id; set => pedestrians_id = value; }
        public int Pos_x { get => pos_x; set => pos_x = value; }
        public int Pos_y { get => pos_y; set => pos_y = value; }
    }
}
