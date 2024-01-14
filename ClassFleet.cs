﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Vehicles
{
    public class Fleet
    {
        public List<Vehicle> Vehicles;
        public Fleet() {
            
            Vehicles = new List<Vehicle>();
            
            Vehicles.Add(new CargoVehicle(1, "Volvo", "VolvoModel1", 1.0, 2020, "black", 5000, "AAAA135", 2000, 20, 150));
            Vehicles.Add(new PassengerVehicle(2, "Toyota", "ToyotaModel1", 1.0, 2020, "white", 5000, "BBBB246", 250, 1100, 100));
            Vehicles.Add(new CargoVehicle(3, "MAC", "MACModel1", 1.0, 2020, "red", 5000, "CCCC782", 250, 3, 320));
            Vehicles.Add(new PassengerVehicle(4, "MiniCooper", "MCModel1", 1.0, 2020, "beige", 5000, "DDDD197", 500, 3, 10));
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
                //Console.Write($"ID: {vehicle.Id}\tType: {(vehicle is CargoVehicle ? "Cargo" : "Passenger")}");
                //if (vehicle is CargoVehicle) { Console.WriteLine($"\tCargoWeight: {(vehicle as CargoVehicle).CargoWeight}"); }
                //if (vehicle is PassengerVehicle) { Console.WriteLine($"\tLesseeRating: {(vehicle as PassengerVehicle).LesseeRating}"); }
                //Console.WriteLine($"Brand: {vehicle.Brand}\tModel: {vehicle.Model}\tModelCoef: {vehicle.ModelCoef}");
                //Console.WriteLine($"Year: {vehicle.Year}\tColor: {vehicle.Color}\tRegNumber: {vehicle.RegNumber}");
                //Console.WriteLine($"Price: {vehicle.Price}\tMileage: {vehicle.Mileage}\tServiceTime: {vehicle.ServiceTime}");
                if (vehicle is CargoVehicle) { (vehicle as CargoVehicle).PrintInfo(); }
                if (vehicle is PassengerVehicle) { (vehicle as PassengerVehicle).PrintInfo(); }

                Console.WriteLine(separator);
            }
        }
    }
}
