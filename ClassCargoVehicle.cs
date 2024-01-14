using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Vehicles
{
    public class CargoVehicle : Vehicle
    {
        public double CargoWeight { get; set; }
        //I find it reasonable to use maximum cargo weight for calculations, so you won't rent a whole x-wheeler
        //for moving only one sofa, choose wisely :-)

        
        public CargoVehicle(uint id, string brand, string model, double modelCoef, int year, string color, double price, string regNumber, int mileage, short servicetime, double cargoweight)
            :base(id, brand, model, modelCoef, year, color, price, regNumber, mileage, servicetime)
        {
            
            CargoWeight = cargoweight;
        }    
       

        public void PrintInfo()
        {
            Console.Write($"ID: {Id}\tType: Cargo");
            Console.WriteLine($"\tCargoWeight: {CargoWeight}");
            Console.WriteLine($"Brand: {Brand}\tModel: {Model}\tModelCoef: {ModelCoef}");
            Console.WriteLine($"Year: {Year}\tColor: {Color}\tRegNumber: {RegNumber}");
            Console.WriteLine($"Price: ${Price}\tMileage: {Mileage}\tServiceTime: {ServiceTime}");
        }

        public double CalculateRentalCost(double ratePerHour, double ratePerKilometer, uint hours, uint kilometers) { 
            return ModelCoef*Math.Max(ratePerHour*hours, ratePerKilometer*kilometers)*Math.Sqrt(CargoWeight);
            //since I don't know how exactly should cargoweight influence the cost, so I'm using sqrt, not to scare away the customers
        }
    }
}
