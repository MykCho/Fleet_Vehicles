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

            //since fleet elements are of class Vehicle, we need to check for child class before calling respective child class function
            //please suggest a better way
            if (Fleet.Vehicles.ElementAt(0) is CargoVehicle) {
                Console.WriteLine($"Rental cost: {(Fleet.Vehicles.ElementAt(0) as CargoVehicle).CalculateRentalCost(10, 5, 1, 2)}");
            }

        }
    }
}
