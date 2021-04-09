using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal: ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{ ID =1 ,BrandId=1000,ColorId=3, ModelYear = 2010, DailyPrice =100, Description="Sadece günlük kiralanabilir."},
                new Car{ ID =2 ,BrandId=1000,ColorId=3, ModelYear = 2019, DailyPrice =75, Description="Sadece haftalık kiralanabilir."},
                new Car{ ID =3 ,BrandId=1000,ColorId=3,  ModelYear = 2012, DailyPrice =50, Description="Sadece aylık kiralanabilir."},
                new Car{ ID =4 ,BrandId=1000,ColorId=3, ModelYear = 2013, DailyPrice =150, Description="Saatlik kiralanır"},
                new Car{ ID =5 ,BrandId=1000,ColorId=3,  ModelYear = 2020, DailyPrice =200, Description="Sadece Şehir içine kiralanır."},
                new Car{ ID =6 ,BrandId=1000,ColorId=3,  ModelYear = 1966, DailyPrice =700, Description="Klasik araçtır.(günlük kiralanır)"},

            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car DeleteCar = _car.SingleOrDefault(c => c.ID == car.ID);
            _car.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

    

        public List<Car> GetById(int Id)
        {
            return _car.Where(c => c.ID == Id).ToList();
        }

        public void Update(Car car)
        {
            Car UpdateCar = _car.SingleOrDefault(p => p.ID == car.ID);
            UpdateCar.DailyPrice = car.DailyPrice;
            UpdateCar.Description = car.Description;
        }

      
    }
}
