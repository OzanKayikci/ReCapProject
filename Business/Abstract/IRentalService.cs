using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int Id);
        IDataResult<Rental> GetByCarId(int Id);
        IDataResult<Rental> GetByCustomerId(int Id);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult isCarAvaliable(int id);
        IDataResult<List<RentalDetailDto>> getRentalDetails();

    }
}
