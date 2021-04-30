using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public static class Program
    {
        static CarManager carManager = new CarManager(new EfCarDal());
        static ColorManager colorManager = new ColorManager(new EfColorDal());

        public static void Main(string[] args)
        {
            //Console.WriteLine("Car ID   " + " Model   " + " Daily Price  " + " Description ");
            //GetAll();
            Console.WriteLine("Car Name   " + " Model   " + " Daily Price  " + " Description ");
            CarTest();
            //Console.WriteLine("\n colorss");
            //GetAllByColorId();
        }

        public static void GetAllByColorId()
        {
            Console.WriteLine("Please enter color ID");
            string id;
            id = Console.ReadLine();
            foreach (var color in carManager.GetCarsByColorId(int.Parse(id)))
            {
                Console.WriteLine(colorManager.GetById(color.ID).ColorName + "         " + color.ColorId );
            }
        }
        public static void GetAll()
        {
          
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ID + "         " + car.ModelYear + "     " + car.DailyPrice + "             "+car.Description);
            }
        }

        public static void CarTest()
        {

            foreach (var car in carManager.GetCarDetailDtos())
            {
                Console.WriteLine(car.CarName + "         " + car.BrandName + "     " + car.ColorName + "             " + car.DailyPrice + "             " + car.Description);
            }
        }
    }

    
}
