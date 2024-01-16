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
        public static string separator = new String('-', Console.WindowWidth); //string of repeating symbols, WindowWidth times

        public List<Vehicle> Vehicles;
        public Fleet() {
            
            Vehicles = new List<Vehicle>();
            //using names for easiness
            Vehicles.Add(new CargoVehicle(id:1, brand:"Volvo", model:"FH16", modelCoef:1.05, year:2020, color:"black", price:25000, regNumber:"AAAA135", mileage:4500, servicetime:20, cargoweight:150));
            Vehicles.Add(new PassengerVehicle(id:2, brand:"Toyota", model:"Camry", modelCoef:1.5, year:2012, color:"white", price:16000, regNumber:"BBBB246", mileage:250, servicetime:10, lesseeRating:100));
            Vehicles.Add(new CargoVehicle(id:3, brand:"MAC", model:"Super-Liner", modelCoef:1.0, year:2021, color:"red", price:24000, regNumber:"CCCC782", mileage:14100, servicetime:3, cargoweight:320));
            Vehicles.Add(new PassengerVehicle(id:4, brand:"MiniCooper", model:"Countryman", modelCoef:1.0, year:2022, color:"beige", price:30100, regNumber:"DDDD197", mileage:500, servicetime:3, lesseeRating:10));
            Vehicles.Add(new CargoVehicle(id:5, brand:"Volvo", model:"FH", modelCoef:1.02, year:2016, color:"white", price:21000, regNumber:"EEEE473", mileage:1000001, servicetime:3, cargoweight:120));
            Vehicles.Add(new CargoVehicle(id:6, brand: "Volvo", model: "FMX", modelCoef: 1.01, year: 2014, color: "white", price: 26500, regNumber: "FFFF438", mileage: 29300, servicetime: 7, cargoweight: 130));
            Vehicles.Add(new PassengerVehicle(id: 7, brand: "Toyota", model: "Corolla", modelCoef: 1.0, year: 1986, color: "red", price: 5000, regNumber: "GGGG761", mileage: 14500, servicetime: 30, lesseeRating: 100));
            Vehicles.Add(new PassengerVehicle(id: 8, brand: "Toyota", model: "Corona", modelCoef: 1.2, year: 1986, color: "red", price: 5000, regNumber: "HHHH468", mileage: 5100, servicetime: 30, lesseeRating: 100));
            Vehicles.Add(new PassengerVehicle(id: 9, brand: "Toyota", model: "Carina", modelCoef: 1.1, year: 1986, color: "red", price: 5000, regNumber: "HHHH468", mileage: 21300, servicetime: 30, lesseeRating: 100));
        }

        public Fleet(string fileName)
        {
            string vehicleType;
            uint Id;
            string Brand;
            string Model;
            double ModelCoef;
            int Year;
            string Color;
            double Price;
            string RegNumber;
            int Mileage;
            short ServiceTime;
            double CargoWeight;
            uint LesseeRating;
            
            if (!File.Exists(fileName)) { throw new FileNotFoundException($"Init file {fileName} is not found."); }

            using (StreamReader sr = File.OpenText(fileName))
            {
                bool parseOutcome;
                string line;
                Vehicles = new List<Vehicle>();

                while (sr.Peek() >= 0)
                {
                    vehicleType = sr.ReadLine();
                    line = sr.ReadLine(); parseOutcome = uint.TryParse(line, out Id);
                    Brand = sr.ReadLine();
                    Model = sr.ReadLine();
                    line = sr.ReadLine(); parseOutcome = double.TryParse(line, out ModelCoef);
                    line = sr.ReadLine(); parseOutcome = int.TryParse(line, out Year);
                    Color = sr.ReadLine();
                    line = sr.ReadLine(); parseOutcome = double.TryParse(line, out Price);
                    RegNumber = sr.ReadLine();
                    line = sr.ReadLine(); parseOutcome = int.TryParse(line, out Mileage);
                    line = sr.ReadLine(); parseOutcome = short.TryParse(line, out ServiceTime);
                    if (vehicleType == "CargoVehicle") { 
                        line = sr.ReadLine(); parseOutcome = double.TryParse(line, out CargoWeight);
                        Vehicles.Add(new CargoVehicle(Id, Brand, Model, ModelCoef, Year, Color, Price, RegNumber, Mileage, ServiceTime, CargoWeight));
                    }
                    if (vehicleType == "PassengerVehicle") { 
                        line = sr.ReadLine(); parseOutcome = uint.TryParse(line, out LesseeRating);
                        Vehicles.Add(new PassengerVehicle(Id, Brand, Model, ModelCoef, Year, Color, Price, RegNumber, Mileage, ServiceTime, LesseeRating));
                    }

                }
            }

            
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
            //string separator = new String('-', Console.WindowWidth); //string of repeating symbols, WindowWidth times
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
            var vehiclesSelected = Vehicles.Where(x => { return x.Brand == brandName; });
            
            Console.WriteLine($"Vehicles of \"{brandName}\" brand:");
            Console.WriteLine(separator);
            foreach (var vehicle in vehiclesSelected) {
                if (vehicle is CargoVehicle) { (vehicle as CargoVehicle).PrintInfo(); }
                if (vehicle is PassengerVehicle) { (vehicle as PassengerVehicle).PrintInfo(); }
                Console.WriteLine(separator);
            }
        }

        public void PrintSameBrandColorSorted(string brandName, string color)
        {
            var vehiclesSelected= from vehicle in Vehicles
                                      where vehicle.Brand == brandName && vehicle.Color == color
                                      orderby vehicle.ModelCoef descending
                                      select vehicle;

            Console.WriteLine($"Vehicles of \"{brandName}\" brand, color {color}, sorted by ModelCoef:"); //let's suppose ModelCoef is Comfort
            Console.WriteLine(separator);
            foreach (var vehicle in vehiclesSelected)
            {
                if (vehicle is CargoVehicle) { (vehicle as CargoVehicle).PrintInfo(); }
                if (vehicle is PassengerVehicle) { (vehicle as PassengerVehicle).PrintInfo(); }
                Console.WriteLine(separator);
            }
        }

        public void PrintExceededTenure()
        {

            var vehiclesSelected = from vehicle in Vehicles
                                   where (vehicle is PassengerVehicle && (vehicle.Mileage > 100000 || vehicle.ServiceTime > 5 )) || (vehicle is CargoVehicle && (vehicle.Mileage > 1000000 || vehicle.ServiceTime > 15))
                                   select vehicle;

            Console.WriteLine($"Vehicles of exceeded tenure:");
            Console.WriteLine(separator);
            foreach (var vehicle in vehiclesSelected)
            {
                if (vehicle is CargoVehicle) { (vehicle as CargoVehicle).PrintInfo(); }
                if (vehicle is PassengerVehicle) { (vehicle as PassengerVehicle).PrintInfo(); }
                Console.WriteLine(separator);
            }
        }

        public void PrintCloseToMaintenance()
        {

            var vehiclesSelected = from vehicle in Vehicles
                                   where (vehicle is PassengerVehicle && (vehicle as PassengerVehicle).GetKmToNextMaintenance() < 1000) || (vehicle is CargoVehicle && (vehicle as CargoVehicle).GetKmToNextMaintenance() < 15000)
                                   select vehicle;

            Console.WriteLine($"--=[Vehicles close to maintenance]=--");
            Console.WriteLine(separator);
            foreach (var vehicle in vehiclesSelected)
            {
                if (vehicle is CargoVehicle) { (vehicle as CargoVehicle).PrintInfo(); }
                if (vehicle is PassengerVehicle) { (vehicle as PassengerVehicle).PrintInfo(); }
                Console.WriteLine(separator);
            }
        }

        public void DumpToFile()
        {
            string fileName = @"FleetDump.txt";
            if (File.Exists(fileName)) { File.Delete(fileName); }

            using (StreamWriter sw = File.CreateText(fileName))
            {
                foreach (var vehicle in Vehicles) { 
                    if (vehicle is CargoVehicle) { sw.WriteLine("CargoVehicle"); }
                    if (vehicle is PassengerVehicle) { sw.WriteLine("PassengerVehicle"); }
                    sw.WriteLine(vehicle.Id);
                    sw.WriteLine(vehicle.Brand);
                    sw.WriteLine(vehicle.Model);
                    sw.WriteLine(vehicle.ModelCoef);
                    sw.WriteLine(vehicle.Year);
                    sw.WriteLine(vehicle.Color);
                    sw.WriteLine(vehicle.Price);
                    sw.WriteLine(vehicle.RegNumber);
                    sw.WriteLine(vehicle.Mileage);
                    sw.WriteLine(vehicle.ServiceTime);
                    if (vehicle is CargoVehicle) { sw.WriteLine($"{(vehicle as CargoVehicle).CargoWeight}"); }
                    if (vehicle is PassengerVehicle) { sw.WriteLine($"{(vehicle as PassengerVehicle).LesseeRating}"); }


                }
            }


        }

    }
}
