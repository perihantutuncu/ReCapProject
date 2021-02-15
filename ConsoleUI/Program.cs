using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            ColorManager colorManager = new ColorManager(new EFColorDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Marka: {0} - Renk: {1} - Model: {2} - Günlük Ücret: {3}",
                    brandManager.GetById(car.BrandId).Name,
                    colorManager.GetById(car.ColorId).Name, car.ModelYear, car.DailyPrice);
            }
            Console.WriteLine("---------------------------------");
            foreach (var car in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine("Marka: {0} - Renk: {1} - Model: {2} - Günlük Ücret: {3}",
                    brandManager.GetById(car.BrandId).Name,
                    colorManager.GetById(car.ColorId).Name, car.ModelYear, car.DailyPrice);
            }
            Console.WriteLine("---------------------------------");
            foreach (var car in carManager.GetAllByColorId(1))
            {
                Console.WriteLine("Marka: {0} - Renk: {1} - Model: {2} - Günlük Ücret: {3}",
                    brandManager.GetById(car.BrandId).Name,
                    colorManager.GetById(car.ColorId).Name, car.ModelYear, car.DailyPrice);
            }
            Console.WriteLine("----------------------------------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka: {0} ", brand.Name);
            }
        }
    }
}
