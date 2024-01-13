namespace Fleet_Vehicles
{
    internal class Program
    {
        static void Main()
        {
            var vehicle1 = new Vehicle(1, "Volvo", "VolvoModel1", 1.0, 1983, "black", 1000, "AAAA135", 2000, 20);
            var vehicle2 = new Vehicle(2, "Toyota", "ToyotaModel1", 1.0, 1995, "white", 1000, "BBBB246", 1500, 1100);

            List<Vehicle> Fleet = new List<Vehicle>();
            Fleet.Add(vehicle1);
            Fleet.Add(vehicle2);

            foreach (var vehicle in Fleet)
            {
                Console.WriteLine(vehicle.Year);
            }

            var vehicle3 = new CargoVehicle(3, "MAC", "MACModel1", 1.0, 2020, "red", 1530, "CCCC782", 500, 3, 320);
            Console.WriteLine($"veh3 Initial value: {vehicle3.Price}");
            Console.WriteLine($"veh3 Current value: {vehicle3.GetVehicleValue()}");

            var vehicle4 = new PassengerVehicle(4, "MiniCooper", "MCModel1", 1.0, 2020, "beige", 1530, "DDDD197", 500, 3, 10);
            Console.WriteLine($"veh4 Initial value: {vehicle4.Price}");
            Console.WriteLine($"veh4 Current value: {vehicle4.GetVehicleValue()}");

        }
    }
}
