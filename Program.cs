using System.IO.Pipes;

namespace Fleet_Vehicles
{
    internal class Program
    {
        static void Pause()
        {
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
        
        static void Main()
        {
            //Console.WriteLine(Fleet.Vehicles.ElementAt(0).Price); //reminder how to get individual element
            var Fleet = new Fleet(); //initializing our fleet with default constructor's values
            
            Fleet.PrintVehiclesPriceCost();
            Pause();
            
            Fleet.PrintVehicles();
            Pause();

            //Here getting rental cost of some vehicles
            //since fleet elements are of class Vehicle, we need to check for child class before calling respective child class function
            //please suggest a better way
            if (Fleet.Vehicles.ElementAt(0) is CargoVehicle) {
                Console.WriteLine($"Rental cost of element 0: ${(Fleet.Vehicles.ElementAt(0) as CargoVehicle).CalculateRentalCost(10, 5, 1, 2)}");
            }

            if (Fleet.Vehicles.ElementAt(1) is PassengerVehicle)
            {
                Console.WriteLine($"Rental cost of element 1: ${(Fleet.Vehicles.ElementAt(1) as PassengerVehicle).CalculateRentalCost(10, 5, 1, 2)}");
            }

            //Getting rental cost for each element with some general parameters
            foreach (Vehicle vehicle in Fleet.Vehicles)
            {
                if (vehicle is CargoVehicle)
                {
                    Console.WriteLine($"Rental cost of {vehicle.Color} {vehicle.Brand} {vehicle.Model}: ${(vehicle as CargoVehicle).CalculateRentalCost(10, 5, 1, 2)}");
                }

                if (vehicle is PassengerVehicle)
                {
                    Console.WriteLine($"Rental cost of {vehicle.Color} {vehicle.Brand} {vehicle.Model}: ${(vehicle as PassengerVehicle).CalculateRentalCost(10, 5, 1, 2)}");
                }
            }

            //continue here
            Pause();

            Console.WriteLine($"Total fleet value, considering vehicle's age: ${Fleet.GetFleetValue()}");

        }
    }
}
