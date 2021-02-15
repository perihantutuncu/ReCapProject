using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public CarDetailDto GetByIdCarDetail(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             where c.Id == id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 ModelYear = c.ModelYear,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice
                             };

                return result.FirstOrDefault();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailDto { 
                                 CarId = c.Id, ModelYear = c.ModelYear, 
                                 BrandName = b.Name, ColorName = co.Name, 
                                 DailyPrice = c.DailyPrice };

                return result.ToList();
            }
        }
    }
}
