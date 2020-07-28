using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Highway_gates_simulator
{
    class Engine
    {
        private List<Car> car_Array;
        private Semaphore semaphore;

        private readonly object Car_Array_Locker = new object();

        public List<Car> Car_Array
        {
            get => car_Array;
            set => car_Array = value;
        }
        public Engine()
        {
            semaphore = new Semaphore(0, 3);
            car_Array = new List<Car>();
            car_Array.Add(new Car(0, 1, 2, "Empty"));
        }

        public void Semaphore()
        {
            lock (Car_Array_Locker)
            {
                //for (int i = 0; i < car_Array.Count; ++i)
                //{
                //    Thread t = new Thread
                //}
            }
        }

        public void Add_Car(object position)
        {
            lock (Car_Array_Locker)
            {
                //Car_Array.Add(new Car(0, (int)position, Thread.CurrentThread.ManagedThreadId, "Empty"));
                car_Array.Add(new Car(0, 1, (1), "Empty"));
            }
        }

        public void Move_Single_Car_Forward(object car_index)
        {
            lock (Car_Array_Locker)
            {
                //car_Array[(int)car_index].Move_Car_Forward();
                car_Array[(int)car_index].Pos_x -= 1;
            }
        }

        public void Move_Cars_Forward()
        {
            lock (Car_Array_Locker)
            {
                for (int i = 0; i < car_Array.Count; ++i)
                {
                    if (car_Array[i].Stop == false) //zmien na jeden wymiar poniewaz i - 1 to moze nie byc wcale kolejny tylko z poziomu nr5 a nie nr1 jak szukam
                    {
                        if (i > 0 && car_Array[i].Pos_y == car_Array[i - 1].Pos_y)
                        {
                            if (car_Array[i].Pos_x + 1 != car_Array[i - 1].Pos_x)
                            {
                                car_Array[i].Move_Car_Forward();
                            }
                        }
                        else
                        {
                            car_Array[i].Move_Car_Forward();
                        }
                        //car_Array[i].Move_Car_Forward();
                    }
                }
            }
        }
    }
}
