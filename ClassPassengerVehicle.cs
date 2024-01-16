using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Vehicles
{
    public class PassengerVehicle : Vehicle
    {
        private static uint MaintenanceDue = 5000;
        public uint LesseeRating {  get; set; }

        public PassengerVehicle (uint id, string brand, string model, double modelCoef, int year, string color, double price, string regNumber, int mileage, short servicetime, uint lesseeRating)
            : base(id, brand, model, modelCoef, year, color, price, regNumber, mileage, servicetime)
        {
            LesseeRating = lesseeRating;
        }

        public double GetVehicleValue() //it hides the parent (Vehicle) method
        {
            int currentYear = DateTime.Now.Year;
            double currentPrice = Price - (currentYear - Year) * (10 * Price / 100); //-10% for passenger vehicle

            return (currentPrice > 0 ? currentPrice : 0);
        }

        public void PrintInfo()
        {
            Console.Write($"ID: {Id}\tType: Passenger");
            Console.WriteLine($"\tLesseeRating: {LesseeRating}");
            Console.WriteLine($"Brand: {Brand}\tModel: {Model}\tModelCoef: {ModelCoef}");
            Console.WriteLine($"Year: {Year}\tColor: {Color}\tRegNumber: {RegNumber}");
            Console.WriteLine($"Price: ${Price}\tMileage: {Mileage}\tServiceTime: {ServiceTime}");
        }
        public double CalculateRentalCost(double ratePerHour, double ratePerKilometer, uint hours, uint kilometers)
        {
            return ModelCoef * Math.Max(ratePerHour * hours, ratePerKilometer * kilometers)*Math.Sqrt(LesseeRating);
            //and similarly in here, using sqrt just because I don't know how should it influence the cost
        }

        public long GetKmToNextMaintenance()
        {
            long MileageTemp = Mileage;
            if (MaintenanceDue >= MileageTemp) { return (MaintenanceDue - MileageTemp); }
            else {
                do { MileageTemp = MileageTemp - MaintenanceDue; } while (MileageTemp > 0);
                return Math.Abs(MileageTemp);
            }
        }
    }
}
