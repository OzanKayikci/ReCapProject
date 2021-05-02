using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = (from rental in context.Rentals 
                              join customer in context.Users 
                              on rental.CustomerId equals customer.Id
                              join car in context.Cars on rental.CarId equals car.ID
                              select new RentalDetailDto
                              {
                                  CarName = car.CarName,
                                  CustomerName = customer.FirstName.Trim() + " " + customer.LastName,
                                  Id = rental.Id,
                                  RentDate = rental.RentDate,
                                  ReturnDate = rental.ReturnDate,
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
