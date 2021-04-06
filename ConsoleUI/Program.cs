﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class Program
    {
        static CarManager carManager = new CarManager(new InMemoryCarDal());
        static void Main(string[] args)
        {
            GetAll();
        }

        public static void GetAll()
        {
            Console.WriteLine("Car ID   " + " Model   " + " Daily Price  " + " Description ");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ID +"         "+ car.ModelYear+"     " + car.DailyPrice+ "             " + car.Description);
            }
        }
    }

    
}
