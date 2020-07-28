using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Highway_gates_simulator
{
    class Engine
    {
        private List<Car> Car_Array;

        private readonly object Car_Array_Locker = new object();
        public Engine()
        {
            Car_Array = new List<Car>();
        }

        public void Add_Car(object position)
        {
            lock (Car_Array_Locker)
            {
                //Car_Array.Add(new Car(0, (int)position, Thread.CurrentThread.ManagedThreadId, "Empty"));
                Car_Array.Add(new Car(0, (int)position, (Car_Array.Count), "Empty"));
            }
        }

        public void Move_Single_Car_Forward(object car_id)
        {
            lock (Car_Array_Locker)
            {
                Car_Array[(int)car_id].Move_Car_Forward();
            }
        }

        public void Move_Cars_Forward()
        {
            lock (Car_Array_Locker)
            {
                for (int i = 0; i < Car_Array.Count; ++i)
                {
                    Car_Array[i].Move_Car_Forward();
                }
            }
        }
    }
}
