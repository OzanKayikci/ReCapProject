using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        bool isCarAvaliable(int id);
        List<RentalDetailDto> GetRentalDetails();
    }
}
