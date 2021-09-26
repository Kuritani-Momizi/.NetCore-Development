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
    }
}
