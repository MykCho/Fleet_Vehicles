namespace Fleet_Vehicles
{
    internal class Program
    {
        static void Main()
        {
            List<Vehicle> Fleet = new List<Vehicle>(); //that's our main fleet for now

            var vehicle1 = new CargoVehicle(1, "Volvo", "VolvoModel1", 1.0, 2020, "black", 5000, "AAAA135", 2000, 20, 150);
            var vehicle2 = new PassengerVehicle(2, "Toyota", "ToyotaModel1", 1.0, 2020, "white", 5000, "BBBB246", 250, 1100, 100);
            var vehicle3 = new CargoVehicle(3, "MAC", "MACModel1", 1.0, 2020, "red", 5000, "CCCC782", 250, 3, 320);
            var vehicle4 = new PassengerVehicle(4, "MiniCooper", "MCModel1", 1.0, 2020, "beige", 5000, "DDDD197", 500, 3, 10);

            Fleet.Add(vehicle1);
            Fleet.Add(vehicle2);
            Fleet.Add(vehicle3);
            Fleet.Add(vehicle4);

            foreach (var vehicle in Fleet)
            {
                //Console.WriteLine($"{vehicle.Id}, {vehicle.Brand}, Initial value: {vehicle.Price}, Current Value: {vehicle.GetVehicleValue()}");
                Console.WriteLine($"{(vehicle is CargoVehicle ? "Cargo" : "Passenger")}, {vehicle.Brand}: ${vehicle.Price}/{(vehicle is PassengerVehicle ? (vehicle as PassengerVehicle).GetVehicleValue() : vehicle.GetVehicleValue())}");
                

            }

            Console.WriteLine(Fleet.ElementAt(3).Id);
            Console.WriteLine((Fleet.ElementAt(3) as PassengerVehicle).GetVehicleValue()); //holy fudge! it works!
        }
    }
}
