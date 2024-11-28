using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.dto.stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage ="Cannot be more than 10 char")]
        public string Symbol {get;set;} = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage ="Cannot be more than 10 char")]
        public string CompanyName {get;set;} = string.Empty;
        [Required]
        [Range(1,1000)]
        public decimal Purchase {get;set;}
        [Required]
        [Range(1,1000)]
        public decimal LastDiv {get;set;}
        [Required]
        [MaxLength(10, ErrorMessage ="Cannot be more than 10 char")]
        public string Industry {get;set;} = string.Empty;
        [Required]
        [Range(1,1000)]
        public long MarketCap {get;set;}
    }
}