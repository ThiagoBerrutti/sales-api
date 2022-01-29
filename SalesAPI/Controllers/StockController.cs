﻿using Microsoft.AspNetCore.Mvc;
using SalesAPI.Dtos;
using SalesAPI.Models;
using SalesAPI.Persistence.Data;
using SalesAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.Controllers
{
    [ApiController]
    [Route("api/v1/stock")]
    public class ProductStockController : Controller
    {
        private IStockService _stockService;
        private readonly StockSeed _seed;

        public ProductStockController(IStockService stockService, StockSeed seed)
        {
            _stockService = stockService;
            _seed = seed;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockReadDto>>> GetAll()
        {
            var result = await _stockService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{productId:int}")]
        public async Task<ActionResult<StockReadDto>> GetByProductId([FromRoute] int productId)
        {
            var productStock = await _stockService.GetByProductId(productId);
            return Ok(productStock);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] StockWriteDto stockUpdate)
        {
            await _stockService.Update(id, stockUpdate);

            return Ok();
        }

        [HttpPut("{id:int}/add")]
        public async Task<IActionResult> AddToStock(int id, int amount)
        {
            await _stockService.AddProductAmount(id, amount);
            return Ok();
        }

        [HttpPut("{id:int}/remove")]
        public async Task<IActionResult> RemoveFromStock(int id, int amount)
        {
            await _stockService.RemoveProductAmount(id, amount);
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _stockService.Delete(id);
            return Ok();
        }
        
        [HttpPost("seed")]
        public IActionResult Seed()
        {
            _seed.Seed();
            return Ok("Stock Seeded");
        }
    }
}