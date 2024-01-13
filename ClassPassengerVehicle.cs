using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Vehicles
{
    public class PassengerVehicle : Vehicle
    {
        public uint LesseeRating {  get; set; }

        public PassengerVehicle (uint id, string brand, string model, double modelCoef, int year, string color, double price, string regNumber, int mileage, short servicetime, uint lesseeRating)
            : base(id, brand, model, modelCoef, year, color, price, regNumber, mileage, servicetime)
        {
            LesseeRating = lesseeRating;
        }

        public double GetVehicleValue() //it hides the original method
        {
            int currentYear = DateTime.Now.Year;
            double currentPrice = Price - (currentYear - Year) * (10 * Price / 100); //-10% for passenger vehicle

            return (currentPrice > 0 ? currentPrice : 0);
        }
    }
}
