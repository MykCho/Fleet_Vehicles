namespace Fleet_Vehicles
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            Vehicle vehicle1 = new Vehicle(1, "Volvo", "Model1", 1.0, 1983, "black", 1000, "AAAA135", 2000, 20);

            Console.WriteLine(vehicle1.Brand);

        }
    }
}
