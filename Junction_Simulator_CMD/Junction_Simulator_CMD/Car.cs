using System;
using System.Collections.Generic;
using System.Text;

namespace Junction_Simulator_CMD
{
    class Car
    {
        private int car_id;
        private String car_name;

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



        public string Car_name { get => car_name; set => car_name = value; }
        public int Car_id { get => car_id; set => car_id = value; }
    }
}
