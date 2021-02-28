using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());
            //GetAllCarTest(carManager);
            CarTests(carManager);
            //ColorTests();
            //BrandTests();
        }

        private static void CarTests(CarManager carManager)
        {
            Console.WriteLine("-------Ekleme--------");
            Car car1 = new Car { BrandId = 6, ColorId = 7, DailyPrice = 400, ModelYear = 2021 };
            carManager.Add(car1);
            Console.WriteLine("Marka: {0} - Renk: {1} - Model: {2} - Günlük Ücret: {3}",
                    carManager.GetByIdCarDetail(car1.Id).Data.BrandName,
                    carManager.GetByIdCarDetail(car1.Id).Data.ColorName,
                    carManager.GetById(car1.Id).Data.ModelYear,
                    carManager.GetById(car1.Id).Data.DailyPrice);

            Console.WriteLine("-------Güncelleme--------");
            car1.BrandId = 4;
            carManager.Update(car1);
            Console.WriteLine("Marka: {0} - Renk: {1} - Model: {2} - Günlük Ücret: {3}",
                    carManager.GetByIdCarDetail(car1.Id).Data.BrandName,
                    carManager.GetByIdCarDetail(car1.Id).Data.ColorName,
                    carManager.GetById(car1.Id).Data.ModelYear,
                    carManager.GetById(car1.Id).Data.DailyPrice);

            Console.WriteLine("-------Silme--------");
            carManager.Delete(car1);
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Marka: {0} - Renk: {1} - Model: {2} - Günlük Ücret: {3}",
                    car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice);
            }
        }

        private static void BrandTests()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());

            Console.WriteLine("-------Ekleme--------");
            Brand brand1 = new Brand { Name = "Hyundai" };
            brandManager.Add(brand1);
            Console.WriteLine(brandManager.GetById(brand1.BrandId).Data.Name);

            Console.WriteLine("-------Güncelleme--------");
            brand1.Name = "Honda";
            brandManager.Update(brand1);
            Console.WriteLine(brandManager.GetById(brand1.BrandId).Data.Name);

            Console.WriteLine("-------Silme--------");
            brandManager.Delete(brand1);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void ColorTests()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());

            Console.WriteLine("-------Ekleme--------");
            Color color1 = new Color { Name = "Mor" };
            colorManager.Add(color1);
            Console.WriteLine(colorManager.GetById(color1.ColorId).Data.Name);

            Console.WriteLine("-------Güncelleme--------");
            color1.Name = "Altın";
            colorManager.Update(color1);
            Console.WriteLine(colorManager.GetById(color1.ColorId).Data.Name);

            Console.WriteLine("-------Silme--------");
            colorManager.Delete(color1);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }
        private static void GetAllCarTest(CarManager carManager)
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            ColorManager colorManager = new ColorManager(new EFColorDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Marka: {0} - Renk: {1} - Model: {2} - Günlük Ücret: {3}",
                    brandManager.GetById(car.BrandId).Data.Name, colorManager.GetById(car.ColorId).Data.Name, car.ModelYear, car.DailyPrice);
            }
        }
    }
}
