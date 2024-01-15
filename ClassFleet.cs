using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Vehicles
{
    public class Fleet
    {
        public List<Vehicle> Vehicles;
        public Fleet() {
            
            Vehicles = new List<Vehicle>();
            //using names for easiness
            Vehicles.Add(new CargoVehicle(id:1, brand:"Volvo", model:"FH16", modelCoef:1.05, year:2020, color:"black", price:25000, regNumber:"AAAA135", mileage:2000, servicetime:20, cargoweight:150));
            Vehicles.Add(new PassengerVehicle(id:2, brand:"Toyota", model:"Camry", modelCoef:1.0, year:2012, color:"white", price:16000, regNumber:"BBBB246", mileage:250, servicetime:1100, lesseeRating:100));
            Vehicles.Add(new CargoVehicle(id:3, brand:"MAC", model:"Super-Liner", modelCoef:1.0, year:2021, color:"red", price:24000, regNumber:"CCCC782", mileage:250, servicetime:3, cargoweight:320));
            Vehicles.Add(new PassengerVehicle(id:4, brand:"MiniCooper", model:"Countryman", modelCoef:1.0, year:2022, color:"beige", price:30100, regNumber:"DDDD197", mileage:500, servicetime:3, lesseeRating:10));
            Vehicles.Add(new CargoVehicle(id:5, brand:"Volvo", model:"FH", modelCoef:1.02, year:2016, color:"white", price:21000, regNumber:"EEEE473", mileage:500, servicetime:3, cargoweight:120));
            Vehicles.Add(new CargoVehicle(id:6, brand: "Volvo", model: "FMX", modelCoef: 1.01, year: 2014, color: "white", price: 26500, regNumber: "FFFF438", mileage: 250, servicetime: 7, cargoweight: 130));
        }

        public void PrintVehiclesPriceCost()
        {
            foreach (var vehicle in Vehicles)
            {
                //as the list is of class Vehicle, GetVehicleValue of "Vehicle" class will be called each time, so we're using "is" and "as" to call the correct function
                //calling correct GetVehicleValue based on derived class
                Console.WriteLine($"{(vehicle is CargoVehicle ? "Cargo" : "Passenger")}, {vehicle.Brand}: ${vehicle.Price}/{(vehicle is PassengerVehicle ? (vehicle as PassengerVehicle).GetVehicleValue() : vehicle.GetVehicleValue())}");
            }
        }
                
        public void PrintVehicles()
        {
            string separator = new String('-', Console.WindowWidth); //string of repeating symbols, WindowWidth times
            foreach (var vehicle in Vehicles)
            {
               
                if (vehicle is CargoVehicle) { (vehicle as CargoVehicle).PrintInfo(); }
                if (vehicle is PassengerVehicle) { (vehicle as PassengerVehicle).PrintInfo(); }

                Console.WriteLine(separator);
            }
        }

        public double GetFleetValue()
        {
            double fleetValue= 0;
            
            foreach (var vehicle in Vehicles)
            {
                
                //could have used "else", but potentially there may be more child classes than 2
                if (vehicle is CargoVehicle) {
                    fleetValue += (vehicle as CargoVehicle).GetVehicleValue();
                }
                
                if (vehicle is PassengerVehicle)
                {
                    fleetValue += (vehicle as PassengerVehicle).GetVehicleValue();
                }
            }

            return fleetValue;
        }

        public void PrintSameBrand(string brandName)
        {
            string separator = new String('-', Console.WindowWidth); //string of repeating symbols, WindowWidth times
            var vehiclesOfSameBrand = Vehicles.Where(x => { return x.Brand == brandName; });
            
            Console.WriteLine($"Vehicles of \"{brandName}\" brand:");
            Console.WriteLine(separator);
            foreach (var vehicle in vehiclesOfSameBrand) {
                if (vehicle is CargoVehicle) { (vehicle as CargoVehicle).PrintInfo(); }
                if (vehicle is PassengerVehicle) { (vehicle as PassengerVehicle).PrintInfo(); }
                Console.WriteLine(separator);
            }
        }
    }
}
