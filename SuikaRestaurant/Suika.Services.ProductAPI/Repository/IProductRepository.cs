using Suika.Services.ProductAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suika.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        //すべての製品情報を取得する
        /// <summary>
        /// 全製品情報取得
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductDto>> GetProducts();

        //選択した製品IDの取得
        /// <summary>
        /// 製品ID取得
        /// </summary>
        /// <param name="productId">製品ID</param>
        /// <returns></returns>
        Task<ProductDto> GetProductById(int productId);

        //製品情報のUpserd
        /// <summary>
        /// 製品情報の登録・更新
        /// </summary>
        /// <param name="productDto">Upserd用製品情報</param>
        /// <returns></returns>
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

        //製品情報の削除
        /// <summary>
        /// 製品情報の削除
        /// </summary>
        /// <param name="productId">製品ID</param>
        /// <returns></returns>
        Task<bool> DeleteProduct(int productId);

    }
}
