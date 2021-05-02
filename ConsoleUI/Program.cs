using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Car ID   " + " Model   " + " Daily Price  " + " Description ");
            GetAll();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Car Name   " + " Model   " + " Daily Price  " + " Description ");
            CarTest();
            Console.WriteLine("rentAdd\n");
            //RentAdd();
            RentGetAll();
            //Console.WriteLine("\n colorss");
            //GetAllByColorId();
        
        }

        private static void GetAllByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("Please enter color ID");
            string id;
            id = Console.ReadLine();
            foreach (var color in carManager.GetCarsByColorId(int.Parse(id)).Data)
            {
                Console.WriteLine(colorManager.GetById(color.ID).Data.ColorName + "         " + color.ColorId );
            }
        }
        public static void RentAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rent = new Rental();
            rent.CarId = 1;
            rent.CustomerId = 1;
            rent.RentDate = DateTime.Now;
            rent.ReturnDate = DateTime.Now.AddDays(2);
            Console.WriteLine(rentalManager.Add(rent).Message);

        }
        private static  void GetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.ID + "         " + car.ModelYear + "     " + car.DailyPrice + "             "+car.Description);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var carDetail = carManager.GetCarDetails();
            
                foreach (var car in carDetail.Data)
                {
                    Console.WriteLine(car.CarName + "         " + car.BrandName + "     " + car.ColorName + "             " + car.DailyPrice + "             " + car.Description);
                }
        }
        public static void RentGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("ID  " +" Customer Name "+ " Model   " + " Rent Date            " + "      Return Date");
            foreach (var item in rentalManager.getRentalDetails().Data)
            {
                Console.WriteLine(item.Id + "   " + item.CustomerName.Trim() + "   " + item.CarName.Trim() + "   " + item.RentDate + "   " + item.ReturnDate);
            }
        }
    }

    
}
