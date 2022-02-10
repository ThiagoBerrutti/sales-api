﻿using SalesAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.Persistence.Repositories
{
    public interface IStockRepository
    {
        public Task<IEnumerable<ProductStock>> GetAll();

        public Task<ProductStock> GetByProductIdAsync(int productId);

        public void Create(ProductStock productStock);

        public void Update(ProductStock productStock);

        public void Delete(ProductStock productStock);
    }
}