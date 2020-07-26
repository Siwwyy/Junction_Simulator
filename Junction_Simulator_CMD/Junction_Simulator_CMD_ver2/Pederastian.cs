using System;
using System.Collections.Generic;
using System.Text;

namespace Junction_Simulator_CMD_ver2
{
    class Pederastian
    {
        private int pederastian_id;
        private String pederastian_name;
        private int pos_x, pos_y;

        public Pederastian()
        {
            this.pederastian_id = 0;
            this.pederastian_name = "Mark";
        }

        public Pederastian(int Pederastian_id, String Pederastian_name)
        {
            this.pederastian_id = Pederastian_id;
            this.pederastian_name = Pederastian_name;
        }

        public Pederastian(int Pederastian_id, String Pederastian_name, int pos_x, int pos_y)
        {
            this.pederastian_id = Pederastian_id;
            this.pederastian_name = Pederastian_name;
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }

        public void Draw_Pederastian()
        {
            Console.SetCursorPosition(this.pos_x, this.pos_y);
            Console.Write("X");
            Console.SetCursorPosition(0, 0);
        }

        public void Erase_Pederastian()
        {
            Console.SetCursorPosition(this.pos_x, this.pos_y);
            Console.Write(" ");
            Console.SetCursorPosition(0, 0);
        }

        public string Pederastian_name { get => pederastian_name; set => pederastian_name = value; }
        public int Pederastian_id { get => pederastian_id; set => pederastian_id = value; }
        public int Pos_x { get => pos_x; set => pos_x = value; }
        public int Pos_y { get => pos_y; set => pos_y = value; }
    }
}
