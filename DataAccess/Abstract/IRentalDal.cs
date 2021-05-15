using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;
using System.Linq.Expressions;
using System;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        bool isCarAvaliable(int id);
        List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
