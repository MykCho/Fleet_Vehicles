using System.IO.Pipes;

namespace Fleet_Vehicles
{
    internal class Program
    {
        static void Pause()
        {
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
        }
        
        static void Main()
        {
            //since creating menu is not mentioned in the requirements, decided not to bother
            //each bit below shows a different functionality of the Fleet class


            //var Fleet = new Fleet(); //initializing our fleet with default constructor's values


            var Fleet = new Fleet(@"..\\..\\..\\FleetDump.txt");

            Console.WriteLine("--=[Initial cost/current cost]=--");
            Fleet.PrintVehiclesPriceCost();
            Pause();

            Console.WriteLine("--=[All vehicles, detailed info]=--");
            Fleet.PrintVehicles();
            Pause();

            //Here getting rental cost of some vehicles
            //since fleet elements are of class Vehicle, we need to check for child class before calling respective child class function
            //please suggest a better way
            Console.WriteLine("--=[Printing info of elements 0 and 1]=--");
            if (Fleet.Vehicles.ElementAt(0) is CargoVehicle)
            {
                Console.WriteLine($"Rental cost of element 0: ${(Fleet.Vehicles.ElementAt(0) as CargoVehicle).CalculateRentalCost(10, 5, 1, 2)}");
            }

            if (Fleet.Vehicles.ElementAt(1) is PassengerVehicle)
            {
                Console.WriteLine($"Rental cost of element 1: ${(Fleet.Vehicles.ElementAt(1) as PassengerVehicle).CalculateRentalCost(10, 5, 1, 2)}");
            }

            //Getting rental cost for each element with some general parameters
            Console.WriteLine("--=[Rental cost of each vehicle (example)]=--");
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

            Pause();
            Console.WriteLine(Fleet.separator);
            Console.WriteLine($"Total fleet value, considering vehicle's age: ${Fleet.GetFleetValue()}");
            Console.WriteLine(Fleet.separator);
            Pause();

            Fleet.PrintSameBrand("Volvo");
            Pause();

            Fleet.PrintSameBrandColorSorted("Toyota", "red");

            Pause();
            Console.WriteLine(Fleet.separator);
            Fleet.PrintExceededTenure();
            Pause();

            Fleet.PrintCloseToMaintenance();

            //Fleet.DumpToFile(); used for dumping to text file


        }
    }
}
