using System;
using System.Collections.Generic;
using System.Text;

namespace Junction_Simulator_CMD
{
    class Draw_Road
    {
        private int width;
        private int height;

        public Draw_Road()
        {
            this.width = 500;
            this.height = 500;
        }

        public Draw_Road(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

       
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
    }
}
