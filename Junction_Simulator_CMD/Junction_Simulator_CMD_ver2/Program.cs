﻿using System;

namespace Junction_Simulator_CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(100, 20);
            engine.Run();
        }
    }
}