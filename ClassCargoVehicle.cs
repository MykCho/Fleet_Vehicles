using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Vehicles
{
    public class CargoVehicle : Vehicle
    {
        public double CargoWeight { get; set; }

        public CargoVehicle(uint id, string brand, string model, double modelCoef, int year, string color, double price, string regNumber, int mileage, short servicetime, double cargoweight)
            :base(id, brand, model, modelCoef, year, color, price, regNumber, mileage, servicetime)
        {
            CargoWeight = cargoweight;
        }    
       

        //public double GetRentalCost()
        //{

        //}

    }
}
