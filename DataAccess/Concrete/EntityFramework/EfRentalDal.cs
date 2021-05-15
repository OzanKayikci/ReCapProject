using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = (from rental in filter==null? context.Rentals: context.Rentals.Where(filter)
                              join customer in context.Customers 
                              on rental.CustomerId equals customer.UserId
                              join user in context.Users
                              on rental.CustomerId equals user.Id
                              join car in context.Cars 
                              on rental.CarId equals car.ID
                              select new RentalDetailDto
                              {
                                  CarName = car.CarName,
                                  CustomerName = user.FirstName.Trim() + " " + user.LastName,
                                  Id = rental.Id,
                                  RentDate = rental.RentDate,
                                  ReturnDate = rental.ReturnDate
                              }
                          ).ToList();
                return result;
            }
        }

        public bool isCarAvaliable(int id)
        {
            throw new System.NotImplementedException();
        }
    }

}
