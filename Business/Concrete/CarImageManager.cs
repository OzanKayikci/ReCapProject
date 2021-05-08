using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.FileUpload;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile image, CarImage carImage)
        {
            var imageCount = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult("One car must have 5 or less images");
            }
            var imageResult = FileUpload.Upload(image);
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            FileUpload.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());

        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == Id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile image, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.Id == carImage.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }
            var updatedFile = FileUpload.Update(image, isImage.ImagePath);
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}

