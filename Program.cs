namespace Fleet_Vehicles
{
    internal class Program
    {
        static void Main()
        {
            //Console.WriteLine(Fleet.Vehicles.ElementAt(0).Price); //reminder how to get individual element
            var Fleet = new Fleet();
            
            //Fleet.PrintVehiclesPriceCost();
            Fleet.PrintVehicles();
        }
    }
}
