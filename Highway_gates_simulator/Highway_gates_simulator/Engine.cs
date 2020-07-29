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
        private Gate gate;

        private readonly object Car_Array_Locker = new object();

        public List<Car> Car_Array
        {
            get => car_Array;
            set => car_Array = value;
        }
        public Engine()
        {
            semaphore = new Semaphore(3, 3);
            gate = new Gate(3);
            car_Array = new List<Car>();
            car_Array.Add(new Car(0, 1, 0, "Empty"));
        }

        //public void Semaphore(int car_index)
        //{
        //    //lock (Car_Array_Locker)
        //    //{
        //    //    for (int i = 0; i < car_Array.Count; ++i)
        //    //    {
        //    //        if (this.Car_Array[i].Stop == true)
        //    //        {
        //    //            int free_gate = gate.Free_Gate();
        //    //            if(free_gate != -1)
        //    //            {
        //    //                Thread t = new Thread(Take_Gate);

        //    //                t.Start(i);
        //    //                semaphore.Release(1);
        //    //            }
        //    //        }
        //    //    }

        //    //}


        //}

        public void Take_Gate(int car_index)
        {
            lock (Car_Array_Locker)
            {
                int free_gate_index = gate.Occupy_Gate(car_index);
                if (free_gate_index != -1)
                {
                    this.car_Array[car_index].Pos_x = 71;
                    this.car_Array[car_index].Pos_y = free_gate_index * 3 + 4;

                    Thread t = new Thread(new ParameterizedThreadStart(Get_Pay));
                    t.Start(car_index);
                    //Get_Pay(car_index);
                    //semaphore.Release();
                }
            }
        }

        private void Get_Pay(object car_index)
        {
            semaphore.WaitOne();
            int car_id = (int)car_index;
            int x,y;
            Draw_Highway obj = new Draw_Highway();
            String message;
            lock (Car_Array_Locker)
            {              
                ////message = string.Format("Car with id {0} | Semaphore {1}", this.car_Array[car_id].Car_id,semaphore.Release());
                message = string.Format("Car with id {0}", this.car_Array[car_id].Car_id);
                obj.Draw_Message(10, 8 + this.car_Array[car_id].Car_id, message);
                x = this.car_Array[car_id].Pos_x;
                y = this.car_Array[car_id].Pos_y;
                this.car_Array.RemoveAt(car_id);
            }         
            Thread.Sleep(3500);
            obj.Erase_Object(x, y);
            gate.Release_Gate(car_id);
            semaphore.Release();
        }

        public void Add_Car(object position)
        {
            lock (Car_Array_Locker)
            {
                //Car_Array.Add(new Car(0, (int)position, Thread.CurrentThread.ManagedThreadId, "Empty"));
                car_Array.Add(new Car(0, 1, Car_Array.Count, "Empty"));
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
                    if (car_Array[i].Stop == false)
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
