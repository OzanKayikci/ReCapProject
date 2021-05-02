﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
     public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetByCarId(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == Id),Messages.RentalsListed);
        }

        public IDataResult<Rental> GetByCustomerId(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CustomerId == Id), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
        }

        public IDataResult<List<RentalDetailDto>> getRentalDetails()
        {
            var result = _rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>(result, Messages.RentalsListed);
        }

        public IResult isCarAvaliable(int id)
        {
            var result = _rentalDal.isCarAvaliable(id);
            if (result)
            {
                return new SuccessResult(Messages.CarAvaliable);

            }
            return new ErrorResult(Messages.CarNotAvaliable);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
