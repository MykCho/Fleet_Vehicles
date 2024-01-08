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
        public uint Year { get; set; }
        public string Color { get; set; }
        public double Price {  get; set; } 
        public string RegNumber {  get; set; }
        public int Mileage { get; set; }
        public short  ServiceTime { get; set; }

        public Vehicle(uint id, string brand, string model, double modelCoef, uint year, string color, double price, string regNumber, int mileage, short servicetime) {
            Id = id;
            Brand = brand;
            Model = model;
            ModelCoef = modelCoef;
            Year = year;
            Color = color;
            Price = price;
            RegNumber = regNumber;
            Mileage = mileage;
            ServiceTime = servicetime;

        
        }
    }
}
