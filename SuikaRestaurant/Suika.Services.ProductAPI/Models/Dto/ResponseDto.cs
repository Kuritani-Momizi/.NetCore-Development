using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suika.Services.ProductAPI.Models.Dto
{
    public class ResponseDto
    {
        public bool IsSuccesss { get; set; } = true;

        public object Result { get; set; }

        public string DisplayMessage { get; set; } = "";

        public List<string> ErrorMessage { get; set; }
    }
}
