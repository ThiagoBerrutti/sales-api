﻿using AutoMapper;
using StoreAPI.Domain;
using StoreAPI.Dtos;
using StoreAPI.Exceptions;
using StoreAPI.Persistence.Repositories;
using StoreAPI.Validations;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductValidator _productValidator;
        private readonly ProductParametersValidator _productParametersValidator;

        public ProductService(IProductRepository productRepository, IStockService stockService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _stockService = stockService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productValidator = new ProductValidator();
            _productParametersValidator = new ProductParametersValidator();
        }


        
        public async Task<PagedList<ProductReadDto>> GetAllDtoPagedAsync(ProductParametersDto parameters)
        {
            var validationResult = _productParametersValidator.Validate(parameters);
            if (!validationResult.IsValid)
            {
                throw new AppValidationException(validationResult)
                    .SetTitle("Validation error")
                    .SetDetail($"Invalid query string parameters. Check '{ExceptionWithProblemDetails.ErrorKey}' for more details");
            }

            Expression<Func<Product, bool>> expression =
                p =>
                    p.Price >= parameters.MinPrice &&
                    p.Price <= parameters.MaxPrice &&
                    p.Name.ToLower().Contains(parameters.Name.ToLower()) &&
                    p.Description.ToLower().Contains(parameters.Description.ToLower()) &&
                    p.ProductStock.Count > 0 == parameters.OnStock;

            var result = await _productRepository.GetAllWherePagedAsync(parameters.PageNumber, parameters.PageSize, expression);

            var dto = _mapper.Map<PagedList<Product>, PagedList<ProductReadDto>>(result);

            return dto;
        }


        public async Task<ProductWithStockDto> CreateAsync(ProductWriteDto productDto, int amount)
        {
            if (amount < 0 || amount > int.MaxValue)
            {
                throw new AppException()
                    .SetTitle("Error creating product")
                    .SetDetail("Amount should be greater or equal to zero");
            }

            var validationResult = _productValidator.Validate(productDto);
            if (!validationResult.IsValid)
            {
                throw new AppValidationException(validationResult)
                    .SetTitle("Validation error")
                    .SetDetail($"Invalid product data. See '{ExceptionWithProblemDetails.ErrorKey}' for more details");
            }

            var product = _mapper.Map<Product>(productDto);
            _productRepository.Add(product);

            _stockService.CreateProductStock(product, amount);
            await _unitOfWork.CompleteAsync();

            var productWithStockDto = _mapper.Map<ProductWithStockDto>(product);

            return productWithStockDto;
        }




        public async Task<ProductReadDto> GetDtoByIdAsync(int id)
        {
            var product = await GetByIdAsync(id);
            var dto = _mapper.Map<ProductReadDto>(product);

            return dto;
        }


        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new DomainNotFoundException()
                    .SetTitle("Product not found")
                    .SetDetail($"Product [Id = {id}] not found.");
            }

            return product;
        }


        public async Task<ProductReadDto> UpdateAsync(int id, ProductWriteDto productDto)
        {
            var validationResult = _productValidator.Validate(productDto);
            if (!validationResult.IsValid)
            {
                throw new AppValidationException(validationResult)
                    .SetTitle("Validation error")
                    .SetDetail($"Invalid product data. See '{ExceptionWithProblemDetails.ErrorKey}' for more details");
            }
            var productOnRepo = await GetByIdAsync(id);

            _mapper.Map(productDto, productOnRepo);
            _productRepository.Update(productOnRepo);

            await _unitOfWork.CompleteAsync();

            var productReadDto = _mapper.Map<ProductReadDto>(productOnRepo);
            return productReadDto;
        }


        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            _productRepository.Delete(product);

            await _unitOfWork.CompleteAsync();
        }
    }
}