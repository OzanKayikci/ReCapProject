﻿using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        List<Brand> GetById(int Id);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);

    }
}