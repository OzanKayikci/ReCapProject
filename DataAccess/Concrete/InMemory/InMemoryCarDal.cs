using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{ ID =1 , BrandID="1", ColorId = "111", ModelYear = "2010", DailyPrice =100, Description="Sadece günlük kiralanabilir."},
                new Car{ ID =2 , BrandID="21", ColorId = "222", ModelYear = "2019", DailyPrice =75, Description="Sadece haftalık kiralanabilir."},
                new Car{ ID =3 , BrandID="4", ColorId = "333", ModelYear = "2012", DailyPrice =50, Description="Sadece aylık kiralanabilir."},
                new Car{ ID =4 , BrandID="43", ColorId = "444", ModelYear = "2013", DailyPrice =150, Description="Saatlik kiralanır"},
                new Car{ ID =5 , BrandID="56", ColorId = "555", ModelYear = "2020", DailyPrice =200, Description="Sadece Şehir içine kiralanır."},
                new Car{ ID =6 , BrandID="78", ColorId = "666", ModelYear = "1966", DailyPrice =700, Description="Klasik araçtır.(günlük kiralanır)"},

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

        public List<Car> GetAll()
        {
            return _car;
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
