using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Vehicles
{
    public class Vehicle
    {
        public uint Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double ModelCoef {  get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public double Price {  get; set; } 
        public string RegNumber {  get; set; }
        public int Mileage { get; set; }
        public short ServiceTime { get; set; }

        public Vehicle(uint id, string brand, string model, double modelCoef, int year, string color, double price, string regNumber, int mileage, short servicetime) {
            Id = id;
            Brand = brand;
            Model = model;
            ModelCoef = modelCoef;
            Year = year;
            Color = color;
            Price = price;
            RegNumber = regNumber;
            Mileage = mileage;
            ServiceTime = servicetime; //I consider service time is different from age, as car may stay idle in garage for 20 years
            //just be sure for it not to exceed age to be realistic, however in my examples there may be inconsistencies, since it's not the main point
                    
        }

        public double GetVehicleValue()
        {
            int currentYear = DateTime.Now.Year;
            double currentPrice = Price - (currentYear - Year)*(7*Price/100); //-7% for each year for default vehicle, default for cargo vehicles

            return (currentPrice > 0 ? currentPrice : 0); ;
        }
    }
}
