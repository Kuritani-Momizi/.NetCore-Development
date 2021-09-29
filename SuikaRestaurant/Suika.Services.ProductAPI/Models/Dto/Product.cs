using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Suika.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        [DisplayName("製品ID")]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("製品名")]
        public string ProductName { get; set; }

        [Range(1,10000)]
        [DisplayName("価格")]
        public double Price { get; set; }

        [DisplayName("製品詳細")]
        public string Description { get; set; }

        [DisplayName("カテゴリー名")]
        public string CategoryName { get; set; }

        [DisplayName("製品画像URL")]
        public string ImageUrl { get; set; }
    }
}
