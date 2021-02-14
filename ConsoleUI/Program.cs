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

            //Car car1 = new Car { BrandId = 7, ColorId = 7, DailyPrice = 0, Description = "", ModelYear = 2017 };
            //Car car2 = new Car { BrandId = 8, ColorId = 6, DailyPrice = 300, Description = "", ModelYear = 2021 };
            //Brand brand1 = new Brand { Name = "a" };
            //Brand brand2 = new Brand { Name = "Porsche" };
            //carManager.Add(car1);
            //carManager.Add(car2);
            //brandManager.Add(brand1);
            //brandManager.Add(brand2);

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
