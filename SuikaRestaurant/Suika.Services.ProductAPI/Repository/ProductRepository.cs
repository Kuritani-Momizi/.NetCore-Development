using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Suika.Services.ProductAPI.DbContexts;
using Suika.Services.ProductAPI.Models;
using Suika.Services.ProductAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suika.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        #region 設定
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        #endregion

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);

            using (var tr = _db.Database.BeginTransaction())
            {
                try
                {
                    //更新時
                    if (product.ProductId > 0)
                    {
                        _db.Products.Update(product);
                    }
                    //登録時
                    else
                    {
                        _db.Products.Add(product);
                    }

                    await _db.SaveChangesAsync();
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                }
            }
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            using (var tr = _db.Database.BeginTransaction())
            {
                try
                {
                    Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

                    if (product == null)
                    {
                        return false;
                    }
                    else
                    {
                        _db.Products.Remove(product);
                        await _db.SaveChangesAsync();
                    }

                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    return false;
                }
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product= await _db.Products.Where(x=>x.ProductId == productId).FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
