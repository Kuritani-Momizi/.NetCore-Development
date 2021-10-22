using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Suika.Services.ProductAPI.Models.Dto;
using Suika.Services.ProductAPI.Models.Dtos;
using Suika.Services.ProductAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suika.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        #region 設定
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }
        #endregion

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDto = await _productRepository.GetProducts();
                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccesss = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                _response.Result = productDto;
            }
            catch(Exception ex)
            {
                _response.IsSuccesss = false;
                _response.ErrorMessage = new List<string>() { ex.ToString()};
            }

            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccesss = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccesss = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        //特定の権限を持つユーザーのみ使用可能！って設定できる
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _productRepository.DeleteProduct(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccesss = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
